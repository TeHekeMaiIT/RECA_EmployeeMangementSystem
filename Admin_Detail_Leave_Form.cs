// Created by Laila Shihada 764700695                   6th November 2022
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
using loginsec;

namespace LeaveMangementForm
{
    public partial class Admin_Detail_Leave_Form : Form
    {
        private readonly Leave_Grievances L_G1;
        public Admin_Detail_Leave_Form(Leave_Grievances L_G)
        {
            InitializeComponent();
            L_G1 = L_G;
        }
        public string Leave_ID;
        
        Connection con = new Connection();

        public string ConnectionString; //= "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        
        private void Admin_Detail_Leave_Form_Load(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            fillForm();
            //Leave_ID_Fill_lbl.Text = Leave_ID;
        }
        public void fillForm()
        {
            
            int counter = 0;
            string sqlCommand = "SELECT distinct human_resources.leave.LE_ID,human_resources.leave.EMP_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName," +
                "human_resources.department.Dep_Name,human_resources.department.Job_Description," +
                "human_resources.leave.LE_Sick_Leave, human_resources.leave.LE_Annual_Leave," +
                "human_resources.leave.LE_Type,human_resources.leave.LE_From_Date,human_resources.leave.LE_To_Date,human_resources.leave.LE_Reason " +
                "FROM human_resources.employee,human_resources.department,human_resources.employee_department,human_resources.leave " +
                "Where((employee.Emp_ID = employee_department.Emp_ID)and(department.Dep_ID = employee_department.Dep_ID))" +
                "and(human_resources.leave.LE_ID = "+ Convert.ToInt32(Leave_ID) +") Group by human_resources.leave.LE_ID";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                counter += 1;
                Leave_ID_Fill_lbl.Text = dr["LE_ID"].ToString();
                Emp_ID_view_Fill_lbl.Text = dr["EMP_ID"].ToString();
                EmpName_view_Fill_lbl.Text = dr["EmployeeName"].ToString();
                Position_view_Fill_lbl.Text = dr["Job_Description"].ToString();
                Dep_view_Fill_lbl.Text = dr["Dep_Name"].ToString();
                TypeOfLeave_View_Fill_lbl.Text = dr["LE_Type"].ToString();
                remSickLeaveBalance_view_Fill_lbl.Text = dr["LE_Sick_Leave"].ToString();
                AnnulaLeaveBalance_view_Fill_lbl.Text = dr["LE_Annual_Leave"].ToString();
                StartDate_View_Fill_lbl.Text = Convert.ToDateTime(dr["LE_From_Date"].ToString()).ToString("yyyy-MM-dd");
                EndDate_View_Fill_lbl.Text = Convert.ToDateTime(dr["LE_To_Date"].ToString()).ToString("yyyy-MM-dd"); 
                Reason_View_Fill_tbx.Text = dr["LE_Reason"].ToString();
            }
        }
        private void Accept_btn_Click(object sender, EventArgs e)
        {
            string sqlCommand = "Update human_resources.leave set LE_Approved = 'Y' where human_resources.leave.LE_ID = "+ Convert.ToInt32(Leave_ID_Fill_lbl.Text);
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            Leave_Grievances LG = new Leave_Grievances();
            //LG.FillLeaveDataGrid();
            //LG.Reload();
            MainFrame MF = new MainFrame();
            MF.OpenChildForm(LG);
            this.Hide();
        }

        private void Reject_btn_Click(object sender, EventArgs e)
        {
            string sqlCommand = "Update human_resources.leave set LE_Approved = 'N' where human_resources.leave.LE_ID = " + Convert.ToInt32(Leave_ID_Fill_lbl.Text);
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            this.Hide();
        }
    }
}
