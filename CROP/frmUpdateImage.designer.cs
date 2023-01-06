namespace VCB_TEGAKI
{
    partial class frmUpdateImage
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateImage));
            this.btnSourceDirectoryBrow = new System.Windows.Forms.Button();
            this.txtSourceDirectory = new System.Windows.Forms.TextBox();
            this.lblSourceDirectoryBrow = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnUpImage = new System.Windows.Forms.Button();
            this.prbUpImage = new System.Windows.Forms.ProgressBar();
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.ComponentModel.BackgroundWorker();
            this.bgw3 = new System.ComponentModel.BackgroundWorker();
            this.bgw5 = new System.ComponentModel.BackgroundWorker();
            this.bgw6 = new System.ComponentModel.BackgroundWorker();
            this.bgw7 = new System.ComponentModel.BackgroundWorker();
            this.bgw8 = new System.ComponentModel.BackgroundWorker();
            this.bgw9 = new System.ComponentModel.BackgroundWorker();
            this.bgw4 = new System.ComponentModel.BackgroundWorker();
            this.bgw10 = new System.ComponentModel.BackgroundWorker();
            this.lblUp = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grThongke = new DevExpress.XtraGrid.GridControl();
            this.grThongkeV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.bgrImage = new System.ComponentModel.BackgroundWorker();
            this.btnDeleteall = new System.Windows.Forms.Button();
            this.btn_importMaster = new System.Windows.Forms.Button();
            this.rdb_img = new System.Windows.Forms.RadioButton();
            this.rdb_pdf = new System.Windows.Forms.RadioButton();
            this.cbb_ca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grThongke)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThongkeV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSourceDirectoryBrow
            // 
            this.btnSourceDirectoryBrow.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSourceDirectoryBrow.Location = new System.Drawing.Point(743, 12);
            this.btnSourceDirectoryBrow.Name = "btnSourceDirectoryBrow";
            this.btnSourceDirectoryBrow.Size = new System.Drawing.Size(122, 57);
            this.btnSourceDirectoryBrow.TabIndex = 18;
            this.btnSourceDirectoryBrow.Text = "Browse...";
            this.btnSourceDirectoryBrow.UseVisualStyleBackColor = true;
            this.btnSourceDirectoryBrow.Click += new System.EventHandler(this.btnSourceDirectoryBrow_Click);
            // 
            // txtSourceDirectory
            // 
            this.txtSourceDirectory.Enabled = false;
            this.txtSourceDirectory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSourceDirectory.Location = new System.Drawing.Point(2, 27);
            this.txtSourceDirectory.Name = "txtSourceDirectory";
            this.txtSourceDirectory.Size = new System.Drawing.Size(467, 26);
            this.txtSourceDirectory.TabIndex = 17;
            // 
            // lblSourceDirectoryBrow
            // 
            this.lblSourceDirectoryBrow.AutoSize = true;
            this.lblSourceDirectoryBrow.BackColor = System.Drawing.Color.Transparent;
            this.lblSourceDirectoryBrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDirectoryBrow.Location = new System.Drawing.Point(2, 5);
            this.lblSourceDirectoryBrow.Name = "lblSourceDirectoryBrow";
            this.lblSourceDirectoryBrow.Size = new System.Drawing.Size(101, 20);
            this.lblSourceDirectoryBrow.TabIndex = 16;
            this.lblSourceDirectoryBrow.Text = "Thư mục ảnh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "Pages:";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.BackColor = System.Drawing.Color.Transparent;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(71, 58);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(18, 20);
            this.lblPage.TabIndex = 31;
            this.lblPage.Text = "0";
            // 
            // btnUpImage
            // 
            this.btnUpImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpImage.ForeColor = System.Drawing.Color.Red;
            this.btnUpImage.Location = new System.Drawing.Point(229, 58);
            this.btnUpImage.Name = "btnUpImage";
            this.btnUpImage.Size = new System.Drawing.Size(163, 48);
            this.btnUpImage.TabIndex = 33;
            this.btnUpImage.Text = "START";
            this.btnUpImage.UseVisualStyleBackColor = false;
            this.btnUpImage.Click += new System.EventHandler(this.btnUpImage_Click);
            // 
            // prbUpImage
            // 
            this.prbUpImage.Location = new System.Drawing.Point(5, 108);
            this.prbUpImage.Name = "prbUpImage";
            this.prbUpImage.Size = new System.Drawing.Size(714, 20);
            this.prbUpImage.TabIndex = 34;
            // 
            // bgw1
            // 
            this.bgw1.WorkerReportsProgress = true;
            this.bgw1.WorkerSupportsCancellation = true;
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw1_DoWork);
            this.bgw1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw2
            // 
            this.bgw2.WorkerReportsProgress = true;
            this.bgw2.WorkerSupportsCancellation = true;
            this.bgw2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw2_DoWork);
            this.bgw2.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw3
            // 
            this.bgw3.WorkerReportsProgress = true;
            this.bgw3.WorkerSupportsCancellation = true;
            this.bgw3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw3_DoWork);
            this.bgw3.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw5
            // 
            this.bgw5.WorkerReportsProgress = true;
            this.bgw5.WorkerSupportsCancellation = true;
            this.bgw5.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw5_DoWork);
            this.bgw5.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw5.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw6
            // 
            this.bgw6.WorkerReportsProgress = true;
            this.bgw6.WorkerSupportsCancellation = true;
            this.bgw6.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw6_DoWork);
            this.bgw6.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw6.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw7
            // 
            this.bgw7.WorkerReportsProgress = true;
            this.bgw7.WorkerSupportsCancellation = true;
            this.bgw7.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw7_DoWork);
            this.bgw7.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw7.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw8
            // 
            this.bgw8.WorkerReportsProgress = true;
            this.bgw8.WorkerSupportsCancellation = true;
            this.bgw8.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw8_DoWork);
            this.bgw8.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw8.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw9
            // 
            this.bgw9.WorkerReportsProgress = true;
            this.bgw9.WorkerSupportsCancellation = true;
            this.bgw9.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw9_DoWork);
            this.bgw9.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw9.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw4
            // 
            this.bgw4.WorkerReportsProgress = true;
            this.bgw4.WorkerSupportsCancellation = true;
            this.bgw4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw4_DoWork);
            this.bgw4.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw4.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // bgw10
            // 
            this.bgw10.WorkerReportsProgress = true;
            this.bgw10.WorkerSupportsCancellation = true;
            this.bgw10.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw10_DoWork);
            this.bgw10.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw1_ProgressChanged);
            this.bgw10.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw1_RunWorkerCompleted);
            // 
            // lblUp
            // 
            this.lblUp.AutoSize = true;
            this.lblUp.BackColor = System.Drawing.Color.Transparent;
            this.lblUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUp.Location = new System.Drawing.Point(71, 86);
            this.lblUp.Name = "lblUp";
            this.lblUp.Size = new System.Drawing.Size(18, 20);
            this.lblUp.TabIndex = 36;
            this.lblUp.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Up:";
            // 
            // grThongke
            // 
            this.grThongke.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grThongke.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.RelationName = "Level1";
            this.grThongke.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grThongke.Location = new System.Drawing.Point(5, 134);
            this.grThongke.MainView = this.grThongkeV;
            this.grThongke.Name = "grThongke";
            this.grThongke.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.grThongke.Size = new System.Drawing.Size(714, 433);
            this.grThongke.TabIndex = 37;
            this.grThongke.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grThongkeV});
            // 
            // grThongkeV
            // 
            this.grThongkeV.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grThongkeV.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grThongkeV.GridControl = this.grThongke;
            this.grThongkeV.Name = "grThongkeV";
            this.grThongkeV.OptionsBehavior.Editable = false;
            this.grThongkeV.OptionsCustomization.AllowGroup = false;
            this.grThongkeV.OptionsFilter.AllowFilterEditor = false;
            this.grThongkeV.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.grThongkeV.OptionsFilter.DefaultFilterEditorView = DevExpress.XtraEditors.FilterEditorViewMode.VisualAndText;
            this.grThongkeV.OptionsFilter.ShowAllTableValuesInFilterPopup = true;
            this.grThongkeV.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grThongkeV.OptionsSelection.MultiSelect = true;
            this.grThongkeV.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.grThongkeV.OptionsView.ShowGroupPanel = false;
            this.grThongkeV.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.grThongkeV_CustomDrawRowIndicator_1);
            this.grThongkeV.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grThongkeV_MouseUp);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // bgrImage
            // 
            this.bgrImage.WorkerReportsProgress = true;
            this.bgrImage.WorkerSupportsCancellation = true;
            this.bgrImage.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgrImage_DoWork);
            this.bgrImage.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgrImage_ProgressChanged);
            this.bgrImage.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgrImage_RunWorkerCompleted);
            // 
            // btnDeleteall
            // 
            this.btnDeleteall.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteall.ForeColor = System.Drawing.Color.Red;
            this.btnDeleteall.Location = new System.Drawing.Point(743, 502);
            this.btnDeleteall.Name = "btnDeleteall";
            this.btnDeleteall.Size = new System.Drawing.Size(117, 54);
            this.btnDeleteall.TabIndex = 38;
            this.btnDeleteall.Text = "Delete All";
            this.btnDeleteall.UseVisualStyleBackColor = true;
            this.btnDeleteall.Click += new System.EventHandler(this.btnDeleteall_Click);
            // 
            // btn_importMaster
            // 
            this.btn_importMaster.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_importMaster.ForeColor = System.Drawing.Color.Blue;
            this.btn_importMaster.Location = new System.Drawing.Point(743, 223);
            this.btn_importMaster.Name = "btn_importMaster";
            this.btn_importMaster.Size = new System.Drawing.Size(122, 61);
            this.btn_importMaster.TabIndex = 39;
            this.btn_importMaster.Text = "Import File Master";
            this.btn_importMaster.UseVisualStyleBackColor = true;
            this.btn_importMaster.Visible = false;
            this.btn_importMaster.Click += new System.EventHandler(this.btn_importMaster_Click);
            // 
            // rdb_img
            // 
            this.rdb_img.AutoSize = true;
            this.rdb_img.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_img.Location = new System.Drawing.Point(765, 172);
            this.rdb_img.Name = "rdb_img";
            this.rdb_img.Size = new System.Drawing.Size(72, 24);
            this.rdb_img.TabIndex = 40;
            this.rdb_img.Text = "Image";
            this.rdb_img.UseVisualStyleBackColor = true;
            this.rdb_img.Visible = false;
            // 
            // rdb_pdf
            // 
            this.rdb_pdf.AutoSize = true;
            this.rdb_pdf.Checked = true;
            this.rdb_pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_pdf.Location = new System.Drawing.Point(488, 29);
            this.rdb_pdf.Name = "rdb_pdf";
            this.rdb_pdf.Size = new System.Drawing.Size(59, 24);
            this.rdb_pdf.TabIndex = 41;
            this.rdb_pdf.TabStop = true;
            this.rdb_pdf.Text = "PDF";
            this.rdb_pdf.UseVisualStyleBackColor = true;
            // 
            // cbb_ca
            // 
            this.cbb_ca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_ca.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_ca.FormattingEnabled = true;
            this.cbb_ca.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbb_ca.Location = new System.Drawing.Point(622, 25);
            this.cbb_ca.Name = "cbb_ca";
            this.cbb_ca.Size = new System.Drawing.Size(72, 32);
            this.cbb_ca.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(585, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 43;
            this.label1.Text = "CA";
            // 
            // lb_time
            // 
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_time.ForeColor = System.Drawing.Color.Red;
            this.lb_time.Location = new System.Drawing.Point(528, 83);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(71, 19);
            this.lb_time.TabIndex = 44;
            this.lb_time.Text = "Time Up:";
            // 
            // frmUpdateImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 568);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_ca);
            this.Controls.Add(this.rdb_pdf);
            this.Controls.Add(this.rdb_img);
            this.Controls.Add(this.btn_importMaster);
            this.Controls.Add(this.btnDeleteall);
            this.Controls.Add(this.grThongke);
            this.Controls.Add(this.lblUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prbUpImage);
            this.Controls.Add(this.btnUpImage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSourceDirectoryBrow);
            this.Controls.Add(this.txtSourceDirectory);
            this.Controls.Add(this.lblSourceDirectoryBrow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUpdateImage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Up Image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdateImage_FormClosing);
            this.Load += new System.EventHandler(this.frmUpdateImage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grThongke)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grThongkeV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnSourceDirectoryBrow;
        internal System.Windows.Forms.TextBox txtSourceDirectory;
        internal System.Windows.Forms.Label lblSourceDirectoryBrow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnUpImage;
        private System.Windows.Forms.ProgressBar prbUpImage;
        private System.ComponentModel.BackgroundWorker bgw1;
        private System.ComponentModel.BackgroundWorker bgw2;
        private System.ComponentModel.BackgroundWorker bgw3;
        private System.ComponentModel.BackgroundWorker bgw5;
        private System.ComponentModel.BackgroundWorker bgw6;
        private System.ComponentModel.BackgroundWorker bgw7;
        private System.ComponentModel.BackgroundWorker bgw8;
        private System.ComponentModel.BackgroundWorker bgw9;
        private System.ComponentModel.BackgroundWorker bgw4;
        private System.ComponentModel.BackgroundWorker bgw10;
        private System.Windows.Forms.Label lblUp;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl grThongke;
        private DevExpress.XtraGrid.Views.Grid.GridView grThongkeV;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private System.ComponentModel.BackgroundWorker bgrImage;
        private System.Windows.Forms.Button btnDeleteall;
        private System.Windows.Forms.Button btn_importMaster;
        private System.Windows.Forms.RadioButton rdb_img;
        private System.Windows.Forms.RadioButton rdb_pdf;
        private System.Windows.Forms.ComboBox cbb_ca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_time;
        //private DevExpress.XtraSplashScreen.SplashScreenManager spl_waitform;
    }
}