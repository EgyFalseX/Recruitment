using System;
using System.Linq;
using Accounting.BusinessObjects.Recruitment;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;

namespace Accounting.DatabaseUpdate {
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppUpdatingModuleUpdatertopic.aspx
    public class Updater : ModuleUpdater {
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
            base(objectSpace, currentDBVersion) {
        }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            //UpdateViewInfo();
            //UpdateSpInfo();
            InsertDefaultData();
        }
        #region UpdateView
        private void UpdateViewInfo()
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;
            CreateView(session, "vacc_Journal_Entry_Detail", Getvacc_Journal_Entry_Detail);
        }
        private void CreateView(Session session, string viewName, string viewContains)
        {
            string GetChechViewSql = @"IF EXISTS(SELECT name FROM sys.views WHERE name = '{0}')
                                            SELECT 1
                                            ELSE
                                            SELECT 0";

            object exists = session.ExecuteScalar(string.Format(GetChechViewSql, viewName));
            if (exists != null && exists.ToString() == "0")
                session.ExecuteNonQuery(viewContains);
        }
        private static string Getvacc_Journal_Entry_Detail
        {
            get
            {
                return @"CREATE VIEW [dbo].[vacc_Journal_Entry_Detail]
AS
SELECT        dbo.acc_Journal_Entry_Detail.jour_entry_detail_id, dbo.acc_Journal_Entry_Detail.jour_entry_id, dbo.acc_Journal_Entry_Detail.account_id, dbo.acc_Journal_Entry_Detail.debit, 
                         dbo.acc_Journal_Entry_Detail.credit, dbo.acc_Journal_Entry_Detail.costcenter_id, dbo.acc_Journal_Entry_Detail.entry_text, dbo.acc_Journal_Entry_Detail.description, 
                         dbo.acc_Journal_Entry_Detail.debit_currency, dbo.acc_Journal_Entry_Detail.credit_currency, dbo.acc_Journal_Entry_Detail.currency_id, dbo.acc_Journal_Entry.entry_date, dbo.acc_Journal_Entry.period_id, 
                         dbo.acc_Journal_Entry.closed, dbo.acc_Journal_Entry.voucher_no, dbo.acc_CostCenter.costcenter_name, dbo.acc_Currency.currency_name, dbo.acc_Account.account_name, dbo.acc_Account.account_code, 
                         dbo.acc_Account.parent_account_id, dbo.acc_Account.account_type_id, dbo.acc_Account.acc_nature_id, dbo.acc_Account.account_fees, dbo.acc_Account_Type.account_type_name, 
                         dbo.acc_Nature.acc_nature_name, dbo.acc_Period.period_name, dbo.acc_Period.year_id, dbo.acc_Period.start_date, dbo.acc_Period.end_date, dbo.acc_Year.year_name, dbo.acc_Year.year_start_date, 
                         dbo.acc_Year.year_end_date, dbo.acc_Nature.factor
FROM            dbo.acc_Journal_Entry_Detail INNER JOIN
                         dbo.acc_Journal_Entry ON dbo.acc_Journal_Entry_Detail.jour_entry_id = dbo.acc_Journal_Entry.jour_entry_id INNER JOIN
                         dbo.acc_Account ON dbo.acc_Journal_Entry_Detail.account_id = dbo.acc_Account.account_id INNER JOIN
                         dbo.acc_Account_Type ON dbo.acc_Account.account_type_id = dbo.acc_Account_Type.account_type_id INNER JOIN
                         dbo.acc_Nature ON dbo.acc_Account.acc_nature_id = dbo.acc_Nature.acc_nature_id INNER JOIN
                         dbo.acc_Period ON dbo.acc_Journal_Entry.period_id = dbo.acc_Period.period_id INNER JOIN
                         dbo.acc_Year ON dbo.acc_Period.year_id = dbo.acc_Year.year_id LEFT OUTER JOIN
                         dbo.acc_Currency ON dbo.acc_Journal_Entry_Detail.currency_id = dbo.acc_Currency.currency_id LEFT OUTER JOIN
                         dbo.acc_CostCenter ON dbo.acc_Journal_Entry_Detail.costcenter_id = dbo.acc_CostCenter.costcenter_id
WHERE        (dbo.acc_Journal_Entry.closed = 1)
";
            }
        }
        #endregion
        #region UpdateSP
        private void UpdateSpInfo()
        {
            Session session = ((XPObjectSpace)ObjectSpace).Session;

            CreateSp(session, "sp_acc_Account_Journals", Getsp_acc_Account_Journals);
            CreateSp(session, "sp_acc_Account_Journals_Currency", Getsp_acc_Account_Journals_Currency);
            CreateSp(session, "sp_acc_Account_Journals_SubAcc", Getsp_acc_Account_Journals_SubAcc);
            CreateSp(session, "sp_acc_Account_Journals_SubAcc_currency", Getsp_acc_Account_Journals_SubAcc_currency);
            CreateSp(session, "sp_Balance_Sheet", Getsp_Balance_Sheet);
            CreateSp(session, "sp_Income_Statement", Getsp_Income_Statement);
            CreateSp(session, "sp_Income_Statement_fixed", Getsp_Income_Statement_fixed);
            CreateSp(session, "sp_Trial_Balance", GetspTrialBalanceSql);
        }
        private void CreateSp(Session session, string spName, string spContains)
        {
            string GetChechSpSql = @"IF EXISTS(SELECT [Routine_Name] FROM [INFORMATION_SCHEMA].[ROUTINES] WHERE [Routine_Name] = '{0}')
                                            SELECT 1
                                            ELSE
                                            SELECT 0";

            object exists = session.ExecuteScalar(string.Format(GetChechSpSql, spName));
            if (exists != null && exists.ToString() == "0")
                session.ExecuteNonQuery(spContains);
        }
        private static string Getsp_acc_Account_Journals
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_acc_Account_Journals]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @account_id INT
AS
BEGIN
	SET NOCOUNT ON;

	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED)
	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account 
	WHERE        (acc_Account.account_id = @account_id)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	INSERT INTO @accTbl
	SELECT account_id FROM CTE1 GROUP BY account_id

	--Fill Opening Balance Table
	

	DECLARE @BeforeEntryTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT)
	;WITH CTE1 AS
	(
	SELECT acc_Opening_Balance.[account_id], SUM([debit]) AS debit, SUM([credit]) AS credit
	FROM acc_Opening_Balance INNER JOIN @accTbl accTbl ON acc_Opening_Balance.[account_id] = accTbl.[account_id]
	WHERE  year_id = @Year
	GROUP BY acc_Opening_Balance.[account_id]
	UNION
	SELECT vacc_Journal_Entry_Detail.account_id, SUM(debit) AS debit, SUM(credit) AS credit
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE vacc_Journal_Entry_Detail.year_id = @Year AND  vacc_Journal_Entry_Detail.entry_date < @StartDate
	GROUP BY vacc_Journal_Entry_Detail.account_id
	)
	INSERT INTO @BeforeEntryTbl
	SELECT @account_id, SUM(debit) AS debit, SUM(credit) AS credit
	FROM CTE1


	DECLARE @OutputTbl TABLE (debit FLOAT, credit FLOAT, entry_text NVARCHAR(100), costcenter_name NVARCHAR(100), account_name NVARCHAR(100), entry_date DATE
	, voucher_no NVARCHAR(100), factor INT, account_type_id INT, acc_nature_id INT
	, RowNumber INT NOT NULL PRIMARY KEY CLUSTERED)
	--Fill Entry Table
	;WITH CTE1 AS
	(
	SELECT vacc_Journal_Entry_Detail.debit, vacc_Journal_Entry_Detail.credit, vacc_Journal_Entry_Detail.entry_text
	, vacc_Journal_Entry_Detail.costcenter_name
	, vacc_Journal_Entry_Detail.account_name
	, vacc_Journal_Entry_Detail.entry_date, vacc_Journal_Entry_Detail.voucher_no
	, vacc_Journal_Entry_Detail.factor
	, vacc_Journal_Entry_Detail.account_type_id
	, vacc_Journal_Entry_Detail.acc_nature_id
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE  vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	UNION
	SELECT debit, credit, 'Balance Before', '-', acc_Account.account_name, @StartDate - 1, '-', acc_Nature.factor, acc_Account.account_type_id, acc_Account.acc_nature_id
	FROM @BeforeEntryTbl BeforeEntryTbl INNER JOIN dbo.acc_Account ON BeforeEntryTbl.account_id = acc_Account.account_id
	LEFT OUTER JOIN dbo.acc_Nature ON acc_Account.acc_nature_id = acc_Nature.acc_nature_id
	)
	INSERT INTO @OutputTbl
	SELECT debit, credit, entry_text, costcenter_name, account_name, entry_date, voucher_no, factor, account_type_id, acc_nature_id
	, ROW_NUMBER() OVER(ORDER BY entry_date ASC)
	FROM CTE1

	SELECT T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.factor
	, T1.debit
	, T1.credit
	, SUM(T2.credit - T2.debit) * T1.factor AS Balance
	FROM @OutputTbl T1 INNER JOIN @OutputTbl T2 ON T1.RowNumber >= T2.RowNumber
	GROUP BY T1.debit, T1.credit, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.RowNumber, T1.factor, T1.account_type_id, T1.acc_nature_id
	ORDER BY T1.RowNumber

END
";
            }
        }
        private static string Getsp_acc_Account_Journals_Currency
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_acc_Account_Journals_Currency]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @account_id INT
AS
BEGIN
	SET NOCOUNT ON;

	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED)
	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account 
	WHERE        (acc_Account.account_id = @account_id)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	INSERT INTO @accTbl
	SELECT account_id FROM CTE1 GROUP BY account_id

	--Fill Opening Balance Table
	

	DECLARE @BeforeEntryTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT, [debit_currency] FLOAT, [credit_currency] FLOAT)
	;WITH CTE1 AS
	(
	SELECT acc_Opening_Balance.[account_id], SUM([debit]) AS debit, SUM([credit]) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency
	FROM acc_Opening_Balance INNER JOIN @accTbl accTbl ON acc_Opening_Balance.[account_id] = accTbl.[account_id]
	WHERE  year_id = @Year
	GROUP BY acc_Opening_Balance.[account_id]
	UNION
	SELECT vacc_Journal_Entry_Detail.account_id, SUM(debit) AS debit, SUM(credit) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE vacc_Journal_Entry_Detail.year_id = @Year AND  vacc_Journal_Entry_Detail.entry_date < @StartDate
	GROUP BY vacc_Journal_Entry_Detail.account_id
	)
	INSERT INTO @BeforeEntryTbl
	SELECT @account_id, SUM(debit) AS debit, SUM(credit) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency
	FROM CTE1


	DECLARE @OutputTbl TABLE (debit FLOAT, credit FLOAT, debit_currency FLOAT, credit_currency FLOAT, entry_text NVARCHAR(100), costcenter_name NVARCHAR(100), account_name NVARCHAR(100), entry_date DATE
	, voucher_no NVARCHAR(100), factor INT, account_type_id INT, acc_nature_id INT
	, RowNumber INT NOT NULL PRIMARY KEY CLUSTERED)
	--Fill Entry Table
	;WITH CTE1 AS
	(
	SELECT vacc_Journal_Entry_Detail.debit, vacc_Journal_Entry_Detail.credit, vacc_Journal_Entry_Detail.debit_currency, vacc_Journal_Entry_Detail.credit_currency
	, vacc_Journal_Entry_Detail.entry_text
	, vacc_Journal_Entry_Detail.costcenter_name
	, vacc_Journal_Entry_Detail.account_name
	, vacc_Journal_Entry_Detail.entry_date, vacc_Journal_Entry_Detail.voucher_no
	, vacc_Journal_Entry_Detail.factor
	, vacc_Journal_Entry_Detail.account_type_id
	, vacc_Journal_Entry_Detail.acc_nature_id
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE  vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	UNION
	SELECT debit, credit, debit_currency, credit_currency, 'Opening ', '-', acc_Account.account_name, @StartDate - 1, '-', acc_Nature.factor, acc_Account.account_type_id, acc_Account.acc_nature_id
	FROM @BeforeEntryTbl BeforeEntryTbl INNER JOIN dbo.acc_Account ON BeforeEntryTbl.account_id = acc_Account.account_id
	LEFT OUTER JOIN dbo.acc_Nature ON acc_Account.acc_nature_id = acc_Nature.acc_nature_id
	)
	INSERT INTO @OutputTbl
	SELECT debit, credit, debit_currency, credit_currency, entry_text, costcenter_name, account_name, entry_date, voucher_no, factor, account_type_id, acc_nature_id
	, ROW_NUMBER() OVER(ORDER BY entry_date ASC)
	FROM CTE1

	SELECT T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.factor
	, T1.debit
	, T1.credit
	, SUM(T2.credit - T2.debit) * T1.factor AS Balance

	, T1.debit_currency
	, T1.credit_currency
	, SUM(T2.credit_currency - T2.debit_currency) * T1.factor AS Balance_currency

	FROM @OutputTbl T1 INNER JOIN @OutputTbl T2 ON T1.RowNumber >= T2.RowNumber
	GROUP BY T1.debit, T1.credit, T1.debit_currency, T1.credit_currency, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.RowNumber, T1.factor, T1.account_type_id, T1.acc_nature_id
	ORDER BY T1.RowNumber

END

";
            }
        }
        private static string Getsp_acc_Account_Journals_SubAcc
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_acc_Account_Journals_SubAcc]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @account_id INT
AS
BEGIN
	SET NOCOUNT ON;

	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, level_id INT)
	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account 
	WHERE        (acc_Account.parent_account_id = @account_id)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	INSERT INTO @accTbl
	SELECT account_id, Parent_Id FROM CTE1 GROUP BY account_id, Parent_Id

	--Fill Opening Balance Table
	
	DECLARE @BeforeEntryTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, level_id INT, [debit] FLOAT, [credit] FLOAT)
	;WITH CTE1 AS
	(
	SELECT acc_Opening_Balance.[account_id], SUM([debit]) AS debit, SUM([credit]) AS credit, accTbl.level_id
	FROM acc_Opening_Balance INNER JOIN @accTbl accTbl ON acc_Opening_Balance.[account_id] = accTbl.[account_id]
	WHERE  year_id = @Year
	GROUP BY acc_Opening_Balance.[account_id], accTbl.level_id
	UNION
	SELECT vacc_Journal_Entry_Detail.account_id, SUM(debit) AS debit, SUM(credit) AS credit, accTbl.level_id
	FROM dbo.vacc_Journal_Entry_Detail INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE vacc_Journal_Entry_Detail.year_id = @Year AND  vacc_Journal_Entry_Detail.entry_date < @StartDate
	GROUP BY vacc_Journal_Entry_Detail.account_id, accTbl.level_id
	)
	INSERT INTO @BeforeEntryTbl
	SELECT account_id, level_id, SUM(debit) AS debit, SUM(credit) AS credit
	FROM CTE1
	GROUP BY account_id, level_id
	

	DECLARE @OutputTbl TABLE (level_id INT, debit FLOAT, credit FLOAT, entry_text NVARCHAR(100), costcenter_name NVARCHAR(100), account_name NVARCHAR(100), entry_date DATE
	, voucher_no NVARCHAR(100), factor INT, account_type_id INT, acc_nature_id INT
	, RowNumber INT NOT NULL PRIMARY KEY CLUSTERED)
	--Fill Entry Table
	;WITH CTE1 AS
	(
	SELECT accTbl.level_id, vacc_Journal_Entry_Detail.debit, vacc_Journal_Entry_Detail.credit, vacc_Journal_Entry_Detail.entry_text
	, vacc_Journal_Entry_Detail.costcenter_name
	, acc_Account.account_name
	, vacc_Journal_Entry_Detail.entry_date, vacc_Journal_Entry_Detail.voucher_no
	, vacc_Journal_Entry_Detail.factor
	, vacc_Journal_Entry_Detail.account_type_id
	, vacc_Journal_Entry_Detail.acc_nature_id
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	INNER JOIN dbo.acc_Account ON accTbl.level_id = acc_Account.account_id
	WHERE  vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	UNION
	SELECT BeforeEntryTbl.level_id, debit, credit, 'Opening', ' - ', Parent_Account.account_name, @StartDate - 1, '-', acc_Nature.factor, acc_Account.account_type_id, acc_Account.acc_nature_id
	FROM @BeforeEntryTbl BeforeEntryTbl INNER JOIN dbo.acc_Account ON BeforeEntryTbl.account_id = acc_Account.account_id
	INNER JOIN dbo.acc_Account Parent_Account ON BeforeEntryTbl.level_id = Parent_Account.account_id
	LEFT OUTER JOIN dbo.acc_Nature ON acc_Account.acc_nature_id = acc_Nature.acc_nature_id
	)
	INSERT INTO @OutputTbl
	SELECT level_id, debit, credit, entry_text, costcenter_name, account_name, entry_date, voucher_no, factor, account_type_id, acc_nature_id
	, ROW_NUMBER() OVER(ORDER BY entry_date ASC)
	FROM CTE1

	SELECT T1.level_id, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.factor
	, T1.debit
	, T1.credit
	, SUM(T2.credit - T2.debit) * T1.factor AS Balance
	FROM @OutputTbl T1 INNER JOIN @OutputTbl T2 ON T1.RowNumber >= T2.RowNumber
	GROUP BY T1.level_id, T1.debit, T1.credit, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.RowNumber, T1.factor, T1.account_type_id, T1.acc_nature_id
	ORDER BY T1.RowNumber

END";
            }
        }
        private static string Getsp_acc_Account_Journals_SubAcc_currency
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_acc_Account_Journals_SubAcc_currency]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @account_id INT
AS
BEGIN
	SET NOCOUNT ON;

	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, level_id INT)
	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account 
	WHERE        (acc_Account.parent_account_id = @account_id)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	INSERT INTO @accTbl
	SELECT account_id, Parent_Id FROM CTE1 GROUP BY account_id, Parent_Id

	--Fill Opening Balance Table
	
	DECLARE @BeforeEntryTbl TABLE (account_id INT, level_id INT, [debit] FLOAT, [credit] FLOAT, debit_currency FLOAT, credit_currency FLOAT, currency_id INT, UNIQUE CLUSTERED(account_id, currency_id))
	;WITH CTE1 AS
	(
	SELECT acc_Opening_Balance.[account_id], SUM([debit]) AS debit, SUM([credit]) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency, acc_Opening_Balance.currency_id, accTbl.level_id
	FROM acc_Opening_Balance INNER JOIN @accTbl accTbl ON acc_Opening_Balance.[account_id] = accTbl.[account_id]
	WHERE  year_id = @Year
	GROUP BY acc_Opening_Balance.[account_id], accTbl.level_id, acc_Opening_Balance.currency_id
	UNION
	SELECT vacc_Journal_Entry_Detail.account_id, SUM(debit) AS debit, SUM(credit) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency, currency_id, accTbl.level_id
	FROM dbo.vacc_Journal_Entry_Detail INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE vacc_Journal_Entry_Detail.year_id = @Year AND  vacc_Journal_Entry_Detail.entry_date < @StartDate
	GROUP BY vacc_Journal_Entry_Detail.account_id, accTbl.level_id, currency_id
	)
	INSERT INTO @BeforeEntryTbl
	SELECT account_id, level_id, SUM(debit) AS debit, SUM(credit) AS credit, SUM(debit_currency) AS debit_currency, SUM(credit_currency) AS credit_currency, currency_id
	FROM CTE1
	GROUP BY account_id, level_id, currency_id
	

	DECLARE @OutputTbl TABLE (level_id INT, debit FLOAT, credit FLOAT, debit_currency FLOAT, credit_currency FLOAT, currency_id INT, entry_text NVARCHAR(100), costcenter_name NVARCHAR(100), account_name NVARCHAR(100), entry_date DATE
	, voucher_no NVARCHAR(100), factor INT, account_type_id INT, acc_nature_id INT
	, RowNumber INT NOT NULL PRIMARY KEY CLUSTERED)
	--Fill Entry Table
	;WITH CTE1 AS
	(
	SELECT accTbl.level_id, vacc_Journal_Entry_Detail.debit, vacc_Journal_Entry_Detail.credit
	, vacc_Journal_Entry_Detail.debit_currency, vacc_Journal_Entry_Detail.credit_currency, vacc_Journal_Entry_Detail.currency_id
	, vacc_Journal_Entry_Detail.entry_text
	, vacc_Journal_Entry_Detail.costcenter_name
	, acc_Account.account_name
	, vacc_Journal_Entry_Detail.entry_date, vacc_Journal_Entry_Detail.voucher_no
	, vacc_Journal_Entry_Detail.factor
	, vacc_Journal_Entry_Detail.account_type_id
	, vacc_Journal_Entry_Detail.acc_nature_id
	FROM dbo.vacc_Journal_Entry_Detail
	INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	INNER JOIN dbo.acc_Account ON accTbl.level_id = acc_Account.account_id
	WHERE  vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	UNION
	SELECT BeforeEntryTbl.level_id, debit, credit, debit_currency, credit_currency, currency_id, 'Opening', ' - ', Parent_Account.account_name, @StartDate - 1, '-', acc_Nature.factor, acc_Account.account_type_id, acc_Account.acc_nature_id
	FROM @BeforeEntryTbl BeforeEntryTbl INNER JOIN dbo.acc_Account ON BeforeEntryTbl.account_id = acc_Account.account_id
	INNER JOIN dbo.acc_Account Parent_Account ON BeforeEntryTbl.level_id = Parent_Account.account_id
	LEFT OUTER JOIN dbo.acc_Nature ON acc_Account.acc_nature_id = acc_Nature.acc_nature_id
	)
	INSERT INTO @OutputTbl
	SELECT level_id, debit, credit, debit_currency, credit_currency, currency_id, entry_text, costcenter_name, account_name, entry_date, voucher_no, factor, account_type_id, acc_nature_id
	, ROW_NUMBER() OVER(ORDER BY entry_date ASC)
	FROM CTE1

	SELECT T1.level_id, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.factor
	, T1.debit, T1.credit, SUM(T2.credit - T2.debit) * T1.factor AS Balance
	, T1.debit_currency, T1.credit_currency, SUM(T2.credit_currency - T2.debit_currency) * T1.factor AS Balance_currency
	,T1.currency_id
	, acc_Currency.currency_name
	FROM @OutputTbl T1 INNER JOIN @OutputTbl T2 ON T1.RowNumber >= T2.RowNumber
	LEFT OUTER JOIN dbo.acc_Currency ON T1.currency_id = acc_Currency.currency_id
	GROUP BY T1.level_id, T1.debit, T1.credit, T1.entry_text, T1.costcenter_name, T1.account_name, T1.entry_date, T1.voucher_no, T1.RowNumber, T1.factor
	, T1.account_type_id, T1.acc_nature_id, T1.debit_currency, T1.credit_currency, T1.currency_id, acc_Currency.currency_name
	ORDER BY T1.RowNumber

END";
            }
        }
        private static string Getsp_Balance_Sheet
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Balance_Sheet]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @Category INT
AS
BEGIN
	SET NOCOUNT ON;

	Declare @account_type_id INT = 2
	Declare @Liabilities INT = 2
	Declare @Equities INT = 1
	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, Parent_Id INT, NetValue FLOAT, sort INT)
	;With CTE1 AS
	(
	SELECT        acc_Account_Category_Detail.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account_Category_Detail INNER JOIN dbo.acc_Account ON acc_Account_Category_Detail.account_id = acc_Account.account_id
	WHERE        (acc_Account_Category_Detail.account_category_id = @Category) AND acc_Account.account_type_id = @account_type_id
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	WHERE acc_Account.account_type_id = @account_type_id
	)
	INSERT INTO @accTbl
	SELECT account_id, Parent_Id, 0, 0 FROM CTE1 GROUP BY account_id, Parent_Id
	
	-- Add Opening Balance Values
	UPDATE @accTbl
	SET NetValue = 
	CASE 
	WHEN acc_Account.acc_nature_id = @Equities THEN acc_Opening_Balance.debit - acc_Opening_Balance.credit
	WHEN acc_Account.acc_nature_id = @Liabilities THEN acc_Opening_Balance.credit - acc_Opening_Balance.debit
	ELSE 0 END
	FROM @accTbl accTbl INNER JOIN dbo.acc_Opening_Balance ON accTbl.account_id = acc_Opening_Balance.opening_balance_id
	INNER JOIN dbo.acc_Account ON accTbl.account_id = acc_Account.account_id
	WHERE acc_Opening_Balance.year_id = @Year
	
	--Fill Entries Values
	;WITH CTE1 AS
	(
	SELECT vacc_Journal_Entry_Detail.account_id
	, CASE 
	WHEN vacc_Journal_Entry_Detail.acc_nature_id = @Equities THEN SUM([debit] - [credit])
	WHEN vacc_Journal_Entry_Detail.acc_nature_id = @Liabilities THEN SUM([credit] - [debit]) ELSE 0 END AS NetValue
	FROM [dbo].vacc_Journal_Entry_Detail INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE  vacc_Journal_Entry_Detail.year_id = @Year AND vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	GROUP BY vacc_Journal_Entry_Detail.account_id, vacc_Journal_Entry_Detail.acc_nature_id
	)
	UPDATE  @accTbl
	SET NetValue = accTbl.NetValue + CTE1.NetValue
	FROM @accTbl accTbl INNER JOIN CTE1 ON accTbl.account_id = CTE1.account_id

	UPDATE  @accTbl
	SET sort = (SELECT top 1 appear_order FROM [dbo].[acc_Account_Category_Detail] WHERE account_category_id = @Category AND account_id = accTbl.Parent_Id ORDER BY appear_order)
	FROM @accTbl accTbl


	DECLARE @SortTbl TABLE (Parent_Id INT NOT NULL PRIMARY KEY CLUSTERED, Sort INT)
	INSERT INTO @SortTbl
	SELECT acc_Account.parent_account_id, MIN(sort)
	FROM @accTbl accTbl INNER JOIN dbo.acc_Account ON accTbl.Parent_Id = acc_Account.account_id
	WHERE acc_Account.parent_account_id IS NOT NULL
	GROUP BY acc_Account.parent_account_id


	SELECT accTbl.Parent_Id, acc_Account.account_name, SUM(NetValue) AS NetValue
	, Acc_Parent.account_name AS Parent_Name
	, accTbl.sort AS appear_order
	, SortTbl.Sort
	FROM @accTbl accTbl INNER JOIN dbo.acc_Account ON accTbl.Parent_Id = acc_Account.account_id
	LEFT OUTER JOIN dbo.acc_Account Acc_Parent ON acc_Account.parent_account_id = Acc_Parent.account_id
	LEFT OUTER JOIN @SortTbl SortTbl ON acc_Account.parent_account_id = SortTbl.Parent_Id
	GROUP BY accTbl.Parent_Id, acc_Account.account_name, acc_Account.acc_nature_id, Acc_Parent.account_name, accTbl.sort, SortTbl.Sort
	
END";
            }
        }
        private static string Getsp_Income_Statement
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Income_Statement]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @Category INT
AS
BEGIN
	SET NOCOUNT ON;

	Declare @account_type_id INT = 1
	Declare @Liabilities INT = 2
	Declare @Equities INT = 1
	--Accounts Table
	DECLARE @accTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, Parent_Id INT, NetValue FLOAT)
	;With CTE1 AS
	(
	SELECT        acc_Account_Category_Detail.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account_Category_Detail INNER JOIN dbo.acc_Account ON acc_Account_Category_Detail.account_id = acc_Account.account_id
	WHERE        (acc_Account_Category_Detail.account_category_id = @Category) AND acc_Account.account_type_id = @account_type_id
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	WHERE acc_Account.account_type_id = @account_type_id
	)
	INSERT INTO @accTbl
	SELECT account_id, Parent_Id, 0 FROM CTE1 GROUP BY account_id, Parent_Id
	
	-- Add Opening Balance Values
	UPDATE @accTbl
	SET NetValue = acc_Opening_Balance.credit - acc_Opening_Balance.debit
	FROM @accTbl accTbl INNER JOIN dbo.acc_Opening_Balance ON accTbl.account_id = acc_Opening_Balance.opening_balance_id
	INNER JOIN dbo.acc_Account ON accTbl.account_id = acc_Account.account_id
	WHERE acc_Opening_Balance.year_id = @Year
	
	--Fill Entries Values
	;WITH CTE1 AS
	(
	SELECT vacc_Journal_Entry_Detail.account_id
	, SUM([credit] - [debit]) AS NetValue
	FROM [dbo].vacc_Journal_Entry_Detail INNER JOIN @accTbl accTbl ON vacc_Journal_Entry_Detail.account_id = accTbl.account_id
	WHERE  vacc_Journal_Entry_Detail.year_id = @Year AND vacc_Journal_Entry_Detail.entry_date BETWEEN @StartDate AND @EndDate
	GROUP BY vacc_Journal_Entry_Detail.account_id, vacc_Journal_Entry_Detail.acc_nature_id
	)
	UPDATE  @accTbl
	SET NetValue = accTbl.NetValue + CTE1.NetValue
	FROM @accTbl accTbl INNER JOIN CTE1 ON accTbl.account_id = CTE1.account_id


	SELECT Parent_Id, acc_Account.account_name, SUM(NetValue) AS NetValue
	, CASE 
	WHEN acc_Account.acc_nature_id = @Equities THEN 'Revenue'
	WHEN acc_Account.acc_nature_id = @Liabilities THEN 'Expenses'
	ELSE 'Other' END AS acc_nature_name
	, (SELECT top 1 appear_order FROM [dbo].[acc_Account_Category_Detail] WHERE account_category_id = @Category AND account_id = accTbl.Parent_Id) AS appear_order
	FROM @accTbl accTbl INNER JOIN dbo.acc_Account ON accTbl.Parent_Id = acc_Account.account_id
	GROUP BY Parent_Id, acc_Account.account_name, acc_Account.acc_nature_id
	
END
";
            }
        }
        private static string Getsp_Income_Statement_fixed
        {
            get
            {
                return @"CREATE PROCEDURE [dbo].[sp_Income_Statement_fixed]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime
AS
BEGIN
	SET NOCOUNT ON;

	Declare @account_type_id INT = 1
	Declare @Liabilities INT = 2
	Declare @Equities INT = 1
	

	DECLARE @Eradat FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2084'))

	DECLARE @KhasmMasmohBeeh FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2089'))

	DECLARE @EradatMotanaweaa FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '57'))
	DECLARE @EradatOmla FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2087')) --New

	DECLARE @TaklefetAshabAamal FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '44'))
	DECLARE @TaklefitElEradat FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2085'))
	DECLARE @TaklefitOmla FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2088'))

	DECLARE @ElmasrofatElomeia FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '33'))

	DECLARE @Eihlakat FLOAT = (SELECT dbo.fn_GetNetValue(@Year, @StartDate, @EndDate, '2086'))

	SELECT 
	@Eradat AS Eradat
	, CASE WHEN @KhasmMasmohBeeh IS NULL THEN 0 ELSE @KhasmMasmohBeeh END AS KhasmMasmohBeeh
	, CASE WHEN @EradatMotanaweaa IS NULL THEN 0 ELSE @EradatMotanaweaa END AS EradatMotanaweaa
	, CASE WHEN @EradatOmla IS NULL THEN 0 ELSE @EradatOmla END AS EradatOmla
	, CASE WHEN @TaklefetAshabAamal IS NULL THEN 0 ELSE @TaklefetAshabAamal END AS TaklefetAshabAamal
	, CASE WHEN @TaklefitElEradat IS NULL THEN 0 ELSE @TaklefitElEradat END AS TaklefitElEradat
	, CASE WHEN @TaklefitOmla IS NULL THEN 0 ELSE @TaklefitOmla END AS TaklefitOmla
	, CASE WHEN @ElmasrofatElomeia IS NULL THEN 0 ELSE @ElmasrofatElomeia END AS ElmasrofatElomeia
	, CASE WHEN @Eihlakat IS NULL THEN 0 ELSE @Eihlakat END AS Eihlakat
	
END
";
            }
        }
        private static string GetspTrialBalanceSql {
            get { return @"CREATE PROCEDURE [dbo].[sp_Trial_Balance]
	 @Year INT,
	 @StartDate Datetime,
	 @EndDate Datetime,
	 @Category INT
AS
BEGIN
	SET NOCOUNT ON;

	--Fill Entry Table
	DECLARE @EntryTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT)
	INSERT INTO @EntryTbl
	SELECT [account_id], SUM([debit]), SUM([credit]) FROM [dbo].[acc_Journal_Entry_Detail] INNER JOIN [dbo].[acc_Journal_Entry] ON [acc_Journal_Entry_Detail].jour_entry_id = [acc_Journal_Entry].jour_entry_id
	INNER JOIN dbo.acc_Period ON [acc_Journal_Entry].period_id = acc_Period.period_id
	WHERE  acc_Period.year_id = @Year AND [acc_Journal_Entry].entry_date BETWEEN @StartDate AND @EndDate
	AND [acc_Journal_Entry].closed = 1
	GROUP BY [account_id]

	--Fill Opening Balance Table
	DECLARE @OBTbl TABLE (account_id INT NOT NULL PRIMARY KEY CLUSTERED, [debit] FLOAT, [credit] FLOAT)
	INSERT INTO @OBTbl
	SELECT [account_id], SUM([debit]), SUM([credit]) FROM acc_Opening_Balance
	WHERE  year_id = @Year
	GROUP BY [account_id]

	;With CTE1 AS
	(
	SELECT        acc_Account.account_id, acc_Account.account_id AS Parent_Id
	FROM     acc_Account INNER JOIN acc_Account_Category_Detail ON acc_Account.account_id = acc_Account_Category_Detail.account_id 
	INNER JOIN acc_Account_Category ON acc_Account_Category_Detail.account_category_id = acc_Account_Category.account_category_id
	WHERE        (acc_Account_Category.account_category_id = @Category)
	UNION ALL
	SELECT acc_Account.account_id, CTE1.Parent_Id
	FROM	acc_Account INNER JOIN CTE1 ON acc_Account.parent_account_id = CTE1.account_id
	)
	SELECT CTE1.Parent_Id, acc_Account.account_name, ISNULL(SUM(EntryTbl.[debit]), 0) AS Entry_debit, ISNULL(SUM(EntryTbl.[credit]), 0) AS Entry_credit
	, ISNULL(SUM(OBTbl.[debit]), 0) AS OB_debit, ISNULL(SUM(OBTbl.[credit]), 0) AS OB_credit
	, (SELECT top 1 appear_order FROM [dbo].[acc_Account_Category_Detail] WHERE account_category_id = @Category AND account_id = CTE1.Parent_Id) AS appear_order
	FROM CTE1 LEFT OUTER JOIN @EntryTbl EntryTbl ON CTE1.account_id = EntryTbl.account_id
	LEFT OUTER JOIN @OBTbl OBTbl ON CTE1.account_id = OBTbl.account_id
	INNER JOIN acc_Account ON CTE1.Parent_Id = acc_Account.account_id
	GROUP BY acc_Account.account_name, CTE1.Parent_Id
END";
            }
        }
        #endregion
        #region InsertDefaultData
        private void InsertDefaultData()
        {
            acc_Account_Type_Data();
            acc_Nature_Data();
            acc_Option_Data();
        }
        private void acc_Account_Type_Data()
        {
            acc_Account_Type record1 = ObjectSpace.FindObject<acc_Account_Type>(new BinaryOperator("account_type_id", 1));
            if (record1 == null)
            {
                record1 = ObjectSpace.CreateObject<acc_Account_Type>();
                record1.account_type_id = 1;
                record1.account_type_name = "Income Statement - قائمة الدخل";
            }
            acc_Account_Type record2 = ObjectSpace.FindObject<acc_Account_Type>(new BinaryOperator("account_type_id", 2));
            if (record2 == null)
            {
                record2 = ObjectSpace.CreateObject<acc_Account_Type>();
                record2.account_type_id = 2;
                record2.account_type_name = "Balance Sheet - المركز المالي";
            }
        }
        private void acc_Nature_Data()
        {
            acc_Nature record1 = ObjectSpace.FindObject<acc_Nature>(new BinaryOperator("acc_nature_id", 1));
            if (record1 == null)
            {
                record1 = ObjectSpace.CreateObject<acc_Nature>();
                record1.acc_nature_id = 1;
                record1.acc_nature_name = "Equities";
                record1.factor = -1;
            }
            acc_Nature record2 = ObjectSpace.FindObject<acc_Nature>(new BinaryOperator("acc_nature_id", 2));
            if (record2 == null)
            {
                record2 = ObjectSpace.CreateObject<acc_Nature>();
                record2.acc_nature_id = 2;
                record2.acc_nature_name = "Liabilities";
                record2.factor = 1;
            }
        }
        private void acc_Option_Data()
        {
            acc_Option record1 = ObjectSpace.FindObject<acc_Option>(new BinaryOperator("acc_option_name", "Advance Revenue"));
            if (record1 == null)
            {
                record1 = ObjectSpace.CreateObject<acc_Option>();
                record1.acc_option_name = "Advance Revenue";
                record1.acc_option_value = "0";
            }
            acc_Option record2 = ObjectSpace.FindObject<acc_Option>(new BinaryOperator("acc_option_name", "Cash"));
            if (record2 == null)
            {
                record2 = ObjectSpace.CreateObject<acc_Option>();
                record2.acc_option_name = "Cash";
                record2.acc_option_value = "0";
            }
            acc_Option record3 = ObjectSpace.FindObject<acc_Option>(new BinaryOperator("acc_option_name", "Customers"));
            if (record3 == null)
            {
                record3 = ObjectSpace.CreateObject<acc_Option>();
                record3.acc_option_name = "Customers";
                record3.acc_option_value = "0";
            }
            acc_Option record4 = ObjectSpace.FindObject<acc_Option>(new BinaryOperator("acc_option_name", "Document Revenue"));
            if (record4 == null)
            {
                record4 = ObjectSpace.CreateObject<acc_Option>();
                record4.acc_option_name = "Document Revenue";
                record4.acc_option_value = "0";
            }
            acc_Option record5 = ObjectSpace.FindObject<acc_Option>(new BinaryOperator("acc_option_name", "Revenue Due"));
            if (record5 == null)
            {
                record5 = ObjectSpace.CreateObject<acc_Option>();
                record5.acc_option_name = "Revenue Due";
                record5.acc_option_value = "0";
            }
        }
        #endregion
        public override void UpdateDatabaseBeforeUpdateSchema() {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
    }
}
