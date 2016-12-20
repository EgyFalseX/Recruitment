using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.Data.Filtering;

namespace Recruitment.Module.Core
{
    public static class SqlOp
    {
        public static DateTime GetServerDateTime(Session session)
        {
            DevExpress.Data.Filtering.CriteriaOperator funcNow =
                new DevExpress.Data.Filtering.FunctionOperator(DevExpress.Data.Filtering.FunctionOperatorType.Now);
            return (DateTime)session.Evaluate(typeof(XPObjectType), funcNow, null);
        }
        public static DateTime GetServerDateTime(DevExpress.ExpressApp.IObjectSpace session)
        {
            DevExpress.Data.Filtering.CriteriaOperator funcNow =
                new DevExpress.Data.Filtering.FunctionOperator(DevExpress.Data.Filtering.FunctionOperatorType.Now);
            return (DateTime)session.Evaluate(typeof(XPObjectType), funcNow, null);
        }

        public static acc_Account GetOptionAccount(Session session, string optionName)
        {
            acc_Option option = session.FindObject<acc_Option>(CriteriaOperator.Parse("acc_option_name = ?", optionName));
            return session.FindObject<acc_Account>(CriteriaOperator.Parse("account_id = ?", option.acc_option_value));
        }
        public static acc_Account GetOptionAccount(DevExpress.ExpressApp.IObjectSpace objectSpace, string optionName)
        {
            acc_Option option = objectSpace.FindObject<acc_Option>(CriteriaOperator.Parse("acc_option_name = ?", optionName));
            return objectSpace.FindObject<acc_Account>(CriteriaOperator.Parse("account_id = ?", option.acc_option_value));
        }
    }
}
