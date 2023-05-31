﻿using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
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
            Application.Run(new FrmLogin());
            //new FrmPrincipal(new Employee(2,"Fuller", "Andrew", "Vice President, Sales", "98401", 0))
            //new FrmVentas(new Employee(2, "Fuller", "Andrew", "Vice President, Sales", "98401", 0))
        }
    }
}
