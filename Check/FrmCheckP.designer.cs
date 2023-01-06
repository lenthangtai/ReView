namespace VCB_TEGAKI
{
    partial class FrmCheckP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCheckP));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.lblpage = new System.Windows.Forms.Label();
            this.btnRR = new System.Windows.Forms.ToolStripButton();
            this.btnRL = new System.Windows.Forms.ToolStripButton();
            this.btnFullImage = new System.Windows.Forms.ToolStripButton();
            this.btnzoomout = new System.Windows.Forms.ToolStripButton();
            this.btnzoomin = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lblsoluong = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblerror = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblbatchname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grTemp = new DevExpress.XtraGrid.GridControl();
            this.grTempV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNotgood = new System.Windows.Forms.Button();
            this.txtTemp = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbluser1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbluser2 = new System.Windows.Forms.Label();
            this.timergetanh = new System.Windows.Forms.Timer(this.components);
            this.view_Image_TN = new ImageViewerTR.ImageViewerTR();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTempV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpage
            // 
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblpage.ForeColor = System.Drawing.Color.Blue;
            this.lblpage.Location = new System.Drawing.Point(192, 6);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(35, 18);
            this.lblpage.TabIndex = 49;
            this.lblpage.Text = "ảnh";
            // 
            // btnRR
            // 
            this.btnRR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRR.Image = global::VCB_Entry.Properties.Resources.object_rotate_right;
            this.btnRR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRR.Name = "btnRR";
            this.btnRR.Size = new System.Drawing.Size(23, 22);
            this.btnRR.Text = "toolStripButton1";
            this.btnRR.Click += new System.EventHandler(this.btnRR_Click);
            // 
            // btnRL
            // 
            this.btnRL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRL.Image = global::VCB_Entry.Properties.Resources.object_rotate_left;
            this.btnRL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRL.Name = "btnRL";
            this.btnRL.Size = new System.Drawing.Size(23, 22);
            this.btnRL.Text = "toolStripButton2";
            this.btnRL.Click += new System.EventHandler(this.btnRL_Click);
            // 
            // btnFullImage
            // 
            this.btnFullImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFullImage.Image = ((System.Drawing.Image)(resources.GetObject("btnFullImage.Image")));
            this.btnFullImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullImage.Name = "btnFullImage";
            this.btnFullImage.Size = new System.Drawing.Size(23, 22);
            this.btnFullImage.ToolTipText = "Ctrl+F";
            this.btnFullImage.Click += new System.EventHandler(this.btnFullImage_Click);
            // 
            // btnzoomout
            // 
            this.btnzoomout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnzoomout.Image = global::VCB_Entry.Properties.Resources.Zoom_Out_icon;
            this.btnzoomout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnzoomout.Name = "btnzoomout";
            this.btnzoomout.Size = new System.Drawing.Size(23, 22);
            this.btnzoomout.Text = "toolStripButton1";
            this.btnzoomout.Click += new System.EventHandler(this.btnzoomout_Click);
            // 
            // btnzoomin
            // 
            this.btnzoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnzoomin.Image = global::VCB_Entry.Properties.Resources.Zoom_In_icon;
            this.btnzoomin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnzoomin.Name = "btnzoomin";
            this.btnzoomin.Size = new System.Drawing.Size(23, 22);
            this.btnzoomin.Text = "toolStripButton2";
            this.btnzoomin.Click += new System.EventHandler(this.btnzoomin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Số lượng còn lại:";
            // 
            // lblsoluong
            // 
            this.lblsoluong.AutoSize = true;
            this.lblsoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblsoluong.Location = new System.Drawing.Point(95, 4);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(18, 20);
            this.lblsoluong.TabIndex = 76;
            this.lblsoluong.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 77;
            this.label8.Text = "Tên ảnh:";
            // 
            // lblerror
            // 
            this.lblerror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblerror.AutoSize = true;
            this.lblerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(391, 67);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 15);
            this.lblerror.TabIndex = 78;
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblusername.Location = new System.Drawing.Point(621, 4);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(0, 20);
            this.lblusername.TabIndex = 99;
            // 
            // lblbatchname
            // 
            this.lblbatchname.AutoSize = true;
            this.lblbatchname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbatchname.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblbatchname.Location = new System.Drawing.Point(438, 4);
            this.lblbatchname.Name = "lblbatchname";
            this.lblbatchname.Size = new System.Drawing.Size(0, 20);
            this.lblbatchname.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 101;
            this.label1.Text = "Chọn Template:";
            // 
            // grTemp
            // 
            this.grTemp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            gridLevelNode1.RelationName = "Level1";
            this.grTemp.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grTemp.Location = new System.Drawing.Point(4, 347);
            this.grTemp.MainView = this.grTempV;
            this.grTemp.Name = "grTemp";
            this.grTemp.Size = new System.Drawing.Size(727, 384);
            this.grTemp.TabIndex = 104;
            this.grTemp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grTempV});
            // 
            // grTempV
            // 
            this.grTempV.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTempV.Appearance.Row.Options.UseFont = true;
            this.grTempV.GridControl = this.grTemp;
            this.grTempV.Name = "grTempV";
            this.grTempV.OptionsBehavior.Editable = false;
            this.grTempV.OptionsCustomization.AllowFilter = false;
            this.grTempV.OptionsCustomization.AllowGroup = false;
            this.grTempV.OptionsCustomization.AllowSort = false;
            this.grTempV.OptionsFilter.AllowFilterEditor = false;
            this.grTempV.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grTempV.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.grTempV.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.grTempV.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grTempV.OptionsSelection.MultiSelect = true;
            this.grTempV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grTempV.OptionsView.ShowGroupPanel = false;
            this.grTempV.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grTempV_RowCellClick);
            this.grTempV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grTempV_FocusedRowChanged);
            this.grTempV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grTempV_KeyDown);
            this.grTempV.RowCountChanged += new System.EventHandler(this.grTempV_RowCountChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(490, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "Ctrl + N";
            // 
            // btnNotgood
            // 
            this.btnNotgood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotgood.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNotgood.Location = new System.Drawing.Point(593, 48);
            this.btnNotgood.Name = "btnNotgood";
            this.btnNotgood.Size = new System.Drawing.Size(134, 34);
            this.btnNotgood.TabIndex = 109;
            this.btnNotgood.Text = "Not Good";
            this.btnNotgood.UseVisualStyleBackColor = true;
            this.btnNotgood.Click += new System.EventHandler(this.btnNotgood_Click_1);
            // 
            // txtTemp
            // 
            this.txtTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemp.Location = new System.Drawing.Point(4, 85);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(729, 71);
            this.txtTemp.TabIndex = 1;
            this.txtTemp.Text = "";
            this.txtTemp.TextChanged += new System.EventHandler(this.txtTemp_TextChanged_1);
            this.txtTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemp_KeyDown);
            this.txtTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTemp_KeyPress);
            this.txtTemp.Leave += new System.EventHandler(this.txtTemp_Leave);
            this.txtTemp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtTemp_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 112;
            this.label3.Text = "User 1:";
            // 
            // lbluser1
            // 
            this.lbluser1.AutoSize = true;
            this.lbluser1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbluser1.Location = new System.Drawing.Point(68, 33);
            this.lbluser1.Name = "lbluser1";
            this.lbluser1.Size = new System.Drawing.Size(45, 16);
            this.lbluser1.TabIndex = 113;
            this.lbluser1.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(435, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 114;
            this.label5.Text = "User 2:";
            // 
            // lbluser2
            // 
            this.lbluser2.AutoSize = true;
            this.lbluser2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluser2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbluser2.Location = new System.Drawing.Point(491, 33);
            this.lbluser2.Name = "lbluser2";
            this.lbluser2.Size = new System.Drawing.Size(45, 16);
            this.lbluser2.TabIndex = 115;
            this.lbluser2.Text = "label7";
            // 
            // timergetanh
            // 
            this.timergetanh.Interval = 200;
            this.timergetanh.Tick += new System.EventHandler(this.timergetanh_Tick);
            // 
            // view_Image_TN
            // 
            this.view_Image_TN.BackColor = System.Drawing.Color.LightGray;
            this.view_Image_TN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.view_Image_TN.CurrentZoom = 1F;
            this.view_Image_TN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view_Image_TN.Image = null;
            this.view_Image_TN.Location = new System.Drawing.Point(0, 0);
            this.view_Image_TN.MaxZoom = 20F;
            this.view_Image_TN.MinZoom = 0.05F;
            this.view_Image_TN.Name = "view_Image_TN";
            this.view_Image_TN.Size = new System.Drawing.Size(601, 736);
            this.view_Image_TN.TabIndex = 116;
            this.view_Image_TN.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSubmit.Location = new System.Drawing.Point(593, 222);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(140, 73);
            this.btnSubmit.TabIndex = 117;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.ForeColor = System.Drawing.Color.White;
            this.txtText.Location = new System.Drawing.Point(4, 160);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(583, 185);
            this.txtText.TabIndex = 118;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1349, 742);
            this.tableLayoutPanel1.TabIndex = 119;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Controls.Add(this.lblbatchname);
            this.panel1.Controls.Add(this.txtText);
            this.panel1.Controls.Add(this.lblerror);
            this.panel1.Controls.Add(this.lbluser1);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.lblpage);
            this.panel1.Controls.Add(this.btnNotgood);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbluser2);
            this.panel1.Controls.Add(this.lblsoluong);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.grTemp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTemp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(610, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 736);
            this.panel1.TabIndex = 117;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.view_Image_TN);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 736);
            this.panel2.TabIndex = 118;
            // 
            // FrmCheckP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 742);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmCheckP";
            this.Text = "Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEntry_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTempV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.ToolStripButton btnRR;
        private System.Windows.Forms.ToolStripButton btnRL;
        private System.Windows.Forms.ToolStripButton btnFullImage;
        private System.Windows.Forms.ToolStripButton btnzoomout;
        private System.Windows.Forms.ToolStripButton btnzoomin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblsoluong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblbatchname;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grTemp;
        private DevExpress.XtraGrid.Views.Grid.GridView grTempV;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNotgood;
        private System.Windows.Forms.RichTextBox txtTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbluser1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbluser2;
        private System.Windows.Forms.Timer timergetanh;
        private ImageViewerTR.ImageViewerTR view_Image_TN;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}