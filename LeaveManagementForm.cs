using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LeaveMangementForm
{
    public partial class LeaveManagementForm : Form
    {
        public LeaveManagementForm()
        {
            InitializeComponent();
            
            
        }
        private void LeaveManagementForm_Load(object sender, EventArgs e)
        {

            LeaveType_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            LeaveType_cbx.SelectedIndex = LeaveType_cbx.FindStringExact("Select leave type");
            fillLables();
            
        }

        private void fillLables()
        {
            string ConnectionString = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
            string sqlCommand = "SELECT distinct human_resources.employee.Emp_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName," +
                "human_resources.department.Dep_Name," +
                "human_resources.department.Job_Description,human_resources.department.Annual_Leave " +
                "FROM human_resources.employee,human_resources.department,human_resources.employee_department " +
                "Where (employee.Emp_ID = 55) and (employee.Emp_ID = employee_department.Emp_ID) group by Emp_ID;";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Emp_ID_Fill_lbl.Text = dr["Emp_ID"].ToString();
                Emp_Name_Fill_lbl.Text = dr["EmployeeName"].ToString();
                Position_Fill_lbl.Text = dr["Job_Description"].ToString();
                Dep_Name_Fill_lbl.Text = dr["Dep_Name"].ToString();

            }


        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        /*
                private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
                {

                }

                private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
                {

                }

                private void Emp_Name_lbl_Click(object sender, EventArgs e)
                {

                }

                private void Position_lbl_Click(object sender, EventArgs e)
                {

                }

                private void Dep_Name_lbl_Click(object sender, EventArgs e)
                {

                }

                private void label1_Click(object sender, EventArgs e)
                {

                }

                private void Emp_ID_lbl_Click(object sender, EventArgs e)
                {

                }

                private void Start_Date_lbl_Click(object sender, EventArgs e)
                {

                }

                private void End_Date_lbl_Click(object sender, EventArgs e)
                {

                }

                private void Reason_lbl_Click(object sender, EventArgs e)
                {

                }

                private void label2_Click(object sender, EventArgs e)
                {

                }

                private void label3_Click(object sender, EventArgs e)
                {

                }

                private void label4_Click(object sender, EventArgs e)
                {

                }
        */
        private void View_btn_Click(object sender, EventArgs e)
        {
            Emp_ID_view_Fill_lbl.Text = "0101";
            EmpName_view_Fill_lbl.Text = "Test1";
            Position_view_Fill_lbl.Text = "ttttt";
            Dep_view_Fill_lbl.Text = "ttttt";
            TypeOfLeave_View_Fill_lbl.Text = "dddddd";
            Reason_View_Fill_tbx.Text = "any thing any thing any thing any thing test test";
            Attach_View_Fill_tbx.Text = "File.exr";
            remHoliday_View_Fill_lbl.Text = "555";
            remSickLeave_View_Fill_lbl.Text = "12.3";
            splitContainer1.Panel2.Enabled = true;
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            clearViewObj();
            splitContainer1.Panel2.Enabled = false;
        }

        public void clearViewObj()
        {
            Emp_ID_view_Fill_lbl.Text = "";
            EmpName_view_Fill_lbl.Text = "";
            Position_view_Fill_lbl.Text = "";
            Dep_view_Fill_lbl.Text = "";
            TypeOfLeave_View_Fill_lbl.Text = "";
            Reason_View_Fill_tbx.Text = "";
            Attach_View_Fill_tbx.Text = "";
            remHoliday_View_Fill_lbl.Text = "";
            remSickLeave_View_Fill_lbl.Text = "";
        }
    }
}
