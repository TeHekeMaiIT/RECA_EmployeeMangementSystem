using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using loginsec;

namespace LeaveMangementForm
{
    public partial class Emp_Registration : Form
    {
        public Emp_Registration()
        {
            InitializeComponent();
            DateBox.CustomFormat = "yyyy-MM-dd";
            dateBox1.CustomFormat = "yyyy-MM-dd";
        }
        Connection con = new Connection();
        public string MySQLConnectionString, EMP_Type, empID;
        public int ID, Emp_DepID;
        private void button4_Click(object sender, EventArgs e)
        {
            queryform();
        }
        private void queryform()// query to load selected employee information into form text boxes for edit 
        {
            if (EMP_Type == "ADM")
            {
                string empdetails = comboBox4.Text;
                string[] empdetails2 = empdetails.Split(','); //separate employee ID from employee information in search box
                empID = empdetails2[0]; // store EmpID in variable 
            }
            
            // query featuring updated Employee_department information salary, annual leave, tax code, etc.
            string query = "select Employee.Emp_ID as Emp_ID, Emp_Type, Emp_FName, Emp_LName, Emp_Address," +
                " Emp_Email, Emp_PhoneNum, Emp_Gender, Emp_Date_Of_Birth, Emp_position, Emp_salary," +
                " Dep_Name, Emp_IRD, Emp_Start_Date, KiwiSaver_Percentage, department.Annual_leave" +
                " from employee, employee_department, department " +
                "where employee.Emp_ID = '" + empID + "' && employee_department.Emp_ID = '" + empID + "' && department.Dep_ID = employee_department.Dep_ID;";
            int counter = 0;
            MySQLConnectionString = con.connectionString(); 
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                counter += 1;
                label15.Text = dr["Emp_ID"].ToString();
                comboBox1.Text = dr["Emp_Type"].ToString();
                textBox3.Text = dr["Emp_FName"].ToString();
                textBox4.Text = dr["Emp_LName"].ToString();
                textBox7.Text = dr["Emp_Address"].ToString();
                textBox8.Text = dr["Emp_Email"].ToString();
                textBox9.Text = dr["Emp_PhoneNum"].ToString();
                comboBox2.Text = dr["Emp_Gender"].ToString();
                  DateBox.Text = dr["Emp_Date_Of_Birth"].ToString();
                comboBox5.Text = dr["Emp_position"].ToString();
                textBox13.Text = dr["Emp_salary"].ToString();
                textBox16.Text = dr["Annual_leave"].ToString();
                textBox14.Text = "";
                textBox2.Text = dr["Emp_IRD"].ToString();
                dateBox1.Text = dr["Emp_Start_Date"].ToString(); //myReader.GetString(14);
                textBox15.Text = dr["KiwiSaver_Percentage"].ToString();
                comboBox3.Text = dr["Dep_Name"].ToString();

            }
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            updateform();
        }
        private void updateform() // send new form data to the database, updating the existing employee information
        {// form information stored in variables for query
            int result;
            string depID;
            string empID = label15.Text;
            string empType = comboBox1.Text;
            string firstName = textBox3.Text;
            string lastName = textBox4.Text;
            string address = textBox7.Text;
            string email = textBox8.Text;
            string phone = textBox9.Text;
            string gender = comboBox2.Text;
            string dob = DateBox.Text;
            string user = firstName + lastName;
            string password = "Password" + empID;
            string department = comboBox3.Text;
            string position = comboBox5.Text;
            string irdNum = textBox2.Text;
            string salary = textBox13.Text;
            string tax = textBox14.Text;
            string kiwi = textBox15.Text;
            string leave = textBox16.Text;
            string startdate = dateBox1.Text;
            // query for updating employe and employee_department information for existing employees
            string query = "update employee set Emp_Type = '" + empType + "', Emp_FName = '" + firstName + "', Emp_LName = '" + lastName + "'," +
                " Emp_Address = '" + address + "', Emp_Email = '" + email + "', Emp_PhoneNum = '" + phone + "', Emp_Gender = '" + gender + "', " +
                "Emp_Date_Of_Birth = '" + dob + "', Emp_User_Name = '" + user + "', Emp_Password = '" + password + "', Emp_position = '" + position + "', Emp_salary = '" + salary + "', " +
                       " Emp_IRD = '" + irdNum + "', Emp_Start_Date = '" + startdate + "', KiwiSaver_Percentage = '" + kiwi + "' where employee.Emp_ID = '" + empID + "';";

            MySQLConnectionString = con.connectionString(); 
            // statement to ensure that all required data is filled in on form before query execution
            if (empType == "" || firstName == "" || lastName == "" || address == "" || phone == "" || irdNum == "" || salary == "" || leave == "" || startdate == "")
            {
                MessageBox.Show("Please enter all neccessary information");
            }
            else
            {
                try
                {   //Execute query emplopyee table
                    MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    databaseConnection.Open();
                    result = commandDatabase.ExecuteNonQuery();
                    //execute query1 to find department ID from department name, depID stored in variable for next query
                    string query1 = "select Dep_ID from department where Dep_Name = '" + department + "';";
                    MySqlConnection databaseConnection1 = new MySqlConnection(MySQLConnectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query1, databaseConnection1);
                    databaseConnection1.Open();
                    MySqlDataReader myReader = commandDatabase1.ExecuteReader();
                    while (myReader.Read())
                    {
                        depID = myReader.GetString(0); //stored department id 
                        //execution of query2 employee_department information
                        string query2 = "update employee_department set Dep_ID = '" + depID + "' where Emp_ID = '" + empID + "';";
                        MySqlConnection databaseConnection2 = new MySqlConnection(MySQLConnectionString);
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                        databaseConnection2.Open();
                        result = commandDatabase2.ExecuteNonQuery();
                        databaseConnection2.Close();
                    }
                    if (result > 0)
                    {
                        MessageBox.Show("Employee details successfully updated");
                        databaseConnection.Close(); databaseConnection1.Close();
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Query error " + a.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            DateBox.CustomFormat = "yyyy-MM-dd";
            dateBox1.CustomFormat = "yyyy-MM-dd";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            searchEmp();
        }
        private void searchEmp()    // enable the function to search for an existing employee and update details
        {
            comboBox4.Show();
            button4.Show();
            label16.Show();
            button2.Hide();
            button5.Show();
            string empresults;
            string query = "select Emp_ID, Emp_FName, Emp_LName from human_resources.employee;";
            MySQLConnectionString = con.connectionString(); 
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            databaseConnection.Open();
            MySqlDataReader myReader = commandDatabase.ExecuteReader();
            while (myReader.Read()) //displaying details on page 
            {
                empresults = myReader.GetString(0) + ", " + myReader.GetString(1) + ", " + myReader.GetString(2);
                comboBox4.Items.Add(empresults);
            }
            databaseConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            submitForm();
        }
        private void submitForm() // send new employee information to a new database row. default username = first+last name default password = password+empID
        {
            int result;
            string depID;
            string empID;
            string empType = comboBox1.Text;
            string firstName = textBox3.Text;
            string lastName = textBox4.Text;
            string address = textBox7.Text;
            string email = textBox8.Text;
            string phone = textBox9.Text;
            string gender = comboBox2.Text;
            string dob = DateBox.Text;
            string user = firstName + lastName;
            string password = "Password";
            string department = comboBox3.Text;
            string position = comboBox5.Text;
            string irdNum = textBox2.Text;
            string salary = textBox13.Text;
            string tax = textBox14.Text;
            string kiwi = textBox15.Text;
            string leave = textBox16.Text;
            string startdate = dateBox1.Text;
            
            string query = "Insert into employee (Emp_ID, Emp_Type, Emp_FName, Emp_LName, Emp_Address, Emp_Email, Emp_PhoneNum, " +
                "Emp_Gender, Emp_Date_Of_Birth, Emp_User_Name,Emp_Password, Emp_Salary, Emp_IRD, Emp_Start_Date, KiwiSaver_Percentage, Emp_Position) values "
            + "('" + ID + "', '" + empType + "', '" + firstName + "', '" + lastName + "', '" + address + "', '" 
            + email + "', '" + phone + "', '" + gender + "', '" + dob + "', '" + user + "', '"  + password + ID +"', '" + salary + "', '" +
             irdNum + "', '" + startdate + "', '" + kiwi+ "', '" + position + "')";
            MySQLConnectionString = con.connectionString(); 
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase;
            if (empType == "" || firstName == "" || lastName == "" || address == "" || phone == "" || irdNum == "" || salary == "" || leave == "" || startdate == "")
            {
                MessageBox.Show("Please enter all neccessary information");
            }
            else
            {
                try
                {// insertion of new employee information into database, execution of query 
                    databaseConnection.Open();
                    commandDatabase = new MySqlCommand();
                    commandDatabase.Connection = databaseConnection;
                    commandDatabase.CommandText = query;
                    result = commandDatabase.ExecuteNonQuery();
                    // execution of query3 for finding employee ID, department name, and departmentID. Store in variable for query2 and query4
                    string query3 = "select Dep_ID from human_resources.department where department.Dep_Name = '" + department + "';";
                    MySqlConnection databaseConnection1 = new MySqlConnection(MySQLConnectionString);
                    MySqlCommand commandDatabase1 = new MySqlCommand(query3, databaseConnection1);
                    databaseConnection1.Open();
                    object Dep_ID = (int)commandDatabase1.ExecuteScalar();
                    depID = Dep_ID.ToString();
                        // insertion of new employee_department information into database. execution of query2
                        string query2 = "insert into employee_department (Emp_Dep_ID,Emp_ID, Dep_ID) values "
                        + "('" + Emp_DepID + "', '" + ID + "', '" + depID + "')";
                        MySqlConnection databaseConnection2 = new MySqlConnection(MySQLConnectionString);
                        MySqlCommand commandDatabase2 = new MySqlCommand(query2, databaseConnection2);
                        databaseConnection2.Open();
                        commandDatabase2.CommandText = query2;
                        result = commandDatabase2.ExecuteNonQuery();
                        // execution of query4 with temporary password using the now known new employee ID 
                        string query4 = "update employee set Emp_Password = '" + password + ID + "' where employee.Emp_ID = '" + ID + "';";
                        MySqlConnection databaseConnection3 = new MySqlConnection(MySQLConnectionString);
                        MySqlCommand commandDatabase3 = new MySqlCommand(query4, databaseConnection3);
                        databaseConnection3.Open();
                        commandDatabase3.CommandText = query4;
                        result = commandDatabase3.ExecuteNonQuery();

                        databaseConnection2.Close(); databaseConnection3.Close();
                    if (result > 0)
                    {
                        MessageBox.Show("Employee details successfully entered");
                        databaseConnection.Close(); databaseConnection1.Close();
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show("Query error " + a.Message);
                }
            }
        }
        public void return_ID()
        {
            
            string sqlCommand = "select max(Emp_ID) from human_resources.Employee";
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            object Emp_ID = (int)cmd.ExecuteScalar();
            mySqlConnection.Close();
            if (Emp_ID == null)
            {
                ID = 0;
            }
            else
            {
                ID = Convert.ToInt32(Emp_ID.ToString());
                ID++;
            }
        }
        public void return_EmpDepID()
        {

            string sqlCommand = "Select max(Emp_Dep_ID) from human_resources.Employee_department";
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            object EmpDepID = (int)cmd.ExecuteScalar();
            mySqlConnection.Close();
            if (EmpDepID == null)
            {
                Emp_DepID = 0;
            }
            else
            {
                Emp_DepID = Convert.ToInt32(EmpDepID.ToString());
                Emp_DepID++;
            }
        }

        private void Emp_Registration_Load(object sender, EventArgs e)
        {
            MySQLConnectionString = con.connectionString();
            return_ID();
            return_EmpDepID();
            EmployeeMode();
        }
        public void EmployeeMode()
        {
            if (EMP_Type == "EMP")
            {
                label15.Enabled = false;
                comboBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                comboBox2.Enabled = false;
                DateBox.Enabled = false;
                comboBox5.Enabled = false;
                textBox13.Enabled = false;
                textBox16.Enabled = false;
                textBox14.Enabled = false;
                textBox2.Enabled = false;
                dateBox1.Enabled = false; 
                textBox15.Enabled = false;
                comboBox3.Enabled = false;
                button1.Visible = false;
                button1.Enabled = false;
                button2.Visible = false;
                button2.Enabled = false;
                button3.Visible = false;
                button3.Enabled = false;
                button5.Visible = false;
                button5.Enabled = false;
                queryform();
            }
           
        }
    }
}
