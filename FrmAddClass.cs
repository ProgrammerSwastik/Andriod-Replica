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
    public partial class FrmAddClass : Form
    {
        public int UserID { get; set; }


        public FrmAddClass()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            DataSet1TableAdapters.ClassesTBLTableAdapter ada = new DataSet1TableAdapters.ClassesTBLTableAdapter();
            ada.Addclass(metroTextBox1.Text, UserID);
            Close();


        }
    }
}
