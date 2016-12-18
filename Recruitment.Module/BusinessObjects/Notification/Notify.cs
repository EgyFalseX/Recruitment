using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Utils.Filtering;

namespace Recruitment.Module.BusinessObjects.Notification
{
    [DefaultClassOptions]
    [NavigationItem("SchedulerEvent")]
    [ImageName("Event")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("Subject")]
    [VisibleInReports]
    //[RuleCriteria("DueDate >= StartDate")]
    public class Notify : XPCustomObject, ISupportNotifications, IXafEntityObject
    {
        public Notify(Session session) : base(session)
        {
            RemindIn = new TimeSpan(0, 0, 0, 0);
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }
        long fOid;
        [Key(AutoGenerate = true), Browsable(false)]
        public long Oid
        {
            get { return fOid; }
            set { SetPropertyValue<long>("Oid", ref fOid, value); }
        }

        private string _subject;
        [RuleRequiredField("Notify_Subject_vld_req", DefaultContexts.Save, "Subject required")]
        public string Subject
        {
            get
            {
                return _subject;
            }
            set
            {
                SetPropertyValue("Subject", ref _subject, value);
            }
        }

        private string _description;
        [Size(SizeAttribute.Unlimited)]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                SetPropertyValue("Description", ref _description, value);
            }
        }
        private SecuritySystemUser _assignedTo;
        public SecuritySystemUser AssignedTo
        {
            get
            {
                return _assignedTo;
            }
            set
            {
                SetPropertyValue("AssignedTo", ref _assignedTo, value);
            }
        }

        #region ISupportNotifications members
        private DateTime? alarmTime;
        [RuleRequiredField("Notify_AlarmTime_vld_req", DefaultContexts.Save, "Alarm Time required")]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set
            {
                alarmTime = value;
                RemindIn = new TimeSpan(0, 0, 0, 0);
                if (value == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }
            }
        }

        private bool _isPostponed;
        public bool IsPostponed
        {
            get
            {
                return _isPostponed;
            }
            set
            {
                SetPropertyValue("IsPostponed", ref _isPostponed, value);
            }
        }
        [Browsable(false)]
        public string NotificationMessage
        {
            get { return Subject; }
        }

        private TimeSpan? _remindIn;
        [MemberDesignTimeVisibility(false)]
        public TimeSpan? RemindIn
        {
            get
            {
                return _remindIn;
            }
            set
            {
                SetPropertyValue("RemindIn", ref _remindIn, value);
            }
        }
        [Browsable(false)]
        public object UniqueId
        {
            get { return Oid; }
        }
        #endregion
        #region IXafEntityObject members
        public void OnCreated() { }
        public void OnLoaded() { }
        public void OnSaving()
        {
            if (RemindIn.HasValue)
            {
                AlarmTime = AlarmTime - RemindIn.Value;
            }
            else
            { 
                AlarmTime = null;
            }
            if (AlarmTime == null)
            {
                RemindIn = null;
                IsPostponed = false;
            }

        }


        #endregion


    }
}