using System.Collections.Generic;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.AuditTrail;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace Recruitment.Module.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class ctr_GeneralSettings : ViewController<ListView>
    {
        FilterController _standardFilterController;

        protected override void OnActivated()
        {
            base.OnActivated();
            View.Model.IsFooterVisible = true;

            _standardFilterController = Frame.GetController<FilterController>();
            _standardFilterController.FullTextSearchTargetPropertiesMode = FullTextSearchTargetPropertiesMode.VisibleColumns;
            if (_standardFilterController != null)
            {
                _standardFilterController.CustomGetFullTextSearchProperties += standardFilterController_CustomGetFullTextSearchProperties;
            }
            }
        private void standardFilterController_CustomGetFullTextSearchProperties(object sender, CustomGetFullTextSearchPropertiesEventArgs e)
        {
            //check if search column  available for this user
            if (View != null)
            {
                List<string> searchProperties = _standardFilterController.GetFullTextSearchProperties().ToList();
                foreach (string propertyName in searchProperties)
                {
                    if (DataManipulationRight.CanRead(View.ObjectTypeInfo.Type, propertyName, null, ((ListView)View).CollectionSource, View.ObjectSpace))
                        e.Properties.Add(propertyName);
                }
                e.Handled = true;
            }
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            ITypeInfo auditTrail = XafTypesInfo.Instance.FindTypeInfo(typeof(AuditDataItemPersistent));
            //auditTrail.CreateMember("Building", typeof(int));
            IMemberInfo oldValue = auditTrail.FindMember("OldValue");
            oldValue.AddAttribute(new VisibleInListViewAttribute(true));
            IMemberInfo newValue = auditTrail.FindMember("NewValue");
            newValue.AddAttribute(new VisibleInListViewAttribute(true));
        }
        protected override void OnDeactivated()
        {
            _standardFilterController.CustomGetFullTextSearchProperties += standardFilterController_CustomGetFullTextSearchProperties;
            base.OnDeactivated();
        }

    }
}
