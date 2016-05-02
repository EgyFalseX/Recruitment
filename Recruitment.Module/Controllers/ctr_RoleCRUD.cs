using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    // ReSharper disable once InconsistentNaming
    public partial class ctr_RoleCRUD : ViewController
    {
        public enum EnumPrivItem
        {
            AllowNavigate, AllowRead, AllowCreate, AllowDelete, AllowWrite
        }
        public ctr_RoleCRUD()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            // ReSharper disable once SuspiciousTypeConversion.Global
            var list = ((IList<EnumPrivItem>)Enum.GetValues(typeof(EnumPrivItem)))
                .Select(t => new ChoiceActionItem(t.ToString(), t)).ToArray();

            act_SetCRUD.Items.Clear();
            act_SetCRUD.Items.AddRange(list);
        }

        private void act_SetCRUD_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;
            EnumPrivItem selectedPriv = (EnumPrivItem)e.SelectedChoiceActionItem.Data;
            
            if (selectedItems.Count == 0)
                return;

            IObjectSpace objectSpace = Application.CreateObjectSpace();
            foreach (object item in selectedItems)
            {
                if (item is DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject == false)
                    continue;

                var securityItem = ObjectSpace.GetObject
                        ((DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject)item);

                switch (selectedPriv)
                {
                    case EnumPrivItem.AllowCreate:
                        securityItem.AllowCreate = !securityItem.AllowCreate;
                        break;
                    case EnumPrivItem.AllowDelete:
                        securityItem.AllowDelete = !securityItem.AllowDelete;
                        break;
                    case EnumPrivItem.AllowNavigate:
                        securityItem.AllowNavigate = !securityItem.AllowNavigate;
                        break;
                    case EnumPrivItem.AllowRead:
                        securityItem.AllowRead = !securityItem.AllowRead;
                        break;
                    case EnumPrivItem.AllowWrite:
                        securityItem.AllowWrite = !securityItem.AllowWrite;
                        break;
                }
            }
            objectSpace.CommitChanges();
        }

    }
}
