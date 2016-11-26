﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
namespace Accounting.BusinessObjects.Recruitment
{
    public static class SprocHelper
    {
        public static DevExpress.Xpo.DB.SelectedData Execsp_Trial_Balance(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.ExecuteSproc("sp_Trial_Balance", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static System.Collections.Generic.ICollection<sp_Trial_BalanceResult> Execsp_Trial_BalanceIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.GetObjectsFromSproc<sp_Trial_BalanceResult>("sp_Trial_Balance", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static XPDataView Execsp_Trial_BalanceIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Trial_Balance", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_Trial_BalanceResult)), sprocData);
        }
        public static void Execsp_Trial_BalanceIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Trial_Balance", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_Trial_BalanceResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_01(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_01", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_01Result> Execsp_acc_01IntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_01Result>("sp_acc_01", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_01IntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_01", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_01Result)), sprocData);
        }
        public static void Execsp_acc_01IntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_01", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_01Result)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_liability_and_equity(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.ExecuteSproc("sp_liability_and_equity", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static System.Collections.Generic.ICollection<sp_liability_and_equityResult> Execsp_liability_and_equityIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.GetObjectsFromSproc<sp_liability_and_equityResult>("sp_liability_and_equity", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static XPDataView Execsp_liability_and_equityIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_liability_and_equity", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_liability_and_equityResult)), sprocData);
        }
        public static void Execsp_liability_and_equityIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_liability_and_equity", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_liability_and_equityResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_02(Session session, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_02", new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_02Result> Execsp_acc_02IntoObjects(Session session, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_02Result>("sp_acc_02", new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_02IntoDataView(Session session, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_02", new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_02Result)), sprocData);
        }
        public static void Execsp_acc_02IntoDataView(XPDataView dataView, Session session, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_02", new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_02Result)));
            dataView.LoadData(sprocData);
        }
    }
}
