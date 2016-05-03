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
using Recruitment.Module.BusinessObjects.Recruitment;
using Recruitment.Module.Core;

namespace Recruitment.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ctr_Order_Edit : ViewController
    {
        public ctr_Order_Edit()
        {
            InitializeComponent();

            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void ActivateControls()
        {
            //activate/deactivate CRUD for rec_Employer_Order depend on its Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order))
            {
                bool active = View.SelectedObjects.Cast<rec_Employer_Order>().All(order => order.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
            //activate/deactivate CRUD for rec_Employer_Order_Detail depend on its Order Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail)){
                bool active = View.SelectedObjects.Cast<rec_Employer_Order_Detail>().All(order => order.rec_employer_order_detail_rec_employer_order_id == null || order.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
            //activate/deactivate CRUD for rec_Employer_Order_Detail_Call depend on its Order Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Call)){
                bool active = View.SelectedObjects.Cast<rec_Employer_Order_Detail_Call>().All(item => item.rec_employer_order_detail_call_rec_employer_order_detail_id == null || item.rec_employer_order_detail_call_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
            //activate/deactivate CRUD for rec_Employer_Order_Detail_Suggest_Applicat depend on its Order Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Suggest_Applicat))
            {
                bool active = View.SelectedObjects.Cast<rec_Employer_Order_Detail_Suggest_Applicat>().All(item => item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id == null || item.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
            //activate/deactivate CRUD for rec_Employer_Order_Detail_Accept_Applicat depend on its Order Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Accept_Applicat))
            {
                bool active = View.SelectedObjects.Cast<rec_Employer_Order_Detail_Accept_Applicat>().All(item => item.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id == null || item.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
            //activate/deactivate CRUD for rec_Employer_Order_Detail_Accept_Applicat_Doc depend on its Order Status
            if (View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Accept_Applicat_Doc))
            {
                bool active = View.SelectedObjects.Cast<rec_Employer_Order_Detail_Accept_Applicat_Doc>().All(item => item.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id == null || item.rec_employer_order_detail_accept_applicat_rec_industry_require_doc_type_rec_employer_order_detail_accept_applicat_id.rec_employer_order_detail_accept_applicat_rec_employer_order_detail_suggest_applicat_id.rec_employer_order_detail_suggest_applicat_rec_employer_order_detail_id.rec_employer_order_detail_rec_employer_order_id.rec_employer_order_rec_employer_order_status_id == Typez.enum_rec_Employer_Order_Status.InProgress);
                Frame.GetController<ModificationsController>().SaveAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndCloseAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ModificationsController>().SaveAndNewAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Accept"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                Frame.GetController<ctr_Order_Accept_App>().Actions["action_Order_Accept_App_Refused"].Active.SetItemValue("Only In Progress Order Can Modify", active);
                return;
            }
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            if (View.ObjectTypeInfo.Type == typeof (rec_Employer_Order) || View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail)
                || View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Call) || View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Suggest_Applicat)
                || View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Accept_Applicat) || View.ObjectTypeInfo.Type == typeof(rec_Employer_Order_Detail_Accept_Applicat_Doc))
            {
                View.SelectionChanged += View_SelectionChanged;
            }
            // Perform various tasks depending on the target View.
        }
        private void View_SelectionChanged(object sender, EventArgs e)
        {
            ActivateControls();
        }
        protected override void OnViewControlsCreated(){
            base.OnViewControlsCreated();
            // Access and customize the target View control.
            ActivateControls();
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
