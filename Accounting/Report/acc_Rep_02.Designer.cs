namespace Accounting.Report
{
    partial class acc_Rep_02
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPivotGrid1 = new DevExpress.XtraReports.UI.XRPivotGrid();
            this.dsMain = new DevExpress.Persistent.Base.ReportsV2.CollectionDataSource();
            this.fieldaccountcode1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldaccountname1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldcostcentername1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldentrydate1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.fieldValue1 = new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellFrom = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow8 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell27 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellAccount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.dsCompany = new DevExpress.Persistent.Base.ReportsV2.CollectionDataSource();
            this.xrpbLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrPageInfoUser = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfoPage = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfoDate = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 8.333333F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPivotGrid1
            // 
            this.xrPivotGrid1.DataSource = this.dsMain;
            this.xrPivotGrid1.Dpi = 100F;
            this.xrPivotGrid1.Fields.AddRange(new DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField[] {
            this.fieldaccountcode1,
            this.fieldaccountname1,
            this.fieldcostcentername1,
            this.fieldentrydate1,
            this.fieldValue1});
            this.xrPivotGrid1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPivotGrid1.Name = "xrPivotGrid1";
            this.xrPivotGrid1.OptionsPrint.FilterSeparatorBarPadding = 3;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotalHeader = false;
            this.xrPivotGrid1.OptionsView.ShowColumnGrandTotals = false;
            this.xrPivotGrid1.OptionsView.ShowColumnHeaders = false;
            this.xrPivotGrid1.OptionsView.ShowDataHeaders = false;
            this.xrPivotGrid1.SizeF = new System.Drawing.SizeF(1104F, 50F);
            // 
            // dsMain
            // 
            this.dsMain.Name = "dsMain";
            this.dsMain.ObjectTypeName = "Accounting.BusinessObjects.Recruitment.sp_acc_02Result";
            this.dsMain.TopReturnedRecords = 0;
            // 
            // fieldaccountcode1
            // 
            this.fieldaccountcode1.AreaIndex = 0;
            this.fieldaccountcode1.Caption = "كود الحساب";
            this.fieldaccountcode1.FieldName = "account_code";
            this.fieldaccountcode1.Name = "fieldaccountcode1";
            // 
            // fieldaccountname1
            // 
            this.fieldaccountname1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldaccountname1.AreaIndex = 0;
            this.fieldaccountname1.Caption = "الحساب";
            this.fieldaccountname1.FieldName = "account_name";
            this.fieldaccountname1.Name = "fieldaccountname1";
            // 
            // fieldcostcentername1
            // 
            this.fieldcostcentername1.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea;
            this.fieldcostcentername1.AreaIndex = 0;
            this.fieldcostcentername1.Caption = "مركز التكلفة";
            this.fieldcostcentername1.FieldName = "costcenter_name";
            this.fieldcostcentername1.Name = "fieldcostcentername1";
            // 
            // fieldentrydate1
            // 
            this.fieldentrydate1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
            this.fieldentrydate1.AreaIndex = 1;
            this.fieldentrydate1.Caption = "التاريخ";
            this.fieldentrydate1.FieldName = "entry_date";
            this.fieldentrydate1.Name = "fieldentrydate1";
            this.fieldentrydate1.ValueFormat.FormatString = "dd/MM/yyyy";
            this.fieldentrydate1.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            // 
            // fieldValue1
            // 
            this.fieldValue1.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea;
            this.fieldValue1.AreaIndex = 0;
            this.fieldValue1.Caption = "القيمة";
            this.fieldValue1.FieldName = "Value";
            this.fieldValue1.Name = "fieldValue1";
            this.fieldValue1.ValueFormat.FormatString = "n2";
            this.fieldValue1.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 8F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 19F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable4,
            this.xrLabel2,
            this.xrLabel1,
            this.xrpbLogo});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 180.7501F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 100F;
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7,
            this.xrTableRow8});
            this.xrTable4.SizeF = new System.Drawing.SizeF(400F, 50F);
            this.xrTable4.StylePriority.UseFont = false;
            this.xrTable4.StylePriority.UseTextAlignment = false;
            this.xrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell31,
            this.xrTableCellFrom,
            this.xrTableCell32,
            this.xrTableCellTo});
            this.xrTableRow7.Dpi = 100F;
            this.xrTableRow7.Name = "xrTableRow7";
            this.xrTableRow7.Weight = 1D;
            // 
            // xrTableCell31
            // 
            this.xrTableCell31.Dpi = 100F;
            this.xrTableCell31.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell31.Name = "xrTableCell31";
            this.xrTableCell31.StylePriority.UseFont = false;
            this.xrTableCell31.Text = "From Date:";
            this.xrTableCell31.Weight = 1D;
            // 
            // xrTableCellFrom
            // 
            this.xrTableCellFrom.Dpi = 100F;
            this.xrTableCellFrom.ForeColor = System.Drawing.Color.DimGray;
            this.xrTableCellFrom.Name = "xrTableCellFrom";
            this.xrTableCellFrom.StylePriority.UseForeColor = false;
            this.xrTableCellFrom.Weight = 0.8541665649414063D;
            // 
            // xrTableCell32
            // 
            this.xrTableCell32.Dpi = 100F;
            this.xrTableCell32.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell32.Name = "xrTableCell32";
            this.xrTableCell32.StylePriority.UseFont = false;
            this.xrTableCell32.Text = "To Date:";
            this.xrTableCell32.Weight = 0.7604165649414063D;
            // 
            // xrTableCellTo
            // 
            this.xrTableCellTo.Dpi = 100F;
            this.xrTableCellTo.ForeColor = System.Drawing.Color.DimGray;
            this.xrTableCellTo.Name = "xrTableCellTo";
            this.xrTableCellTo.StylePriority.UseForeColor = false;
            this.xrTableCellTo.Weight = 1.3854168701171874D;
            // 
            // xrTableRow8
            // 
            this.xrTableRow8.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell27,
            this.xrTableCellAccount});
            this.xrTableRow8.Dpi = 100F;
            this.xrTableRow8.Name = "xrTableRow8";
            this.xrTableRow8.Weight = 1D;
            // 
            // xrTableCell27
            // 
            this.xrTableCell27.Dpi = 100F;
            this.xrTableCell27.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold);
            this.xrTableCell27.Name = "xrTableCell27";
            this.xrTableCell27.StylePriority.UseFont = false;
            this.xrTableCell27.Text = "Account:";
            this.xrTableCell27.Weight = 1D;
            // 
            // xrTableCellAccount
            // 
            this.xrTableCellAccount.Dpi = 100F;
            this.xrTableCellAccount.ForeColor = System.Drawing.Color.DimGray;
            this.xrTableCellAccount.Name = "xrTableCellAccount";
            this.xrTableCellAccount.StylePriority.UseForeColor = false;
            this.xrTableCellAccount.Weight = 3D;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(450F, 75F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(211.4583F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Account Balance";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsCompany, "company_name")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(867.5417F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(226.4583F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // dsCompany
            // 
            this.dsCompany.Name = "dsCompany";
            this.dsCompany.ObjectTypeName = "Accounting.BusinessObjects.Recruitment.acc_AppCompany";
            this.dsCompany.TopReturnedRecords = 0;
            // 
            // xrpbLogo
            // 
            this.xrpbLogo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", this.dsCompany, "company_logo")});
            this.xrpbLogo.Dpi = 100F;
            this.xrpbLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrpbLogo.Name = "xrpbLogo";
            this.xrpbLogo.SizeF = new System.Drawing.SizeF(96F, 96F);
            this.xrpbLogo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1,
            this.xrPageInfoUser,
            this.xrPageInfoPage,
            this.xrPageInfoDate});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 108.7083F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTable1
            // 
            this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable1.Dpi = 100F;
            this.xrTable1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(390.1667F, 10.00001F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(298.9583F, 24.99997F);
            this.xrTable1.StylePriority.UseBorders = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // xrTableCell1
            // 
            this.xrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Value")});
            this.xrTableCell1.Dpi = 100F;
            this.xrTableCell1.Name = "xrTableCell1";
            this.xrTableCell1.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#.##}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell1.Summary = xrSummary1;
            this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell1.Weight = 1.641114722577488D;
            // 
            // xrTableCell2
            // 
            this.xrTableCell2.Dpi = 100F;
            this.xrTableCell2.Name = "xrTableCell2";
            this.xrTableCell2.Text = ":الصافي";
            this.xrTableCell2.Weight = 0.35888527742251208D;
            // 
            // xrPageInfoUser
            // 
            this.xrPageInfoUser.Dpi = 100F;
            this.xrPageInfoUser.Format = "Login:{0}";
            this.xrPageInfoUser.LocationFloat = new DevExpress.Utils.PointFloat(0F, 62.70828F);
            this.xrPageInfoUser.Name = "xrPageInfoUser";
            this.xrPageInfoUser.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoUser.PageInfo = DevExpress.XtraPrinting.PageInfo.UserName;
            this.xrPageInfoUser.SizeF = new System.Drawing.SizeF(261.4583F, 23.00001F);
            this.xrPageInfoUser.StylePriority.UseTextAlignment = false;
            this.xrPageInfoUser.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrPageInfoPage
            // 
            this.xrPageInfoPage.Dpi = 100F;
            this.xrPageInfoPage.LocationFloat = new DevExpress.Utils.PointFloat(994F, 85.7083F);
            this.xrPageInfoPage.Name = "xrPageInfoPage";
            this.xrPageInfoPage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoPage.SizeF = new System.Drawing.SizeF(100F, 23.00001F);
            this.xrPageInfoPage.StylePriority.UseTextAlignment = false;
            this.xrPageInfoPage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfoDate
            // 
            this.xrPageInfoDate.Dpi = 100F;
            this.xrPageInfoDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 85.7083F);
            this.xrPageInfoDate.Name = "xrPageInfoDate";
            this.xrPageInfoDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoDate.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfoDate.SizeF = new System.Drawing.SizeF(261.4583F, 23.00001F);
            this.xrPageInfoDate.StylePriority.UseTextAlignment = false;
            this.xrPageInfoDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPivotGrid1});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 50F;
            this.PageHeader.Name = "PageHeader";
            // 
            // acc_Rep_02
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.PageHeader});
            this.Bookmark = "Report";
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsMain,
            this.dsCompany});
            this.DataSource = this.dsMain;
            this.DisplayName = "Report";
            this.Landscape = true;
            this.Margins = new System.Drawing.Printing.Margins(39, 26, 8, 19);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "16.1";
            this.VerticalContentSplitting = DevExpress.XtraPrinting.VerticalContentSplitting.Smart;
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.acc_Rep_02_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        protected DevExpress.Persistent.Base.ReportsV2.CollectionDataSource dsMain;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        protected DevExpress.Persistent.Base.ReportsV2.CollectionDataSource dsCompany;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox xrpbLogo;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoUser;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoPage;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoDate;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellFrom;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTo;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow8;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell27;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellAccount;
        private DevExpress.XtraReports.UI.XRPivotGrid xrPivotGrid1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldaccountname1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldentrydate1;
        private DevExpress.XtraReports.UI.XRTable xrTable1;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldaccountcode1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldcostcentername1;
        private DevExpress.XtraReports.UI.PivotGrid.XRPivotGridField fieldValue1;
    }
}
