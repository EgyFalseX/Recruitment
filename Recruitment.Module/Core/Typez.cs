﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Module.Core
{
    public static class Typez
    {
        public static string OptionAdvanceRevenue => "Advance Revenue";
        public static string OptionRevenueDue => "Revenue Due";
        public static string OptionDocumentRevenue => "Document Revenue";
        public static string OptionCash => "Cash";


        public enum enum_Doc_Status
        {
            [DevExpress.Persistent.Base.ImageName("State_Task_Completed")]
            Completed = 1,
            [DevExpress.Persistent.Base.ImageName("State_Task_InProgress")]
            InProgress = 2
        }
        public enum enum_rec_Applicant_Status{
            [DevExpress.Persistent.Base.ImageName("State_Validation_Information")]
            Ready = 1,
            [DevExpress.Persistent.Base.ImageName("State_Task_Deferred")]
            Busy = 2,
        }
        public enum enum_rec_Suggest_Applicant_Status
        {
            [DevExpress.Persistent.Base.ImageName("State_Task_Completed")]
            Accepted = 3,
            [DevExpress.Persistent.Base.ImageName("State_Validation_Invalid")]
            Refused = 4,
            [DevExpress.Persistent.Base.ImageName("State_Task_Deferred")]
            WaitingConfirmation = 5,
        }
        public enum enum_rec_Employer_Order_Status
        {
            [DevExpress.Persistent.Base.ImageName("State_Task_InProgress")]
            InProgress = 1,
            [DevExpress.Persistent.Base.ImageName("State_Task_Completed")]
            Completed = 2,
            [DevExpress.Persistent.Base.ImageName("Action_Delete")]
            Canceled = 3,
            [DevExpress.Persistent.Base.ImageName("State_Task_Deferred")]
            Pasued = 4,

        }

        public enum enum_rec_Activity_Type
        {
            //[DevExpress.Persistent.Base.ImageName("State_Task_InProgress")]
            BudgetRevenue = 1,
            //[DevExpress.Persistent.Base.ImageName("State_Task_Completed")]
            ActualRevenue = 2,
            //[DevExpress.Persistent.Base.ImageName("Action_Delete")]
            Expenses = 3,
            AdvanceRevenue = 4,
            Salary = 5,

        }


    }
}
