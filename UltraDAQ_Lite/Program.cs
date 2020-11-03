using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltraDAQ_Lite.SubForm;

namespace UltraDAQ_Lite
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form_Main());
            //Application.Run(new Form_DeviceConfig());
            //Application.Run(new Form_Register());
           // Application.Run(new Form_WaveMonitor());
        }
    }
}
