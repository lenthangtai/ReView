using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace VCB_TEGAKI
{
    partial class frmLastCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLastCheck));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            this.splitContainerControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.view_Image_TN = new ImageViewerTR.ImageViewerTR();
            this.lbsodong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblsoluonganh = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSaveN = new System.Windows.Forms.ToolStripButton();
            this.btnSavetxtN = new System.Windows.Forms.ToolStripButton();
            this.btnRRN = new System.Windows.Forms.ToolStripButton();
            this.btnRRLN = new System.Windows.Forms.ToolStripButton();
            this.btnfull = new System.Windows.Forms.ToolStripButton();
            this.btnZoomin = new System.Windows.Forms.ToolStripButton();
            this.btnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.cboimage = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grThongke = new DevExpress.XtraGrid.GridControl();
            this.grThongkeV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridCheck = new DevExpress.XtraGrid.GridControl();
            this.gridVCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox4 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bgwLoad = new System.ComponentModel.BackgroundWorker();
            this.bgwLoadExel = new System.ComponentModel.BackgroundWorker();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtContentReplace = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtReplaceText = new System.Windows.Forms.ToolStripTextBox();
            this.btnReplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel6 = new System.Windows.Forms.ToolStripLabel();
            this.btncheck = new System.Windows.Forms.Button();
            this.lblbao = new System.Windows.Forms.Label();
            this.btnUpMaster = new System.Windows.Forms.Button();
            this.bgwTr1 = new System.ComponentModel.BackgroundWorker();
            this.bgwTr4 = new System.ComponentModel.BackgroundWorker();
            this.bgwTr6 = new System.ComponentModel.BackgroundWorker();
            this.bgwTr8 = new System.ComponentModel.BackgroundWorker();
            this.bgwTr10 = new System.ComponentModel.BackgroundWorker();
            this.btn_truong1 = new System.Windows.Forms.Button();
            this.btn_truong2 = new System.Windows.Forms.Button();
            this.btn_truong6 = new System.Windows.Forms.Button();
            this.btn_truong8 = new System.Windows.Forms.Button();
            this.btn_truong10 = new System.Windows.Forms.Button();
            this.btn_checkFullData = new System.Windows.Forms.Button();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm4), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).BeginInit();
            this.splitContainerControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grThongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThongkeV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl
            // 
            this.splitContainerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.splitContainerControl.Location = new System.Drawing.Point(-1, 30);
            this.splitContainerControl.Name = "splitContainerControl";
            this.splitContainerControl.Padding = new System.Windows.Forms.Padding(6);
            this.splitContainerControl.Panel1.AutoScroll = true;
            this.splitContainerControl.Panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.splitContainerControl.Panel1.Controls.Add(this.view_Image_TN);
            this.splitContainerControl.Panel1.Controls.Add(this.lbsodong);
            this.splitContainerControl.Panel1.Controls.Add(this.label1);
            this.splitContainerControl.Panel1.Controls.Add(this.lblsoluonganh);
            this.splitContainerControl.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerControl.Panel1.Text = "Panel1";
            this.splitContainerControl.Panel2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.splitContainerControl.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainerControl.Panel2.Text = "Panel2";
            this.splitContainerControl.Size = new System.Drawing.Size(1307, 670);
            this.splitContainerControl.SplitterPosition = 617;
            this.splitContainerControl.TabIndex = 0;
            this.splitContainerControl.Text = "splitContainerControl1";
            this.splitContainerControl.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerControl_Paint);
            // 
            // view_Image_TN
            // 
            this.view_Image_TN.BackColor = System.Drawing.Color.LightGray;
            this.view_Image_TN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.view_Image_TN.CurrentZoom = 1F;
            this.view_Image_TN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.view_Image_TN.Image = null;
            this.view_Image_TN.Location = new System.Drawing.Point(0, 27);
            this.view_Image_TN.Margin = new System.Windows.Forms.Padding(4);
            this.view_Image_TN.MaxZoom = 20F;
            this.view_Image_TN.MinZoom = 0.05F;
            this.view_Image_TN.Name = "view_Image_TN";
            this.view_Image_TN.Size = new System.Drawing.Size(613, 623);
            this.view_Image_TN.TabIndex = 117;
            this.view_Image_TN.TabStop = false;
            // 
            // lbsodong
            // 
            this.lbsodong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbsodong.AutoSize = true;
            this.lbsodong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsodong.ForeColor = System.Drawing.Color.Red;
            this.lbsodong.Location = new System.Drawing.Point(541, 4);
            this.lbsodong.Name = "lbsodong";
            this.lbsodong.Size = new System.Drawing.Size(19, 20);
            this.lbsodong.TabIndex = 118;
            this.lbsodong.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(412, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Số ảnh:";
            // 
            // lblsoluonganh
            // 
            this.lblsoluonganh.AutoSize = true;
            this.lblsoluonganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluonganh.ForeColor = System.Drawing.Color.Red;
            this.lblsoluonganh.Location = new System.Drawing.Point(485, 5);
            this.lblsoluonganh.Name = "lblsoluonganh";
            this.lblsoluonganh.Size = new System.Drawing.Size(19, 20);
            this.lblsoluonganh.TabIndex = 24;
            this.lblsoluonganh.Text = "0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveN,
            this.btnSavetxtN,
            this.btnRRN,
            this.btnRRLN,
            this.btnfull,
            this.btnZoomin,
            this.btnZoomOut,
            this.cboimage});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(613, 27);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnSaveN
            // 
            this.btnSaveN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveN.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveN.Image")));
            this.btnSaveN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveN.Name = "btnSaveN";
            this.btnSaveN.Size = new System.Drawing.Size(24, 24);
            this.btnSaveN.Text = "Save";
            this.btnSaveN.ToolTipText = "Save(Ctrl+S)";
            this.btnSaveN.Click += new System.EventHandler(this.btnSaveN_Click);
            // 
            // btnSavetxtN
            // 
            this.btnSavetxtN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSavetxtN.Image = global::VCB_Entry.Properties.Resources.save_as;
            this.btnSavetxtN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSavetxtN.Name = "btnSavetxtN";
            this.btnSavetxtN.Size = new System.Drawing.Size(24, 24);
            this.btnSavetxtN.Text = "Export Excel";
            this.btnSavetxtN.ToolTipText = "Save TXT(Ctrl+T)";
            this.btnSavetxtN.Click += new System.EventHandler(this.btnSavetxtN_Click);
            // 
            // btnRRN
            // 
            this.btnRRN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRRN.Image = ((System.Drawing.Image)(resources.GetObject("btnRRN.Image")));
            this.btnRRN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRRN.Name = "btnRRN";
            this.btnRRN.Size = new System.Drawing.Size(24, 24);
            this.btnRRN.Text = "Turn Right";
            this.btnRRN.ToolTipText = "Rotate right";
            this.btnRRN.Click += new System.EventHandler(this.btnRRN_Click);
            // 
            // btnRRLN
            // 
            this.btnRRLN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRRLN.Image = ((System.Drawing.Image)(resources.GetObject("btnRRLN.Image")));
            this.btnRRLN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRRLN.Name = "btnRRLN";
            this.btnRRLN.Size = new System.Drawing.Size(24, 24);
            this.btnRRLN.Text = "Turn Left";
            this.btnRRLN.ToolTipText = "Rotate left";
            this.btnRRLN.Click += new System.EventHandler(this.btnRRLN_Click);
            // 
            // btnfull
            // 
            this.btnfull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnfull.Image = ((System.Drawing.Image)(resources.GetObject("btnfull.Image")));
            this.btnfull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnfull.Name = "btnfull";
            this.btnfull.Size = new System.Drawing.Size(24, 24);
            this.btnfull.Text = "Full image";
            this.btnfull.Click += new System.EventHandler(this.btnfull_Click);
            // 
            // btnZoomin
            // 
            this.btnZoomin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomin.Image = global::VCB_Entry.Properties.Resources.Zoom_In_icon;
            this.btnZoomin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomin.Name = "btnZoomin";
            this.btnZoomin.Size = new System.Drawing.Size(24, 24);
            this.btnZoomin.Text = "ZoomIn";
            this.btnZoomin.Click += new System.EventHandler(this.btnZoomin_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnZoomOut.Image = global::VCB_Entry.Properties.Resources.Zoom_Out_icon;
            this.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(24, 24);
            this.btnZoomOut.Text = "ZoomOut";
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // cboimage
            // 
            this.cboimage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboimage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboimage.Name = "cboimage";
            this.cboimage.Size = new System.Drawing.Size(230, 27);
            this.cboimage.SelectedIndexChanged += new System.EventHandler(this.cboimage_SelectedValueChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grThongke);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gridCheck);
            this.splitContainer1.Size = new System.Drawing.Size(665, 650);
            this.splitContainer1.SplitterDistance = 419;
            this.splitContainer1.TabIndex = 4;
            // 
            // grThongke
            // 
            this.grThongke.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode2.RelationName = "Level1";
            this.grThongke.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.grThongke.Location = new System.Drawing.Point(0, 0);
            this.grThongke.MainView = this.grThongkeV;
            this.grThongke.Name = "grThongke";
            this.grThongke.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.grThongke.Size = new System.Drawing.Size(419, 650);
            this.grThongke.TabIndex = 2;
            this.grThongke.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grThongkeV});
            this.grThongke.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.grThongke_EditorKeyDown);
            this.grThongke.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grThongke_KeyDown);
            // 
            // grThongkeV
            // 
            this.grThongkeV.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.FocusedRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grThongkeV.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grThongkeV.Appearance.FocusedRow.Options.UseBorderColor = true;
            this.grThongkeV.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grThongkeV.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.grThongkeV.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grThongkeV.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grThongkeV.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grThongkeV.Appearance.SelectedRow.BorderColor = System.Drawing.Color.Red;
            this.grThongkeV.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grThongkeV.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grThongkeV.Appearance.SelectedRow.Options.UseBorderColor = true;
            this.grThongkeV.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grThongkeV.GridControl = this.grThongke;
            this.grThongkeV.IndicatorWidth = 30;
            this.grThongkeV.Name = "grThongkeV";
            this.grThongkeV.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.grThongkeV.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.grThongkeV.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grThongkeV.OptionsSelection.MultiSelect = true;
            this.grThongkeV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grThongkeV.OptionsView.ColumnAutoWidth = false;
            this.grThongkeV.OptionsView.ShowGroupPanel = false;
            this.grThongkeV.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grThongkeV_CustomDrawRowIndicator);
            this.grThongkeV.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grThongkeV_RowCellStyle_1);
            this.grThongkeV.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grThongkeV_RowStyle);
            this.grThongkeV.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grThongkeV_CellValueChanged);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // gridCheck
            // 
            this.gridCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode3.RelationName = "Level1";
            this.gridCheck.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.gridCheck.Location = new System.Drawing.Point(0, 0);
            this.gridCheck.MainView = this.gridVCheck;
            this.gridCheck.Name = "gridCheck";
            this.gridCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox3,
            this.repositoryItemComboBox4});
            this.gridCheck.Size = new System.Drawing.Size(242, 650);
            this.gridCheck.TabIndex = 3;
            this.gridCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridVCheck});
            this.gridCheck.Visible = false;
            // 
            // gridVCheck
            // 
            this.gridVCheck.GridControl = this.gridCheck;
            this.gridVCheck.Name = "gridVCheck";
            this.gridVCheck.OptionsBehavior.Editable = false;
            this.gridVCheck.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.gridVCheck.OptionsCustomization.AllowSort = false;
            this.gridVCheck.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.gridVCheck.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.gridVCheck.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridVCheck.OptionsSelection.MultiSelect = true;
            this.gridVCheck.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gridVCheck.OptionsView.ColumnAutoWidth = false;
            this.gridVCheck.OptionsView.ShowGroupPanel = false;
            this.gridVCheck.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridVCheck_RowCellClick);
            this.gridVCheck.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridVCheck_FocusedRowChanged);
            this.gridVCheck.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridVCheck_KeyDown);
            // 
            // repositoryItemComboBox3
            // 
            this.repositoryItemComboBox3.Name = "repositoryItemComboBox3";
            // 
            // repositoryItemComboBox4
            // 
            this.repositoryItemComboBox4.Name = "repositoryItemComboBox4";
            // 
            // bgwLoad
            // 
            this.bgwLoad.WorkerReportsProgress = true;
            this.bgwLoad.WorkerSupportsCancellation = true;
            this.bgwLoad.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoad_DoWork);
            this.bgwLoad.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoad_RunWorkerCompleted);
            // 
            // bgwLoadExel
            // 
            this.bgwLoadExel.WorkerReportsProgress = true;
            this.bgwLoadExel.WorkerSupportsCancellation = true;
            this.bgwLoadExel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadExel_DoWork);
            this.bgwLoadExel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadExel_RunWorkerCompleted);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripLabel2,
            this.txtContentReplace,
            this.toolStripLabel1,
            this.txtReplaceText,
            this.btnReplate});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1313, 27);
            this.toolStrip2.TabIndex = 22;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(0, 24);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(131, 24);
            this.toolStripLabel2.Text = "                        Find what";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // txtContentReplace
            // 
            this.txtContentReplace.Name = "txtContentReplace";
            this.txtContentReplace.Size = new System.Drawing.Size(100, 27);
            this.txtContentReplace.ToolTipText = "Find what";
            this.txtContentReplace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContentReplace_KeyDown);
            this.txtContentReplace.TextChanged += new System.EventHandler(this.txtContentReplace_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 24);
            this.toolStripLabel1.Text = "Replace with";
            // 
            // txtReplaceText
            // 
            this.txtReplaceText.Name = "txtReplaceText";
            this.txtReplaceText.Size = new System.Drawing.Size(100, 27);
            this.txtReplaceText.ToolTipText = "Replate with";
            this.txtReplaceText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContentReplace_KeyDown);
            // 
            // btnReplate
            // 
            this.btnReplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnReplate.Image = ((System.Drawing.Image)(resources.GetObject("btnReplate.Image")));
            this.btnReplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReplate.Name = "btnReplate";
            this.btnReplate.Size = new System.Drawing.Size(24, 24);
            this.btnReplate.Text = "toolStripButton1";
            this.btnReplate.ToolTipText = "Find and replace";
            this.btnReplate.Click += new System.EventHandler(this.btnReplate_Click);
            // 
            // toolStripLabel6
            // 
            this.toolStripLabel6.Name = "toolStripLabel6";
            this.toolStripLabel6.Size = new System.Drawing.Size(0, 22);
            this.toolStripLabel6.Text = "toolStripLabel6";
            this.toolStripLabel6.Visible = false;
            // 
            // btncheck
            // 
            this.btncheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheck.ForeColor = System.Drawing.Color.Red;
            this.btncheck.Location = new System.Drawing.Point(1226, 1);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(82, 23);
            this.btncheck.TabIndex = 23;
            this.btncheck.Text = "Check";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // lblbao
            // 
            this.lblbao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbao.AutoSize = true;
            this.lblbao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbao.ForeColor = System.Drawing.Color.Red;
            this.lblbao.Location = new System.Drawing.Point(1120, 3);
            this.lblbao.Name = "lblbao";
            this.lblbao.Size = new System.Drawing.Size(0, 24);
            this.lblbao.TabIndex = 24;
            // 
            // btnUpMaster
            // 
            this.btnUpMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpMaster.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnUpMaster.Location = new System.Drawing.Point(443, 1);
            this.btnUpMaster.Name = "btnUpMaster";
            this.btnUpMaster.Size = new System.Drawing.Size(89, 23);
            this.btnUpMaster.TabIndex = 25;
            this.btnUpMaster.Text = "Up Master";
            this.btnUpMaster.UseVisualStyleBackColor = true;
            this.btnUpMaster.Visible = false;
            this.btnUpMaster.Click += new System.EventHandler(this.btnUpMaster_Click);
            // 
            // bgwTr1
            // 
            this.bgwTr1.WorkerReportsProgress = true;
            this.bgwTr1.WorkerSupportsCancellation = true;
            this.bgwTr1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTr1_DoWork);
            this.bgwTr1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTr1_RunWorkerCompleted);
            // 
            // bgwTr4
            // 
            this.bgwTr4.WorkerReportsProgress = true;
            this.bgwTr4.WorkerSupportsCancellation = true;
            this.bgwTr4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTr4_DoWork);
            this.bgwTr4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTr4_RunWorkerCompleted);
            // 
            // bgwTr6
            // 
            this.bgwTr6.WorkerReportsProgress = true;
            this.bgwTr6.WorkerSupportsCancellation = true;
            this.bgwTr6.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTr6_DoWork);
            this.bgwTr6.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTr6_RunWorkerCompleted);
            // 
            // bgwTr8
            // 
            this.bgwTr8.WorkerReportsProgress = true;
            this.bgwTr8.WorkerSupportsCancellation = true;
            this.bgwTr8.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTr8_DoWork);
            this.bgwTr8.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTr8_RunWorkerCompleted);
            // 
            // bgwTr10
            // 
            this.bgwTr10.WorkerReportsProgress = true;
            this.bgwTr10.WorkerSupportsCancellation = true;
            this.bgwTr10.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwTr10_DoWork);
            this.bgwTr10.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwTr10_RunWorkerCompleted);
            // 
            // btn_truong1
            // 
            this.btn_truong1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_truong1.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_truong1.Location = new System.Drawing.Point(597, 2);
            this.btn_truong1.Name = "btn_truong1";
            this.btn_truong1.Size = new System.Drawing.Size(82, 23);
            this.btn_truong1.TabIndex = 26;
            this.btn_truong1.Text = "Check 1";
            this.btn_truong1.UseVisualStyleBackColor = true;
            this.btn_truong1.Visible = false;
            this.btn_truong1.Click += new System.EventHandler(this.btn_truong1_Click);
            // 
            // btn_truong2
            // 
            this.btn_truong2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_truong2.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_truong2.Location = new System.Drawing.Point(702, 2);
            this.btn_truong2.Name = "btn_truong2";
            this.btn_truong2.Size = new System.Drawing.Size(82, 23);
            this.btn_truong2.TabIndex = 27;
            this.btn_truong2.Text = "Check 2";
            this.btn_truong2.UseVisualStyleBackColor = true;
            this.btn_truong2.Visible = false;
            this.btn_truong2.Click += new System.EventHandler(this.btn_truong3_Click);
            // 
            // btn_truong6
            // 
            this.btn_truong6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_truong6.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_truong6.Location = new System.Drawing.Point(803, 2);
            this.btn_truong6.Name = "btn_truong6";
            this.btn_truong6.Size = new System.Drawing.Size(82, 23);
            this.btn_truong6.TabIndex = 28;
            this.btn_truong6.Text = "Check 6";
            this.btn_truong6.UseVisualStyleBackColor = true;
            this.btn_truong6.Visible = false;
            this.btn_truong6.Click += new System.EventHandler(this.btn_truong6_Click);
            // 
            // btn_truong8
            // 
            this.btn_truong8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_truong8.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_truong8.Location = new System.Drawing.Point(906, 2);
            this.btn_truong8.Name = "btn_truong8";
            this.btn_truong8.Size = new System.Drawing.Size(82, 23);
            this.btn_truong8.TabIndex = 29;
            this.btn_truong8.Text = "Check 8";
            this.btn_truong8.UseVisualStyleBackColor = true;
            this.btn_truong8.Visible = false;
            this.btn_truong8.Click += new System.EventHandler(this.btn_truong8_Click);
            // 
            // btn_truong10
            // 
            this.btn_truong10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_truong10.ForeColor = System.Drawing.Color.DarkGreen;
            this.btn_truong10.Location = new System.Drawing.Point(1015, 2);
            this.btn_truong10.Name = "btn_truong10";
            this.btn_truong10.Size = new System.Drawing.Size(82, 23);
            this.btn_truong10.TabIndex = 30;
            this.btn_truong10.Text = "Check 10";
            this.btn_truong10.UseVisualStyleBackColor = true;
            this.btn_truong10.Visible = false;
            this.btn_truong10.Click += new System.EventHandler(this.btn_truong10_Click);
            // 
            // btn_checkFullData
            // 
            this.btn_checkFullData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_checkFullData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkFullData.ForeColor = System.Drawing.Color.Red;
            this.btn_checkFullData.Location = new System.Drawing.Point(966, 2);
            this.btn_checkFullData.Name = "btn_checkFullData";
            this.btn_checkFullData.Size = new System.Drawing.Size(96, 23);
            this.btn_checkFullData.TabIndex = 31;
            this.btn_checkFullData.Text = "Check Data";
            this.btn_checkFullData.UseVisualStyleBackColor = true;
            this.btn_checkFullData.Visible = false;
            this.btn_checkFullData.Click += new System.EventHandler(this.btn_checkFullData_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmLastCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 700);
            this.Controls.Add(this.btn_checkFullData);
            this.Controls.Add(this.splitContainerControl);
            this.Controls.Add(this.btn_truong10);
            this.Controls.Add(this.btn_truong8);
            this.Controls.Add(this.btn_truong6);
            this.Controls.Add(this.btn_truong2);
            this.Controls.Add(this.btn_truong1);
            this.Controls.Add(this.btnUpMaster);
            this.Controls.Add(this.lblbao);
            this.Controls.Add(this.btncheck);
            this.Controls.Add(this.toolStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmLastCheck";
            this.Text = "VCB Lastcheck";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThongke_FormClosing);
            this.Load += new System.EventHandler(this.frmLastCheck_Load_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLastCheck_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl)).EndInit();
            this.splitContainerControl.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grThongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThongkeV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridVCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox4)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl;
        private System.ComponentModel.BackgroundWorker bgwLoad;
        private System.ComponentModel.BackgroundWorker bgwLoadExel;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox txtContentReplace;
        private System.Windows.Forms.ToolStripButton btnReplate;
        private System.Windows.Forms.ToolStripTextBox txtReplaceText;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnSaveN;
        private System.Windows.Forms.ToolStripButton btnSavetxtN;
        private System.Windows.Forms.ToolStripButton btnRRN;
        private System.Windows.Forms.ToolStripButton btnRRLN;
        private System.Windows.Forms.ToolStripButton btnfull;
        private System.Windows.Forms.ToolStripButton btnZoomin;
        private System.Windows.Forms.ToolStripButton btnZoomOut;
        private System.Windows.Forms.ToolStripComboBox cboimage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel6;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Label lblsoluonganh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblbao;
        private ImageViewerTR.ImageViewerTR view_Image_TN;
        private DevExpress.XtraGrid.GridControl grThongke;
        private DevExpress.XtraGrid.Views.Grid.GridView grThongkeV;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private System.Windows.Forms.Button btnUpMaster;
        private GridControl gridCheck;
        private GridView gridVCheck;
        private RepositoryItemComboBox repositoryItemComboBox3;
        private RepositoryItemComboBox repositoryItemComboBox4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.ComponentModel.BackgroundWorker bgwTr1;
        private System.ComponentModel.BackgroundWorker bgwTr4;
        private System.ComponentModel.BackgroundWorker bgwTr6;
        private System.ComponentModel.BackgroundWorker bgwTr8;
        private System.ComponentModel.BackgroundWorker bgwTr10;
        private System.Windows.Forms.Button btn_truong1;
        private System.Windows.Forms.Button btn_truong2;
        private System.Windows.Forms.Button btn_truong6;
        private System.Windows.Forms.Button btn_truong8;
        private System.Windows.Forms.Button btn_truong10;
        private System.Windows.Forms.Button btn_checkFullData;
        private System.Windows.Forms.Label lbsodong;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}
