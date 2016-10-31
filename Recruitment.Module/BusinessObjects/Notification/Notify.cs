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

namespace Recruitment.Module.BusinessObjects.Notification
{
    [DefaultClassOptions]
    [NavigationItem("SchedulerEvent")]
    [ImageName("Event16")]
    [DevExpress.ExpressApp.DC.XafDefaultProperty("Subject")]
    [VisibleInReports]
    //[RuleCriteria("DueDate >= StartDate")]
    public class Notify : XPCustomObject, ISupportNotifications, IXafEntityObject
    {
        public Notify(Session session) : base(session)
        {
            RemindIn = new TimeSpan(0, 12, 0, 0);
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
        [RuleRequiredField("", DefaultContexts.Save, "Subject required")]
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
        private DateTime _dueDate;

        [RuleRequiredField("", DefaultContexts.Save, "StartDate required")]
        public DateTime DueDate
        {
            get
            {
                return _dueDate;
            }
            set
            {
                SetPropertyValue("DueDate", ref _dueDate, value);
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
        //[Browsable(false)]
        public DateTime? AlarmTime
        {
            get { return alarmTime; }
            set
            {
                alarmTime = value;
                if (value == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }
            }
        }

        private bool _isPostponed;
        //[Browsable(false)]
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
        //[NonPersistent]
        public string NotificationMessage
        {
            get { return Subject; }
        }

        private TimeSpan? _remindIn;
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
        //[NonPersistent]
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
                AlarmTime = DueDate - RemindIn.Value;
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