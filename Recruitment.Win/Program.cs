using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security.Adapters;
using DevExpress.ExpressApp.Security.Xpo.Adapters;
using DevExpress.Xpo.DB;


namespace Recruitment.Win {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if EASYTEST
            DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif
            //Core.AppUpdater.PerformChangeExe();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            EditModelPermission.AlwaysGranted = false;//EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
            RecruitmentWindowsFormsApplication winApplication = new RecruitmentWindowsFormsApplication() { DelayedViewItemsInitialization = true };
            // Refer to the https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112680.aspx help article for more details on how to provide a custom splash form.
            winApplication.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen("recruitment.png");
            IsGrantedAdapter.Enable(XPOSecurityAdapterHelper.GetXpoCachedRequestSecurityAdapters());

            if (ConfigurationManager.ConnectionStrings["ConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
#if EASYTEST
            if(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] != null) {
                winApplication.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
            }
#endif
            winApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
            //if (System.Diagnostics.Debugger.IsAttached && winApplication.CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            //    winApplication.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;}
            
            try {
                //((WinApplication)winApplication).GetUserChoice("Eshtaaaaaaaaaa?", MessageBoxButtons.YesNo);
                DevExpress.Persistent.AuditTrail.AuditTrailService.Instance.TimestampStrategy = new Module.Core.ServerTimestampStrategy();// Set server time for Audit trail Service instead of using local time

                if (FXFW.SqlDB.LoadSqlDBPath("Recruitment") /*&& Authentication()*/)
                {
                    winApplication.ConnectionString = FXFW.SqlDB.SqlConStr;// set connection string.
                    //winApplication.ConnectionString = @"XpoProvider=MSAccess;Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\!Activities\2017-01-27\Recruitment.accdb.mdb;User Id=admin;Password=;";
                    //winApplication.ConnectionString = SQLiteConnectionProvider.GetConnectionString(@"d:\Recruitment.db");
                    //winApplication.ConnectionString = AccessConnectionProvider.GetConnectionString(@"g:\db.mdb");
                    //winApplication.ConnectionString =  MySqlConnectionProvider.GetConnectionString("localhost", "root", "123456", "recruitment2");
                    //winApplication.ConnectionString = PostgreSqlConnectionProvider.GetConnectionString("127.0.0.1", 5432, "postgres", "123456", "recruitment");
                    winApplication.LoggedOn += Core.AppUpdater.WinApplication_LoggedOn;
                    winApplication.Setup();
                    if (!TestVersion(winApplication))
                    {
                        MessageBox.Show($"Data limit reached, ask for Full version {Environment.NewLine} Please call 01004558638");
                        return;
                    }
                    winApplication.Start();
                }
            }
            catch(Exception e) {
                winApplication.HandleException(e);
            }
        }

        private static bool TestVersion(WinApplication winApplication)
        {
            IObjectSpace objectSpace = winApplication.CreateObjectSpace();
            DateTime dtTime = Module.Core.SqlOp.GetServerDateTime(((DevExpress.ExpressApp.Xpo.XPObjectSpace)objectSpace).Session);
            return dtTime <= new DateTime(2017,2,28);
        }

    }
}
