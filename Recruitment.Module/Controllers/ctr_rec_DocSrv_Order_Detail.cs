using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using Recruitment.Module.BusinessObjects.Recruitment;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_rec_DocSrv_Order_Detail : ViewController
    {
        public ctr_rec_DocSrv_Order_Detail()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            //Perform various tasks depending on the target View.
            View.SelectionChanged += (sender, args) =>
            {
                ActivateControls();
            };
        }

        private void ActivateControls()
        {
            bool activeDelivered = View.SelectedObjects.Cast<rec_DocSrv_Order_Detail>().All(item =>
                item.rec_DocSrv_Order_Detail_Srvs.All(srv => srv.is_completed && srv.paid)
                );
            bool alreadyDelivered = View.SelectedObjects.Cast<rec_DocSrv_Order_Detail>().All(item => !item.delivered);

            act_Delivered.Active.SetItemValue("Active For Not Completed Service Only", activeDelivered && alreadyDelivered);
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            ActivateControls();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
        private void act_Delivered_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(rec_DocSrv_Order_Detail));
            DateTime serviceDateTime = Core.SqlOp.GetServerDateTime(objectSpace);
            foreach (rec_DocSrv_Order_Detail item in e.SelectedObjects)
            {
                rec_DocSrv_Order_Detail detail = objectSpace.GetObject(item);
                detail.delivered = true;
                detail.delivered_date = serviceDateTime;
            }
            objectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }
    }
}
