using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;                     //To use C Win32 functions

//Source of TouchCalibrate function: https://developer.toradex.com/knowledge-base/touch-screen-calibration-windows-ce

namespace SmartDeviceProject1
{
    public partial class runcalibration : Form
    {
        [DllImport("coredll.dll")]
        private static extern bool TouchCalibrate();      //import function from coredll

        [DllImport("coredll.dll", EntryPoint = "RegFlushKey", SetLastError = true)]
        public static extern uint RegFlushKey(uint hKey); //import function from coredll

        const uint HKEY_LOCAL_MACHINE = 0x80000002;

        public runcalibration()
        {
            InitializeComponent();
            touchCalibrate();// function will be called on Form Load
            this.Close();
        }
        public void touchCalibrate()
        {
            TouchCalibrate();
            RegFlushKey(HKEY_LOCAL_MACHINE);
        }
    }
}