namespace VCB_Entry.Admin
{
    partial class Form_Crop
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbimg = new System.Windows.Forms.PictureBox();
            this.grid_1 = new DevExpress.XtraGrid.GridControl();
            this.gridV_1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.rdo_ROle1 = new System.Windows.Forms.RadioButton();
            this.btn_Del_truong1 = new System.Windows.Forms.Button();
            this.cbb_Role1 = new System.Windows.Forms.ComboBox();
            this.rdo_Role = new System.Windows.Forms.RadioButton();
            this.btn_brow = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbb_form = new System.Windows.Forms.ComboBox();
            this.btnsubmit = new System.Windows.Forms.Button();
            this.grd_poi = new DevExpress.XtraGrid.GridControl();
            this.grdV_poi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btndeldot = new System.Windows.Forms.Button();
            this.cbb_role_img = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_poi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdV_poi)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitContainer1_Panel1_MouseDown);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grid_1);
            this.splitContainer1.Panel2.Controls.Add(this.rdo_ROle1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Del_truong1);
            this.splitContainer1.Panel2.Controls.Add(this.cbb_Role1);
            this.splitContainer1.Panel2.Controls.Add(this.rdo_Role);
            this.splitContainer1.Panel2.Controls.Add(this.btn_brow);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.cbb_form);
            this.splitContainer1.Panel2.Controls.Add(this.btnsubmit);
            this.splitContainer1.Panel2.Controls.Add(this.grd_poi);
            this.splitContainer1.Panel2.Controls.Add(this.btndeldot);
            this.splitContainer1.Panel2.Controls.Add(this.cbb_role_img);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 726);
            this.splitContainer1.SplitterDistance = 809;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pbimg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 726);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(674, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Zoomin: \r\nCtrl + Left Click";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(674, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Zoomout: \r\nCtrl + Right Click";
            // 
            // pbimg
            // 
            this.pbimg.Location = new System.Drawing.Point(12, 12);
            this.pbimg.Name = "pbimg";
            this.pbimg.Size = new System.Drawing.Size(100, 50);
            this.pbimg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbimg.TabIndex = 1;
            this.pbimg.TabStop = false;
            this.pbimg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbimg_MouseDown);
            this.pbimg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbimg_MouseMove);
            this.pbimg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbimg_MouseUp);
            // 
            // grid_1
            // 
            this.grid_1.Location = new System.Drawing.Point(7, 453);
            this.grid_1.MainView = this.gridV_1;
            this.grid_1.Name = "grid_1";
            this.grid_1.Size = new System.Drawing.Size(378, 194);
            this.grid_1.TabIndex = 37;
            this.grid_1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_1});
            // 
            // gridV_1
            // 
            this.gridV_1.GridControl = this.grid_1;
            this.gridV_1.Name = "gridV_1";
            this.gridV_1.OptionsBehavior.ReadOnly = true;
            this.gridV_1.OptionsCustomization.AllowFilter = false;
            this.gridV_1.OptionsCustomization.AllowSort = false;
            this.gridV_1.OptionsView.ShowGroupPanel = false;
            // 
            // rdo_ROle1
            // 
            this.rdo_ROle1.AutoSize = true;
            this.rdo_ROle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_ROle1.ForeColor = System.Drawing.Color.Red;
            this.rdo_ROle1.Location = new System.Drawing.Point(115, 382);
            this.rdo_ROle1.Name = "rdo_ROle1";
            this.rdo_ROle1.Size = new System.Drawing.Size(158, 23);
            this.rdo_ROle1.TabIndex = 36;
            this.rdo_ROle1.Text = "ROLE TRƯỜNG 1";
            this.rdo_ROle1.UseVisualStyleBackColor = true;
            this.rdo_ROle1.CheckedChanged += new System.EventHandler(this.rdo_ROle1_CheckedChanged);
            // 
            // btn_Del_truong1
            // 
            this.btn_Del_truong1.BackColor = System.Drawing.Color.Tomato;
            this.btn_Del_truong1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Del_truong1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Del_truong1.ForeColor = System.Drawing.Color.White;
            this.btn_Del_truong1.Location = new System.Drawing.Point(320, 403);
            this.btn_Del_truong1.Name = "btn_Del_truong1";
            this.btn_Del_truong1.Size = new System.Drawing.Size(56, 39);
            this.btn_Del_truong1.TabIndex = 35;
            this.btn_Del_truong1.Text = "X";
            this.btn_Del_truong1.UseVisualStyleBackColor = false;
            this.btn_Del_truong1.Click += new System.EventHandler(this.btn_truong1_Click);
            // 
            // cbb_Role1
            // 
            this.cbb_Role1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Role1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Role1.FormattingEnabled = true;
            this.cbb_Role1.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbb_Role1.Location = new System.Drawing.Point(76, 411);
            this.cbb_Role1.Name = "cbb_Role1";
            this.cbb_Role1.Size = new System.Drawing.Size(211, 31);
            this.cbb_Role1.TabIndex = 34;
            this.cbb_Role1.SelectedIndexChanged += new System.EventHandler(this.cbb_Role1_SelectedIndexChanged);
            // 
            // rdo_Role
            // 
            this.rdo_Role.AutoSize = true;
            this.rdo_Role.Checked = true;
            this.rdo_Role.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Role.Location = new System.Drawing.Point(125, 126);
            this.rdo_Role.Name = "rdo_Role";
            this.rdo_Role.Size = new System.Drawing.Size(119, 23);
            this.rdo_Role.TabIndex = 33;
            this.rdo_Role.TabStop = true;
            this.rdo_Role.Text = "ROLE NHẬP";
            this.rdo_Role.UseVisualStyleBackColor = true;
            this.rdo_Role.CheckedChanged += new System.EventHandler(this.rdo_Role_CheckedChanged);
            // 
            // btn_brow
            // 
            this.btn_brow.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_brow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_brow.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_brow.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_brow.Location = new System.Drawing.Point(47, 23);
            this.btn_brow.Name = "btn_brow";
            this.btn_brow.Size = new System.Drawing.Size(300, 39);
            this.btn_brow.TabIndex = 32;
            this.btn_brow.Text = "Browers Image Draw";
            this.btn_brow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_brow.UseVisualStyleBackColor = false;
            this.btn_brow.Click += new System.EventHandler(this.btn_brow_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "FORM";
            // 
            // cbb_form
            // 
            this.cbb_form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_form.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_form.FormattingEnabled = true;
            this.cbb_form.Location = new System.Drawing.Point(76, 81);
            this.cbb_form.Name = "cbb_form";
            this.cbb_form.Size = new System.Drawing.Size(211, 39);
            this.cbb_form.TabIndex = 30;
            this.cbb_form.SelectedIndexChanged += new System.EventHandler(this.cbb_form_SelectedIndexChanged);
            // 
            // btnsubmit
            // 
            this.btnsubmit.BackColor = System.Drawing.Color.OrangeRed;
            this.btnsubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnsubmit.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsubmit.ForeColor = System.Drawing.Color.White;
            this.btnsubmit.Location = new System.Drawing.Point(125, 659);
            this.btnsubmit.Name = "btnsubmit";
            this.btnsubmit.Size = new System.Drawing.Size(148, 61);
            this.btnsubmit.TabIndex = 28;
            this.btnsubmit.Text = "Submit";
            this.btnsubmit.UseVisualStyleBackColor = false;
            this.btnsubmit.Click += new System.EventHandler(this.btnsubmit_Click);
            // 
            // grd_poi
            // 
            this.grd_poi.Location = new System.Drawing.Point(7, 192);
            this.grd_poi.MainView = this.grdV_poi;
            this.grd_poi.Name = "grd_poi";
            this.grd_poi.Size = new System.Drawing.Size(378, 174);
            this.grd_poi.TabIndex = 27;
            this.grd_poi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdV_poi});
            // 
            // grdV_poi
            // 
            this.grdV_poi.GridControl = this.grd_poi;
            this.grdV_poi.Name = "grdV_poi";
            this.grdV_poi.OptionsBehavior.ReadOnly = true;
            this.grdV_poi.OptionsCustomization.AllowFilter = false;
            this.grdV_poi.OptionsCustomization.AllowSort = false;
            this.grdV_poi.OptionsView.ShowGroupPanel = false;
            // 
            // btndeldot
            // 
            this.btndeldot.BackColor = System.Drawing.Color.Tomato;
            this.btndeldot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndeldot.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndeldot.ForeColor = System.Drawing.Color.White;
            this.btndeldot.Location = new System.Drawing.Point(320, 147);
            this.btndeldot.Name = "btndeldot";
            this.btndeldot.Size = new System.Drawing.Size(56, 39);
            this.btndeldot.TabIndex = 26;
            this.btndeldot.Text = "X";
            this.btndeldot.UseVisualStyleBackColor = false;
            this.btndeldot.Click += new System.EventHandler(this.btndeldot_Click);
            // 
            // cbb_role_img
            // 
            this.cbb_role_img.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_role_img.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_role_img.FormattingEnabled = true;
            this.cbb_role_img.Location = new System.Drawing.Point(76, 155);
            this.cbb_role_img.Name = "cbb_role_img";
            this.cbb_role_img.Size = new System.Drawing.Size(211, 31);
            this.cbb_role_img.TabIndex = 24;
            // 
            // Form_Crop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 726);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form_Crop";
            this.Text = "Form Crop Plus NNC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Crop_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_poi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdV_poi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pbimg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbb_role_img;
        private System.Windows.Forms.Button btndeldot;
        private DevExpress.XtraGrid.GridControl grd_poi;
        private DevExpress.XtraGrid.Views.Grid.GridView grdV_poi;
        private System.Windows.Forms.Button btnsubmit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbb_form;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_brow;
        private System.Windows.Forms.RadioButton rdo_Role;
        private System.Windows.Forms.RadioButton rdo_ROle1;
        private System.Windows.Forms.Button btn_Del_truong1;
        private System.Windows.Forms.ComboBox cbb_Role1;
        private DevExpress.XtraGrid.GridControl grid_1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_1;
    }
}