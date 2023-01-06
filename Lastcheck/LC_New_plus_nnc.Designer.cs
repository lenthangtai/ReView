using VCB_TEGAKI;

namespace VCB_Entry.Lastcheck
{
    partial class LC_New_plus_NNC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LC_New_plus_NNC));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Done = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbsodong = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_checkLogic = new System.Windows.Forms.Button();
            this.lblsoluonganh = new System.Windows.Forms.Label();
            this.btn_export = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridExport = new DevExpress.XtraGrid.GridControl();
            this.gridV_Export = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ImgV = new ImageViewerTR.ImageViewerTR();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid_img = new DevExpress.XtraGrid.GridControl();
            this.gridV_Img = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_data = new DevExpress.XtraGrid.GridControl();
            this.gridV_data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_checkLogic = new DevExpress.XtraGrid.GridControl();
            this.gridV_checkLogic = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bgw_run_data = new System.ComponentModel.BackgroundWorker();
            this.spl_mng = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::VCB_TEGAKI.WaitForm4), true, true);
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_checkLogic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_checkLogic)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1351, 730);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Done);
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(543, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 30);
            this.panel3.TabIndex = 7;
            // 
            // btn_Done
            // 
            this.btn_Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Done.BackColor = System.Drawing.Color.OrangeRed;
            this.btn_Done.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Done.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Done.ForeColor = System.Drawing.Color.Snow;
            this.btn_Done.Location = new System.Drawing.Point(700, 0);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(102, 30);
            this.btn_Done.TabIndex = 3;
            this.btn_Done.Text = "Done";
            this.btn_Done.UseVisualStyleBackColor = false;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            this.btn_Done.MouseHover += new System.EventHandler(this.btn_Done_MouseHover);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Location = new System.Drawing.Point(502, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            this.btn_save.MouseHover += new System.EventHandler(this.btn_save_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbsodong);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_checkLogic);
            this.panel2.Controls.Add(this.lblsoluonganh);
            this.panel2.Controls.Add(this.btn_export);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 30);
            this.panel2.TabIndex = 6;
            // 
            // lbsodong
            // 
            this.lbsodong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbsodong.AutoSize = true;
            this.lbsodong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbsodong.ForeColor = System.Drawing.Color.Red;
            this.lbsodong.Location = new System.Drawing.Point(480, 5);
            this.lbsodong.Name = "lbsodong";
            this.lbsodong.Size = new System.Drawing.Size(19, 20);
            this.lbsodong.TabIndex = 121;
            this.lbsodong.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(276, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 120;
            this.label1.Text = "Số ảnh:";
            // 
            // btn_checkLogic
            // 
            this.btn_checkLogic.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_checkLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_checkLogic.Location = new System.Drawing.Point(157, 0);
            this.btn_checkLogic.Name = "btn_checkLogic";
            this.btn_checkLogic.Size = new System.Drawing.Size(102, 30);
            this.btn_checkLogic.TabIndex = 0;
            this.btn_checkLogic.Text = "Check Logic";
            this.btn_checkLogic.UseVisualStyleBackColor = true;
            this.btn_checkLogic.Visible = false;
            this.btn_checkLogic.Click += new System.EventHandler(this.btn_checkLogic_Click);
            this.btn_checkLogic.MouseHover += new System.EventHandler(this.btn_checkLogic_MouseHover);
            // 
            // lblsoluonganh
            // 
            this.lblsoluonganh.AutoSize = true;
            this.lblsoluonganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluonganh.ForeColor = System.Drawing.Color.Red;
            this.lblsoluonganh.Location = new System.Drawing.Point(353, 6);
            this.lblsoluonganh.Name = "lblsoluonganh";
            this.lblsoluonganh.Size = new System.Drawing.Size(19, 20);
            this.lblsoluonganh.TabIndex = 119;
            this.lblsoluonganh.Text = "0";
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(3, 0);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(102, 30);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Visible = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            this.btn_export.MouseHover += new System.EventHandler(this.btn_export_MouseHover);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridExport);
            this.panel1.Controls.Add(this.ImgV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 688);
            this.panel1.TabIndex = 5;
            // 
            // gridExport
            // 
            this.gridExport.Location = new System.Drawing.Point(95, 141);
            this.gridExport.MainView = this.gridV_Export;
            this.gridExport.Name = "gridExport";
            this.gridExport.Size = new System.Drawing.Size(351, 182);
            this.gridExport.TabIndex = 5;
            this.gridExport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_Export});
            this.gridExport.Visible = false;
            // 
            // gridV_Export
            // 
            this.gridV_Export.GridControl = this.gridExport;
            this.gridV_Export.Name = "gridV_Export";
            // 
            // ImgV
            // 
            this.ImgV.BackColor = System.Drawing.Color.LightGray;
            this.ImgV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgV.CurrentZoom = 1F;
            this.ImgV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgV.Image = null;
            this.ImgV.Location = new System.Drawing.Point(0, 0);
            this.ImgV.MaxZoom = 20F;
            this.ImgV.MinZoom = 0.05F;
            this.ImgV.Name = "ImgV";
            this.ImgV.Size = new System.Drawing.Size(534, 688);
            this.ImgV.TabIndex = 4;
            this.ImgV.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(543, 39);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grid_checkLogic);
            this.splitContainer2.Size = new System.Drawing.Size(805, 688);
            this.splitContainer2.SplitterDistance = 530;
            this.splitContainer2.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grid_img);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grid_data);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(805, 530);
            this.splitContainer1.SplitterDistance = 242;
            this.splitContainer1.TabIndex = 0;
            // 
            // grid_img
            // 
            this.grid_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_img.Location = new System.Drawing.Point(0, 0);
            this.grid_img.MainView = this.gridV_Img;
            this.grid_img.Name = "grid_img";
            this.grid_img.Size = new System.Drawing.Size(242, 530);
            this.grid_img.TabIndex = 0;
            this.grid_img.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_Img});
            // 
            // gridV_Img
            // 
            this.gridV_Img.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridV_Img.Appearance.Row.Options.UseFont = true;
            this.gridV_Img.GridControl = this.grid_img;
            this.gridV_Img.IndicatorWidth = 30;
            this.gridV_Img.Name = "gridV_Img";
            this.gridV_Img.OptionsBehavior.Editable = false;
            this.gridV_Img.OptionsBehavior.ReadOnly = true;
            this.gridV_Img.OptionsCustomization.AllowFilter = false;
            this.gridV_Img.OptionsCustomization.AllowSort = false;
            this.gridV_Img.OptionsView.ShowGroupPanel = false;
            this.gridV_Img.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridV_Img_RowCellClick);
            this.gridV_Img.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridV_Img_CustomDrawRowIndicator);
            this.gridV_Img.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridV_Img_RowCellStyle);
            this.gridV_Img.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridV_Img_FocusedRowChanged);
            // 
            // grid_data
            // 
            this.grid_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_data.Location = new System.Drawing.Point(0, 0);
            this.grid_data.MainView = this.gridV_data;
            this.grid_data.Name = "grid_data";
            this.grid_data.Size = new System.Drawing.Size(559, 530);
            this.grid_data.TabIndex = 1;
            this.grid_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_data});
            this.grid_data.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_data_EditorKeyDown);
            this.grid_data.Leave += new System.EventHandler(this.grid_data_Leave);
            // 
            // gridV_data
            // 
            this.gridV_data.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Tomato;
            this.gridV_data.Appearance.FocusedCell.ForeColor = System.Drawing.Color.DarkOrange;
            this.gridV_data.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridV_data.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridV_data.Appearance.Row.Options.UseFont = true;
            this.gridV_data.GridControl = this.grid_data;
            this.gridV_data.IndicatorWidth = 30;
            this.gridV_data.Name = "gridV_data";
            this.gridV_data.OptionsCustomization.AllowFilter = false;
            this.gridV_data.OptionsCustomization.AllowSort = false;
            this.gridV_data.OptionsView.ShowGroupPanel = false;
            this.gridV_data.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridV_data_CustomDrawRowIndicator);
            this.gridV_data.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridV_data_RowCellStyle);
            this.gridV_data.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridV_data_CellValueChanged);
            // 
            // grid_checkLogic
            // 
            this.grid_checkLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_checkLogic.Location = new System.Drawing.Point(0, 0);
            this.grid_checkLogic.MainView = this.gridV_checkLogic;
            this.grid_checkLogic.Name = "grid_checkLogic";
            this.grid_checkLogic.Size = new System.Drawing.Size(805, 154);
            this.grid_checkLogic.TabIndex = 1;
            this.grid_checkLogic.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_checkLogic});
            // 
            // gridV_checkLogic
            // 
            this.gridV_checkLogic.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridV_checkLogic.Appearance.Row.Options.UseFont = true;
            this.gridV_checkLogic.GridControl = this.grid_checkLogic;
            this.gridV_checkLogic.IndicatorWidth = 30;
            this.gridV_checkLogic.Name = "gridV_checkLogic";
            this.gridV_checkLogic.OptionsBehavior.Editable = false;
            this.gridV_checkLogic.OptionsBehavior.ReadOnly = true;
            this.gridV_checkLogic.OptionsCustomization.AllowFilter = false;
            this.gridV_checkLogic.OptionsCustomization.AllowSort = false;
            this.gridV_checkLogic.OptionsView.ShowGroupPanel = false;
            this.gridV_checkLogic.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridV_checkLogic_RowCellStyle);
            this.gridV_checkLogic.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridV_checkLogic_FocusedRowChanged);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 300;
            this.toolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip_Popup);
            // 
            // bgw_run_data
            // 
            this.bgw_run_data.WorkerReportsProgress = true;
            this.bgw_run_data.WorkerSupportsCancellation = true;
            // 
            // spl_mng
            // 
            this.spl_mng.ClosingDelay = 500;
            // 
            // LC_New_plus_NNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LC_New_plus_NNC";
            this.Text = "LASTCHECK";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LC_New_plus_nnc_FormClosing);
            this.Load += new System.EventHandler(this.LC_New_plus_nnc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LC_New_plus_NNC_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_checkLogic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_checkLogic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grid_img;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_Img;
        private DevExpress.XtraGrid.GridControl grid_data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_data;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_checkLogic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_Export;
        private ImageViewerTR.ImageViewerTR ImgV;
        //private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Label lbsodong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblsoluonganh;
        private System.Windows.Forms.Button btn_Done;
        private DevExpress.XtraGrid.GridControl grid_checkLogic;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_checkLogic;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.BackgroundWorker bgw_run_data;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private DevExpress.XtraSplashScreen.SplashScreenManager spl_mng;
        private System.ComponentModel.BackgroundWorker bgWorker;
    }
}