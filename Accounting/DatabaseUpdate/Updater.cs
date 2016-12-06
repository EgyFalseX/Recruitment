using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;

namespace Accounting.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            UpdateSpInfo();
            //string name = "MyName";
            //EntityObject1 theObject = ObjectSpace.FindObject<EntityObject1>(CriteriaOperator.Parse("Name=?", name));
            //if(theObject == null) {
            //    theObject = ObjectSpace.CreateObject<EntityObject1>();
            //    theObject.Name = name;
            //}

            //ObjectSpace.CommitChanges(); //Uncomment this line to persist created object(s).

        }
        private void UpdateSpInfo()
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            object exists = session.ExecuteScalar(string.Format(GetChechSpSql, "sp_Trial_Balance"));
            if (exists != null && exists.ToString() == "0")
                session.ExecuteNonQuery(GetspTrialBalanceSql);

        }
        private static string GetChechSpSql => @"IF EXISTS(SELECT [Routine_Name] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [Routine_Name] = '{0}')
                                            SELECT 1
                                            ELSE
                                            SELECT 0";
        private static string GetspTrialBalanceSql {
            get { return @"CREATE PROCEDURE [dbo].[sp_Trial_Balance]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @Category INT
AS
BEGIN
	SET NOCOUNT ON;

	--Fill Entry Table
	DECLARE @EntryTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT)
	INSERT INTO @EntryTbl
	SELECT [account_id], SUM([debit]), SUM([credit]) FROM [dbo].[acc_Journal_Entry_Detail] INNER JOIN [dbo].[acc_Journal_Entry] ON [acc_Journal_Entry_Detail].jour_entry_id = [acc_Journal_Entry].jour_entry_id
	INNER JOIN dbo.acc_Period ON [acc_Journal_Entry].period_id = acc_Period.period_id
	WHERE  acc_Period.year_id = @Year AND [acc_Journal_Entry].entry_date BETWEEN @StartDate AND @EndDate
	AND [acc_Journal_Entry].closed = 1
	GROUP BY [account_id]

	--Fill Opening Balance Table
	DECLARE @OBTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT)
	INSERT INTO @OBTbl
	SELECT [account_id], SUM([debit]), SUM([credit]) FROM acc_Opening_Balance
	WHERE  year_id = @Year
	GROUP BY [account_id]


	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account INNER JOIN acc_Account_Category_Detail ON acc_Account.account_id = acc_Account_Category_Detail.account_id 
	INNER JOIN acc_Account_Category ON acc_Account_Category_Detail.account_category_id = acc_Account_Category.account_category_id
	WHERE        (acc_Account_Category.account_category_id = @Category)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	SELECT CTE1.Parent_Id, acc_Account.account_name, SUM(EntryTbl.[debit]) AS Entry_debit, SUM(EntryTbl.[credit]) AS Entry_credit
	, SUM(OBTbl.[debit]) AS OB_debit, SUM(OBTbl.[credit]) AS OB_credit
	FROM CTE1 LEFT OUTER JOIN @EntryTbl EntryTbl ON CTE1.account_id = EntryTbl.account_id
	LEFT OUTER JOIN @OBTbl OBTbl ON CTE1.account_id = OBTbl.account_id
	INNER JOIN acc_Account ON CTE1.Parent_Id = acc_Account.account_id
	GROUP BY acc_Account.account_name, CTE1.Parent_Id
END";
            }
        }
    
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
    }
}
