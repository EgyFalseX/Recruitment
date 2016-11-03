using ControllerManagement.Module.BusinessObjects;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerManagement.Module.Controllers
{
    public class ControllerSettingsHelper
    {
        private static readonly ControllerSettingsHelper instance = new ControllerSettingsHelper();
        private ControllerSettingsHelper() { }
        public static ControllerSettingsHelper Instance { get { return instance; } }

        Dictionary<Type, bool> controllerSettings = new Dictionary<Type, bool>();

        private void PopulateControllerDictionary(ICollection<Controller> controllers)
        {
            if (controllerSettings.Count > 0)
                return;

            foreach (Controller c in controllers)
            {
                if (!controllerSettings.ContainsKey(c.GetType()))
                    controllerSettings.Add(c.GetType(), true);
            }
        }

        public void CustomizeViewSettings(ViewShowingEventArgs e)
        {
            PopulateControllerDictionary(e.TargetFrame.Controllers.Values);

            foreach (Controller c in e.TargetFrame.Controllers.Values)
            {
                if (controllerSettings.ContainsKey(c.GetType()))
                    c.Active["PerformanceTuning"] = controllerSettings[c.GetType()];
                else
                    controllerSettings.Add(c.GetType(), true);
            }
        }

        public void EnableController(Type type)
        {
            controllerSettings[type] = true;
        }

        public void DisableController(Type type)
        {
            controllerSettings[type] = false;
        }

        public void DisableAllCustomControllers()
        {
            foreach (Type type in controllerSettings.Keys)
                controllerSettings[type] &= type.FullName.StartsWith("DevExpress");
        }

        public void EnableAllCustomControllers()
        {
            foreach (Type type in controllerSettings.Keys)
                controllerSettings[type] = !type.FullName.StartsWith("DevExpress");
        }

        public List<ControllerSettingsItem> GetSettings(IObjectSpace space)
        {
            List<ControllerSettingsItem> list = new List<ControllerSettingsItem>();
            foreach (Type t in controllerSettings.Keys)
            {
                ControllerSettingsItem item = space.CreateObject<ControllerSettingsItem>();
                item.Controller = t;
                item.Active = controllerSettings[t];
                list.Add(item);
            }

            return list;
        }

        public void SetSettings(List<ControllerSettingsItem> settings)
        {
            foreach (ControllerSettingsItem item in settings)
            {
                controllerSettings[item.Controller] = item.Active;
            }
        }
    }
}
