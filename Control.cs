using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andriod_Emulator
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            FullBattery.Hide();
            NearlyFullBattery.Hide();
            LowBattery.Hide();
            HalfBattery.Hide();
            PowerOff.Enabled = false;
            WebBrowsersFolder.Enabled = false;
            Home.Enabled = false;
            Lock.Enabled = false;
            FullBattery.Enabled = false;
            Charging.Enabled = false;
            FullBattery.Enabled = false;
            NearlyFullBattery.Enabled = false;
            LowBattery.Enabled = false;
            HalfBattery.Enabled = false;
        }

        private void PowerOn_Click(object sender, EventArgs e)
        {
            Form AndriodStart = new AndriodStart();
            AndriodStart.Show();

            PowerOff.Enabled = true;
            WebBrowsersFolder.Enabled = true;
            Home.Enabled = true;
            Charging.Hide();
            FullBattery.Show();

            Thread.Sleep(3600000);
            FullBattery.Hide();
            NearlyFullBattery.Show();

            Thread.Sleep(7200000);
            NearlyFullBattery.Hide();
            HalfBattery.Show();

            Thread.Sleep(10800000);
            HalfBattery.Hide();
            LowBattery.Show();



        }
    }
}
