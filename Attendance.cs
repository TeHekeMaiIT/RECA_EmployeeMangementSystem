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
using System.Diagnostics;
using System.IO;
using System.Globalization;
using loginsec;


namespace RecaPayroll
{
    public partial class Attendance : Form
    {
        public string Emp_ID = "100";
        public Attendance()
        {
            InitializeComponent();
            Start_date_pkr.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }
        Connection con = new Connection();
        public string ConnectionString, EMP_Type; 
        

        private void Add_Click(object sender, EventArgs e)
        {
            if (validateFields(Fri) && validateFields(Mon) 
                && validateFields(Tue) && validateFields(Wed) 
                && validateFields(Thu) && validateFields(Sat) && validateFields(Sun))
            {
                int num1, num2, num3, num4, num5, num6, num7, res;
                num1 = Convert.ToInt32(Mon.Text);
                num2 = Convert.ToInt32(Tue.Text);
                num3 = Convert.ToInt32(Wed.Text);   
                num4 = Convert.ToInt32(Thu.Text);
                num5 = Convert.ToInt32(Fri.Text);
                num6 = Convert.ToInt32(Sat.Text);
                num7 = Convert.ToInt32(Sun.Text);

                res = num1 + num2 + num3 + num4 + num5 + num6 + num7;
                TotalHours.Text = Convert.ToString(res);
            }
            else
            {
                MessageBox.Show("Please complete your attenedance hours!", "Attendance");
            }
            
        }
        public bool validateFields(TextBox tb)
        {
            if (tb.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void SaveitDatabase()
        {
            
            string Total_Att_hours = TotalHours.Text;
            string Emp_ID = EmpID.Text;
            string Week_Start_Date = Start_date_pkr.Text;
            string Week_End_Date = dateTimePicker1.Text;
            int ID;
            int count = 0;
            string sqlCommand = "select max(Att_ID) as Att_ID from human_resources.weekly_attendence";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            string strAtt_ID = "0";
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Att_ID"].ToString() != "")
                {
                    strAtt_ID = dr["Att_ID"].ToString();
                    count++;
                }

            }

            int Att_ID = Convert.ToInt32(strAtt_ID);

            if ((Att_ID >= 0) && (count > 0))
            {
                Att_ID ++ ;
            }
            mySqlConnection.Close();
     
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO human_resources.weekly_attendence(Att_ID, Emp_ID, Week_Start_Date, Week_End_Date, Total_Att_Hours) " +
                            "VALUES (?Att_ID, ?Emp_ID, ?Week_Start_Date, ?Week_End_Date, ?Total_Att_Hours)";

                        MySqlParameter blobAtt_ID = new MySqlParameter("?Att_ID", MySqlDbType.Int32);
                        MySqlParameter blobEmp_ID = new MySqlParameter("?Emp_ID", MySqlDbType.Int32);
                        MySqlParameter blobLE_From_Date = new MySqlParameter("?Week_Start_Date", MySqlDbType.Date);
                        MySqlParameter blobLE_To_Date = new MySqlParameter("?Week_End_Date", MySqlDbType.Date);
                        MySqlParameter blobLE_Att_Hours = new MySqlParameter("?Total_Att_Hours", MySqlDbType.Double);
                                              

                        blobAtt_ID.Value = Att_ID;
                        blobEmp_ID.Value = Convert.ToInt32(Emp_ID);
                        blobLE_From_Date.Value = Convert.ToDateTime(Start_date_pkr.Text);
                        blobLE_To_Date.Value = Convert.ToDateTime(dateTimePicker1.Text);
                        blobLE_Att_Hours.Value = Convert.ToInt32(TotalHours.Text);


                        command.Parameters.Add(blobAtt_ID);
                        command.Parameters.Add(blobEmp_ID);
                        command.Parameters.Add(blobLE_From_Date);
                        command.Parameters.Add(blobLE_To_Date);
                        command.Parameters.Add(blobLE_Att_Hours);


                        connection.Open();

                        command.ExecuteNonQuery();
                        connection.Close();

                    }

                }
                MessageBox.Show("Employee Attendance Saved Sucessfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Attendance");
            }
        
        }
        private void Submit_btn_Click(object sender, EventArgs e)
        {
            SaveitDatabase();
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            Mon.Clear();
            Tue.Clear();
            Wed.Clear();
            Thu.Clear();
            Fri.Clear();
            Sat.Clear();
            Sun.Clear();
            TotalHours.Clear();
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            DiaplayLables();
            FillEmpInfo();
        }
        public void DiaplayLables()
        {
            if (EMP_Type == "ADM")
            {
                Emp_ID_lbl.Visible = false;
                Emp_Name_lbl.Visible = false;
                Admin_ID_lbl.Visible = true;
                Admin_Name_lbl.Visible = true;
            }
            else
            {
                Emp_ID_lbl.Visible = true;
                Emp_Name_lbl.Visible = true;
                Admin_ID_lbl.Visible = false;
                Admin_Name_lbl.Visible = false;
            }
        }
        public void FillEmpInfo()
        {
            if (Emp_ID == " ")
            {
                Emp_ID = "0";
            }
            string sqlCommand = "SELECT distinct human_resources.employee.Emp_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName" +
                " FROM human_resources.employee" +
                " Where employee.Emp_ID = " + Convert.ToInt32(Emp_ID) + ";";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            // This part needs to be updating to hold the first employee leave request.
            foreach (DataRow dr in dt.Rows)
            {
                EmpID.Text = dr["Emp_ID"].ToString();
                EmpName.Text = dr["EmployeeName"].ToString();
            }
        }
    }
}
