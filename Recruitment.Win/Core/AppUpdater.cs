using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Recruitment.Module.BusinessObjects.Recruitment;
using DevExpress.XtraSplashScreen;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Xpo;

namespace Recruitment.Win.Core
{
    public static class AppUpdater
    {
        public static string updatePath = Application.StartupPath + @"\zUpdateObject.exe";
        public static string updaterPath = Application.StartupPath + @"\Updater.exe";
        public static string AppPath = Application.StartupPath + @"\" + Application.ProductName + ".exe";
        public static Char SplitChar = Convert.ToChar("|");
        public enum UpdaterArgsEnum
        {
            Upload = 1,
            Download = 2
        }

        public static void PerformChangeExe()
        {
            if (updatePath == Application.ExecutablePath)
            {
                byte[] data = File.ReadAllBytes(Application.ExecutablePath);
                FileStream fs = File.Create(AppPath);
                fs.Write(data, 0, data.Length);
                fs.Close();
                System.Diagnostics.Process.Start(AppPath);
                System.Diagnostics.Process.GetCurrentProcess().Kill();
                return;
            }
        }
        public static Int64 GetServerVersion(WinApplication app)
        {
            string filename = Application.ProductName + ".exe";

            IObjectSpace objSpc = app.CreateObjectSpace();
            XafDataView ServerFiles = (XafDataView)objSpc.CreateDataView(typeof(AppDependenceFile), "FileVersion", new DevExpress.Data.Filtering.BinaryOperator("FileName", filename), null);
            if (ServerFiles == null || ServerFiles.Count != 1)
                return -1;
            return (Int64)ServerFiles[0]["FileVersion"];
        }
        public static Dictionary<string, Int64> GetCurrentAssemblyFiles()
        {
            Dictionary<string, Int64> Asm = new Dictionary<string, Int64>();
            
            Asm.Add("DevExpress.BonusSkins.v16.1.dll", 16160);
            Asm.Add("DevExpress.Charts.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.CodeParser.v16.1.dll", 16160);
            Asm.Add("DevExpress.Data.v16.1.dll", 16160);
            Asm.Add("DevExpress.DataAccess.v16.1.dll", 16160);
            Asm.Add("DevExpress.DataAccess.v16.1.UI.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.AuditTrail.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Chart.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Chart.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.CloneObject.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ConditionalAppearance.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.FileAttachment.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.HtmlPropertyEditor.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Images.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Kpi.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Notifications.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Notifications.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Objects.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.PivotChart.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.PivotChart.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.PivotGrid.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.PivotGrid.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Reports.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ReportsV2.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ReportsV2.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Scheduler.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Scheduler.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ScriptRecorder.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ScriptRecorder.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Security.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Security.Xpo.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.StateMachine.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.TreeListEditors.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.TreeListEditors.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Validation.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Validation.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.ViewVariantsModule.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Workflow.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Workflow.Win.v16.1.dll", 16160);
            Asm.Add("DevExpress.ExpressApp.Xpo.v16.1.dll", 16160);
            Asm.Add("DevExpress.Office.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.Pdf.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.Pdf.v16.1.Drawing.dll", 16160);
            Asm.Add("DevExpress.Persistent.Base.v16.1.dll", 16160);
            Asm.Add("DevExpress.Persistent.BaseImpl.EF.v16.1.dll", 16160);
            Asm.Add("DevExpress.Persistent.BaseImpl.v16.1.dll", 16160);
            Asm.Add("DevExpress.PivotGrid.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.Printing.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.RichEdit.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.Sparkline.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.Utils.v16.1.dll", 16160);
            Asm.Add("DevExpress.Utils.v16.1.UI.dll", 16160);
            Asm.Add("DevExpress.Workflow.Activities.v16.1.dll", 16160);
            Asm.Add("DevExpress.Workflow.Activities.v16.1.Design.dll", 16160);
            Asm.Add("DevExpress.Xpo.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraBars.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraCharts.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraCharts.v16.1.Extensions.dll", 16160);
            Asm.Add("DevExpress.XtraCharts.v16.1.UI.dll", 16160);
            Asm.Add("DevExpress.XtraCharts.v16.1.Wizard.dll", 16160);
            Asm.Add("DevExpress.XtraEditors.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraGauges.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.XtraGrid.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraLayout.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraNavBar.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraPivotGrid.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraPrinting.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraReports.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraReports.v16.1.Extensions.dll", 16160);
            Asm.Add("DevExpress.XtraRichEdit.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraScheduler.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraScheduler.v16.1.Core.dll", 16160);
            Asm.Add("DevExpress.XtraTreeList.v16.1.dll", 16160);
            Asm.Add("DevExpress.XtraVerticalGrid.v16.1.dll", 16160);
            //Asm.Add("Recruitment.Module.dll", 10594322305);
            //Asm.Add("Recruitment.Module.Win.dll", 10594322473);
            //Asm.Add("Accounting.dll", 10594322473);
            Asm.Add("FXFW.dll", 1005);
            Asm.Add(Application.ProductName + ".exe", Convert.ToInt64(Application.ProductVersion.Replace(".", "")));

            //Asm.Add("Ionic.Zip.dll", 1918);
            //Asm.Add("log4net.dll", 12110);
            return Asm;
        }
        public static Dictionary<string, Int64> GetDeletedAssemblyFiles()
        {
            Dictionary<string, Int64> Asm = new Dictionary<string, Int64>();
            //Asm.Add("DevExpress.BonusSkins.v16.1.dll", 15250);
            return Asm;
        }
        public static Dictionary<string, Int64> GetUploadDependanceies(WinApplication app)
        {
            //XafDataView dataView = (XafDataView)objSpc.CreateDataView(typeof(AppDependenceFile), "ID;Name;Sales.Sum([Count] * Price)", null, null);
            IObjectSpace objSpc = app.CreateObjectSpace();
            XafDataView ServerFiles = (XafDataView)objSpc.CreateDataView(typeof(AppDependenceFile), "FileName;FileVersion", null, null);
            Dictionary<string, Int64> NeededFiles = new Dictionary<string, Int64>();
            Dictionary<string, Int64> LocalFiles = GetCurrentAssemblyFiles();
            foreach (KeyValuePair<string, Int64> item in LocalFiles)
            {
                DevExpress.ExpressApp.Xpo.XpoDataViewRecord found = null;
                for (int i = 0; i < ServerFiles.Count; i++)
                {
                    DevExpress.ExpressApp.Xpo.XpoDataViewRecord serverfile = (DevExpress.ExpressApp.Xpo.XpoDataViewRecord)ServerFiles[i];
                    if (item.Key == serverfile["FileName"].ToString())
                        found = serverfile;
                }
                if (found == null)
                    NeededFiles.Add(item.Key, item.Value);
                else
                {
                    if (Convert.ToInt64(item.Value) > Convert.ToInt64(found["FileVersion"]))
                        NeededFiles.Add(item.Key, item.Value);
                }
            }
            return NeededFiles;
        }
        public static Dictionary<string, Int64> GetDownloadDependanceies(WinApplication app)
        {
            XafDataView ServerFiles = (XafDataView)app.CreateObjectSpace().CreateDataView(typeof(AppDependenceFile), "FileName;FileVersion", null, null);
            Dictionary<string, Int64> Downloadiles = new Dictionary<string, Int64>();
            Dictionary<string, Int64> LocalFiles = GetCurrentAssemblyFiles();
            for (int i = (ServerFiles.Count - 1); i >= 0; i--)
            {
                Int64 Version = 0;
                if (LocalFiles.TryGetValue(ServerFiles[i]["FileName"].ToString(), out Version))
                {
                    if ((Int64)ServerFiles[i]["FileVersion"] > Version)
                        Downloadiles.Add((string)ServerFiles[i]["FileName"], (Int64)ServerFiles[i]["FileVersion"]);
                }
            }
            return Downloadiles;
        }
        public static void PerformUpdaterDownload(Dictionary<string, Int64> Files, WinApplication app)
        {
            if (Files.Count == 0)// No Update Found
                return;
            //string Data = String.Format("{0}|{1}|", (int)UpdaterArgsEnum.Download, FXFW.SqlDB.SqlConStr);
            //foreach (KeyValuePair<string, Int64> item in Files)
            //{
            //    Data += item.Key + "|";
            //}
            //Data = Data.Substring(0, Data.Length - 1);

            //Data = String.Format("\"{0}\"", Data);
            //using (System.Diagnostics.Process process = new System.Diagnostics.Process() { StartInfo = new System.Diagnostics.ProcessStartInfo(updaterPath, Data) })
            //{
            //    process.Start();
            //}
            //System.Diagnostics.Process.GetCurrentProcess().Kill();

            IObjectSpace objSpc = app.CreateObjectSpace();

            foreach (KeyValuePair<string, Int64> item in Files)
            {
                if (SplashScreenManager.Default.IsSplashFormVisible)
                    SplashScreenManager.Default.SetWaitFormCaption("Downloading " + item.Key + "  ...");

                string filename = Application.StartupPath + "\\" + item.Key;
                AppDependenceFile obj = objSpc.GetObjectByKey<AppDependenceFile>(item.Key);

                if (File.Exists(filename))
                    File.Delete(filename);
                FileStream fs = new FileStream(filename, FileMode.CreateNew);
                fs.Write(obj.FileData, 0, obj.FileData.Length);
                fs.Close();
            }

        }
        public static void PerformUpdaterUpload(Dictionary<string, Int64> FilesList, WinApplication app)
        {
            IObjectSpace objSpc = app.CreateObjectSpace();
            DevExpress.Xpo.Session session = ((XPObjectSpace)objSpc).Session;
            foreach (KeyValuePair<string, Int64> item in FilesList)
            {
                if (SplashScreenManager.Default.IsSplashFormVisible)
                    SplashScreenManager.Default.SetWaitFormCaption("Uploading " + item.Key + "  ...");
                //delete recored
                XafDataView ServerFiles = (XafDataView)objSpc.CreateDataView(typeof(AppDependenceFile), "FileName;FileVersion", new DevExpress.Data.Filtering.BinaryOperator("FileName", item.Key), null);
                session.Delete<AppDependenceFile>(DevExpress.Data.Filtering.CriteriaOperator.Parse("FileName == '" + item.Key + "'"));
                session.CommitTransaction();
                //insert recored
                AppDependenceFile obj = objSpc.CreateObject<AppDependenceFile>();
                obj.FileName = item.Key; obj.FileVersion = item.Value;
                obj.FileData = File.ReadAllBytes(Application.StartupPath + "\\" + item.Key);
                obj.Save();
                objSpc.CommitChanges();
            }
        }
        public static void UpdateCheck(WinApplication app)
        {
            SplashScreenManager.ShowForm(typeof(WaitWindowFrm)); SplashScreenManager.Default.SetWaitFormCaption("Updating .......");

            Int64 localVersion = Convert.ToInt64(Application.ProductVersion.Replace(".", ""));
            Int64 ServerVersion = GetServerVersion(app);
            if (localVersion > ServerVersion && SecuritySystem.CurrentUserName.ToString() == "Admin")
            {
                PerformUpdaterUpload(GetUploadDependanceies(app), app);// Perform Update Server If Exists
                //PerformUpdaterDelete(GetDeletedAssemblyFiles(), app);//Perform Delete Server If Exists
            }
            else if (localVersion < ServerVersion)
                PerformUpdaterDownload(GetDownloadDependanceies(app), app);// Perform Update Client If Exists
                
            SplashScreenManager.CloseForm(false);
        }

        public static void WinApplication_LoggedOn(object sender, LogonEventArgs e)
        {
            UpdateCheck((WinApplication)sender);
        }

    }
}
