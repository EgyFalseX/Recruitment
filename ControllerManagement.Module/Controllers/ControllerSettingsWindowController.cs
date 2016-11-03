using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using ControllerManagement.Module.BusinessObjects;
using System.Diagnostics;

namespace ControllerManagement.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class ControllerSettingsWindowController : WindowController
    {
        public ControllerSettingsWindowController()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
            this.TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.

#if DEBUG
            actionShowControllerSettings.Active[this.Name] = Debugger.IsAttached;
#else
            actionShowControllerSettings.Active[this.Name] = false;
#endif
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void actionShowControllerSettings_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace space = Application.CreateObjectSpace();
            ControllerSettings settings = space.CreateObject<ControllerSettings>();
            settings.PopulateSettings(space);
            e.View = Application.CreateDetailView(space, settings);
            e.DialogController.Accepting += DialogController_Accepting;
        }

        void DialogController_Accepting(object sender, DialogControllerAcceptingEventArgs e)
        {
            ControllerSettings settings = e.AcceptActionArgs.CurrentObject as ControllerSettings;
            ControllerSettingsHelper.Instance.SetSettings(settings.Settings);
        }
    }
}
