using QLSinhViennhom5.Thong_Tin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QLSinhViennhom5.TimKiem;
using System.Windows.Forms;

namespace QLSinhViennhom5
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Man_chinh());
        }
    }
}
