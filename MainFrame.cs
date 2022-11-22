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
using System.IO;
using RECA_EmployeeMangementSystem;
using RecaPayroll;
//using AdminEmpRegForm;


namespace LeaveMangementForm
{
    public partial class MainFrame : Form
    {
        public MainFrame()
        {
            InitializeComponent();
        }
        public string PassEmp_ID, EMP_Type;
        private Form currentChildForm;
        private object iconCurrentChildForm;
        private void MainFrame_Load(object sender, EventArgs e)     // Load the form.
        {
            CurrentTime_tmr.Start();                // Start the timer
            displayButton();                // Switch between Admin and Employee buttons
            HomePage HM = new HomePage() { TopLevel = false, TopMost = true };
            SubForm_pnl.Controls.Add(HM);
            SubFormTitle_lbl.Text = "Home Page";
            OpenChildForm(HM);     // Dispaly the form on panel and hide the exist one.
        }

        private void CurrentTime_tmr_Tick(object sender, EventArgs e)       // Set the current day and time.
        {
            CurrentTime_lbl.Text = DateTime.Now.ToShortTimeString();
            CurrentDate_lbl.Text = DateTime.Now.ToLongDateString();

        }

        private void LeaveMg_Menu_btn_Click(object sender, EventArgs e)     // Click the Leave management Button
        {
            setButton();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\LeaveManagement_Click.png");  // Change the button image when click
            LeaveMg_Menu_btn.BackgroundImage = B;
            LeaveManagement LMF = new LeaveManagement() { TopLevel = false, TopMost = true };           // Load the leave management subform into the main frame.
            SubForm_pnl.Controls.Add(LMF);
            SubFormTitle_lbl.Text = "Leave Management";
            LMF.Emp_ID = PassEmp_ID;
            OpenChildForm(LMF);     // Dispaly the form on panel and hide the exist one.

        }

        private void Leave_Grievances_btn_Click(object sender, EventArgs e)
        {
            setButton();
            LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\Leave_Grievances_Button_Click.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            SubForm_pnl.Controls.Add(LGF);
            SubFormTitle_lbl.Text = "Leave and Grievances";
            LGF.Emp_ID = PassEmp_ID;
            OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.

        }
        public void OpenChildForm(Form childform)          // I took this part from Tati's Code in Admin Forms.
        {
            if (iconCurrentChildForm != null)
            {
                //open a specific fomr
                currentChildForm.Close();
            }
            currentChildForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            childform.BringToFront();
            childform.Show();
        }
               
        public void setButton()
        {
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\LeaveManagement.png");  // Change the button image when click
            LeaveMg_Menu_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Images\Leave_Grievances_Button.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Images\Registration_btn.png");  // Change the button image when click
            Registration_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Images\AttendanceManagement_btn.png");  // Change the button image when click
            AttendanceManagement_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Images\PayrollPage_btn.png");  // Change the button image when click
            PayrollPage_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Resources\ViewFinalRep_btn.png");  // Change the button image when click
            ViewFinalRep_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Images\AttendanceManagement_btn.png");  // Change the button image when click
            Emp_AttendanceManagment_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Resources\ViewSalaryDetails_btn.png");  // Change the button image when click
            ViewSalaryDetails_btn.BackgroundImage = B;
            B = new Bitmap(@"..\..\..\RECA_EMS\Resources\Personal_Grievances_btn.png");  // Change the button image when click
            Personal_Grievances_btn.BackgroundImage = B;
        }
        public void displayButton()
        {
            if (EMP_Type == "ADM")
            {
                DisplayAdmin_btn();
            }
            else
            {
                DisplayEmployee_btn();
            }
        }
        public void DisplayAdmin_btn()
        {
            LeaveMg_Menu_btn.Visible = false;
            Leave_Grievances_btn.Visible = true;
            Registration_btn.Visible = true;
            AttendanceManagement_btn.Visible = true;
            PayrollPage_btn.Visible = true;
            ViewFinalRep_btn.Visible = true;
            Emp_AttendanceManagment_btn.Visible = false;
            ViewSalaryDetails_btn.Visible = false;
            Personal_Grievances_btn.Visible = false;

        }
        public void DisplayEmployee_btn()
        {
            LeaveMg_Menu_btn.Visible = true;
            Leave_Grievances_btn.Visible = false;
            Registration_btn.Visible = true;
            AttendanceManagement_btn.Visible = false;
            PayrollPage_btn.Visible = false;
            Emp_AttendanceManagment_btn.Visible = true;
            ViewSalaryDetails_btn.Visible = true;
            Personal_Grievances_btn.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)          // LogOut Button
        {
            setButton();
            LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\LogOut_btn_Click.png");  // Change the button image when click
            Leave_Grievances_btn.BackgroundImage = B;
            LogIn_Form LGN = new LogIn_Form();
            LGN.Show();
            this.Close();
        }

        private void AttendanceManagement_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\AttendanceManagement_Click_btn.png");  // Change the button image when click
            Emp_AttendanceManagment_btn.BackgroundImage = B;
            Attendance Att = new Attendance() { TopLevel = false, TopMost = true };     // Load the Employee Attendance subform into the main frame.
            SubForm_pnl.Controls.Add(Att);
            SubFormTitle_lbl.Text = "Attendance";
            Att.Emp_ID = PassEmp_ID;
            Att.EMP_Type = EMP_Type;
            OpenChildForm(Att);     // Dispaly the form on panel and hide the exist one.
        }

        private void PayrollPage_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\PayrollPage_Click_btn.png");  // Change the button image when click
            PayrollPage_btn.BackgroundImage = B;
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            //SubForm_pnl.Controls.Add(LGF);
            //SubFormTitle_lbl.Text = "Leave and Grievances";
            //LGF.Emp_ID = PassEmp_ID;
            //OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.
        }

        private void ViewFinalRep_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
        
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Resources\ViewFinalRep_Click_btn.png");  // Change the button image when click
            ViewFinalRep_btn.BackgroundImage = B;
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            //SubForm_pnl.Controls.Add(LGF);
            //SubFormTitle_lbl.Text = "Leave and Grievances";
            //LGF.Emp_ID = PassEmp_ID;
            //OpenChildForm(LGF);     // Dispaly the form on panel and hide the exist one.
        }

        private void Emp_AttendanceManagment_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\AttendanceManagement_Click_btn.png");  // Change the button image when click
            Emp_AttendanceManagment_btn.BackgroundImage = B;
            Attendance Att = new Attendance() { TopLevel = false, TopMost = true };     // Load the Employee Attendance subform into the main frame.
            SubForm_pnl.Controls.Add(Att);
            SubFormTitle_lbl.Text = "Attendance";
            Att.Emp_ID = PassEmp_ID;
            Att.EMP_Type = EMP_Type;
            OpenChildForm(Att);     // Dispaly the form on panel and hide the exist one.
        }

        private void ViewSalaryDetails_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Resources\ViewSalaryDetails_Click_btn.png");  // Change the button image when click
            ViewSalaryDetails_btn.BackgroundImage = B;
            Emp_ViewSalaryForm EVS = new Emp_ViewSalaryForm() { TopLevel = false, TopMost = true };
            //Leave_Grievances LGF = new Leave_Grievances() { TopLevel = false, TopMost = true };           // Load the leave Grievances subform into the main frame.
            SubForm_pnl.Controls.Add(EVS);
            SubFormTitle_lbl.Text = "View Salary Details";
            EVS.Emp_ID = PassEmp_ID;
            OpenChildForm(EVS);     // Dispaly the form on panel and hide the exist one.
        }

        private void Personal_Grievances_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Resources\Personal_Grievances_Click_btn.png");  // Change the button image when click
            Personal_Grievances_btn.BackgroundImage = B;
            EmployeeGrievanceForm EG = new EmployeeGrievanceForm(){ TopLevel = false, TopMost = true };           // Load the Grievances and resigning subform into the main frame.
            SubForm_pnl.Controls.Add(EG);
            SubFormTitle_lbl.Text = "Grievances and Resigning";
            EG.Emp_ID = PassEmp_ID;
            OpenChildForm(EG);     // Dispaly the form on panel and hide the exist one.
        }

        private void Logo_btn_Click(object sender, EventArgs e)         // Display the home page.
        {
            HomePage HM = new HomePage() { TopLevel = false, TopMost = true };
            SubForm_pnl.Controls.Add(HM);
            SubFormTitle_lbl.Text = "Home Page";
            OpenChildForm(HM);     // Dispaly the form on panel and hide the exist one.
        }

        private void Registration_btn_Click(object sender, EventArgs e)
        {
            setButton();
            //LeaveManagement LMF = new LeaveManagement();
            Bitmap B = new Bitmap(@"..\..\..\RECA_EMS\Images\Registration_Click_btn.png");  // Change the button image when click
            Registration_btn.BackgroundImage = B;
            Emp_Registration ER = new Emp_Registration() { TopLevel = false, TopMost = true };  // Load the employee registration subform into the main frame.
            SubForm_pnl.Controls.Add(ER);
            SubFormTitle_lbl.Text = "New Employee Registration";
            ER.EMP_Type = EMP_Type;
            ER.empID = PassEmp_ID;
            OpenChildForm(ER);     // Dispaly the form on panel and hide the exist one.
        }


    }
}
