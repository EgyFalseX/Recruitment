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
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class rec_ctr_Journal_Entry_Edit : ViewController
    {
        public rec_ctr_Journal_Entry_Edit()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void ActivateControls()
        {
            //if (View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry))
            //{
            //    bool active = true;
            //    foreach (acc_Journal_Entry accJournalEntry in View.SelectedObjects)
            //    {
            //        rec_Accept_App_Activity activity = ObjectSpace.FindObject<rec_Accept_App_Activity>(CriteriaOperator.Parse("jour_entry_id", 2004));
            //        if (activity != null)
            //        {
            //            active = false;
            //            break;
            //        }
            //    }
            //    //bool active = View.SelectedObjects.Cast<acc_Journal_Entry>().All(entry => ObjectSpace.FindObject<rec_Accept_App_Activity>(CriteriaOperator.Parse("jour_entry_id.jour_entry_id", entry.jour_entry_id)) == null);
            //    Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    return;
            //}
            //if (View.ObjectTypeInfo.Type == typeof(acc_Journal_Entry_Detail))
            //{
            //    bool active = View.SelectedObjects.Cast<acc_Journal_Entry_Detail>().All(entry => ObjectSpace.FindObject<rec_Accept_App_Activity>(CriteriaOperator.Parse("jour_entry_id = ", entry.jour_entry_id.jour_entry_id)) == null);
            //    Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Can't Modify Activity Entry", active);
            //    return;
            //}
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
