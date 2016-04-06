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
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
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
        private void UpdateBasicInfo()
        {
            //Update rec_Require_Doc_Status
            rec_Require_Doc_Status rec_Require_Doc_Status_1 = ObjectSpace.FindObject<rec_Require_Doc_Status>(new BinaryOperator("rec_require_doc_status_id", 1));
            if (rec_Require_Doc_Status_1 == null)
            {
                rec_Require_Doc_Status_1 = ObjectSpace.CreateObject<rec_Require_Doc_Status>();
                rec_Require_Doc_Status_1.rec_require_doc_status_id = 1;
                rec_Require_Doc_Status_1.rec_require_doc_status_name = "Completed";
            }
            rec_Require_Doc_Status rec_Require_Doc_Status_2 = ObjectSpace.FindObject<rec_Require_Doc_Status>(new BinaryOperator("rec_require_doc_status_id", 2));
            if (rec_Require_Doc_Status_2 == null)
            {
                rec_Require_Doc_Status_2 = ObjectSpace.CreateObject<rec_Require_Doc_Status>();
                rec_Require_Doc_Status_2.rec_require_doc_status_id = 2;
                rec_Require_Doc_Status_2.rec_require_doc_status_name = "InProgress";
            }
            //Update rec_Applicant_Status
            rec_Applicant_Status rec_Applicant_Status_1 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 1));
            if (rec_Applicant_Status_1 == null)
            {
                rec_Applicant_Status_1 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                rec_Applicant_Status_1.rec_applicant_status_id = 1;
                rec_Applicant_Status_1.rec_applicant_status_name = "Ready";
            }
            rec_Applicant_Status rec_Applicant_Status_2 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 2));
            if (rec_Applicant_Status_2 == null)
            {
                rec_Applicant_Status_2 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                rec_Applicant_Status_2.rec_applicant_status_id = 2;
                rec_Applicant_Status_2.rec_applicant_status_name = "Busy";
            }
            rec_Applicant_Status rec_Applicant_Status_3 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 3));
            if (rec_Applicant_Status_3 == null)
            {
                rec_Applicant_Status_3 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                rec_Applicant_Status_3.rec_applicant_status_id = 3;
                rec_Applicant_Status_3.rec_applicant_status_name = "Accepted";
            }
            rec_Applicant_Status rec_Applicant_Status_4 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 4));
            if (rec_Applicant_Status_4 == null)
            {
                rec_Applicant_Status_4 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                rec_Applicant_Status_4.rec_applicant_status_id = 4;
                rec_Applicant_Status_4.rec_applicant_status_name = "Refused";
            }
            rec_Applicant_Status rec_Applicant_Status_5 = ObjectSpace.FindObject<rec_Applicant_Status>(new BinaryOperator("rec_applicant_status_id", 5));
            if (rec_Applicant_Status_5 == null)
            {
                rec_Applicant_Status_5 = ObjectSpace.CreateObject<rec_Applicant_Status>();
                rec_Applicant_Status_5.rec_applicant_status_id = 5;
                rec_Applicant_Status_5.rec_applicant_status_name = "Refused";
            }
            //rec_Employer_Order_Status
           rec_Employer_Order_Status rec_Employer_Order_Status_1 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 1));
            if (rec_Employer_Order_Status_1 == null)
            {
                rec_Employer_Order_Status_1 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                rec_Employer_Order_Status_1.rec_employer_order_status_id = 1;
                rec_Employer_Order_Status_1.rec_employer_order_status_name = "In_Progress";
            }
            rec_Employer_Order_Status rec_Employer_Order_Status_2 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 2));
            if (rec_Employer_Order_Status_2 == null)
            {
                rec_Employer_Order_Status_2 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                rec_Employer_Order_Status_2.rec_employer_order_status_id = 2;
                rec_Employer_Order_Status_2.rec_employer_order_status_name = "Completed";
            }
            rec_Employer_Order_Status rec_Employer_Order_Status_3 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 3));
            if (rec_Employer_Order_Status_3 == null)
            {
                rec_Employer_Order_Status_3 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                rec_Employer_Order_Status_3.rec_employer_order_status_id = 3;
                rec_Employer_Order_Status_3.rec_employer_order_status_name = "Canceled";
            }
            rec_Employer_Order_Status rec_Employer_Order_Status_4 = ObjectSpace.FindObject<rec_Employer_Order_Status>(new BinaryOperator("rec_employer_order_status_id", 4));
            if (rec_Employer_Order_Status_4 == null)
            {
                rec_Employer_Order_Status_4 = ObjectSpace.CreateObject<rec_Employer_Order_Status>();
                rec_Employer_Order_Status_4.rec_employer_order_status_id = 4;
                rec_Employer_Order_Status_4.rec_employer_order_status_name = "Pasued";
            }
            ObjectSpace.CommitChanges();
        }
        
    }
}
