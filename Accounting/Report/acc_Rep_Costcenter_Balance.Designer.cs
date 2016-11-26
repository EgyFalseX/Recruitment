namespace Accounting.Report
{
    partial class acc_Rep_Costcenter_Balance
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
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell10 = new DevExpress.XtraReports.UI.XRTableCell();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrTable4 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell31 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellFrom = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell32 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCellTo = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrpbLogo = new DevExpress.XtraReports.UI.XRPictureBox();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrPageInfoUser = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfoPage = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrPageInfoDate = new DevExpress.XtraReports.UI.XRPageInfo();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell12 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.calcTotal = new DevExpress.XtraReports.UI.CalculatedField();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.dsCompany = new DevExpress.Persistent.Base.ReportsV2.CollectionDataSource();
            this.dsMain = new DevExpress.Persistent.Base.ReportsV2.CollectionDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTable2
            // 
            this.xrTable2.BorderColor = System.Drawing.Color.Gray;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.BorderWidth = 0.5F;
            this.xrTable2.Dpi = 100F;
            this.xrTable2.ForeColor = System.Drawing.Color.Maroon;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(2.384186E-05F, 0F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(750F, 25F);
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseBorderWidth = false;
            this.xrTable2.StylePriority.UseForeColor = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell9,
            this.xrTableCell10});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "calcTotal")});
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseTextAlignment = false;
            xrSummary1.FormatString = "{0:#,#.##}";
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.xrTableCell9.Summary = xrSummary1;
            this.xrTableCell9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell9.Weight = 1.9545431253175551D;
            // 
            // xrTableCell10
            // 
            this.xrTableCell10.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "costcenter_id.costcenter_name")});
            this.xrTableCell10.Dpi = 100F;
            this.xrTableCell10.Name = "xrTableCell10";
            this.xrTableCell10.StylePriority.UseTextAlignment = false;
            this.xrTableCell10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell10.Weight = 1.4295717735938598D;
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
            this.BottomMargin.HeightF = 14.49998F;
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
            this.ReportHeader.HeightF = 153.6667F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrTable4
            // 
            this.xrTable4.Dpi = 100F;
            this.xrTable4.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.xrTable4.LocationFloat = new DevExpress.Utils.PointFloat(0F, 110F);
            this.xrTable4.Name = "xrTable4";
            this.xrTable4.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.xrTable4.SizeF = new System.Drawing.SizeF(400F, 25F);
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
            // xrLabel2
            // 
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(275F, 75F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(211.4583F, 23F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Cost Center Balance";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrLabel1
            // 
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.dsCompany, "company_name")});
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(513.5417F, 10.00001F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(226.4583F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "xrLabel1";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // xrpbLogo
            // 
            this.xrpbLogo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Image", this.dsCompany, "company_logo")});
            this.xrpbLogo.Dpi = 100F;
            this.xrpbLogo.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrpbLogo.Name = "xrpbLogo";
            this.xrpbLogo.SizeF = new System.Drawing.SizeF(96F, 96F);
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfoUser,
            this.xrPageInfoPage,
            this.xrPageInfoDate,
            this.xrTable3});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 135.5F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrPageInfoUser
            // 
            this.xrPageInfoUser.Dpi = 100F;
            this.xrPageInfoUser.Format = "Login:{0}";
            this.xrPageInfoUser.LocationFloat = new DevExpress.Utils.PointFloat(0F, 89.49995F);
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
            this.xrPageInfoPage.LocationFloat = new DevExpress.Utils.PointFloat(649.9999F, 112.5F);
            this.xrPageInfoPage.Name = "xrPageInfoPage";
            this.xrPageInfoPage.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoPage.SizeF = new System.Drawing.SizeF(100F, 23.00001F);
            this.xrPageInfoPage.StylePriority.UseTextAlignment = false;
            this.xrPageInfoPage.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfoDate
            // 
            this.xrPageInfoDate.Dpi = 100F;
            this.xrPageInfoDate.LocationFloat = new DevExpress.Utils.PointFloat(0F, 112.5F);
            this.xrPageInfoDate.Name = "xrPageInfoDate";
            this.xrPageInfoDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfoDate.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfoDate.SizeF = new System.Drawing.SizeF(261.4583F, 23.00001F);
            this.xrPageInfoDate.StylePriority.UseTextAlignment = false;
            this.xrPageInfoDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrTable3
            // 
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 100F;
            this.xrTable3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.xrTable3.ForeColor = System.Drawing.Color.Maroon;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3});
            this.xrTable3.SizeF = new System.Drawing.SizeF(750F, 25F);
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseForeColor = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell12,
            this.xrTableCell21});
            this.xrTableRow3.Dpi = 100F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell12
            // 
            this.xrTableCell12.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "calcTotal")});
            this.xrTableCell12.Dpi = 100F;
            this.xrTableCell12.Name = "xrTableCell12";
            this.xrTableCell12.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#.##}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.xrTableCell12.Summary = xrSummary2;
            this.xrTableCell12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell12.Weight = 1.9545427980108219D;
            // 
            // xrTableCell21
            // 
            this.xrTableCell21.Dpi = 100F;
            this.xrTableCell21.Name = "xrTableCell21";
            this.xrTableCell21.StylePriority.UseTextAlignment = false;
            this.xrTableCell21.Text = "الاجمالي";
            this.xrTableCell21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell21.Weight = 1.4295717060118918D;
            // 
            // calcTotal
            // 
            this.calcTotal.Expression = "[credit] - [debit]";
            this.calcTotal.Name = "calcTotal";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("costcenter_id.costcenter_name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.HeightF = 25F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // dsCompany
            // 
            this.dsCompany.Name = "dsCompany";
            this.dsCompany.ObjectTypeName = "Accounting.BusinessObjects.Recruitment.vacc_AppCompany";
            this.dsCompany.TopReturnedRecords = 0;
            // 
            // dsMain
            // 
            this.dsMain.Name = "dsMain";
            this.dsMain.ObjectTypeName = "Accounting.BusinessObjects.Recruitment.acc_Journal_Entry_Detail";
            this.dsMain.TopReturnedRecords = 0;
            // 
            // acc_Rep_Costcenter_Balance
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeader,
            this.ReportFooter,
            this.GroupHeader1});
            this.Bookmark = "Report";
            this.CalculatedFields.AddRange(new DevExpress.XtraReports.UI.CalculatedField[] {
            this.calcTotal});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.dsMain,
            this.dsCompany});
            this.DataSource = this.dsMain;
            this.DisplayName = "Report";
            this.Margins = new System.Drawing.Printing.Margins(51, 49, 8, 14);
            this.Version = "16.1";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.acc_Rep_Trial_Balance_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMain)).EndInit();
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
        private DevExpress.XtraReports.UI.XRTable xrTable2;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell9;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell10;
        private DevExpress.XtraReports.UI.CalculatedField calcTotal;
        private DevExpress.XtraReports.UI.XRTable xrTable3;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow3;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell12;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell21;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoUser;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoPage;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfoDate;
        private DevExpress.XtraReports.UI.XRTable xrTable4;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell31;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellFrom;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCell32;
        private DevExpress.XtraReports.UI.XRTableCell xrTableCellTo;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
    }
}
