namespace VCB_TEGAKI
{
    partial class frmLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogIn));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.updateInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chbRememberpasss = new System.Windows.Forms.CheckBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_template = new System.Windows.Forms.ComboBox();
            this.lb_tem = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_viewFb = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(572, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // updateInfoToolStripMenuItem
            // 
            this.updateInfoToolStripMenuItem.Name = "updateInfoToolStripMenuItem";
            this.updateInfoToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.updateInfoToolStripMenuItem.Text = "Software Info";
            this.updateInfoToolStripMenuItem.Click += new System.EventHandler(this.updateInfoToolStripMenuItem_Click);
            // 
            // butLogin
            // 
            this.butLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.butLogin.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.butLogin.Location = new System.Drawing.Point(215, 203);
            this.butLogin.Name = "butLogin";
            this.butLogin.Size = new System.Drawing.Size(168, 66);
            this.butLogin.TabIndex = 5;
            this.butLogin.Text = "LOGIN";
            this.butLogin.UseVisualStyleBackColor = true;
            this.butLogin.Click += new System.EventHandler(this.butLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPassword.Location = new System.Drawing.Point(103, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(458, 31);
            this.txtPassword.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // chbRememberpasss
            // 
            this.chbRememberpasss.AutoSize = true;
            this.chbRememberpasss.Checked = true;
            this.chbRememberpasss.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRememberpasss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbRememberpasss.Location = new System.Drawing.Point(210, 274);
            this.chbRememberpasss.Name = "chbRememberpasss";
            this.chbRememberpasss.Size = new System.Drawing.Size(179, 24);
            this.chbRememberpasss.TabIndex = 20;
            this.chbRememberpasss.Text = "Remember password";
            this.chbRememberpasss.UseVisualStyleBackColor = true;
            this.chbRememberpasss.CheckedChanged += new System.EventHandler(this.chbRememberpasss_CheckedChanged);
            // 
            // txtUserId
            // 
            this.txtUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtUserId.Location = new System.Drawing.Point(103, 58);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(458, 31);
            this.txtUserId.TabIndex = 1;
            this.txtUserId.TextChanged += new System.EventHandler(this.txtUserId_TextChanged);
            this.txtUserId.Leave += new System.EventHandler(this.txtUserId_Leave);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(145, 139);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 24);
            this.lblError.TabIndex = 21;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.Location = new System.Drawing.Point(227, 304);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(145, 27);
            this.btnChangePassword.TabIndex = 23;
            this.btnChangePassword.Text = "Change password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn1.Location = new System.Drawing.Point(103, 30);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(79, 20);
            this.rbtn1.TabIndex = 24;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "Sever 1";
            this.rbtn1.UseVisualStyleBackColor = true;
            this.rbtn1.Visible = false;
            this.rbtn1.CheckedChanged += new System.EventHandler(this.rbtn1_CheckedChanged);
            this.rbtn1.Click += new System.EventHandler(this.rbtn1_Click);
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn2.Location = new System.Drawing.Point(282, 30);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(79, 20);
            this.rbtn2.TabIndex = 25;
            this.rbtn2.TabStop = true;
            this.rbtn2.Text = "Sever 2";
            this.rbtn2.UseVisualStyleBackColor = true;
            this.rbtn2.Visible = false;
            this.rbtn2.Click += new System.EventHandler(this.rbtn2_Click);
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtn3.Location = new System.Drawing.Point(481, 32);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(79, 20);
            this.rbtn3.TabIndex = 26;
            this.rbtn3.TabStop = true;
            this.rbtn3.Text = "Sever 3";
            this.rbtn3.UseVisualStyleBackColor = true;
            this.rbtn3.Visible = false;
            this.rbtn3.Click += new System.EventHandler(this.rbtn3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.Controls.Add(this.cbb_template);
            this.groupBox1.Controls.Add(this.lb_tem);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.rbtn3);
            this.groupBox1.Controls.Add(this.rbtn2);
            this.groupBox1.Controls.Add(this.rbtn1);
            this.groupBox1.Controls.Add(this.btnChangePassword);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.txtUserId);
            this.groupBox1.Controls.Add(this.chbRememberpasss);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.butLogin);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 348);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbb_template
            // 
            this.cbb_template.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_template.FormattingEnabled = true;
            this.cbb_template.Location = new System.Drawing.Point(103, 156);
            this.cbb_template.Name = "cbb_template";
            this.cbb_template.Size = new System.Drawing.Size(457, 32);
            this.cbb_template.TabIndex = 29;
            this.cbb_template.Visible = false;
            // 
            // lb_tem
            // 
            this.lb_tem.AutoSize = true;
            this.lb_tem.Font = new System.Drawing.Font("Century Gothic", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tem.Location = new System.Drawing.Point(17, 161);
            this.lb_tem.Name = "lb_tem";
            this.lb_tem.Size = new System.Drawing.Size(83, 21);
            this.lb_tem.TabIndex = 28;
            this.lb_tem.Text = "Template";
            this.lb_tem.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(482, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_viewFb
            // 
            this.btn_viewFb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_viewFb.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btn_viewFb.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_viewFb.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_viewFb.Location = new System.Drawing.Point(420, 361);
            this.btn_viewFb.Name = "btn_viewFb";
            this.btn_viewFb.Size = new System.Drawing.Size(152, 14);
            this.btn_viewFb.TabIndex = 28;
            this.btn_viewFb.Text = "View FeedBack";
            this.btn_viewFb.UseVisualStyleBackColor = false;
            this.btn_viewFb.Visible = false;
            this.btn_viewFb.Click += new System.EventHandler(this.btn_viewFb_Click);
            // 
            // frmLogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(572, 377);
            this.Controls.Add(this.btn_viewFb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogIn";
            this.Text = "PLUS NNC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogIn_FormClosing);
            this.Load += new System.EventHandler(this.frmLogIn_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogIn_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem updateInfoToolStripMenuItem;
        private System.Windows.Forms.Button butLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox chbRememberpasss;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.RadioButton rbtn3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_viewFb;
        private System.Windows.Forms.Label lb_tem;
        private System.Windows.Forms.ComboBox cbb_template;
    }
}

