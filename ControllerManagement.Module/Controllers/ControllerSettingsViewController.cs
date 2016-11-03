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
using System.Collections;
using ControllerManagement.Module.BusinessObjects;

namespace ControllerManagement.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ControllerSettingsViewController : ViewController
    {
        public ControllerSettingsViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            this.TargetObjectType = typeof(ControllerSettingsItem);
            this.TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

#if !DEBUG
            this.actionDisableControllers.Active[this.Name] = false;
            this.actionEnableControllers.Active[this.Name] = false;
            this.actionDisableCustomControllers.Active[this.Name] = false;
#endif
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private ICollection CollectionSource { get { return (this.View as ListView).CollectionSource.Collection as ICollection; } }

        private void actionDisableCustomControllers_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (ControllerSettingsItem item in CollectionSource)
                if (item.IsCustom)
                    item.Active = false;
        }

        private void actionEnableControllers_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (ControllerSettingsItem item in this.View.SelectedObjects)
                item.Active = true;

            this.View.RefreshDataSource();
        }

        private void actionDisableControllers_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (ControllerSettingsItem item in this.View.SelectedObjects)
                item.Active = false;

            this.View.RefreshDataSource();
        }
    }
}
