using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
