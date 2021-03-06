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
        public static DevExpress.Xpo.DB.SelectedData Execsp_Income_Statement(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.ExecuteSproc("sp_Income_Statement", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static System.Collections.Generic.ICollection<sp_Income_StatementResult> Execsp_Income_StatementIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.GetObjectsFromSproc<sp_Income_StatementResult>("sp_Income_Statement", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static XPDataView Execsp_Income_StatementIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Income_Statement", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_Income_StatementResult)), sprocData);
        }
        public static void Execsp_Income_StatementIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Income_Statement", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_Income_StatementResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_Account_Journals_SubAcc(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_Account_Journals_SubAcc", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_Account_Journals_SubAccResult> Execsp_acc_Account_Journals_SubAccIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_Account_Journals_SubAccResult>("sp_acc_Account_Journals_SubAcc", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_Account_Journals_SubAccIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_SubAcc", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_Account_Journals_SubAccResult)), sprocData);
        }
        public static void Execsp_acc_Account_Journals_SubAccIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_SubAcc", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_Account_Journals_SubAccResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_Account_Journals_SubAcc_currency(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_Account_Journals_SubAcc_currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_Account_Journals_SubAcc_currencyResult> Execsp_acc_Account_Journals_SubAcc_currencyIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_Account_Journals_SubAcc_currencyResult>("sp_acc_Account_Journals_SubAcc_currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_Account_Journals_SubAcc_currencyIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_SubAcc_currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_Account_Journals_SubAcc_currencyResult)), sprocData);
        }
        public static void Execsp_acc_Account_Journals_SubAcc_currencyIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_SubAcc_currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_Account_Journals_SubAcc_currencyResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_Account_Journals(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_Account_Journals", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_Account_JournalsResult> Execsp_acc_Account_JournalsIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_Account_JournalsResult>("sp_acc_Account_Journals", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_Account_JournalsIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_Account_JournalsResult)), sprocData);
        }
        public static void Execsp_acc_Account_JournalsIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_Account_JournalsResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_acc_Account_Journals_Currency(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.ExecuteSproc("sp_acc_Account_Journals_Currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static System.Collections.Generic.ICollection<sp_acc_Account_Journals_CurrencyResult> Execsp_acc_Account_Journals_CurrencyIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            return session.GetObjectsFromSproc<sp_acc_Account_Journals_CurrencyResult>("sp_acc_Account_Journals_Currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
        }
        public static XPDataView Execsp_acc_Account_Journals_CurrencyIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_Currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_acc_Account_Journals_CurrencyResult)), sprocData);
        }
        public static void Execsp_acc_Account_Journals_CurrencyIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int account_id)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_acc_Account_Journals_Currency", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(account_id));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_acc_Account_Journals_CurrencyResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_Balance_Sheet(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.ExecuteSproc("sp_Balance_Sheet", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static System.Collections.Generic.ICollection<sp_Balance_SheetResult> Execsp_Balance_SheetIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            return session.GetObjectsFromSproc<sp_Balance_SheetResult>("sp_Balance_Sheet", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
        }
        public static XPDataView Execsp_Balance_SheetIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Balance_Sheet", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_Balance_SheetResult)), sprocData);
        }
        public static void Execsp_Balance_SheetIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate, int Category)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Balance_Sheet", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate), new OperandValue(Category));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_Balance_SheetResult)));
            dataView.LoadData(sprocData);
        }
        public static DevExpress.Xpo.DB.SelectedData Execsp_Income_Statement_fixed(Session session, int Year, DateTime StartDate, DateTime EndDate)
        {
            return session.ExecuteSproc("sp_Income_Statement_fixed", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate));
        }
        public static System.Collections.Generic.ICollection<sp_Income_Statement_fixedResult> Execsp_Income_Statement_fixedIntoObjects(Session session, int Year, DateTime StartDate, DateTime EndDate)
        {
            return session.GetObjectsFromSproc<sp_Income_Statement_fixedResult>("sp_Income_Statement_fixed", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate));
        }
        public static XPDataView Execsp_Income_Statement_fixedIntoDataView(Session session, int Year, DateTime StartDate, DateTime EndDate)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Income_Statement_fixed", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate));
            return new XPDataView(session.Dictionary, session.GetClassInfo(typeof(sp_Income_Statement_fixedResult)), sprocData);
        }
        public static void Execsp_Income_Statement_fixedIntoDataView(XPDataView dataView, Session session, int Year, DateTime StartDate, DateTime EndDate)
        {
            DevExpress.Xpo.DB.SelectedData sprocData = session.ExecuteSproc("sp_Income_Statement_fixed", new OperandValue(Year), new OperandValue(StartDate), new OperandValue(EndDate));
            dataView.PopulateProperties(session.GetClassInfo(typeof(sp_Income_Statement_fixedResult)));
            dataView.LoadData(sprocData);
        }
    }
}
