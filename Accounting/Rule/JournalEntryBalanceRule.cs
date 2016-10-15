using System;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Persistent.Validation;

namespace Accounting.Rule
{
    [CodeRule]
    public class JournalEntryBalanceRule : RuleBase<acc_Journal_Entry>
    {
        protected override bool IsValidInternal(acc_Journal_Entry target, out string errorMessageTemplate)
        {
            errorMessageTemplate = "";
            //Check whether the rule is satisfied 
            if (!target.closed || target.acc_Journal_Entry_Details == null || target.acc_Journal_Entry_Details.Count == 0)
                return true;
            double debit = 0, credit = 0;
            foreach (acc_Journal_Entry_Detail accJournalEntryDetail in target.acc_Journal_Entry_Details)
            {
                debit += accJournalEntryDetail.debit;
                credit += accJournalEntryDetail.credit;
            }
            if (Math.Abs(debit - credit) < 0 || Math.Abs(debit - credit) > 0)
            {
                errorMessageTemplate = "Journal entry unbalanced";
                return false;
            }
            return true;
        }
        public JournalEntryBalanceRule() : base("", "Save") { }
        public JournalEntryBalanceRule(IRuleBaseProperties properties) : base(properties) { }
    }
}
