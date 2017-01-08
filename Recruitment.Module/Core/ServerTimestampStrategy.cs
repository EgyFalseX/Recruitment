using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Xpo;

namespace Recruitment.Module.Core
{
    public class ServerTimestampStrategy : IAuditTimestampStrategy
    {
        DateTime _cachedTimestamp;
        #region IAuditTimestampStrategy Members
        public DateTime GetTimestamp(AuditDataItem auditDataItem)
        {
            return _cachedTimestamp;
        }
        public void OnBeginSaveTransaction(Session session)
        {
            _cachedTimestamp = SqlOp.GetServerDateTime(session);
        }
        #endregion
    }

}
