using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using Accounting.BusinessObjects.Recruitment;
using Accounting.Report;
using Accounting.Rule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Validation;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Validation;


namespace Accounting {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class AccountingModule : ModuleBase {
        static AccountingModule() {
            //DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
			//DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.DbFunctions);
            
            // Uncomment this code to delete and recreate the database each time the data model has changed.
            // Do not use this code in a production environment to avoid data loss.
            // #if DEBUG
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AccountingDbContext>());
            // #endif 
        }
        public AccountingModule() {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            //Register the predefined reports
            PredefinedReportsUpdater reportsUpdater = new PredefinedReportsUpdater(Application, objectSpace,
                versionFromDB) {UseMultipleUpdaters = true};
            AddPredefindreports(reportsUpdater);
            return new ModuleUpdater[] { updater, reportsUpdater };
        }
        private static void AddPredefindreports(PredefinedReportsUpdater reportsUpdater)
        {
            reportsUpdater.AddPredefinedReport<acc_Rep_Trial_Balance>("Trial Balance", typeof (sp_Trial_BalanceResult), typeof (RepParam_acc_Rep_Trial_Balance));
            //reportsUpdater.AddPredefinedReport<acc_Rep_01>("Account Balance", typeof (sp_acc_01Result), typeof (RepParam_acc_Rep_01));
            //reportsUpdater.AddPredefinedReport<acc_Rep_02>("Account Balance per cost center", typeof(sp_acc_02Result), typeof(RepParam_acc_Rep_02));
            reportsUpdater.AddPredefinedReport<acc_Rep_Income_Statement>("Income Statement", typeof(sp_Income_StatementResult), typeof (RepParam_acc_Rep_Income_Statement));
            reportsUpdater.AddPredefinedReport<acc_Rep_Balance_Sheet>("Balance Sheet", typeof(sp_Balance_SheetResult), typeof(RepParam_acc_Rep_Balance_Sheet));
            reportsUpdater.AddPredefinedReport<acc_Rep_Costcenter_Balance>("Cost Center Balance", typeof (acc_Journal_Entry_Detail), typeof (RepParam_acc_Rep_Costcenter_Balance));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals>("Account Journals", typeof(sp_acc_Account_JournalsResult), typeof(RepParam_acc_Rep_Account_Journals));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals_Consolidated>("Account Journals Consolidated", typeof(sp_acc_Account_JournalsResult), typeof(RepParam_acc_Rep_Account_Journals));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals_SubAcc>("Account Journals (Sub Account)", typeof(sp_acc_Account_Journals_SubAccResult), typeof(RepParam_acc_Rep_Account_Journals_SubAcc));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals_SubAcc_Consolidated>("Account Journals Consolidated (Sub Account)", typeof(sp_acc_Account_Journals_SubAccResult), typeof(RepParam_acc_Rep_Account_Journals_SubAcc));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals_SubAcc_Currency_Consolidated>("Account Journals Consolidated (Sub Account) Per Currency", typeof(sp_acc_Account_Journals_SubAcc_currencyResult), typeof(RepParam_acc_Rep_Account_Journals_SubAcc_Currency));
            reportsUpdater.AddPredefinedReport<acc_Rep_Account_Journals_Fee>("Account Journals Vs Fee", typeof(sp_acc_Account_Journals_FeeResult), typeof(RepParam_acc_Rep_Account_Journals_Fee));
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void Setup(ApplicationModulesManager moduleManager)
        {
            base.Setup(moduleManager);
            ValidationRulesRegistrator.RegisterRule(moduleManager, typeof(JournalEntryBalanceRule), typeof(IRuleBaseProperties));
        }

    }
}
