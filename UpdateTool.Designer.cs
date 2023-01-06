namespace VCB_Entry
{
    partial class UpdateTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grdFile = new DevExpress.XtraGrid.GridControl();
            this.grvFile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.button2 = new System.Windows.Forms.Button();
            this.lbTenFile = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cbTenFile = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFile)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.grdFile);
            this.panel1.Location = new System.Drawing.Point(1, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 164);
            this.panel1.TabIndex = 15;
            // 
            // grdFile
            // 
            this.grdFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFile.Location = new System.Drawing.Point(0, 0);
            this.grdFile.MainView = this.grvFile;
            this.grdFile.Name = "grdFile";
            this.grdFile.Size = new System.Drawing.Size(546, 164);
            this.grdFile.TabIndex = 0;
            this.grdFile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFile});
            // 
            // grvFile
            // 
            this.grvFile.GridControl = this.grdFile;
            this.grvFile.Name = "grvFile";
            this.grvFile.OptionsBehavior.ReadOnly = true;
            this.grvFile.OptionsView.ShowGroupPanel = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(379, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 84);
            this.button2.TabIndex = 14;
            this.button2.Text = "UP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbTenFile
            // 
            this.lbTenFile.AutoSize = true;
            this.lbTenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenFile.Location = new System.Drawing.Point(106, 21);
            this.lbTenFile.Name = "lbTenFile";
            this.lbTenFile.Size = new System.Drawing.Size(0, 20);
            this.lbTenFile.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(11, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 33);
            this.button1.TabIndex = 12;
            this.button1.Text = "Open...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbTenFile
            // 
            this.cbTenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenFile.FormattingEnabled = true;
            this.cbTenFile.Location = new System.Drawing.Point(11, 53);
            this.cbTenFile.Name = "cbTenFile";
            this.cbTenFile.Size = new System.Drawing.Size(352, 28);
            this.cbTenFile.TabIndex = 16;
            // 
            // UpdateTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 282);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbTenFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbTenFile);
            this.Name = "UpdateTool";
            this.Text = "UpdateTool";
            this.Load += new System.EventHandler(this.UpdateTool_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl grdFile;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFile;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbTenFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbTenFile;

    }
}