using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_othodov
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Avtorizacia avtorizacia = new Avtorizacia();
            Application.Run(avtorizacia);
            if (avtorizacia.DialogResult == DialogResult.Yes)
                Application.Run(new Main());
            if (avtorizacia.DialogResult == DialogResult.No)
                Application.Run(new User_Main(avtorizacia.ID));
        }
    }
}
