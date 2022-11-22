using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using loginsec;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LeaveMangementForm
{
    public partial class LogIn_Form : Form
    {
        Connection con = new Connection();
         string id, EmpType;
        
        private Panel leftBoarderBtn;
        public LogIn_Form()
        {
            InitializeComponent();
        }

   

        private void LogIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {

                    con.Open();
                    string query = "select Emp_ID,EMP_Type from human_resources.employee WHERE Emp_User_Name ='" + textBox1.Text + "' AND Emp_password ='" + textBox2.Text + "'";   // changing username to Emp_User_Name, password to Emp_password and human.resources.employee to human_resources.employee
                    MySqlDataReader row;
                    row = con.ExecuteReader(query);
                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            id = row["Emp_ID"].ToString();
                            EmpType = row["EMP_Type"].ToString();
                           
                        }
                        MainFrame MF = new MainFrame();
                        MF.PassEmp_ID = id;
                        MF.EMP_Type = EmpType;
                        this.Hide();
                        MF.StartPosition = FormStartPosition.CenterScreen;
                        MF.ShowDialog();
                        
                        //MessageBox.Show("Data found your name is " + firstname + " " + username + " " + " and your ID at " + id);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Username or Password!", "Login Page");
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is empty!", "Login Page");
                }
            }
            catch
            {
                MessageBox.Show("Connection Error!", "Database Information");
            }
        }


    
    }
}
