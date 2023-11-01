using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDFwiz.Helper;
using Spire.DataExport.XLS;

namespace PDFwiz
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppInitializer();


            string[] args = Environment.GetCommandLineArgs();

            Form form;
            if (Boolean.Parse(AppConfigHelper.Appconfig_GetValue("DebugMode")))
            {
                form = new TestForm(args);
            }
            else 
            {
                form = new StartForm(args);
                form.Visible = false;
                form.StartPosition = FormStartPosition.CenterScreen;
            }

            Application.Run(form);

            
        }

        private static void AppInitializer()
        {
            ApplicationHelper.SetFileOpenApp2(
                ".pdfw", 
                Global.ExecutablePath,
                Global.StartupPath + "\\ic_pdfw.ico"
                );
        }


    }
}
