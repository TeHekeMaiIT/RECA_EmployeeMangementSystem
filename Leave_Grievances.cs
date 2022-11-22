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
    public partial class Leave_Grievances : Form
    {
        public Leave_Grievances()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        public string Emp_ID;
        public string ConnectionString; // = "server=localhost;user id=root;password=Dbms@2022;persistsecurityinfo=True;database=human_resources";
        private void Leave_Grievances_Load(object sender, EventArgs e)
        {
            ConnectionString = con.connectionString();
            datagrid_tmr.Start();
            Reload();           // Fill The grids.
         
        }
        public void FillLeaveDataGrid()
        {
            string sqlCommand = "SELECT LE_ID as No, concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as Employee," +
                "human_resources.leave.LE_Type as Type,human_resources.leave.LE_Reason as Reason," +
                "human_resources.leave.LE_Sick_Leave,human_resources.leave.LE_Annual_Leave " +
                " FROM human_resources.employee,human_resources.leave" +
                " Where (employee.Emp_ID = human_resources.leave.Emp_ID)" +
                "And (human_resources.leave.LE_Approved is null)";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                LeaveRequest_dgv.DataSource = dt;
                LeaveRequest_dgv.Enabled = false;
            }
            else
            {
                LeaveRequest_dgv.DataSource = dt;
                LeaveRequest_dgv.Columns[0].Width = 50;// The id column 
                LeaveRequest_dgv.Columns[1].Width = 100;// The employee name columln
                LeaveRequest_dgv.Columns[2].Width = 100;// The leave type columln
                LeaveRequest_dgv.Columns[3].Width = 300;// The reason columln
                LeaveRequest_dgv.Columns[4].Visible = false;
                LeaveRequest_dgv.Columns[5].Visible = false;
                for (int i = 0; i < LeaveRequest_dgv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(LeaveRequest_dgv.Rows[i].Cells[4].Value) < 0)
                    {
                        LeaveRequest_dgv.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                        LeaveRequest_dgv.Rows[i].Cells[0].Style.ForeColor = Color.Red;
                    }
                }
               

            }
            if (LeaveRequest_dgv.Rows.Count == 1)
                ViewLeaveDetails_btn.Enabled = false;
            else
                ViewLeaveDetails_btn.Enabled = true;


        }

        public void Reload()
        {
            FillLeaveDataGrid();
            FillGrievancesDataGrid();
        }
        
        public void FillGrievancesDataGrid()
        {
            string sqlCommand = "SELECT distinct human_resources.grievances_resigning.GR_ID, " +
                "concat(human_resources.employee.Emp_FName,' ',human_resources.employee.Emp_LName) as EmployeeName," +
                "human_resources.grievances_resigning.Reason" +
                " FROM human_resources.grievances_resigning, human_resources.employee " +
                "where (human_resources.employee.Emp_ID = human_resources.grievances_resigning.Emp_ID)" +
                " and Admin_Reply is null group by GR_ID";
            MySqlConnection mySqlConnection = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand(sqlCommand, mySqlConnection);
            mySqlConnection.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            mySqlConnection.Close();

            if (dt.Rows.Count == 0)
            {
                LeaveRequest_dgv.DataSource = dt;
                LeaveRequest_dgv.Enabled = false;
            }
            else
            {
                Grievances_dgv.DataSource = dt;
                Grievances_dgv.Columns[0].Width = 50;// The id column 
                Grievances_dgv.Columns[1].Width = 100;// The employee name column
                Grievances_dgv.Columns[2].Width = 500;// The reason column
            }
            if (Grievances_dgv.Rows.Count == 1)
                ViewGrievances_btn.Enabled = false;
            else
                ViewGrievances_btn.Enabled = true;
        }

        private void ViewLeaveDetails_btn_Click(object sender, EventArgs e)
        {
            int rowindex = LeaveRequest_dgv.CurrentCell.RowIndex;

            Admin_Detail_Leave_Form ADLF = new Admin_Detail_Leave_Form(this);

            ADLF.Leave_ID =  LeaveRequest_dgv.Rows[rowindex].Cells[0].Value.ToString();
             
            ADLF.Tag = this;
            ADLF.StartPosition = FormStartPosition.CenterScreen;
            ADLF.Location = this.Location;
            ADLF.Show(this);
        }
       


        private void ViewGrievances_btn_Click(object sender, EventArgs e)
        {
            int rowindex = Grievances_dgv.CurrentCell.RowIndex;
            //int columnindex = Grievances_dgv.CurrentCell.ColumnIndex;
            Admin_Detail_Grievances_Form ADGF = new Admin_Detail_Grievances_Form(this);               // Needs to be changed
            ADGF.GR_ID = Grievances_dgv.Rows[rowindex].Cells[0].Value.ToString();
            ADGF.Admin_ID = Emp_ID;
            ADGF.Tag = this;
            ADGF.StartPosition = FormStartPosition.CenterScreen;
            ADGF.Location = this.Location;
            ADGF.Show(this);

        }

        private void Leave_Grievances_Activated(object sender, EventArgs e)
        {
            FillLeaveDataGrid();
            FillGrievancesDataGrid();
            this.Refresh();
        }

        private void datagrid_tmr_Tick(object sender, EventArgs e)
        {
            Reload();
            datagrid_tmr.Start();
        }
    }
}
