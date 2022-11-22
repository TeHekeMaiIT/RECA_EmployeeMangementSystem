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
using System.Diagnostics;
using System.IO;
using loginsec;


namespace LeaveMangementForm
{
    public partial class LeaveManagement : Form
    {
        public string Emp_ID;
        public LeaveManagement()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        public string ConnectionString; // = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        public Double remLeaveBalance = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            LeaveType_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            LeaveType_cbx.SelectedIndex = LeaveType_cbx.FindStringExact("Select leave type");
            diapleObjects();
            fillLables();

        }
        private void fillLables()
        {
            if (Emp_ID == " ")
            {
                Emp_ID = "0";
            }
            int counter = 0;
            string sqlCommand = "SELECT distinct human_resources.employee.Emp_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName," +
                "human_resources.department.Dep_Name,human_resources.department.Sick_Leave," +
                "human_resources.department.Job_Description,human_resources.department.Annual_Leave " +
                "FROM human_resources.employee,human_resources.department,human_resources.employee_department " +
                "Where (employee.Emp_ID = " + Convert.ToInt32(Emp_ID) + ") and (employee.Emp_ID = employee_department.Emp_ID) group by Emp_ID;";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();
            // This part needs to be updating to hold the first employee leave request.
            foreach (DataRow dr in dt.Rows)
            {
                counter += 1;
                Emp_ID_Fill_lbl.Text = dr["Emp_ID"].ToString();
                Emp_Name_Fill_lbl.Text = dr["EmployeeName"].ToString();
                Position_Fill_lbl.Text = dr["Job_Description"].ToString();
                Dep_Name_Fill_lbl.Text = dr["Dep_Name"].ToString();
                remHolidayFill_lbl.Text = dr["Annual_Leave"].ToString();
                remSickLeaveFill_lbl.Text = dr["Sick_Leave"].ToString(); 
            }
            if (counter == 0)
            {
                MessageBox.Show("To access the leave management form, attach the employee to a department!", "Leave Management");
                View_btn.Enabled = false;
                Submit_btn.Enabled = false;
                fileUpload_btn.Enabled = false;
            }
            else
            {
                View_btn.Enabled = true;
                Submit_btn.Enabled = true;
                fileUpload_btn.Enabled = true;
            }
              


        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            clearViewObj();
            diapleObjects();
        }
        public void clearViewObj()
        {
            Emp_ID_view_Fill_lbl.Text = "";
            EmpName_view_Fill_lbl.Text = "";
            Position_view_Fill_lbl.Text = "";
            Dep_view_Fill_lbl.Text = "";
            TypeOfLeave_View_Fill_lbl.Text = "";
            StartDate_View_Fill_lbl.Text = "";
            EndDate_View_Fill_lbl.Text = "";
            Reason_View_Fill_tbx.Text = "";
            Attach_View_Fill_tbx.Text = "";
            remHoliday_View_Fill_lbl.Text = "";
            remSickLeave_View_Fill_lbl.Text = "";
        }

        private void View_btn_Click(object sender, EventArgs e)
        {
            enableObjects();
            
            if (validateObjects())
            {
                LeaveType_lbl.ForeColor = Color.Black;
                TypeOfLeave_View_Fill_lbl.Text = LeaveType_cbx.SelectedItem.ToString();

                if (LeaveType_cbx.SelectedItem.ToString() == "Sick leave")
                {
                    remLeaveBalance = Convert.ToDouble(remSickLeaveFill_lbl.Text) - calculateLeaveBalance();
                    remSickLeave_View_Fill_lbl.Text = Convert.ToString(remLeaveBalance);
                    remHoliday_View_Fill_lbl.Text = remHolidayFill_lbl.Text;
                }
                else
                {
                    remLeaveBalance = Convert.ToDouble(remHolidayFill_lbl.Text) - calculateLeaveBalance();
                    remSickLeave_View_Fill_lbl.Text = remSickLeaveFill_lbl.Text;
                    remHoliday_View_Fill_lbl.Text = Convert.ToString(remLeaveBalance);
                }
            }
            
            
            
            
            Emp_ID_view_Fill_lbl.Text = Emp_ID_Fill_lbl.Text;
            EmpName_view_Fill_lbl.Text = Emp_Name_Fill_lbl.Text;
            Position_view_Fill_lbl.Text = Position_Fill_lbl.Text;
            Dep_view_Fill_lbl.Text = Dep_Name_Fill_lbl.Text;
            StartDate_View_Fill_lbl.Text = Start_date_pkr.Value.ToString("yyyy-MM-dd");
            EndDate_View_Fill_lbl.Text = End_date_pkr.Value.ToString("yyyy-MM-dd");
            Reason_View_Fill_tbx.Text = Reson_tbx.Text;
            Attach_View_Fill_tbx.Text = uploadAtt_tbx.Text;
            
            

        }
        public Boolean validateObjects()
        {
            if (string.IsNullOrEmpty(LeaveType_cbx.Text))
            {
                LeaveType_lbl.ForeColor = Color.Red;
                MessageBox.Show("Pleae select Type of Leave!", "Leave Management");
                return false;
            }
            else
                return true;
        }
        public void diapleObjects()
        {
            Emp_ID_view_Fill_lbl.Visible = false;
            EmpName_view_Fill_lbl.Visible = false;
            Position_view_Fill_lbl.Visible = false;
            Dep_view_Fill_lbl.Visible = false;
            TypeOfLeave_View_Fill_lbl.Visible = false;
            StartDate_View_Fill_lbl.Visible = false;
            EndDate_View_Fill_lbl.Visible = false;
            Reason_View_Fill_tbx.Visible = false;
            Attach_View_Fill_tbx.Visible = false;
            remHoliday_View_Fill_lbl.Visible = false;
            remSickLeave_View_Fill_lbl.Visible = false;
            EmpID_view_lbl.Visible = false;
            EmpName_view_lbl.Visible = false;
            Position_view_lbl.Visible = false;
            Dpt_view_lbl.Visible = false;
            TypeOfLeave_view_lbl.Visible = false;
            StartDate_view_lbl.Visible = false;
            EndDate_view_lbl.Visible = false;
            Reason_view_lbl.Visible = false;
            Attach_view_lbl.Visible = false;
            remHoliday_view_lbl.Visible = false;
            remSickLeave_view_lbl.Visible = false;


        }

        public void enableObjects()
        {
            Emp_ID_view_Fill_lbl.Visible = true;
            EmpName_view_Fill_lbl.Visible = true;
            Position_view_Fill_lbl.Visible = true;
            Dep_view_Fill_lbl.Visible = true;
            TypeOfLeave_View_Fill_lbl.Visible = true;
            StartDate_View_Fill_lbl.Visible = true;
            EndDate_View_Fill_lbl.Visible = true;
            Reason_View_Fill_tbx.Visible = true;
            Attach_View_Fill_tbx.Visible = true;
            remHoliday_View_Fill_lbl.Visible = true;
            remSickLeave_View_Fill_lbl.Visible = true;
            EmpID_view_lbl.Visible = true;
            EmpName_view_lbl.Visible = true;
            Position_view_lbl.Visible = true;
            Dpt_view_lbl.Visible = true;
            TypeOfLeave_view_lbl.Visible = true;
            StartDate_view_lbl.Visible = true;
            EndDate_view_lbl.Visible = true;
            Reason_view_lbl.Visible = true;
            Attach_view_lbl.Visible = true;
            remHoliday_view_lbl.Visible = true;
            remSickLeaveFill_lbl.Visible = true;
            remSickLeave_view_lbl.Visible = true;

        }
        private void fileUpload_btn_Click(object sender, EventArgs e)
        {
            open_Att_File_dlg.InitialDirectory = "C://Desktop";
            //Your opendialog box title name.
            //open_Att_File_dlg.Title = "Select file to be upload.";
            //which type file format you want to upload in database. just add them.
            open_Att_File_dlg.Filter = "Select Valid Document(*.txt;*.pdf; *.doc; *.xlsx; *.img; *.png)|*.txt;*.pdf; *.docx; *.xlsx; *.img; *.png";
            //FilterIndex property represents the index of the filter currently selected in the file dialog box.
            open_Att_File_dlg.FilterIndex = 1;
            try
            {
                if (open_Att_File_dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (open_Att_File_dlg.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(open_Att_File_dlg.FileName);
                        uploadAtt_tbx.Text = path;
                        long length = new System.IO.FileInfo(path).Length;
                        if (length > 65535)
                        {
                            MessageBox.Show("Your document is over 65,535 bytes! Please attach smaller one!", "Leave Management");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Upload document.","Leave Management");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        public void SaveToMysql() 
        {
            int ID;
            string sqlCommand = "select max(LE_ID) from human_resources.leave";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
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

            byte[] rawData;
            if (Attach_View_Fill_tbx.Text != "")
            {
                rawData = File.ReadAllBytes(Attach_View_Fill_tbx.Text);
            }
            else
               rawData = null;
            
            
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO human_resources.leave (LE_ID, Emp_ID, LE_Type, LE_From_Date, LE_To_Date, LE_Balance, LE_Reason, LE_Docs, LE_Sick_Leave, LE_Annual_Leave) " +
                            "VALUES (?LE_ID, ?Emp_ID, ?LE_Type, ?LE_From_Date, ?LE_To_Date, ?LE_Balance, ?LE_Reason, ?LE_Docs, ?LE_Sick_Leave, ?LE_Annual_Leave)";

                        MySqlParameter blobLeave_ID = new MySqlParameter("?LE_ID", MySqlDbType.Int32);
                        MySqlParameter blobEmp_ID = new MySqlParameter("?Emp_ID", MySqlDbType.Int32);
                        MySqlParameter blobLeave_Type = new MySqlParameter("?LE_Type", MySqlDbType.String);
                        MySqlParameter blobLE_From_Date = new MySqlParameter("?LE_From_Date", MySqlDbType.Date);
                        MySqlParameter blobLE_To_Date = new MySqlParameter("?LE_To_Date", MySqlDbType.Date);
                        MySqlParameter blobLE_Balance = new MySqlParameter("?LE_Balance", MySqlDbType.Double);
                        MySqlParameter blobLE_Sick_Leave = new MySqlParameter("?LE_Sick_Leave", MySqlDbType.Double);
                        MySqlParameter blobLE_Annual_Leave = new MySqlParameter("?LE_Annual_Leave", MySqlDbType.Double);
                        MySqlParameter blobLE_Reason = new MySqlParameter("?LE_Reason", MySqlDbType.String);
                        MySqlParameter blobData;
                        if (rawData == null)
                            blobData = new MySqlParameter("?LE_Docs", MySqlDbType.Blob, 0);
                        else
                            blobData = new MySqlParameter("?LE_Docs", MySqlDbType.Blob, rawData.Length);

                        blobLeave_ID.Value = ID;
                        blobEmp_ID.Value = Convert.ToInt32(Emp_ID);
                        blobLeave_Type.Value = TypeOfLeave_View_Fill_lbl.Text;
                        blobLE_From_Date.Value = Convert.ToDateTime(StartDate_View_Fill_lbl.Text);
                        blobLE_To_Date.Value = Convert.ToDateTime(EndDate_View_Fill_lbl.Text);
                        blobLE_Balance.Value = remLeaveBalance;
                        blobLE_Sick_Leave.Value = Convert.ToDouble(remSickLeave_View_Fill_lbl.Text);
                        blobLE_Annual_Leave.Value = Convert.ToDouble(remHoliday_View_Fill_lbl.Text);
                        blobLE_Reason.Value = Reason_View_Fill_tbx.Text;
                        blobData.Value = rawData;

                        command.Parameters.Add(blobLeave_ID);
                        command.Parameters.Add(blobEmp_ID);
                        command.Parameters.Add(blobLeave_Type);
                        command.Parameters.Add(blobLE_From_Date);
                        command.Parameters.Add(blobLE_To_Date);
                        command.Parameters.Add(blobLE_Balance);
                        command.Parameters.Add(blobLE_Reason);
                        command.Parameters.Add(blobLE_Sick_Leave);
                        command.Parameters.Add(blobLE_Annual_Leave);
                        command.Parameters.Add(blobData);

                        connection.Open();

                        command.ExecuteNonQuery();
                        connection.Close();

                    }

                }
                MessageBox.Show("Your leave number is: "+Convert.ToString(ID),"Leave Management");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message,"Leave Management");
            }
            
        }
        public double calculateLeaveBalance()
        {
            DateTime d1 = Convert.ToDateTime(Start_date_pkr.Value.ToString("yyyy-MM-dd"));
            DateTime d2 = Convert.ToDateTime(End_date_pkr.Value.ToString("yyyy-MM-dd"));

            TimeSpan t = d2 - d1;
            double NrOfDays = t.TotalDays;
            return NrOfDays;
        }

        private void Submit_btn_Click(object sender, EventArgs e)
        {
            SaveToMysql();
        }
    }
}
