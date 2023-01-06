namespace VCB_TEGAKI
{
    partial class LC_Level
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LC_Level));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grid_img = new DevExpress.XtraGrid.GridControl();
            this.gridV_Img = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grid_data = new DevExpress.XtraGrid.GridControl();
            this.gridV_data = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_checkLogic = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_export = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridExport = new DevExpress.XtraGrid.GridControl();
            this.gridV_Export = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ImgV = new ImageViewerTR.ImageViewerTR();
            this.spl_wait = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(WaitForm4), true, true);
            this.timeLC = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_data)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.48705F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.51295F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1351, 730);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.splitContainer1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(577, 39);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(771, 688);
            this.panel4.TabIndex = 8;
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
            this.splitContainer1.Size = new System.Drawing.Size(771, 688);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // grid_img
            // 
            this.grid_img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_img.Location = new System.Drawing.Point(0, 0);
            this.grid_img.MainView = this.gridV_Img;
            this.grid_img.Name = "grid_img";
            this.grid_img.Size = new System.Drawing.Size(297, 688);
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
            this.gridV_Img.OptionsView.ShowGroupPanel = false;
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
            this.grid_data.Size = new System.Drawing.Size(470, 688);
            this.grid_data.TabIndex = 1;
            this.grid_data.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_data});
            this.grid_data.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_data_EditorKeyDown);
            this.grid_data.Leave += new System.EventHandler(this.grid_data_Leave);
            // 
            // gridV_data
            // 
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
            this.gridV_data.MouseLeave += new System.EventHandler(this.gridV_data_MouseLeave);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_save);
            this.panel3.Controls.Add(this.btn_checkLogic);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(577, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 30);
            this.panel3.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.OrangeRed;
            this.btn_save.Location = new System.Drawing.Point(666, 0);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(102, 30);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_checkLogic
            // 
            this.btn_checkLogic.Location = new System.Drawing.Point(3, 1);
            this.btn_checkLogic.Name = "btn_checkLogic";
            this.btn_checkLogic.Size = new System.Drawing.Size(102, 30);
            this.btn_checkLogic.TabIndex = 0;
            this.btn_checkLogic.Text = "Check Logic";
            this.btn_checkLogic.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_export);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(568, 30);
            this.panel2.TabIndex = 6;
            // 
            // btn_export
            // 
            this.btn_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_export.Location = new System.Drawing.Point(3, 1);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(102, 30);
            this.btn_export.TabIndex = 1;
            this.btn_export.Text = "Export";
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Visible = false;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridExport);
            this.panel1.Controls.Add(this.ImgV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 688);
            this.panel1.TabIndex = 5;
            // 
            // gridExport
            // 
            this.gridExport.Location = new System.Drawing.Point(54, 77);
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
            this.ImgV.Size = new System.Drawing.Size(568, 688);
            this.ImgV.TabIndex = 4;
            this.ImgV.TabStop = false;
            // 
            // spl_wait
            // 
            this.spl_wait.ClosingDelay = 500;
            // 
            // LC_Level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "LC_Level";
            this.Text = "LC SPOT 2021";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LC_Level_FormClosing);
            this.Load += new System.EventHandler(this.LC_Level_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LC_Level_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_data)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_checkLogic;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private ImageViewerTR.ImageViewerTR ImgV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraSplashScreen.SplashScreenManager spl_wait;
        private System.Windows.Forms.Timer timeLC;
        private DevExpress.XtraGrid.GridControl grid_img;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_Img;
        private DevExpress.XtraGrid.GridControl grid_data;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_data;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_export;
        private DevExpress.XtraGrid.GridControl gridExport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_Export;
    }
}