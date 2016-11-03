using System;
using System.ComponentModel;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using DevExpress.ExpressApp.Updating;
using DevExpress.Persistent.BaseImpl;

namespace Recruitment.Module.Win {
    [ToolboxItemFilter("Xaf.Platform.Win")]
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppModuleBasetopic.aspx.
    public sealed partial class RecruitmentWindowsFormsModule : ModuleBase {
        private void Application_CreateCustomModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
#if !DEBUG
            //e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
            //e.Handled = true;
#endif
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), true, "Win");
            e.Handled = true;
        }
        private void Application_CreateCustomUserModelDifferenceStore(Object sender, CreateCustomModelDifferenceStoreEventArgs e) {
            e.Store = new ModelDifferenceDbStore((XafApplication)sender, typeof(ModelDifference), false, "Win");
            e.Handled = true;
        }
        public RecruitmentWindowsFormsModule() {
            InitializeComponent();
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            return ModuleUpdater.EmptyModuleUpdaters;
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
            application.CreateCustomModelDifferenceStore += Application_CreateCustomModelDifferenceStore;
            application.CreateCustomUserModelDifferenceStore += Application_CreateCustomUserModelDifferenceStore;
            // Manage various aspects of the application UI and behavior at the module level.

            application.ModelChanged += new EventHandler(application_ModelChanged);
        }
        void application_ModelChanged(object sender, EventArgs e)
        {

            UIType uiType = ((DevExpress.ExpressApp.Win.SystemModule.IModelOptionsWin)Application.Model.Options).UIType;
            if (uiType == UIType.StandardMDI)
            {
                Application.ShowViewStrategy = new Controllers.Filter.MyMdiShowViewStrategy(Application, DevExpress.ExpressApp.Win.Templates.MdiMode.Standard);
            }
            else if (uiType == UIType.TabbedMDI)
            {
                Application.ShowViewStrategy = new Controllers.Filter.MyMdiShowViewStrategy(Application, DevExpress.ExpressApp.Win.Templates.MdiMode.Tabbed);
            }
        }
    }
}
