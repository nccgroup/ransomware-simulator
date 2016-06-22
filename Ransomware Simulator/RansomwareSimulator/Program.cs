/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Donato Ferrante, donato dot ferrante at nccgroup dot trust

https://www.github.com/nccgroup/ransomware-simulator

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RansomwareSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
