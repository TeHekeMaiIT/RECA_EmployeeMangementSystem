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
using System.IO;
using loginsec;

namespace LeaveMangementForm
{
    public partial class Emp_ViewSalaryForm : Form
    {
        public Emp_ViewSalaryForm()
        {
            InitializeComponent();
        }
        public string Emp_ID;
        Connection con = new Connection();
        private void Emp_ViewSalaryForm_Load(object sender, EventArgs e)
        {
            // query execution to pull employee details into form
            string query = "select employee.Emp_ID, Emp_FName, Emp_LName, Dep_Name, Job_Description, Emp_Salary, KiwiSaver_Percentage, LE_Annual_Leave, " +
                "LE_Sick_Leave from human_resources.employee, human_resources.department, human_resources.employee_department, human_resources.leave where " +
                "employee_department.Emp_ID = employee_department.Dep_ID = department.Dep_ID and human_resources.leave.Emp_ID = employee.Emp_ID and employee.Emp_ID = '"+ Emp_ID +"' ORDER BY LE_ID ASC LIMIT 1; ";
            string MySQLConnectionString = con.connectionString();//"datasource=127.0.0.1;port=3306;username=root;password=Dbms@2022;database=human_resources";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            databaseConnection.Open();
            MySqlDataReader myReader = commandDatabase.ExecuteReader();
            while (myReader.Read()) //displaying details on page 
            {
                label1.Text = myReader.GetString(0);
                label2.Text = myReader.GetString(1) + " " + myReader.GetString(2);
                label3.Text = myReader.GetString(3);
                label4.Text = myReader.GetString(4);
                label20.Text = "$" + myReader.GetString(5);
                label18.Text = myReader.GetString(6) + "%";
                label14.Text = myReader.GetString(7);
                label13.Text = myReader.GetString(8);
            }
        }
        private void RenderPdf(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                webBrowser1.Navigate(@filePath);
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    textBox1.Text = path;
                }
                RenderPdf(@path);   // opens the file in webBrowser window
            }
        }
    }
}
