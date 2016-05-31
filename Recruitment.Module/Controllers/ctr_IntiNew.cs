using System.Reflection;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    // ReSharper disable once InconsistentNaming
    public partial class ctr_IntiNew : ViewController
    {
        private object _parentObj;
        public ctr_IntiNew()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            var ctr = Frame.GetController<NewObjectViewController>();
            if (ctr == null || Frame.GetType() != typeof(NestedFrame) || ((NestedFrame)Frame).ViewItem.View == null)
                return;
            _parentObj = ((NestedFrame)Frame).ViewItem.View.CurrentObject;
            ctr.ObjectCreated += IntiNew_ObjectCreated;
        }
        private void IntiNew_ObjectCreated(object sender, ObjectCreatedEventArgs e)
        {
            foreach (PropertyInfo prop in e.CreatedObject.GetType().GetProperties())
            {
                if (prop.PropertyType == _parentObj.GetType())
                    prop.SetValue(e.CreatedObject, e.ObjectSpace.GetObject(_parentObj), null);
            }
        }
        protected override void OnDeactivated(){
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            var ctr = Frame.GetController<NewObjectViewController>();
            if (ctr == null || Frame.GetType() != typeof(NestedFrame))
                return;
            ctr.ObjectCreated -= IntiNew_ObjectCreated;
        }}
}
