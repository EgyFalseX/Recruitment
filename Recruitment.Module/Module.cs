using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Notifications;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base.General;
using Recruitment.Module.BusinessObjects.Notification;
using Recruitment.Module.BusinessObjects.Recruitment;
using Recruitment.Module.Report;

namespace Recruitment.Module {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class RecruitmentModule : ModuleBase
    {
        public RecruitmentModule()
        {
            InitializeComponent();
            BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }

        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }

        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);

            //Register Predefined Reports
            PredefinedReportsUpdater reportsUpdater = new PredefinedReportsUpdater(Application, objectSpace,
                versionFromDB) {UseMultipleUpdaters = true};
            reportsUpdater.AddPredefinedReport<rec_Applicant_01>("Applicant Information", typeof (rec_Applicant),
                typeof (RepParamObjCri));

            return new ModuleUpdater[] {updater, reportsUpdater};
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
            application.LoggedOn += new EventHandler<LogonEventArgs>(application_LoggedOn);

        }

        public override void ExtendModelInterfaces(DevExpress.ExpressApp.Model.ModelInterfaceExtenders extenders)
        {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<DevExpress.ExpressApp.Model.IModelListView, Core.IModelListViewExt>();
        }
        public override void Setup(ApplicationModulesManager moduleManager)
        {
            base.Setup(moduleManager);
            //ValidationRulesRegistrator.RegisterRule(moduleManager, typeof(MobileLengthRule), typeof(IRuleBaseProperties));
        }
        void application_LoggedOn(object sender, LogonEventArgs e)
        {
            NotificationsModule notificationsModule = Application.Modules.FindModule<NotificationsModule>();
            DefaultNotificationsProvider notificationsProvider = notificationsModule.DefaultNotificationsProvider;
            notificationsProvider.CustomizeNotificationCollectionCriteria += notificationsProvider_CustomizeNotificationCollectionCriteria;
        }
        void notificationsProvider_CustomizeNotificationCollectionCriteria(object sender, CustomizeCollectionCriteriaEventArgs e)
        {
            if (e.Type == typeof (Notify))
            {
                e.Criteria = CriteriaOperator.Parse("AssignedTo is null || AssignedTo.Oid == CurrentUserId()");
            }
        }


    }

}
