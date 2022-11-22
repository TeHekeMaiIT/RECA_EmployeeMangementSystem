
namespace LeaveMangementForm
{
    partial class SendEmail_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendEmail_Form));
            this.From_lbl = new System.Windows.Forms.Label();
            this.From_tbx = new System.Windows.Forms.TextBox();
            this.Subject_tbx = new System.Windows.Forms.TextBox();
            this.Subject_lbl = new System.Windows.Forms.Label();
            this.To_tbx = new System.Windows.Forms.TextBox();
            this.To_lbl = new System.Windows.Forms.Label();
            this.message_lbl = new System.Windows.Forms.Label();
            this.Message_tbx = new System.Windows.Forms.TextBox();
            this.Pass_tbx = new System.Windows.Forms.TextBox();
            this.Password_lbl = new System.Windows.Forms.Label();
            this.Send_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // From_lbl
            // 
            this.From_lbl.AutoSize = true;
            this.From_lbl.Location = new System.Drawing.Point(61, 234);
            this.From_lbl.Name = "From_lbl";
            this.From_lbl.Size = new System.Drawing.Size(52, 17);
            this.From_lbl.TabIndex = 17;
            this.From_lbl.Text = "From : ";
            // 
            // From_tbx
            // 
            this.From_tbx.Location = new System.Drawing.Point(123, 234);
            this.From_tbx.MaxLength = 30;
            this.From_tbx.Name = "From_tbx";
            this.From_tbx.Size = new System.Drawing.Size(387, 22);
            this.From_tbx.TabIndex = 1;
            // 
            // Subject_tbx
            // 
            this.Subject_tbx.Location = new System.Drawing.Point(123, 283);
            this.Subject_tbx.Name = "Subject_tbx";
            this.Subject_tbx.Size = new System.Drawing.Size(387, 22);
            this.Subject_tbx.TabIndex = 2;
            // 
            // Subject_lbl
            // 
            this.Subject_lbl.AutoSize = true;
            this.Subject_lbl.Location = new System.Drawing.Point(61, 283);
            this.Subject_lbl.Name = "Subject_lbl";
            this.Subject_lbl.Size = new System.Drawing.Size(67, 17);
            this.Subject_lbl.TabIndex = 13;
            this.Subject_lbl.Text = "Subject : ";
            // 
            // To_tbx
            // 
            this.To_tbx.Location = new System.Drawing.Point(123, 183);
            this.To_tbx.Name = "To_tbx";
            this.To_tbx.Size = new System.Drawing.Size(387, 22);
            this.To_tbx.TabIndex = 0;
            // 
            // To_lbl
            // 
            this.To_lbl.AutoSize = true;
            this.To_lbl.Location = new System.Drawing.Point(61, 183);
            this.To_lbl.Name = "To_lbl";
            this.To_lbl.Size = new System.Drawing.Size(37, 17);
            this.To_lbl.TabIndex = 15;
            this.To_lbl.Text = "To : ";
            // 
            // message_lbl
            // 
            this.message_lbl.AutoSize = true;
            this.message_lbl.Location = new System.Drawing.Point(61, 329);
            this.message_lbl.Name = "message_lbl";
            this.message_lbl.Size = new System.Drawing.Size(77, 17);
            this.message_lbl.TabIndex = 12;
            this.message_lbl.Text = "Message : ";
            // 
            // Message_tbx
            // 
            this.Message_tbx.Location = new System.Drawing.Point(64, 358);
            this.Message_tbx.Multiline = true;
            this.Message_tbx.Name = "Message_tbx";
            this.Message_tbx.Size = new System.Drawing.Size(446, 246);
            this.Message_tbx.TabIndex = 3;
            // 
            // Pass_tbx
            // 
            this.Pass_tbx.Location = new System.Drawing.Point(183, 614);
            this.Pass_tbx.Name = "Pass_tbx";
            this.Pass_tbx.Size = new System.Drawing.Size(327, 22);
            this.Pass_tbx.TabIndex = 4;
            this.Pass_tbx.UseSystemPasswordChar = true;
            // 
            // Password_lbl
            // 
            this.Password_lbl.AutoSize = true;
            this.Password_lbl.Location = new System.Drawing.Point(61, 614);
            this.Password_lbl.Name = "Password_lbl";
            this.Password_lbl.Size = new System.Drawing.Size(123, 17);
            this.Password_lbl.TabIndex = 11;
            this.Password_lbl.Text = "Email Password  : ";
            // 
            // Send_btn
            // 
            this.Send_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.Send_btn;
            this.Send_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Send_btn.FlatAppearance.BorderSize = 0;
            this.Send_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Send_btn.Location = new System.Drawing.Point(241, 663);
            this.Send_btn.Name = "Send_btn";
            this.Send_btn.Size = new System.Drawing.Size(132, 33);
            this.Send_btn.TabIndex = 5;
            this.Send_btn.UseVisualStyleBackColor = true;
            this.Send_btn.Click += new System.EventHandler(this.Send_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.BackgroundImage = global::LeaveMangementForm.Properties.Resources.Email_Cancel_btn;
            this.Cancel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancel_btn.FlatAppearance.BorderSize = 0;
            this.Cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel_btn.Location = new System.Drawing.Point(377, 663);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(132, 33);
            this.Cancel_btn.TabIndex = 6;
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LeaveMangementForm.Properties.Resources.email_14733;
            this.pictureBox1.Location = new System.Drawing.Point(223, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SendEmail_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 715);
            this.Controls.Add(this.Pass_tbx);
            this.Controls.Add(this.Password_lbl);
            this.Controls.Add(this.Send_btn);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Message_tbx);
            this.Controls.Add(this.message_lbl);
            this.Controls.Add(this.To_tbx);
            this.Controls.Add(this.To_lbl);
            this.Controls.Add(this.Subject_tbx);
            this.Controls.Add(this.Subject_lbl);
            this.Controls.Add(this.From_tbx);
            this.Controls.Add(this.From_lbl);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SendEmail_Form";
            this.Text = "Send Email";
            this.Load += new System.EventHandler(this.SendEmail_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label From_lbl;
        private System.Windows.Forms.TextBox From_tbx;
        private System.Windows.Forms.TextBox Subject_tbx;
        private System.Windows.Forms.Label Subject_lbl;
        private System.Windows.Forms.TextBox To_tbx;
        private System.Windows.Forms.Label To_lbl;
        private System.Windows.Forms.Label message_lbl;
        private System.Windows.Forms.TextBox Message_tbx;
        private System.Windows.Forms.Button Cancel_btn;
        private System.Windows.Forms.Button Send_btn;
        private System.Windows.Forms.TextBox Pass_tbx;
        private System.Windows.Forms.Label Password_lbl;
    }
}