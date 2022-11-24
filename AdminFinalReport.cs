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
using System.Globalization;
using loginsec;

namespace LeaveMangementForm
{
    public partial class AdminFinalReport : Form
    {
        public AdminFinalReport()
        {
            InitializeComponent();
            double YearlyRevenue = 100000000000;
            double TotalTaxBayed = (YearlyRevenue * 25) / 100;
            textBox7.Text = YearlyRevenue.ToString("c", CultureInfo.CreateSpecificCulture("en-US"));
            textBox8.Text = TotalTaxBayed.ToString("c", CultureInfo.CreateSpecificCulture("en-US"));//"$ Taxation is theft";
            textBox9.Text = Convert.ToString(DateTime.Now.ToShortDateString());
            label8.Text = "Financial report " + DateTime.Now.ToShortDateString();
            textBox4.Text = "1st April - 31st March";
        }
        Connection con = new Connection();
        public string MySQLConnectionString;
        private void AdminFinalReport_Load(object sender, EventArgs e)
        {
            
            int Payroll;
            //queries to display company details on the form 
            string query = "select (select count(*) from employee Emp_ID) as 'employee', (select count(*) from department Dep_ID) as 'department', (select Sum(Emp_Salary) from employee) as 'total';";

            MySQLConnectionString = con.connectionString();
            MySqlConnection mySqlConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand cmd = new MySqlCommand(query, mySqlConnection);
            mySqlConnection.Open();

            MySqlDataReader myReader = cmd.ExecuteReader();
            while (myReader.Read()) //displaying details on page 
            {
                textBox2.Text = myReader.GetString(0);
                textBox1.Text = myReader.GetString(1);
                textBox3.Text = myReader.GetString(1);
                //method to calculate year to date salary expenses
                Payroll = Convert.ToInt32(myReader.GetString(2));
                int weeklyP = Payroll / 52;
                int dailyP = Payroll / 365;
                int ytd;
                int date = Convert.ToInt32(DateTime.Now.DayOfYear);
                if (date > 91)
                {
                    ytd = (date - 91) * dailyP;
                }
                else
                {
                    ytd = ((365 - 91) + date) * dailyP;
                }
                textBox5.Text = "$ " + Convert.ToString(weeklyP);
                textBox6.Text = "$ " + Convert.ToString(ytd);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files (*.txt)|*.txt"; //|pdf files (*.pdf)|*.pdf"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                String path = dialog.FileName; // get name of file
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding())) // do anything you want, e.g. read it
                {
                    textBox10.Text = path;
                    ViewFinalReportFile VFF = new ViewFinalReportFile();
                    VFF.Bath = path;
                    VFF.ShowDialog();
                }
            }
        }
    }
}
