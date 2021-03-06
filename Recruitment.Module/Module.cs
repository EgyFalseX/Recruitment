﻿using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using Accounting;
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
            PredefinedReportsUpdater reportsUpdater = RegisterPredefindReports(objectSpace, versionFromDB);
            return new ModuleUpdater[] {updater, reportsUpdater};
        }

        private PredefinedReportsUpdater RegisterPredefindReports(IObjectSpace objectSpace, Version versionFromDB)
        {
            //Register Predefined Reports
            PredefinedReportsUpdater reportsUpdater = new PredefinedReportsUpdater(Application, objectSpace, versionFromDB) {UseMultipleUpdaters = true};
            reportsUpdater.AddPredefinedReport<rec_Applicant_01>("Applicant Information", typeof (rec_Applicant), typeof (RepParamObjCri));
            reportsUpdater.AddPredefinedReport<rec_Rep_Activity_01>("Employer Activity - Per Employer And Activity", typeof(sp_Activity_01Result), typeof(RepParam_rec_Rep_Activity_01));
            reportsUpdater.AddPredefinedReport<rec_Rep_Activity_01A>("Employer Activity - Per Employer", typeof(sp_Activity_01Result), typeof(RepParam_rec_Rep_Activity_01A));
            reportsUpdater.AddPredefinedReport<rec_Rep_Activity_02>("Employer Activity - Detailed", typeof(sp_Activity_02Result), typeof(RepParam_rec_Rep_Activity_02));
            reportsUpdater.AddPredefinedReport<rec_Rep_Activity_03>("Employer Activity - Per Applicant", typeof(sp_Activity_03Result), typeof(RepParam_rec_Rep_Activity_03));
            return reportsUpdater;
        }

        public override void Setup(XafApplication application)
        {
            ReportDataProvider.ReportsStorage = new ReportsStorageX();
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
            application.LoggedOn += new EventHandler<LogonEventArgs>(application_LoggedOn);
            // for auto association between relation fields
            DevExpress.ExpressApp.Security.Strategy.SecuritySystemRoleBase.AutoAssociationPermissions = true;
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
