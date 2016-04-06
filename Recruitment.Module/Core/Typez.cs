using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Module.Core
{
    public static class Typez
    {
        public enum enum_Doc_Status
        {
            Completed = 1,
            InProgress = 2
        }
        public enum enum_rec_Applicant_Status
        {
            Ready = 1,
            Busy = 2,
            Accepted = 3,
            Refused = 4,
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

    }
}
