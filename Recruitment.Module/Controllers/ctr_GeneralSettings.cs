using DevExpress.ExpressApp;
using DevExpress.ExpressApp.AuditTrail;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace Recruitment.Module.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class ctr_GeneralSettings : ViewController<ListView>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.Model.IsFooterVisible = true;
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

    }
}
