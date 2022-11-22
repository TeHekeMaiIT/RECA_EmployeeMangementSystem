using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using loginsec;

namespace LeaveMangementForm
{
    public partial class EmployeeGrievanceForm : Form
    {
        public string username;
        public string password;
        public string Emp_ID;
        Connection con = new Connection();
        public string MySQLConnectionString;
        public EmployeeGrievanceForm()
        {
            InitializeComponent();
                        
            DateBox.CustomFormat = "yyyy-MM-dd";
            DateBox.Enabled = false;
            DateBox.Value = DateTime.Now.Date;


        }

    
        public void fillForm()
        {
            string query = "select employee.Emp_ID, Emp_FName, Emp_LName, Dep_Name, Job_Description," +
               " Emp_User_Name, Emp_Password from human_resources.employee, human_resources.department," +
               " human_resources.employee_department where " +
               "employee_department.Emp_ID = employee_department.Dep_ID = department.Dep_ID and employee.Emp_ID = " + Convert.ToInt32(Emp_ID) + ";";
            MySQLConnectionString = con.connectionString(); 
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            databaseConnection.Open();
            MySqlDataReader myReader = commandDatabase.ExecuteReader();
            while (myReader.Read())
            {
                label1.Text = myReader.GetString(0);
                label2.Text = myReader.GetString(1) + " " + myReader.GetString(2);
                label3.Text = myReader.GetString(3);
                label4.Text = myReader.GetString(4);
                username = myReader.GetString(5);
                password = myReader.GetString(6);
            }
        }
        private void button1_Click(object sender, EventArgs e)  //Cancel button
        {
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)//Grievance form submition
        {
            int result;
            string reason = richTextBox1.Text;
            string rawdate = DateBox.Text;
            string EmpID = label1.Text;
            string query = "insert into grievances_resigning (GR_ID, Emp_ID, Issue_Date, Reason) values (" + createGR_ID() + ",'" + EmpID + "', '" + rawdate + "', '" + reason + "')";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase;
            try
            {
                databaseConnection.Open();
                commandDatabase = new MySqlCommand();
                commandDatabase.Connection = databaseConnection;
                commandDatabase.CommandText = query;
                result = commandDatabase.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Grievance report sent successfully");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Query error " + a.Message);
            }
        }

   public int createGR_ID()
        {
            int ID;
            string sqlCommand = "select max(GR_ID) from human_resources.grievances_resigning";
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            int leave_ID = (int)cmd.ExecuteScalar();
            mySqlConnection.Close();
            if (leave_ID == null)
            {
                ID = 0;
            }
            else
            {
                ID = leave_ID;
                ID++;
            }
            return ID;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void runQuery() //resignation form procedure
        {
            int result;
            string reason = textBox1.Text;
            DateBox.Value = DateTime.Now.Date;
            string date = DateBox.Text;
            string EmpID = label1.Text;
            string query = "insert into grievances_resigning (GR_ID, Emp_ID, Issue_Date, Reason) values (" + createGR_ID() + ", '" + EmpID + "', '" + date + "', 'RESIGNATION!- " + reason + "')";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase;

            if (checkBox1.Checked && watermarkTextBox1.Text == username && watermarkTextBox2.Text == password)
            {
                try
                {
                    databaseConnection.Open();
                    commandDatabase = new MySqlCommand();
                    commandDatabase.Connection = databaseConnection;
                    commandDatabase.CommandText = query;
                    result = commandDatabase.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Resignation request sent successfully");
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Query error " + a.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter the required information, and / or check your credentials");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            runQuery();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EmployeeGrievanceForm_Load(object sender, EventArgs e)
        {
            MySQLConnectionString = con.connectionString();
            fillForm();
    }
    }
}
