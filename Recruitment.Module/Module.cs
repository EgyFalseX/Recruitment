using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
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
using Recruitment.Module.BusinessObjects.Recruitment;
using Recruitment.Module.Report;

namespace Recruitment.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class RecruitmentModule : ModuleBase {
        public RecruitmentModule() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
        
		public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
			base.CustomizeTypesInfo(typesInfo);
			CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
		}
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            
            //Register Predefined Reports
            PredefinedReportsUpdater reportsUpdater = new PredefinedReportsUpdater(Application, objectSpace,
                versionFromDB) {UseMultipleUpdaters = true};
            reportsUpdater.AddPredefinedReport<rec_Applicant_01>("Applicant Information", typeof(rec_Applicant), typeof(RepParamObjCri));

            return new ModuleUpdater[] { updater , reportsUpdater };
        }
        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void Setup(ApplicationModulesManager moduleManager)
        {
            base.Setup(moduleManager);
            //ValidationRulesRegistrator.RegisterRule(moduleManager, typeof(MobileLengthRule), typeof(IRuleBaseProperties));
        }
    }
}
