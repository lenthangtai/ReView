namespace VCB_Entry.Lastcheck
{
    partial class frm_table_export
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_table_export));
            this.grid_Export = new DevExpress.XtraGrid.GridControl();
            this.gridV_Export = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_Export
            // 
            this.grid_Export.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Export.Location = new System.Drawing.Point(0, 0);
            this.grid_Export.MainView = this.gridV_Export;
            this.grid_Export.Name = "grid_Export";
            this.grid_Export.Size = new System.Drawing.Size(1351, 670);
            this.grid_Export.TabIndex = 2;
            this.grid_Export.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridV_Export});
            // 
            // gridV_Export
            // 
            this.gridV_Export.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridV_Export.Appearance.Row.Options.UseFont = true;
            this.gridV_Export.GridControl = this.grid_Export;
            this.gridV_Export.IndicatorWidth = 30;
            this.gridV_Export.Name = "gridV_Export";
            this.gridV_Export.OptionsBehavior.Editable = false;
            this.gridV_Export.OptionsBehavior.ReadOnly = true;
            this.gridV_Export.OptionsCustomization.AllowFilter = false;
            this.gridV_Export.OptionsCustomization.AllowSort = false;
            this.gridV_Export.OptionsView.ColumnAutoWidth = false;
            this.gridV_Export.OptionsView.ShowGroupPanel = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grid_Export);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1351, 730);
            this.splitContainer1.SplitterDistance = 670;
            this.splitContainer1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_return);
            this.panel1.Controls.Add(this.btn_export);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1351, 56);
            this.panel1.TabIndex = 0;
            // 
            // btn_return
            // 
            this.btn_return.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_return.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_return.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_return.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_return.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_return.ForeColor = System.Drawing.Color.Snow;
            this.btn_return.Location = new System.Drawing.Point(3, 2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(140, 53);
            this.btn_return.TabIndex = 1;
            this.btn_return.Text = "RETURN BACK";
            this.btn_return.UseVisualStyleBackColor = false;
            this.btn_return.Click += new System.EventHandler(this.btn_return_Click);
            // 
            // btn_export
            // 
            this.btn_export.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_export.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_export.BackgroundImage")));
            this.btn_export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_export.Location = new System.Drawing.Point(1213, 0);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(135, 53);
            this.btn_export.TabIndex = 0;
            this.btn_export.UseVisualStyleBackColor = true;
            this.btn_export.Click += new System.EventHandler(this.btn_export_Click);
            // 
            // frm_table_export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 730);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_table_export";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHECK INFOMATION DATA EXPORT";
            this.Load += new System.EventHandler(this.frm_table_export_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Export)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridV_Export)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid_Export;
        private DevExpress.XtraGrid.Views.Grid.GridView gridV_Export;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Button btn_return;
    }
}