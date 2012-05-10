using System;

using System.Collections.Generic;
using System.Windows.Forms;

namespace OEMTitleBarHandler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("CmdLine Args:");
            foreach (string s in args)
                System.Diagnostics.Debug.WriteLine(s);
            System.Diagnostics.Debug.WriteLine("=============");
            Application.Run(new FormMain(args));
        }
    }
}