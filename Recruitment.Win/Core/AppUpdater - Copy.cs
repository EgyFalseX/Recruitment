﻿using DevExpress.ExpressApp;
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
            
            Asm.Add("DevExpress.BonusSkins.v15.2.dll", 15250);
            Asm.Add("DevExpress.Charts.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.CodeParser.v15.2.dll", 15250);
            Asm.Add("DevExpress.Data.v15.2.dll", 15250);
            Asm.Add("DevExpress.DataAccess.v15.2.dll", 15250);
            Asm.Add("DevExpress.DataAccess.v15.2.UI.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.AuditTrail.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Chart.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Chart.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.CloneObject.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ConditionalAppearance.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.FileAttachment.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.HtmlPropertyEditor.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Images.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Kpi.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Notifications.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Notifications.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Objects.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.PivotChart.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.PivotChart.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.PivotGrid.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.PivotGrid.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Reports.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ReportsV2.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ReportsV2.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Scheduler.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Scheduler.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ScriptRecorder.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ScriptRecorder.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Security.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Security.Xpo.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.StateMachine.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.TreeListEditors.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.TreeListEditors.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Validation.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Validation.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.ViewVariantsModule.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Workflow.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Workflow.Win.v15.2.dll", 15250);
            Asm.Add("DevExpress.ExpressApp.Xpo.v15.2.dll", 15250);
            Asm.Add("DevExpress.Office.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.Pdf.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.Pdf.v15.2.Drawing.dll", 15250);
            Asm.Add("DevExpress.Persistent.Base.v15.2.dll", 15250);
            Asm.Add("DevExpress.Persistent.BaseImpl.EF.v15.2.dll", 15250);
            Asm.Add("DevExpress.Persistent.BaseImpl.v15.2.dll", 15250);
            Asm.Add("DevExpress.PivotGrid.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.Printing.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.RichEdit.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.Sparkline.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.Utils.v15.2.dll", 15250);
            Asm.Add("DevExpress.Utils.v15.2.UI.dll", 15250);
            Asm.Add("DevExpress.Workflow.Activities.v15.2.dll", 15250);
            Asm.Add("DevExpress.Workflow.Activities.v15.2.Design.dll", 15250);
            Asm.Add("DevExpress.Xpo.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraBars.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraCharts.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraCharts.v15.2.Extensions.dll", 15250);
            Asm.Add("DevExpress.XtraCharts.v15.2.UI.dll", 15250);
            Asm.Add("DevExpress.XtraCharts.v15.2.Wizard.dll", 15250);
            Asm.Add("DevExpress.XtraEditors.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraGauges.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.XtraGrid.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraLayout.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraNavBar.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraPivotGrid.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraPrinting.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraReports.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraReports.v15.2.Extensions.dll", 15250);
            Asm.Add("DevExpress.XtraRichEdit.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraScheduler.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraScheduler.v15.2.Core.dll", 15250);
            Asm.Add("DevExpress.XtraTreeList.v15.2.dll", 15250);
            Asm.Add("DevExpress.XtraVerticalGrid.v15.2.dll", 15250);
            //Asm.Add("Recruitment.Module.dll", 10594322305);
            //Asm.Add("Recruitment.Module.Win.dll", 10594322473);
            Asm.Add("FXFW.dll", 1005);
            //Asm.Add(Application.ProductName + ".exe", Convert.ToInt64(Application.ProductVersion.Replace(".", "")));

            //Asm.Add("Ionic.Zip.dll", 1918);
            //Asm.Add("log4net.dll", 12110);
            return Asm;
        }
        public static Dictionary<string, Int64> GetDeletedAssemblyFiles()
        {
            Dictionary<string, Int64> Asm = new Dictionary<string, Int64>();
            //Asm.Add("DevExpress.BonusSkins.v15.2.dll", 15250);
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
        public static void PerformUpdaterDownload(Dictionary<string, Int64> Files)
        {
            if (Files.Count == 0)// No Update Found
                return;
            string Data = String.Format("{0}|{1}|", (int)UpdaterArgsEnum.Download, FXFW.SqlDB.SqlConStr);
            foreach (KeyValuePair<string, Int64> item in Files)
            {
                Data += item.Key + "|";
            }
            Data = Data.Substring(0, Data.Length - 1);

            Data = String.Format("\"{0}\"", Data);
            using (System.Diagnostics.Process process = new System.Diagnostics.Process() { StartInfo = new System.Diagnostics.ProcessStartInfo(updaterPath, Data) })
            {
                process.Start();
            }
            System.Diagnostics.Process.GetCurrentProcess().Kill();

        }
        public static void PerformUpdaterUpload(Dictionary<string, Int64> FilesList)
        {
            if (FilesList.Count == 0)
                return;
            string Data = String.Format("{0}{1}{2}{1}", (int)UpdaterArgsEnum.Upload, SplitChar, FXFW.SqlDB.SqlConStr);

            foreach (KeyValuePair<string, Int64> item in FilesList)
            {
                Data += String.Format("{0}{1}{2}{1}", item.Key, SplitChar, item.Value);
            }
            Data = Data.Substring(0, Data.Length - 1);
            Data = String.Format("\"{0}\"", Data);
            using (System.Diagnostics.Process process = new System.Diagnostics.Process() { StartInfo = new System.Diagnostics.ProcessStartInfo(updaterPath, Data) })
            {
                process.Start();
            } 
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        public static void PerformUpdaterDelete(Dictionary<string, Int64> FilesList, WinApplication app)
        {

        }

        public static void UpdateCheck(WinApplication app)
        {
            SplashScreenManager.ShowForm(typeof(WaitWindowFrm)); SplashScreenManager.Default.SetWaitFormCaption("Updating .......");

            Int64 localVersion = Convert.ToInt64(Application.ProductVersion.Replace(".", ""));
            Int64 ServerVersion = GetServerVersion(app);

            if (localVersion > ServerVersion && SecuritySystem.CurrentUserId.ToString() == "1")
            {
                PerformUpdaterUpload(GetUploadDependanceies(app));// Perform Update Server If Exists
                PerformUpdaterDelete(GetDeletedAssemblyFiles(), app);//Perform Delete Server If Exists
            }
            else if (localVersion < ServerVersion)
                PerformUpdaterDownload(GetDownloadDependanceies(app));// Perform Update Client If Exists
                
            SplashScreenManager.CloseForm(false);
        }

        public static void WinApplication_LoggedOn(object sender, LogonEventArgs e)
        {
            UpdateCheck((WinApplication)sender);
        }

    }
}
