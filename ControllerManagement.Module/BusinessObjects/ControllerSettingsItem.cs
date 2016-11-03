using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerManagement.Module.BusinessObjects
{
    [DomainComponent]
    public class ControllerSettingsItem
    {
        public ControllerSettingsItem() { }
        public ControllerSettingsItem(Session session) { }

        public Type Controller { get; set; }
        public bool Active { get; set; }

        public bool IsCustom { get { return Namespace != null && !Namespace.StartsWith("DevExpress") && !Namespace.StartsWith("PerformanceTuning"); } }
        public string ControllerName { get { return Controller == null ? null : Controller.Name; } }
        public string Product { get { return Controller == null ? null : Controller.FullName.Substring(0, Controller.FullName.IndexOf('.')); } }
        public string Namespace { get { return Controller == null ? null : Controller.Namespace; } }
    }
}
