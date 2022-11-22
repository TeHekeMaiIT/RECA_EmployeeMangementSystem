// Created by Laila Shihada 764700695                   4th November 2022
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
    public partial class Admin_Detail_Grievances_Form : Form
    {
        private readonly Leave_Grievances L_G1;
        public Admin_Detail_Grievances_Form(Leave_Grievances L_G)
        {
            InitializeComponent();
            L_G1 = L_G;
        }
        Connection con = new Connection();
        public string GR_ID;
        public string Admin_ID;
        public string ConnectionString; // = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        private void Reply_btn_Click(object sender, EventArgs e)
        {
            SendEmail_Form EF = new SendEmail_Form();
            EF.EMP_Email = Email_view_Fill_lbl.Text;
            EF.GR_ID = GR_ID;
            EF.Admin_ID = Admin_ID;
            EF.Tag = this;
            EF.StartPosition = FormStartPosition.CenterScreen;
            EF.Location = this.Location;
            EF.Show(this);
            //EF.ShowDialog();
            

        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void fillForm()
        {
            int counter = 0;
            string sqlCommand = "SELECT distinct human_resources.grievances_resigning.GR_ID," +
                "human_resources.employee.Emp_ID,concat(human_resources.employee.Emp_FName, ' ', human_resources.employee.Emp_LName) as EmployeeName," +
                "Emp_Email,Emp_PhoneNum, human_resources.department.Dep_Name, human_resources.department.Job_Description," +
                "human_resources.grievances_resigning.Reason " +
                "FROM human_resources.grievances_resigning," +
                "human_resources.employee, human_resources.employee_department, human_resources.department" +
                " where((employee.Emp_ID = grievances_resigning.Emp_ID)" +
                " and(employee.Emp_ID = employee_department.Emp_ID)" +
                " and(employee_department.Dep_ID = department.Dep_ID))" +
                " and(grievances_resigning.GR_ID ="+ Convert.ToInt32(GR_ID) +") group by GR_ID"; 
            try 
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
                mySqlConnection.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                mySqlConnection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    counter += 1;
                    Grievance_ID_Fill_lbl.Text = dr["GR_ID"].ToString();
                    Emp_ID_view_Fill_lbl.Text = dr["EMP_ID"].ToString();
                    EmpName_view_Fill_lbl.Text = dr["EmployeeName"].ToString();
                    Position_view_Fill_lbl.Text = dr["Job_Description"].ToString();
                    Dep_view_Fill_lbl.Text = dr["Dep_Name"].ToString();
                    Email_view_Fill_lbl.Text = dr["Emp_Email"].ToString();
                    PhoneNo_view_Fill_lbl.Text = dr["Emp_PhoneNum"].ToString();
                    Reason_View_Fill_tbx.Text = dr["Reason"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Admin_Detail_Grievances_Form_Load_1(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            fillForm();
        }
    }
}
