using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accounting.BusinessObjects.Recruitment;
using Accounting.Core;
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

namespace Accounting.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Journal_Entry_Edit : ViewController
    {
        public ctr_Journal_Entry_Edit()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void ActivateControls()
        {
            if (View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry))
            {
                bool active = View.SelectedObjects.Cast<acc_Journal_Entry>().All(entry => entry.closed == false);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                return;
            }
            if (View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry_Detail))
            {
                bool active = View.SelectedObjects.Cast<acc_Journal_Entry_Detail>().All(entry => !entry.jour_entry_id?.closed ?? false);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Can't Modify Closed Entry", active);
                return;
            }
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry) || View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry_Detail))
            {
                View.SelectionChanged += View_SelectionChanged;
            }
        }
        private void View_SelectionChanged(object sender, EventArgs e)
        {
            ActivateControls();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            ActivateControls();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

    }
}
