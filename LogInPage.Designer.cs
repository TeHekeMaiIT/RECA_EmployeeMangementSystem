
namespace LeaveMangementForm
{
    partial class LogInPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInPage));
            this.LogIn_pnl = new System.Windows.Forms.Panel();
            this.resetLink_lbl = new System.Windows.Forms.LinkLabel();
            this.Password_tbx = new System.Windows.Forms.TextBox();
            this.UserName_tbx = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Login_btn = new System.Windows.Forms.Button();
            this.CreateAccount_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LogIn_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogIn_pnl
            // 
            this.LogIn_pnl.BackColor = System.Drawing.Color.Transparent;
            this.LogIn_pnl.BackgroundImage = global::LeaveMangementForm.Properties.Resources.LoginSupBackGround01;
            this.LogIn_pnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogIn_pnl.Controls.Add(this.label4);
            this.LogIn_pnl.Controls.Add(this.resetLink_lbl);
            this.LogIn_pnl.Controls.Add(this.Password_tbx);
            this.LogIn_pnl.Controls.Add(this.UserName_tbx);
            this.LogIn_pnl.Location = new System.Drawing.Point(331, 261);
            this.LogIn_pnl.Name = "LogIn_pnl";
            this.LogIn_pnl.Size = new System.Drawing.Size(425, 331);
            this.LogIn_pnl.TabIndex = 0;
            this.LogIn_pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.LogIn_pnl_Paint);
            // 
            // resetLink_lbl
            // 
            this.resetLink_lbl.AutoSize = true;
            this.resetLink_lbl.BackColor = System.Drawing.Color.LightGray;
            this.resetLink_lbl.Font = new System.Drawing.Font("Bahnschrift Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetLink_lbl.LinkColor = System.Drawing.Color.Black;
            this.resetLink_lbl.Location = new System.Drawing.Point(250, 257);
            this.resetLink_lbl.Name = "resetLink_lbl";
            this.resetLink_lbl.Size = new System.Drawing.Size(38, 18);
            this.resetLink_lbl.TabIndex = 4;
            this.resetLink_lbl.TabStop = true;
            this.resetLink_lbl.Text = "RESET";
            // 
            // Password_tbx
            // 
            this.Password_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_tbx.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.Password_tbx.Location = new System.Drawing.Point(70, 196);
            this.Password_tbx.Name = "Password_tbx";
            this.Password_tbx.Size = new System.Drawing.Size(296, 24);
            this.Password_tbx.TabIndex = 1;
            this.Password_tbx.Text = "Password ...";
            this.Password_tbx.UseSystemPasswordChar = true;
            // 
            // UserName_tbx
            // 
            this.UserName_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserName_tbx.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.UserName_tbx.Location = new System.Drawing.Point(70, 155);
            this.UserName_tbx.Name = "UserName_tbx";
            this.UserName_tbx.Size = new System.Drawing.Size(296, 24);
            this.UserName_tbx.TabIndex = 0;
            this.UserName_tbx.Text = "User Name ... ";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::LeaveMangementForm.Properties.Resources.Logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(489, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 109);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(511, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "RECA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(360, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "The only place where SUCCESS comes before WORKS in ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(504, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "the dictionary";
            // 
            // Login_btn
            // 
            this.Login_btn.BackColor = System.Drawing.Color.Transparent;
            this.Login_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.LoginButton;
            this.Login_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Login_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Login_btn.FlatAppearance.BorderSize = 0;
            this.Login_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_btn.Location = new System.Drawing.Point(542, 580);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(213, 78);
            this.Login_btn.TabIndex = 2;
            this.Login_btn.UseVisualStyleBackColor = false;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // CreateAccount_btn
            // 
            this.CreateAccount_btn.BackColor = System.Drawing.Color.Transparent;
            this.CreateAccount_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.CreateAccountButton;
            this.CreateAccount_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CreateAccount_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateAccount_btn.FlatAppearance.BorderSize = 0;
            this.CreateAccount_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccount_btn.Location = new System.Drawing.Point(329, 580);
            this.CreateAccount_btn.Name = "CreateAccount_btn";
            this.CreateAccount_btn.Size = new System.Drawing.Size(213, 77);
            this.CreateAccount_btn.TabIndex = 3;
            this.CreateAccount_btn.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(100, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Forget your password?";
            // 
            // LogInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LeaveMangementForm.Properties.Resources.LoginBackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1101, 780);
            this.Controls.Add(this.CreateAccount_btn);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LogIn_pnl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogInPage";
            this.Text = "RECA";
            this.LogIn_pnl.ResumeLayout(false);
            this.LogIn_pnl.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel LogIn_pnl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password_tbx;
        private System.Windows.Forms.TextBox UserName_tbx;
        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.Button CreateAccount_btn;
        private System.Windows.Forms.LinkLabel resetLink_lbl;
        private System.Windows.Forms.Label label4;
    }
}