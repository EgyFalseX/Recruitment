using System;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Editors;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.Utils;

namespace Recruitment.Module.BusinessObjects.Filter
{
    [DefaultProperty("FilterName")]
    [ImageName("Recruitment16")]
    public class ViewFilterObject : BaseObject {
        public ViewFilterObject(Session session) : base(session) { }
        private Type _ObjectType;
        [ValueConverter(typeof(TypeToStringConverter)), MemberDesignTimeVisibility(false)]
        public Type ObjectType {
            get { return _ObjectType; }
            set {
                if (SetPropertyValue("ObjectType", ref _ObjectType, value) && !IsLoading)
                    Criteria = String.Empty;
            }
        }
        private string _Criteria;
        [CriteriaOptions("ObjectType")]
        public string Criteria {
            get { return _Criteria; }
            set { SetPropertyValue("Criteria", ref _Criteria, value); }
        }
        private string _FilterName;
        public string FilterName {
            get { return _FilterName; }
            set { SetPropertyValue("FilterName", ref _FilterName, value); }
        }
        [MemberDesignTimeVisibility(false)]
        [Browsable(false)]
        private SecuritySystemUser _User;
        public SecuritySystemUser User
        {
            get { return _User; }
            set { SetPropertyValue("User", ref _User, value); }
        }
    }
}
