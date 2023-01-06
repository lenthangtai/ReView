namespace VCB_TEGAKI
{
    partial class FrmEntryP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntryP));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
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
            this.label9 = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblbatchname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grTemp = new DevExpress.XtraGrid.GridControl();
            this.grTempV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNotgood = new System.Windows.Forms.Button();
            this.timergetanh = new System.Windows.Forms.Timer(this.components);
            this.view_Image_TN = new ImageViewerTR.ImageViewerTR();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.btnsop = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTempV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblpage
            // 
            this.lblpage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblpage.ForeColor = System.Drawing.Color.Blue;
            this.lblpage.Location = new System.Drawing.Point(64, 32);
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
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Số lượng còn lại:";
            // 
            // lblsoluong
            // 
            this.lblsoluong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsoluong.AutoSize = true;
            this.lblsoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.ForeColor = System.Drawing.Color.Blue;
            this.lblsoluong.Location = new System.Drawing.Point(98, 3);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(18, 20);
            this.lblsoluong.TabIndex = 76;
            this.lblsoluong.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 36);
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
            this.lblerror.Location = new System.Drawing.Point(598, 24);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 15);
            this.lblerror.TabIndex = 78;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 95;
            this.label9.Text = "Username:";
            // 
            // lblusername
            // 
            this.lblusername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.Blue;
            this.lblusername.Location = new System.Drawing.Point(364, 3);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(0, 20);
            this.lblusername.TabIndex = 99;
            // 
            // lblbatchname
            // 
            this.lblbatchname.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbatchname.AutoSize = true;
            this.lblbatchname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbatchname.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblbatchname.Location = new System.Drawing.Point(593, 142);
            this.lblbatchname.Name = "lblbatchname";
            this.lblbatchname.Size = new System.Drawing.Size(0, 20);
            this.lblbatchname.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(5, 177);
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
            gridLevelNode2.RelationName = "Level1";
            this.grTemp.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grTemp.Location = new System.Drawing.Point(3, 241);
            this.grTemp.MainView = this.grTempV;
            this.grTemp.Name = "grTemp";
            this.grTemp.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.grTemp.Size = new System.Drawing.Size(730, 491);
            this.grTemp.TabIndex = 104;
            this.grTemp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grTempV});
            this.grTemp.Click += new System.EventHandler(this.grTemp_Click);
            this.grTemp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grTemp_MouseMove);
            // 
            // grTempV
            // 
            this.grTempV.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTempV.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.grTempV.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTempV.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.grTempV.Appearance.FocusedCell.BorderColor = System.Drawing.Color.Red;
            this.grTempV.Appearance.FocusedCell.Options.UseBorderColor = true;
            this.grTempV.Appearance.FocusedRow.BorderColor = System.Drawing.Color.Red;
            this.grTempV.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grTempV.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTempV.Appearance.Row.Options.UseFont = true;
            this.grTempV.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Red;
            this.grTempV.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grTempV.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grTempV.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.grTempV.Appearance.SelectedRow.Options.UseForeColor = true;
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
            this.grTempV.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grTempV_RowCellStyle);
            this.grTempV.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grTempV_RowStyle);
            this.grTempV.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grTempV_FocusedRowChanged);
            this.grTempV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grTempV_KeyDown);
            this.grTempV.RowCountChanged += new System.EventHandler(this.grTempV_RowCountChanged);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // txtTemp
            // 
            this.txtTemp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemp.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTemp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTemp.Location = new System.Drawing.Point(3, 203);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(731, 32);
            this.txtTemp.TabIndex = 105;
            this.txtTemp.TextChanged += new System.EventHandler(this.txtTemp_TextChanged);
            this.txtTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemp_KeyDown);
            this.txtTemp.Leave += new System.EventHandler(this.txtTemp_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(559, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 111;
            this.label2.Text = "Ctrl + N";
            // 
            // btnNotgood
            // 
            this.btnNotgood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotgood.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNotgood.Location = new System.Drawing.Point(430, 166);
            this.btnNotgood.Name = "btnNotgood";
            this.btnNotgood.Size = new System.Drawing.Size(122, 31);
            this.btnNotgood.TabIndex = 109;
            this.btnNotgood.Text = "Not Good";
            this.btnNotgood.UseVisualStyleBackColor = true;
            this.btnNotgood.Click += new System.EventHandler(this.btnNotgood_Click_1);
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
            this.view_Image_TN.Location = new System.Drawing.Point(4, 4);
            this.view_Image_TN.Margin = new System.Windows.Forms.Padding(4);
            this.view_Image_TN.MaxZoom = 20F;
            this.view_Image_TN.MinZoom = 0.05F;
            this.view_Image_TN.Name = "view_Image_TN";
            this.view_Image_TN.Size = new System.Drawing.Size(599, 734);
            this.view_Image_TN.TabIndex = 114;
            this.view_Image_TN.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSubmit.Location = new System.Drawing.Point(252, 166);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(122, 31);
            this.btnSubmit.TabIndex = 115;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.ForeColor = System.Drawing.Color.White;
            this.txtText.Location = new System.Drawing.Point(3, 53);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.ReadOnly = true;
            this.txtText.Size = new System.Drawing.Size(731, 114);
            this.txtText.TabIndex = 113;
            // 
            // btnsop
            // 
            this.btnsop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsop.Location = new System.Drawing.Point(680, 3);
            this.btnsop.Name = "btnsop";
            this.btnsop.Size = new System.Drawing.Size(54, 36);
            this.btnsop.TabIndex = 178;
            this.btnsop.TabStop = false;
            this.btnsop.Text = "SOP";
            this.btnsop.UseVisualStyleBackColor = true;
            this.btnsop.Visible = false;
            this.btnsop.Click += new System.EventHandler(this.btnsop_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel1.Controls.Add(this.view_Image_TN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1349, 742);
            this.tableLayoutPanel1.TabIndex = 179;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grTemp);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.btnsop);
            this.panel1.Controls.Add(this.txtText);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblpage);
            this.panel1.Controls.Add(this.btnNotgood);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblsoluong);
            this.panel1.Controls.Add(this.txtTemp);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lblerror);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(610, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 736);
            this.panel1.TabIndex = 115;
            // 
            // FrmEntryP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 742);
            this.Controls.Add(this.lblbatchname);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmEntryP";
            this.Text = "Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEntry_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.grTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grTempV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblbatchname;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grTemp;
        private DevExpress.XtraGrid.Views.Grid.GridView grTempV;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private System.Windows.Forms.TextBox txtTemp;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNotgood;
        private System.Windows.Forms.Timer timergetanh;
        private ImageViewerTR.ImageViewerTR view_Image_TN;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Button btnsop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}