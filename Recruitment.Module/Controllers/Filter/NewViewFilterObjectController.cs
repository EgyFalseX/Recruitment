using System;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.ExpressApp.SystemModule;
using Recruitment.Module.BusinessObjects.Filter;
using Recruitment.Module.Core;

namespace Recruitment.Module.Controllers.Filter
{
    /// <summary>
    /// Set Object Type for Filter View before it show
    /// </summary>
    public class NewViewFilterObjectController : ObjectViewController<ListView, ViewFilterObject> {
        public NewViewFilterObjectController() {
            TargetViewId = "ViewFilterObject_LookupListView";
        }
        protected override void OnActivated() {
            base.OnActivated();
            if (View.CollectionSource is PropertyCollectionSource && ((PropertyCollectionSource)View.CollectionSource).MasterObjectType == typeof(ViewFilterContainer)) {
                Frame.GetController<NewObjectViewController>().ObjectCreated += new EventHandler<ObjectCreatedEventArgs>(ViewController1_ObjectCreated);
            }
        }
        void ViewController1_ObjectCreated(object sender, ObjectCreatedEventArgs e) {
            if (e.CreatedObject is ViewFilterObject) {
                ViewFilterObject newViewFilterObject = (ViewFilterObject)e.CreatedObject;
                PropertyCollectionSource pcs = (PropertyCollectionSource)View.CollectionSource;
                newViewFilterObject.ObjectType = ((ViewFilterContainer)pcs.MasterObject).ObjectType;
                newViewFilterObject.User = e.ObjectSpace.FindObject<SecuritySystemUser>(CriteriaOperator.Parse("Oid = CurrentUserId()"));
                }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            if (View.CollectionSource is PropertyCollectionSource && ((PropertyCollectionSource)View.CollectionSource).MasterObjectType == typeof(ViewFilterContainer)) {
                Frame.GetController<NewObjectViewController>().ObjectCreated -= new EventHandler<ObjectCreatedEventArgs>(ViewController1_ObjectCreated);
            }
        }
    }
}
