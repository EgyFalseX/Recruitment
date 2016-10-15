using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using Accounting.BusinessObjects.Recruitment;
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
    public partial class ctr_Journal_Entry_Closed : ViewController
    {
        public ctr_Journal_Entry_Closed()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.


            View.SelectionChanged += (sender, args) => { ActivateControls(); };
        }

        private void ActivateControls()
        {
            bool entryClosed = View.SelectedObjects.Cast<acc_Journal_Entry>().All(entry => entry.closed == false);
            //bool entryBalanced = View.SelectedObjects.Cast<acc_Journal_Entry>().All(entry => Math.Abs(entry.acc_Journal_Entry_Details.Sum(detail => detail.credit - detail.debit) - Convert.ToDouble(0)) > 0.0);
            bool entryBalanced = View.SelectedObjects.Cast<acc_Journal_Entry>().All(EntryBalanced);
            Active.SetItemValue("All selected entry must be open and balanced", entryClosed && entryBalanced);
        }

        private bool EntryBalanced(acc_Journal_Entry entry)
        {
            if (entry.acc_Journal_Entry_Details == null || entry.acc_Journal_Entry_Details.Count == 0)
                return false;
            double debit = 0, credit = 0;
            foreach (acc_Journal_Entry_Detail detail in entry.acc_Journal_Entry_Details)
            {
                debit += detail.debit;
                credit += detail.credit;
            }
            double aaa =
            Math.Abs(debit - credit);
            return !(Math.Abs(debit - credit) > 0);
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

        private void act_Closed_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IList selectedEntries = e.SelectedObjects;
            if (selectedEntries.Count == 0)
                return;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            foreach (object entry in selectedEntries)
            {
                if (entry is acc_Journal_Entry == false)
                    continue;
                acc_Journal_Entry entryObject = ObjectSpace.GetObject((acc_Journal_Entry)entry);
                entryObject.closed = true;
            }
            objectSpace.CommitChanges();
        }
    }
}
