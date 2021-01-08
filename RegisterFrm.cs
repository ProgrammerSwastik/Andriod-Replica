using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Attendance_System
{
    public partial class RegisterFrm : Form
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if(TxtPass1 .Text != Txtpass2 .Text)
            {
                MessageBox.Show("Passwords Dont match!");
                return;
            }


            DataSet1TableAdapters.UsersTableAdapter ada = new DataSet1TableAdapters.UsersTableAdapter();
            ada.InsertQuery(TxtUSer.Text, TxtPass1.Text);
            MessageBox.Show("Registeration Succesfull!");
            Close();
        }
    }
}
