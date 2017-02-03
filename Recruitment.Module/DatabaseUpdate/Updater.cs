using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Module.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDbVersion) :
            base(objectSpace, currentDbVersion) {
        }
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
            //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
            //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
            //}
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            UpdateSecurityInfo();
            //UpdateSpInfo();
            UpdateBasicInfo();
        }
        private SecuritySystemRole CreateDefaultRole()
        {
            SecuritySystemRole defaultRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Default"));
            if (defaultRole == null)
            {
                defaultRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                defaultRole.Name = "Default";

                defaultRole.AddObjectAccessPermission<SecuritySystemUser>("[Oid] = CurrentUserId()", SecurityOperations.ReadOnlyAccess);
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("ChangePasswordOnFirstLogon", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.AddMemberAccessPermission<SecuritySystemUser>("StoredPassword", SecurityOperations.Write, "[Oid] = CurrentUserId()");
                defaultRole.SetTypePermissionsRecursively<SecuritySystemRole>(SecurityOperations.Read, SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifference>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Allow);
                defaultRole.SetTypePermissionsRecursively<ModelDifferenceAspect>(SecurityOperations.ReadWriteAccess, SecuritySystemModifier.Allow);
            }
            return defaultRole;
        }
        private void UpdateSecurityInfo()
        {
            //string name = "MyName";
            //DomainObject1 theObject = ObjectSpace.FindObject<DomainObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<DomainObject1>();
            //    theObject.Name = name;
            //}
            //SecuritySystemUser sampleUser = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "User"));
            //if(sampleUser == null) {
            //    sampleUser = ObjectSpace.CreateObject<SecuritySystemUser>();
            //    sampleUser.UserName = "User";
            //    sampleUser.SetPassword("");
            //}
            //SecuritySystemRole defaultRole = CreateDefaultRole();
            //sampleUser.Roles.Add(defaultRole);

            SecuritySystemUser userAdmin = ObjectSpace.FindObject<SecuritySystemUser>(new BinaryOperator("UserName", "Admin"));
            if (userAdmin == null)
            {
                userAdmin = ObjectSpace.CreateObject<SecuritySystemUser>();
                userAdmin.UserName = "Admin";
                // Set a password if the standard authentication type is used
                userAdmin.SetPassword("");
            }
            // If a role with the Administrators name doesn't exist in the database, create this role
            SecuritySystemRole adminRole = ObjectSpace.FindObject<SecuritySystemRole>(new BinaryOperator("Name", "Administrators"));
            if (adminRole == null)
            {
                adminRole = ObjectSpace.CreateObject<SecuritySystemRole>();
                adminRole.Name = "Administrators";
            }
            adminRole.IsAdministrative = true;
            adminRole.CanEditModel = false;
            userAdmin.Roles.Add(adminRole);
            ObjectSpace.CommitChanges();
        }
        #region UpdateSP
        private void UpdateSpInfo()
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            CreateSp(session, "sp_Activity_01", Getsp_Activity_01);
            CreateSp(session, "sp_Activity_02", Getsp_Activity_02);
            CreateSp(session, "sp_Activity_03", Getsp_Activity_03);
        }
        private void CreateSp(Session session, string spName, string spContains)
        {
            string GetChechSpSql = @"IF EXISTS(SELECT [Routine_Name] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [Routine_Name] = '{0}')
                                            SELECT 1
                                            ELSE
                                            SELECT 0";

            object exists = session.ExecuteScalar(string.Format(GetChechSpSql, spName));
            if (exists != null && exists.ToString() == "0")
                session.ExecuteNonQuery(spContains);
        }
        private static string Getsp_Activity_01
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Activity_01]
	-- Add the parameters for the stored procedure here
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @employer_id INT = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DECLARE @EmpTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_logo varbinary(MAX), employer_company_name NVARCHAR(100),activity_id INT, activity_name NVARCHAR(100)
, BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT,UNIQUE CLUSTERED(employer_id, activity_id))

;WITH CTE1 AS
(
SELECT rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_logo, rec_Employer.employer_company_name, rec_Activity.activity_id
, rec_Activity.activity_name
, CASE WHEN rec_Activity.activity_type_id = 1 THEN value ELSE 0 END AS BudgetRevenue
, CASE WHEN rec_Activity.activity_type_id = 2 THEN value ELSE 0 END AS ActualRevenue
, CASE WHEN rec_Activity.activity_type_id = 3 THEN value ELSE 0 END AS Expenses
FROM rec_Employer_Order_Activity 
INNER JOIN rec_Employer_Order INNER JOIN
rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id ON 
rec_Employer_Order_Activity.rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
rec_Activity ON rec_Employer_Order_Activity.activity_id = rec_Activity.activity_id
WHERE rec_Employer_Order_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1)
)
INSERT INTO @EmpTbl
SELECT employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue), SUM(ActualRevenue), SUM(Expenses)
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name


DECLARE @AppTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_logo varbinary(MAX), employer_company_name NVARCHAR(100),activity_id INT, activity_name NVARCHAR(100)
, BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT,UNIQUE CLUSTERED(employer_id, activity_id))

;WITH CTE1 AS
(
SELECT rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_logo, rec_Employer.employer_company_name, 
rec_Accept_App_Activity.activity_id, rec_Activity.activity_name
, CASE WHEN rec_Activity.activity_type_id = 2 THEN rec_Accept_App_Activity.value ELSE 0 END AS BudgetRevenue
, CASE WHEN rec_Activity.activity_type_id = 1 OR rec_Activity.activity_type_id = 4 THEN rec_Accept_App_Activity.value ELSE 0 END AS ActualRevenue
, CASE WHEN rec_Activity.activity_type_id = 3 THEN rec_Accept_App_Activity.value ELSE 0 END AS Expenses
FROM rec_Employer_Order_Detail INNER JOIN
                         rec_Employer_Order ON rec_Employer_Order_Detail.rec_employer_order_detail_rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
                         rec_Employer_Order_Detail_Suggest_Applicat ON 
                         rec_Employer_Order_Detail.rec_employer_order_detail_id = rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id INNER JOIN
                         rec_Employer_Order_Detail_Accept_Applicat ON 
                         rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_id = rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Accept_App_Activity ON 
                         rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = rec_Accept_App_Activity.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Activity ON rec_Accept_App_Activity.activity_id = rec_Activity.activity_id INNER JOIN
                         rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id
WHERE rec_Accept_App_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1)
)
INSERT INTO @AppTbl
SELECT employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name

;WITH CTE1 AS
(
SELECT employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM @EmpTbl
GROUP BY employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
UNION
SELECT employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM @AppTbl
GROUP BY employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
)
SELECT employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_logo, employer_company_name, activity_id, activity_name

END
";
            }
        }
        private static string Getsp_Activity_02
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Activity_02]
	-- Add the parameters for the stored procedure here
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @employer_id INT = -1,
	 @applicant_id INT = -1
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @EmpTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_company_name NVARCHAR(100),activity_id INT, activity_name NVARCHAR(100)
	, BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT, Person_Name NVARCHAR(100), activity_date DATETIME, [description] NVARCHAR(1000)
	,UNIQUE CLUSTERED(employer_id, activity_id))
	
;WITH CTE1 AS
(
SELECT rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_company_name, rec_Activity.activity_id
, rec_Activity.activity_name,
CASE WHEN rec_Activity.activity_type_id = 1 THEN value ELSE 0 END AS BudgetRevenue,
CASE WHEN rec_Activity.activity_type_id = 2 THEN value ELSE 0 END AS ActualRevenue,
CASE WHEN rec_Activity.activity_type_id = 3 THEN value ELSE 0 END AS Expenses,
rec_Employer.employer_company_name AS Person_Name,
rec_Employer_Order_Activity.activity_date,
rec_Employer_Order_Activity.[description]
FROM rec_Employer_Order_Activity 
INNER JOIN rec_Employer_Order INNER JOIN
rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id ON 
rec_Employer_Order_Activity.rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
rec_Activity ON rec_Employer_Order_Activity.activity_id = rec_Activity.activity_id
WHERE rec_Employer_Order_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1) AND @applicant_id = -1
)
INSERT INTO @EmpTbl
SELECT employer_id, employer_owner_name, employer_company_name, activity_id, activity_name
, SUM(BudgetRevenue), SUM(ActualRevenue), SUM(Expenses), Person_Name, activity_date, [description] 
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, activity_id, activity_name
, Person_Name, activity_date, [description] 



	DECLARE @AppTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_company_name NVARCHAR(100),activity_id INT, activity_name NVARCHAR(100)
	, BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT, Person_Name NVARCHAR(100), activity_date DATETIME, [description] NVARCHAR(1000)
	,UNIQUE CLUSTERED(employer_id, activity_id))

;WITH CTE1 AS
(
SELECT        rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_company_name, rec_Accept_App_Activity.activity_id, rec_Activity.activity_name, 
CASE WHEN rec_Activity.activity_type_id = 2 THEN rec_Accept_App_Activity.value ELSE 0 END AS BudgetRevenue, 
CASE WHEN rec_Activity.activity_type_id = 1  OR rec_Activity.activity_type_id = 4 THEN rec_Accept_App_Activity.value ELSE 0 END AS ActualRevenue, 
CASE WHEN rec_Activity.activity_type_id = 3 THEN rec_Accept_App_Activity.value ELSE 0 END AS Expenses
, rec_Applicant.applicant_name AS Person_Name,
rec_Accept_App_Activity.activity_date,
rec_Accept_App_Activity.[description]
FROM            rec_Employer_Order_Detail INNER JOIN
                         rec_Employer_Order ON rec_Employer_Order_Detail.rec_employer_order_detail_rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
                         rec_Employer_Order_Detail_Suggest_Applicat ON 
                         rec_Employer_Order_Detail.rec_employer_order_detail_id = rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id INNER JOIN
                         rec_Employer_Order_Detail_Accept_Applicat ON 
                         rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_id = rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Accept_App_Activity ON 
                         rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = rec_Accept_App_Activity.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Activity ON rec_Accept_App_Activity.activity_id = rec_Activity.activity_id INNER JOIN
                         rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id INNER JOIN
                         rec_Applicant ON rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_applicant_id = rec_Applicant.applicant_id
WHERE rec_Accept_App_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1)
AND (rec_Applicant.applicant_id = @applicant_id OR @applicant_id = -1)
)
INSERT INTO @AppTbl
SELECT employer_id, employer_owner_name, employer_company_name, activity_id, activity_name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses,
Person_Name, activity_date, [description]
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, activity_id, activity_name, Person_Name, activity_date, [description]

;WITH CTE1 AS
(
SELECT employer_id, employer_owner_name, employer_company_name, activity_id, activity_name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses,
Person_Name, activity_date, [description]
FROM @EmpTbl
GROUP BY employer_id, employer_owner_name, employer_company_name, activity_id, activity_name, Person_Name, activity_date, [description]
UNION
SELECT employer_id, employer_owner_name, employer_company_name, activity_id, activity_name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses,
Person_Name, activity_date, [description]
FROM @AppTbl
GROUP BY employer_id, employer_owner_name, employer_company_name, activity_id, activity_name, Person_Name, activity_date, [description]
)
SELECT employer_id, employer_owner_name, employer_company_name, activity_id, activity_name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses,
Person_Name, activity_date, [description]
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, activity_id, activity_name, Person_Name, activity_date, [description]

END
";
            }
        }
        private static string Getsp_Activity_03
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Activity_03]
	-- Add the parameters for the stored procedure here
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @employer_id INT = -1,
	 @applicant_id INT = -1,
	 @Unbalanced BIT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
DECLARE @EmpTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_company_name NVARCHAR(100), Person_Name NVARCHAR(100), BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT
, UNIQUE CLUSTERED(employer_id, Person_Name))
;WITH CTE1 AS
(
SELECT rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_company_name,
CASE WHEN rec_Activity.activity_type_id = 1 THEN value ELSE 0 END AS BudgetRevenue,
CASE WHEN rec_Activity.activity_type_id = 2 THEN value ELSE 0 END AS ActualRevenue,
CASE WHEN rec_Activity.activity_type_id = 3 THEN value ELSE 0 END AS Expenses,
rec_Employer.employer_company_name AS Person_Name
FROM rec_Employer_Order_Activity 
INNER JOIN rec_Employer_Order INNER JOIN
rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id ON 
rec_Employer_Order_Activity.rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
rec_Activity ON rec_Employer_Order_Activity.activity_id = rec_Activity.activity_id
WHERE rec_Employer_Order_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1) AND @applicant_id = -1
)
INSERT INTO @EmpTbl
SELECT employer_id, employer_owner_name, employer_company_name,Person_Name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, Person_Name


DECLARE @AppTbl TABLE(employer_id INT, employer_owner_name NVARCHAR(100), employer_company_name NVARCHAR(100), Person_Name NVARCHAR(100), BudgetRevenue FLOAT, ActualRevenue FLOAT, Expenses FLOAT
, UNIQUE CLUSTERED(employer_id, Person_Name))
;WITH CTE1 AS
(
SELECT        rec_Employer.employer_id, rec_Employer.employer_owner_name, rec_Employer.employer_company_name,  
CASE WHEN rec_Activity.activity_type_id = 2 THEN rec_Accept_App_Activity.value ELSE 0 END AS BudgetRevenue, 
CASE WHEN rec_Activity.activity_type_id = 1  OR rec_Activity.activity_type_id = 4 THEN rec_Accept_App_Activity.value ELSE 0 END AS ActualRevenue, 
CASE WHEN rec_Activity.activity_type_id = 3 THEN rec_Accept_App_Activity.value ELSE 0 END AS Expenses
, rec_Applicant.applicant_name AS Person_Name
FROM            rec_Employer_Order_Detail INNER JOIN
                         rec_Employer_Order ON rec_Employer_Order_Detail.rec_employer_order_detail_rec_employer_order_id = rec_Employer_Order.rec_employer_order_id INNER JOIN
                         rec_Employer_Order_Detail_Suggest_Applicat ON 
                         rec_Employer_Order_Detail.rec_employer_order_detail_id = rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id INNER JOIN
                         rec_Employer_Order_Detail_Accept_Applicat ON 
                         rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_id = rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Accept_App_Activity ON 
                         rec_Employer_Order_Detail_Accept_Applicat.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id = rec_Accept_App_Activity.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id
                          INNER JOIN
                         rec_Activity ON rec_Accept_App_Activity.activity_id = rec_Activity.activity_id INNER JOIN
                         rec_Employer ON rec_Employer_Order.rec_employer_order_employer_id = rec_Employer.employer_id INNER JOIN
                         rec_Applicant ON rec_Employer_Order_Detail_Suggest_Applicat.rec_employer_order_detail_suggest_applicat_applicant_id = rec_Applicant.applicant_id
WHERE rec_Accept_App_Activity.activity_date BETWEEN @StartDate AND @EndDate
AND (rec_Employer.employer_id = @employer_id OR @employer_id = -1)
AND (rec_Applicant.applicant_id = @applicant_id OR @applicant_id = -1)
)
INSERT INTO @AppTbl
SELECT employer_id, employer_owner_name, employer_company_name, Person_Name,
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, Person_Name

;WITH CTE1 AS
(
SELECT employer_id, employer_owner_name, employer_company_name, Person_Name,
BudgetRevenue, ActualRevenue, Expenses
FROM @EmpTbl
UNION 
SELECT employer_id, employer_owner_name, employer_company_name, Person_Name,
BudgetRevenue, ActualRevenue, Expenses
FROM @AppTbl
)
SELECT employer_id, employer_owner_name, employer_company_name, 
SUM(BudgetRevenue) AS BudgetRevenue, SUM(ActualRevenue) AS ActualRevenue, SUM(Expenses) AS Expenses,
Person_Name
FROM CTE1
GROUP BY employer_id, employer_owner_name, employer_company_name, Person_Name
HAVING (SUM(ActualRevenue) <> SUM(BudgetRevenue)) OR @Unbalanced = 0

END

";
            }
        }
        #endregion
        #region UpdateBasicInfo

        private void UpdateBasicInfo()
        {
            rec_Activity_Type_Data();
            //rec_Require_Doc_Status_Data();
            //rec_Applicant_Status_Data();
            //rec_Employer_Order_Status_Data();
            //rec_Annual_Vacation_Type_Data();
            //rec_Delivery_Type_Data();
            //rec_Housing_Type_Data();
            //rec_Medical_Insurance_Types_Data();
            //rec_Residence_Type_Data();

            ObjectSpace.CommitChanges();
        }
        private void rec_Activity_Type_Data()
        {
            //rec_Activity_Type
            rec_Activity_Type record1 = ObjectSpace.FindObject<rec_Activity_Type>(new BinaryOperator("activity_type_id", 1));
            if (record1 == null)
            {
                record1 = ObjectSpace.CreateObject<rec_Activity_Type>();
                record1.activity_type_id = 1;
                record1.activity_type_name = "Budget Revenue";
            }

            rec_Activity_Type record2 = ObjectSpace.FindObject<rec_Activity_Type>(new BinaryOperator("activity_type_id", 2));
            if (record2 == null)
            {
                record2 = ObjectSpace.CreateObject<rec_Activity_Type>();
                record2.activity_type_id = 2;
                record2.activity_type_name = "Actual Revenue";
            }

            rec_Activity_Type record3 = ObjectSpace.FindObject<rec_Activity_Type>(new BinaryOperator("activity_type_id", 3));
            if (record3 == null)
            {
                record3 = ObjectSpace.CreateObject<rec_Activity_Type>();
                record3.activity_type_id = 3;
                record3.activity_type_name = "Expenses";
            }

            rec_Activity_Type record4 = ObjectSpace.FindObject<rec_Activity_Type>(new BinaryOperator("activity_type_id", 4));
            if (record4 == null)
            {
                record4 = ObjectSpace.CreateObject<rec_Activity_Type>();
                record4.activity_type_id = 4;
                record4.activity_type_name = "Advance Revenue";
            }

            rec_Activity_Type record5 = ObjectSpace.FindObject<rec_Activity_Type>(new BinaryOperator("activity_type_id", 5));
            if (record5 == null)
            {
                record5 = ObjectSpace.CreateObject<rec_Activity_Type>();
                record5.activity_type_id = 5;
                record5.activity_type_name = "Salary";
            }

        }
        private void rec_Residence_Type_Data()
        {
            //rec_Residence_Type
            rec_Residence_Type recResidenceTypeId1 = ObjectSpace.FindObject<rec_Residence_Type>(new BinaryOperator("rec_residence_type_id", 1));
            if (recResidenceTypeId1 == null)
            {
                recResidenceTypeId1 = ObjectSpace.CreateObject<rec_Residence_Type>();
                recResidenceTypeId1.rec_residence_type_id = 1;
                recResidenceTypeId1.rec_residence_type_name = "None";
            }
            rec_Residence_Type recResidenceTypeId2 = ObjectSpace.FindObject<rec_Residence_Type>(new BinaryOperator("rec_residence_type_id", 2));
            if (recResidenceTypeId2 == null)
            {
                recResidenceTypeId2 = ObjectSpace.CreateObject<rec_Residence_Type>();
                recResidenceTypeId2.rec_residence_type_id = 2;
                recResidenceTypeId2.rec_residence_type_name = "Individual";
            }
            rec_Residence_Type recResidenceTypeId3 = ObjectSpace.FindObject<rec_Residence_Type>(new BinaryOperator("rec_residence_type_id", 3));
            if (recResidenceTypeId3 == null)
            {
                recResidenceTypeId3 = ObjectSpace.CreateObject<rec_Residence_Type>();
                recResidenceTypeId3.rec_residence_type_id = 3;
                recResidenceTypeId3.rec_residence_type_name = "Family";
            }
        }
        private void rec_Medical_Insurance_Types_Data()
        {
            rec_Medical_Insurance_Types recMedicalInsuranceTypes1 = ObjectSpace.FindObject<rec_Medical_Insurance_Types>(new BinaryOperator("rec_medical_insurance_types_id", 1));
            if (recMedicalInsuranceTypes1 == null)
            {
                recMedicalInsuranceTypes1 = ObjectSpace.CreateObject<rec_Medical_Insurance_Types>();
                recMedicalInsuranceTypes1.rec_medical_insurance_types_id = 1;
                recMedicalInsuranceTypes1.rec_medical_insurance_types_name = "None";
            }
            rec_Medical_Insurance_Types recMedicalInsuranceTypes2 = ObjectSpace.FindObject<rec_Medical_Insurance_Types>(new BinaryOperator("rec_medical_insurance_types_id", 2));
            if (recMedicalInsuranceTypes2 == null)
            {
                recMedicalInsuranceTypes2 = ObjectSpace.CreateObject<rec_Medical_Insurance_Types>();
                recMedicalInsuranceTypes2.rec_medical_insurance_types_id = 2;
                recMedicalInsuranceTypes2.rec_medical_insurance_types_name = "Individual";
            }
            rec_Medical_Insurance_Types recMedicalInsuranceTypes3 = ObjectSpace.FindObject<rec_Medical_Insurance_Types>(new BinaryOperator("rec_medical_insurance_types_id", 3));
            if (recMedicalInsuranceTypes3 == null)
            {
                recMedicalInsuranceTypes3 = ObjectSpace.CreateObject<rec_Medical_Insurance_Types>();
                recMedicalInsuranceTypes3.rec_medical_insurance_types_id = 3;
                recMedicalInsuranceTypes3.rec_medical_insurance_types_name = "Family";
            }
        }
        private void rec_Housing_Type_Data()
        {
            //rec_Housing_Type
            rec_Housing_Type recHousingType1 = ObjectSpace.FindObject<rec_Housing_Type>(new BinaryOperator("rec_housing_type_id", 1));
            if (recHousingType1 == null)
            {
                recHousingType1 = ObjectSpace.CreateObject<rec_Housing_Type>();
                recHousingType1.rec_housing_type_id = 1;
                recHousingType1.rec_housing_name = "None";
            }
            rec_Housing_Type recHousingType2 = ObjectSpace.FindObject<rec_Housing_Type>(new BinaryOperator("rec_housing_type_id", 2));
            if (recHousingType2 == null)
            {
                recHousingType2 = ObjectSpace.CreateObject<rec_Housing_Type>();
                recHousingType2.rec_housing_type_id = 2;
                recHousingType2.rec_housing_name = "Individual";
            }
            rec_Housing_Type recHousingType3 = ObjectSpace.FindObject<rec_Housing_Type>(new BinaryOperator("rec_housing_type_id", 3));
            if (recHousingType3 == null)
            {
                recHousingType3 = ObjectSpace.CreateObject<rec_Housing_Type>();
                recHousingType3.rec_housing_type_id = 3;
                recHousingType3.rec_housing_name = "Family";
            }
        }
        private void rec_Delivery_Type_Data()
        {
            //rec_Delivery_Type
            rec_Delivery_Type recDeliveryType1 = ObjectSpace.FindObject<rec_Delivery_Type>(new BinaryOperator("rec_delivery_type_id", 1));
            if (recDeliveryType1 == null)
            {
                recDeliveryType1 = ObjectSpace.CreateObject<rec_Delivery_Type>();
                recDeliveryType1.rec_delivery_type_id = 1;
                recDeliveryType1.rec_delivery_type_name = "Interview";
            }
            rec_Delivery_Type recDeliveryType2 = ObjectSpace.FindObject<rec_Delivery_Type>(new BinaryOperator("rec_delivery_type_id", 2));
            if (recDeliveryType2 == null)
            {
                recDeliveryType2 = ObjectSpace.CreateObject<rec_Delivery_Type>();
                recDeliveryType2.rec_delivery_type_id = 2;
                recDeliveryType2.rec_delivery_type_name = "E-Mail";
            }
        }
        private void rec_Annual_Vacation_Type_Data()
        {
            rec_Annual_Vacation_Type recAnnualVacationType1 = ObjectSpace.FindObject<rec_Annual_Vacation_Type>(new BinaryOperator("rec_annual_vacation_type_id", 1));
            if (recAnnualVacationType1 == null)
            {
                recAnnualVacationType1 = ObjectSpace.CreateObject<rec_Annual_Vacation_Type>();
                recAnnualVacationType1.rec_annual_vacation_type_id = 1;
                recAnnualVacationType1.rec_annual_vacation_type_name = "1 Year";
            }
            rec_Annual_Vacation_Type recAnnualVacationType2 = ObjectSpace.FindObject<rec_Annual_Vacation_Type>(new BinaryOperator("rec_annual_vacation_type_id", 2));
            if (recAnnualVacationType2 == null)
            {
                recAnnualVacationType2 = ObjectSpace.CreateObject<rec_Annual_Vacation_Type>();
                recAnnualVacationType2.rec_annual_vacation_type_id = 2;
                recAnnualVacationType2.rec_annual_vacation_type_name = "2 Year";
            }
            rec_Annual_Vacation_Type recAnnualVacationType3 = ObjectSpace.FindObject<rec_Annual_Vacation_Type>(new BinaryOperator("rec_annual_vacation_type_id", 3));
            if (recAnnualVacationType3 == null)
            {
                recAnnualVacationType3 = ObjectSpace.CreateObject<rec_Annual_Vacation_Type>();
                recAnnualVacationType3.rec_annual_vacation_type_id = 3;
                recAnnualVacationType3.rec_annual_vacation_type_name = "3 Year";
            }
        }
        private void rec_Employer_Order_Status_Data()
        {
            //rec_Employer_Order_Status
            rec_Employer_Order_Status recEmployerOrderStatus1 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 1));
            if (recEmployerOrderStatus1 == null)
            {
                recEmployerOrderStatus1 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                recEmployerOrderStatus1.rec_employer_order_status_id = 1;
                recEmployerOrderStatus1.rec_employer_order_status_name = "In_Progress";
            }
            rec_Employer_Order_Status recEmployerOrderStatus2 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 2));
            if (recEmployerOrderStatus2 == null)
            {
                recEmployerOrderStatus2 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                recEmployerOrderStatus2.rec_employer_order_status_id = 2;
                recEmployerOrderStatus2.rec_employer_order_status_name = "Completed";
            }
            rec_Employer_Order_Status recEmployerOrderStatus3 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 3));
            if (recEmployerOrderStatus3 == null)
            {
                recEmployerOrderStatus3 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                recEmployerOrderStatus3.rec_employer_order_status_id = 3;
                recEmployerOrderStatus3.rec_employer_order_status_name = "Canceled";
            }
            rec_Employer_Order_Status recEmployerOrderStatus4 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 4));
            if (recEmployerOrderStatus4 == null)
            {
                recEmployerOrderStatus4 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                recEmployerOrderStatus4.rec_employer_order_status_id = 4;
                recEmployerOrderStatus4.rec_employer_order_status_name = "Pasued";
            }
        }
        private void rec_Applicant_Status_Data()
        {
            //Update rec_Applicant_Status
            rec_Applicant_Status recApplicantStatus1 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 1));
            if (recApplicantStatus1 == null)
            {
                recApplicantStatus1 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                recApplicantStatus1.rec_applicant_status_id = 1;
                recApplicantStatus1.rec_applicant_status_name = "Ready";
            }
            rec_Applicant_Status recApplicantStatus2 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 2));
            if (recApplicantStatus2 == null)
            {
                recApplicantStatus2 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                recApplicantStatus2.rec_applicant_status_id = 2;
                recApplicantStatus2.rec_applicant_status_name = "Busy";
            }
            rec_Applicant_Status recApplicantStatus3 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 3));
            if (recApplicantStatus3 == null)
            {
                recApplicantStatus3 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                recApplicantStatus3.rec_applicant_status_id = 3;
                recApplicantStatus3.rec_applicant_status_name = "Accepted";
            }
            rec_Applicant_Status recApplicantStatus4 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 4));
            if (recApplicantStatus4 == null)
            {
                recApplicantStatus4 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                recApplicantStatus4.rec_applicant_status_id = 4;
                recApplicantStatus4.rec_applicant_status_name = "Refused";
            }
            rec_Applicant_Status recApplicantStatus5 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 5));
            if (recApplicantStatus5 == null)
            {
                recApplicantStatus5 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                recApplicantStatus5.rec_applicant_status_id = 5;
                recApplicantStatus5.rec_applicant_status_name = "Refused";
            }
        }
        private void rec_Require_Doc_Status_Data()
        {
            //Update rec_Require_Doc_Status
            rec_Require_Doc_Status recRequireDocStatus1 = ObjectSpace.FindObject<rec_Require_Doc_Status>(new BinaryOperator("rec_require_doc_status_id", 1));
            if (recRequireDocStatus1 == null)
            {
                recRequireDocStatus1 = ObjectSpace.CreateObject<rec_Require_Doc_Status>();
                recRequireDocStatus1.rec_require_doc_status_id = 1;
                recRequireDocStatus1.rec_require_doc_status_name = "Completed";
            }
            rec_Require_Doc_Status recRequireDocStatus2 = ObjectSpace.FindObject<rec_Require_Doc_Status>(new BinaryOperator("rec_require_doc_status_id", 2));
            if (recRequireDocStatus2 == null)
            {
                recRequireDocStatus2 = ObjectSpace.CreateObject<rec_Require_Doc_Status>();
                recRequireDocStatus2.rec_require_doc_status_id = 2;
                recRequireDocStatus2.rec_require_doc_status_name = "InProgress";
            }
        }

        #endregion

    }
}
