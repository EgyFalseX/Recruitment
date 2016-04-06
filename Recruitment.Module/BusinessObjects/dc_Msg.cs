using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;

namespace Recruitment.Module.BusinessObjects
{
    [DomainComponent]
    public class dc_Msg
    {
        public dc_Msg() { }

        [Size(SizeAttribute.Unlimited), ModelDefault("AllowEdit", "False")]
        public string Comment
        {
            get; set;
        }

        //[Action(Caption = "Postpone", TargetObjectsCriteria = "[Deadline] Is Not Null And Not [IsCompleted]")]
        //public void Postpone(PostponeParametersObject parameters)
        //{
        //    if (Deadline.HasValue && !IsCompleted && (parameters.PostponeForDays > 0))
        //    {
        //        Deadline += TimeSpan.FromDays(parameters.PostponeForDays);
        //        Comments += String.Format("Postponed for {0} days, new deadline is {1:d}\r\n{2}\r\n",
        //        parameters.PostponeForDays, Deadline, parameters.Comment);
        //    }
        //}
    }
}
