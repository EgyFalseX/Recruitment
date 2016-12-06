using DevExpress.Xpo;
using System;

namespace Accounting.Core
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
    }
}
