
namespace LeaveMangementForm
{
    partial class Leave_Grievances
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grievances_dgv = new System.Windows.Forms.DataGridView();
            this.LeaveRequest_dgv = new System.Windows.Forms.DataGridView();
            this.ViewLeaveDetails_btn = new System.Windows.Forms.Button();
            this.ViewGrievances_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.datagrid_tmr = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Grievances_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeaveRequest_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // Grievances_dgv
            // 
            this.Grievances_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grievances_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Grievances_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.Grievances_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.Grievances_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grievances_dgv.Location = new System.Drawing.Point(50, 306);
            this.Grievances_dgv.Name = "Grievances_dgv";
            this.Grievances_dgv.RowHeadersWidth = 51;
            this.Grievances_dgv.RowTemplate.Height = 24;
            this.Grievances_dgv.Size = new System.Drawing.Size(730, 165);
            this.Grievances_dgv.TabIndex = 2;
            // 
            // LeaveRequest_dgv
            // 
            this.LeaveRequest_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LeaveRequest_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LeaveRequest_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.LeaveRequest_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.LeaveRequest_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LeaveRequest_dgv.Location = new System.Drawing.Point(50, 45);
            this.LeaveRequest_dgv.Name = "LeaveRequest_dgv";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LeaveRequest_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.LeaveRequest_dgv.RowHeadersWidth = 51;
            this.LeaveRequest_dgv.RowTemplate.Height = 24;
            this.LeaveRequest_dgv.Size = new System.Drawing.Size(730, 173);
            this.LeaveRequest_dgv.TabIndex = 0;
            // 
            // ViewLeaveDetails_btn
            // 
            this.ViewLeaveDetails_btn.BackColor = System.Drawing.Color.Transparent;
            this.ViewLeaveDetails_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.View;
            this.ViewLeaveDetails_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewLeaveDetails_btn.FlatAppearance.BorderSize = 0;
            this.ViewLeaveDetails_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewLeaveDetails_btn.Location = new System.Drawing.Point(596, 235);
            this.ViewLeaveDetails_btn.Name = "ViewLeaveDetails_btn";
            this.ViewLeaveDetails_btn.Size = new System.Drawing.Size(184, 45);
            this.ViewLeaveDetails_btn.TabIndex = 1;
            this.ViewLeaveDetails_btn.UseVisualStyleBackColor = false;
            this.ViewLeaveDetails_btn.Click += new System.EventHandler(this.ViewLeaveDetails_btn_Click);
            // 
            // ViewGrievances_btn
            // 
            this.ViewGrievances_btn.BackColor = System.Drawing.Color.Transparent;
            this.ViewGrievances_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.View;
            this.ViewGrievances_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewGrievances_btn.FlatAppearance.BorderSize = 0;
            this.ViewGrievances_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewGrievances_btn.Location = new System.Drawing.Point(596, 493);
            this.ViewGrievances_btn.Name = "ViewGrievances_btn";
            this.ViewGrievances_btn.Size = new System.Drawing.Size(184, 45);
            this.ViewGrievances_btn.TabIndex = 3;
            this.ViewGrievances_btn.UseVisualStyleBackColor = false;
            this.ViewGrievances_btn.Click += new System.EventHandler(this.ViewGrievances_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pending Leave Requests ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold SemiConden", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(50, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pending Grievances / Resignations ";
            // 
            // datagrid_tmr
            // 
            this.datagrid_tmr.Interval = 5000;
            this.datagrid_tmr.Tick += new System.EventHandler(this.datagrid_tmr_Tick);
            // 
            // Leave_Grievances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(807, 567);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ViewGrievances_btn);
            this.Controls.Add(this.ViewLeaveDetails_btn);
            this.Controls.Add(this.LeaveRequest_dgv);
            this.Controls.Add(this.Grievances_dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Leave_Grievances";
            this.Text = "Leave_Grievances";
            this.Activated += new System.EventHandler(this.Leave_Grievances_Activated);
            this.Load += new System.EventHandler(this.Leave_Grievances_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grievances_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeaveRequest_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grievances_dgv;
        private System.Windows.Forms.DataGridView LeaveRequest_dgv;
        private System.Windows.Forms.Button ViewLeaveDetails_btn;
        private System.Windows.Forms.Button ViewGrievances_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer datagrid_tmr;
    }
}