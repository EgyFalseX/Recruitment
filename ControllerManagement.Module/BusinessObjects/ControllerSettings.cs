using ControllerManagement.Module.Controllers;
using DevExpress.ExpressApp;
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
    public class ControllerSettings
    {
        public ControllerSettings() { }
        public ControllerSettings(Session session) { }

        public void PopulateSettings(IObjectSpace space)
        {
            Settings = ControllerSettingsHelper.Instance.GetSettings(space);
        }

        public List<ControllerSettingsItem> Settings { get; private set; }
    }
}
