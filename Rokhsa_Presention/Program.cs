using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Create_DVLD.Login;
using Create_DVLD;
using System.Globalization;
using System.Threading;

namespace Create_DVLD
{
    internal static class Program
    {
        // استدعاء مكتبة الويندوز للتحكم بالأبعاد
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // هذا السطر يخبر الويندوز بتشغيل البرنامج بأبعاده الأصلية 100% ويمنع مبعثرة الأدوات على شاشة 150%
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();
            

            // 1. إنشاء ثقافة (Culture) بريطانية أو أمريكية لتثبيت الأرقام والتواريخ بالإنجليزية
            CultureInfo culture = new CultureInfo("en-US");

            // 2. تعيين هذه الثقافة على مستوى البرنامج بالكامل (الـ Thread الحالي)
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new frmLoginDVLD());
        }
    }
}