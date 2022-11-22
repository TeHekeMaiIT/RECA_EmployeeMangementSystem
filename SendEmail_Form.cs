// Created by Laila Shihada 764700695                   11th November 2022
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using MySql.Data;
using MySql.Data.MySqlClient;
using loginsec;

namespace LeaveMangementForm
{
    public partial class SendEmail_Form : Form
    {
        public SendEmail_Form()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        public string EMP_Email;
        public string GR_ID;
        public string Admin_ID;
        public string ConnectionString;// = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        private void Send_btn_Click(object sender, EventArgs e)
        {
            if (validateInput())
            {
                string from, to, pass, messageBody;
                MailMessage message = new MailMessage();
                to = To_tbx.Text;            // To email ToMailAdd_tbx
                from = From_tbx.Text;          // your email
                pass = Pass_tbx.Text;          // your password
                messageBody = Message_tbx.Text;   // Message Body
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = Subject_tbx.Text; // Subject message
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);   //"dfxccwlrshwjgakv"
                try
                {
                    smtp.Send(message);
                    DialogResult code = MessageBox.Show("Email sent successfully!", "Email notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (code == DialogResult.OK)
                    {
                        To_tbx.Clear();
                        From_tbx.Clear();
                        Subject_tbx.Clear();
                        Message_tbx.Clear();
                        Pass_tbx.Clear();
                    }
                    if (updateGrievances())
                    {
                       this.Hide();
                    }
                    else
                        MessageBox.Show("Database error. Please Connect with your DBA", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        public bool updateGrievances()
        {
            string sqlCommand = "Update human_resources.grievances_resigning set Admin_Reply = 'Y' " +
                "where human_resources.grievances_resigning.GR_ID = " + Convert.ToInt32(GR_ID);
            try
            {
                MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
                MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
                mySqlConnection.Open();
                cmd.ExecuteNonQuery();
                mySqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
        }
        public bool validateInput()
        {
            if(!isValidEmail(To_tbx.Text))
            {
                To_lbl.ForeColor = Color.Red;
                MessageBox.Show("Please enter a correct email address.", "Error massage", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            else if(!isValidEmail(From_tbx.Text))
            {
                From_lbl.ForeColor = Color.Red;
                MessageBox.Show("Please enter a correct email address.", "Error massage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                To_lbl.ForeColor = Color.Black;
                From_lbl.ForeColor = Color.Black;
                if (Pass_tbx.Text == "")
                {
                    Password_lbl.ForeColor = Color.Red;
                    MessageBox.Show("Please enter your email's password.", "Error massage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    Password_lbl.ForeColor = Color.Black;
                    return true;
                }
                
            }
            

            
        }
        public bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            if (!regex.IsMatch(email)|| email == "")
            {
                
                return false;
            }
            else
            {
                
                return true;
            }
        }

        private void SendEmail_Form_Load(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            //To_tbx.Enabled = false;
            To_tbx.Text = EMP_Email;
            From_tbx.Text = AdminEmail();
            Pass_tbx.Text = "dfxccwlrshwjgakv";
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private string AdminEmail()
        {
            string Admin_Email = "";
            string sqlCommand = "Select Emp_Email From human_resources.employee Where Emp_ID = " + Convert.ToInt32(Admin_ID) + ";"; 
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Emp_Email"].ToString() != "")
                {
                    Admin_Email = dr["Emp_Email"].ToString();
                }
            }
        return Admin_Email;
            
        }
    }
}
