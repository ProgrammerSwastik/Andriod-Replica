using Attendance_System.DataSet1TableAdapters;
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
    public partial class MainFrm : MetroFramework.Forms.MetroForm
    {
        public int loggedIn { get; set; }
        public int UserID { get; set; }

        public MainFrm()
        {
            InitializeComponent();
            loggedIn = 0;
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {



        }


        private void MainFrm_Activated(object sender, EventArgs e)
        {
            if (loggedIn == 0)
            {
                //Open Login Form
                LoginFrm newLogin = new LoginFrm();
                newLogin.ShowDialog();

                if (newLogin.loginFlag == false)
                {

                    Close();
                }
                else
                {
                    UserID = newLogin.UserID;
                    statLblUser.Text = UserID.ToString();
                    loggedIn = 1;

                    this.classesTBLTableAdapter.Fill(this.dataSet1.ClassesTBL);
                    classesTBLBindingSource.Filter = "UserID = '" + UserID.ToString() + "'";

                }
            }


        }
        private void metroButton3_Click(object sender, EventArgs e)
        {
            FrmAddClass addclass = new FrmAddClass();
            addclass.UserID = this.UserID;
            addclass.ShowDialog();



        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            StudentsFrm students = new StudentsFrm();
            students.ClassName = metroComboBox1.Text;
            students.ClassID = (int)metroComboBox1.SelectedValue;

            students.ShowDialog();

        }

        private void metroButtonGet_Click(object sender, EventArgs e)
        {
            // Check if records exists, if yes load them for edit and if not create a record for each student and load for edit

            AttendanceREcordsTBLTableAdapter ada = new AttendanceREcordsTBLTableAdapter();
            DataTable dt = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

            if (dt.Rows.Count > 0)
            {
                //we have records, so we can edit
                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;


            }
            else
            {
                //create a record for each student
                //Get the class students list
                StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();

                DataTable dt_Students = students_adapter.GetDataByCLassID((int)metroComboBox1.SelectedValue);

                foreach (DataRow row in dt_Students.Rows)
                {

                    //INsert a new record for this student
                    ada.InsertQuery((int)row[0], (int)metroComboBox1.SelectedValue, dateTimePicker1.Text, "", row[1].ToString(), metroComboBox1.Text);



                }

                DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
                dataGridView1.DataSource = dt_new;


            }


        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            AttendanceREcordsTBLTableAdapter ada = new AttendanceREcordsTBLTableAdapter();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    ada.UpdateQuery(row.Cells[1].Value.ToString(), row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

                }
                
            }

            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AttendanceREcordsTBLTableAdapter ada = new AttendanceREcordsTBLTableAdapter();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    ada.UpdateQuery("", row.Cells[0].Value.ToString(), (int)metroComboBox1.SelectedValue, dateTimePicker1.Text);

                }

            }

            DataTable dt_new = ada.GetDataBy((int)metroComboBox1.SelectedValue, dateTimePicker1.Text);
            dataGridView1.DataSource = dt_new;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            // get students
            StudentsTBLTableAdapter students_adapter = new StudentsTBLTableAdapter();
            DataTable dt_Students = students_adapter.GetDataByCLassID((int)metroComboBox2.SelectedValue);

            AttendanceREcordsTBLTableAdapter ada = new AttendanceREcordsTBLTableAdapter();


            int p = 0;
            int A = 0;
            int L = 0;
            int E = 0;

            //loop through students and get the values
            foreach (DataRow row in dt_Students.Rows)
            {
                //Presence count
                p = (int)ada.GetDataByReport(dateTimePicker2.Value.Month, row[1].ToString(), "present").Rows[0][6];

                // Absence
                A = (int)ada.GetDataByReport(dateTimePicker2.Value.Month, row[1].ToString(), "absent").Rows[0][6];

                // late
                L = (int)ada.GetDataByReport(dateTimePicker2.Value.Month, row[1].ToString(), "late").Rows[0][6];

                
                //Execuse
                E = (int)ada.GetDataByReport(dateTimePicker2.Value.Month, row[1].ToString(), "execused").Rows[0][6];


                ListViewItem litem = new ListViewItem();
                litem.Text = row[1].ToString();
                litem.SubItems.Add(p.ToString());
                litem.SubItems.Add(A.ToString());
                litem.SubItems.Add(L.ToString());
                litem.SubItems.Add(E.ToString());
                listView1.Items.Add(litem);
            }


           
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            RegisterFrm reg = new RegisterFrm();
            reg.ShowDialog();
        }
    }
}
