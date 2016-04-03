using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_RoleCRUD : ViewController
    {
        public enum enum_Priv_Item
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
            var list = ((IList<enum_Priv_Item>)Enum.GetValues(typeof(enum_Priv_Item)))
                .Select(t => new ChoiceActionItem(t.ToString(), t)).ToArray();

            act_SetCRUD.Items.Clear();
            act_SetCRUD.Items.AddRange(list);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        private void act_SetCRUD_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var selectedItems = e.SelectedObjects;
            enum_Priv_Item selectedPriv = (enum_Priv_Item)e.SelectedChoiceActionItem.Data;
            
            if (selectedItems.Count == 0)
                return;

            IObjectSpace objectSpace = Application.CreateObjectSpace();
            foreach (object item in selectedItems)
            {
                if (item is DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject == false)
                    continue;

                var securityItem = ObjectSpace.GetObject<DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject>
                        ((DevExpress.ExpressApp.Security.Strategy.SecuritySystemTypePermissionObject)item);

                switch (selectedPriv)
                {
                    case enum_Priv_Item.AllowCreate:
                        securityItem.AllowCreate = !securityItem.AllowCreate;
                        break;
                    case enum_Priv_Item.AllowDelete:
                        securityItem.AllowDelete = !securityItem.AllowDelete;
                        break;
                    case enum_Priv_Item.AllowNavigate:
                        securityItem.AllowNavigate = !securityItem.AllowNavigate;
                        break;
                    case enum_Priv_Item.AllowRead:
                        securityItem.AllowRead = !securityItem.AllowRead;
                        break;
                    case enum_Priv_Item.AllowWrite:
                        securityItem.AllowWrite = !securityItem.AllowWrite;
                        break;
                    default:
                        break;
                }
            }
            objectSpace.CommitChanges();
        }

    }
}
