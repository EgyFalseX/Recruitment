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
            bool entryBalanced = View.SelectedObjects.Cast<acc_Journal_Entry>().All(EntryBalanced);
            act_Closed.Active.SetItemValue("All selected entry must be open and balanced", entryClosed && entryBalanced);
            
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
                acc_Journal_Entry entryObject = objectSpace.GetObject((acc_Journal_Entry)entry);
                entryObject.closed = true;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

        private void act_Refund_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IList selectedEntries = e.SelectedObjects;
            if (selectedEntries.Count != 1)
                return;
            IObjectSpace objectSpace = Application.CreateObjectSpace();
            acc_Journal_Entry entry = (acc_Journal_Entry)selectedEntries[0];
            acc_Journal_Entry newEntry = objectSpace.CreateObject<acc_Journal_Entry>();
            newEntry.entry_date = Core.SqlOp.GetServerDateTime(objectSpace);
            newEntry.closed = false;
            newEntry.entry_text = "Refund Entry Id " + entry.jour_entry_id;
            newEntry.description = $"Auto refund entry {entry.jour_entry_id}, requested from action Refund";
            foreach (acc_Journal_Entry_Detail accJournalEntryDetail in entry.acc_Journal_Entry_Details)
            {
                acc_Journal_Entry_Detail newEntryDetail = objectSpace.CreateObject<acc_Journal_Entry_Detail>();
                newEntryDetail.jour_entry_id = newEntry;
                newEntryDetail.account_id = objectSpace.GetObject(accJournalEntryDetail.account_id);
                newEntryDetail.debit = accJournalEntryDetail.debit*-1;
                newEntryDetail.credit = accJournalEntryDetail.credit * -1;
                newEntryDetail.costcenter_id = objectSpace.GetObject(accJournalEntryDetail.costcenter_id);
                newEntryDetail.entry_text = accJournalEntryDetail.entry_text + " (Refund)";
                newEntryDetail.description = accJournalEntryDetail.description + " (Refund)";
                newEntryDetail.debit_currency = accJournalEntryDetail.debit_currency;
                newEntryDetail.credit_currency = accJournalEntryDetail.credit_currency;
                newEntryDetail.currency_id = objectSpace.GetObject(accJournalEntryDetail.currency_id);
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}
