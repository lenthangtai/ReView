namespace VCB_TEGAKI
{
    partial class frmEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntry));
            this.timergetimage = new System.Windows.Forms.Timer(this.components);
            this.view_Image_TN = new ImageViewerTR.ImageViewerTR();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnNotgood = new System.Windows.Forms.Button();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl9 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsoluong = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblpage = new System.Windows.Forms.Label();
            this.btnsop = new System.Windows.Forms.Button();
            this.txt8 = new System.Windows.Forms.TextBox();
            this.txt9 = new System.Windows.Forms.TextBox();
            this.txtlb9 = new System.Windows.Forms.TextBox();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.txtlb5 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.txtlb4 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txtlb2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.txt7 = new System.Windows.Forms.TextBox();
            this.txtlb7 = new System.Windows.Forms.TextBox();
            this.lbl6 = new System.Windows.Forms.Label();
            this.txt6 = new System.Windows.Forms.TextBox();
            this.txtlb6 = new System.Windows.Forms.TextBox();
            this.lbl_6_chuthich = new System.Windows.Forms.Label();
            this.txtlb3 = new System.Windows.Forms.TextBox();
            this.txtlb8 = new System.Windows.Forms.TextBox();
            this.pb_img = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).BeginInit();
            this.SuspendLayout();
            // 
            // timergetimage
            // 
            this.timergetimage.Interval = 500;
            this.timergetimage.Tick += new System.EventHandler(this.timergetimage_Tick);
            // 
            // view_Image_TN
            // 
            this.view_Image_TN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.view_Image_TN.BackColor = System.Drawing.Color.LightGray;
            this.view_Image_TN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.view_Image_TN.CurrentZoom = 1F;
            this.view_Image_TN.Image = null;
            this.view_Image_TN.Location = new System.Drawing.Point(3, 12);
            this.view_Image_TN.MaxZoom = 20F;
            this.view_Image_TN.MinZoom = 0.05F;
            this.view_Image_TN.Name = "view_Image_TN";
            this.view_Image_TN.Size = new System.Drawing.Size(435, 714);
            this.view_Image_TN.TabIndex = 0;
            this.view_Image_TN.TabStop = false;
            this.view_Image_TN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.view_Image_TN_MouseDown);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(1120, 1);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(122, 31);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.TabStop = false;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnNotgood
            // 
            this.btnNotgood.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotgood.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotgood.Location = new System.Drawing.Point(442, 12);
            this.btnNotgood.Name = "btnNotgood";
            this.btnNotgood.Size = new System.Drawing.Size(109, 31);
            this.btnNotgood.TabIndex = 10;
            this.btnNotgood.TabStop = false;
            this.btnNotgood.Text = "Not Good";
            this.btnNotgood.UseVisualStyleBackColor = true;
            this.btnNotgood.Visible = false;
            this.btnNotgood.Click += new System.EventHandler(this.btnNotgood_Click);
            // 
            // lbl8
            // 
            this.lbl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl8.AutoSize = true;
            this.lbl8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.Location = new System.Drawing.Point(440, 110);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(87, 13);
            this.lbl8.TabIndex = 160;
            this.lbl8.Text = "8-直送先コード";
            // 
            // lbl5
            // 
            this.lbl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(865, 143);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(125, 13);
            this.lbl5.TabIndex = 163;
            this.lbl5.Text = "5-SL/取引数量（バラ）";
            // 
            // lbl4
            // 
            this.lbl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(713, 143);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(87, 13);
            this.lbl4.TabIndex = 162;
            this.lbl4.Text = "4-Mã SP/品番";
            // 
            // lbl9
            // 
            this.lbl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl9.AutoSize = true;
            this.lbl9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl9.Location = new System.Drawing.Point(1308, 102);
            this.lbl9.Name = "lbl9";
            this.lbl9.Size = new System.Drawing.Size(66, 26);
            this.lbl9.TabIndex = 161;
            this.lbl9.Text = "9-Ghi chú 3\r\n/予備項目3";
            // 
            // lbl2
            // 
            this.lbl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(465, 142);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(147, 13);
            this.lbl2.TabIndex = 159;
            this.lbl2.Text = "2-Mã đơn hàng/発注 NO";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 171;
            this.label3.Text = "Tên ảnh:";
            // 
            // lblsoluong
            // 
            this.lblsoluong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsoluong.AutoSize = true;
            this.lblsoluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsoluong.ForeColor = System.Drawing.Color.Blue;
            this.lblsoluong.Location = new System.Drawing.Point(655, 7);
            this.lblsoluong.Name = "lblsoluong";
            this.lblsoluong.Size = new System.Drawing.Size(18, 20);
            this.lblsoluong.TabIndex = 170;
            this.lblsoluong.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(567, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 169;
            this.label7.Text = "Số lượng còn lại:";
            // 
            // lblpage
            // 
            this.lblpage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblpage.AutoSize = true;
            this.lblpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblpage.ForeColor = System.Drawing.Color.Blue;
            this.lblpage.Location = new System.Drawing.Point(628, 31);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(35, 18);
            this.lblpage.TabIndex = 168;
            this.lblpage.Text = "ảnh";
            // 
            // btnsop
            // 
            this.btnsop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsop.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsop.Location = new System.Drawing.Point(1280, 1);
            this.btnsop.Name = "btnsop";
            this.btnsop.Size = new System.Drawing.Size(67, 33);
            this.btnsop.TabIndex = 177;
            this.btnsop.TabStop = false;
            this.btnsop.Text = "SOP";
            this.btnsop.UseVisualStyleBackColor = true;
            this.btnsop.Click += new System.EventHandler(this.btnsop_Click);
            // 
            // txt8
            // 
            this.txt8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt8.Location = new System.Drawing.Point(573, 102);
            this.txt8.Name = "txt8";
            this.txt8.Size = new System.Drawing.Size(340, 29);
            this.txt8.TabIndex = 8;
            this.txt8.Visible = false;
            this.txt8.TextChanged += new System.EventHandler(this.txt8_TextChanged);
            this.txt8.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt8_KeyDown);
            this.txt8.Leave += new System.EventHandler(this.txt8_Leave);
            // 
            // txt9
            // 
            this.txt9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt9.Location = new System.Drawing.Point(1337, 132);
            this.txt9.Multiline = true;
            this.txt9.Name = "txt9";
            this.txt9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt9.Size = new System.Drawing.Size(10, 594);
            this.txt9.TabIndex = 9;
            this.txt9.Visible = false;
            this.txt9.TextChanged += new System.EventHandler(this.txt9_TextChanged);
            this.txt9.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt9_KeyDown);
            this.txt9.Leave += new System.EventHandler(this.txt9_Leave);
            // 
            // txtlb9
            // 
            this.txtlb9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb9.Enabled = false;
            this.txtlb9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb9.Location = new System.Drawing.Point(1318, 131);
            this.txtlb9.Multiline = true;
            this.txtlb9.Name = "txtlb9";
            this.txtlb9.ReadOnly = true;
            this.txtlb9.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb9.Size = new System.Drawing.Size(45, 594);
            this.txtlb9.TabIndex = 16;
            this.txtlb9.TabStop = false;
            // 
            // txt5
            // 
            this.txt5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.Location = new System.Drawing.Point(893, 159);
            this.txt5.Multiline = true;
            this.txt5.Name = "txt5";
            this.txt5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt5.Size = new System.Drawing.Size(92, 559);
            this.txt5.TabIndex = 5;
            this.txt5.Visible = false;
            this.txt5.TextChanged += new System.EventHandler(this.txt5_TextChanged);
            this.txt5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt5_KeyDown);
            this.txt5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt5_KeyPress);
            this.txt5.Leave += new System.EventHandler(this.txt5_Leave);
            // 
            // txtlb5
            // 
            this.txtlb5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb5.Enabled = false;
            this.txtlb5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb5.Location = new System.Drawing.Point(868, 159);
            this.txtlb5.Multiline = true;
            this.txtlb5.Name = "txtlb5";
            this.txtlb5.ReadOnly = true;
            this.txtlb5.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb5.Size = new System.Drawing.Size(45, 559);
            this.txtlb5.TabIndex = 14;
            this.txtlb5.TabStop = false;
            this.txtlb5.Visible = false;
            // 
            // txt4
            // 
            this.txt4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.Location = new System.Drawing.Point(671, 159);
            this.txt4.Multiline = true;
            this.txt4.Name = "txt4";
            this.txt4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt4.Size = new System.Drawing.Size(195, 559);
            this.txt4.TabIndex = 4;
            this.txt4.Visible = false;
            this.txt4.TextChanged += new System.EventHandler(this.txt4_TextChanged);
            this.txt4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt4_KeyDown);
            this.txt4.Leave += new System.EventHandler(this.txt4_Leave);
            // 
            // txtlb4
            // 
            this.txtlb4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb4.Enabled = false;
            this.txtlb4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb4.Location = new System.Drawing.Point(647, 159);
            this.txtlb4.Multiline = true;
            this.txtlb4.Name = "txtlb4";
            this.txtlb4.ReadOnly = true;
            this.txtlb4.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb4.Size = new System.Drawing.Size(45, 559);
            this.txtlb4.TabIndex = 12;
            this.txtlb4.TabStop = false;
            this.txtlb4.Visible = false;
            // 
            // txt2
            // 
            this.txt2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.Location = new System.Drawing.Point(465, 159);
            this.txt2.Multiline = true;
            this.txt2.Name = "txt2";
            this.txt2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt2.Size = new System.Drawing.Size(180, 559);
            this.txt2.TabIndex = 2;
            this.txt2.Visible = false;
            this.txt2.TextChanged += new System.EventHandler(this.txt2_TextChanged);
            this.txt2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt2_KeyDown);
            this.txt2.Leave += new System.EventHandler(this.txt2_Leave);
            // 
            // txtlb2
            // 
            this.txtlb2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb2.Enabled = false;
            this.txtlb2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb2.Location = new System.Drawing.Point(442, 159);
            this.txtlb2.Multiline = true;
            this.txtlb2.Name = "txtlb2";
            this.txtlb2.ReadOnly = true;
            this.txtlb2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb2.Size = new System.Drawing.Size(49, 559);
            this.txtlb2.TabIndex = 2;
            this.txtlb2.TabStop = false;
            this.txtlb2.Visible = false;
            this.txtlb2.TextChanged += new System.EventHandler(this.txtlb2_TextChanged);
            // 
            // txt3
            // 
            this.txt3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3.Location = new System.Drawing.Point(573, 60);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(340, 29);
            this.txt3.TabIndex = 3;
            this.txt3.Visible = false;
            this.txt3.TextChanged += new System.EventHandler(this.txt3_TextChanged_1);
            this.txt3.Leave += new System.EventHandler(this.txt3_Leave_1);
            // 
            // lbl3
            // 
            this.lbl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(440, 69);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(128, 13);
            this.lbl3.TabIndex = 181;
            this.lbl3.Text = "3-Message/メッセージ:";
            // 
            // lbl7
            // 
            this.lbl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(1171, 143);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(94, 13);
            this.lbl7.TabIndex = 184;
            this.lbl7.Text = "7-Ghi chú/備考";
            // 
            // txt7
            // 
            this.txt7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt7.Location = new System.Drawing.Point(1120, 159);
            this.txt7.Multiline = true;
            this.txt7.Name = "txt7";
            this.txt7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt7.Size = new System.Drawing.Size(222, 559);
            this.txt7.TabIndex = 7;
            this.txt7.Visible = false;
            this.txt7.TextChanged += new System.EventHandler(this.txt7_TextChanged);
            this.txt7.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt7_KeyDown);
            this.txt7.Leave += new System.EventHandler(this.txt7_Leave);
            // 
            // txtlb7
            // 
            this.txtlb7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb7.Enabled = false;
            this.txtlb7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb7.Location = new System.Drawing.Point(1098, 159);
            this.txtlb7.Multiline = true;
            this.txtlb7.Name = "txtlb7";
            this.txtlb7.ReadOnly = true;
            this.txtlb7.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb7.Size = new System.Drawing.Size(45, 559);
            this.txtlb7.TabIndex = 183;
            this.txtlb7.TabStop = false;
            this.txtlb7.Visible = false;
            // 
            // lbl6
            // 
            this.lbl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(996, 143);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(87, 13);
            this.lbl6.TabIndex = 187;
            this.lbl6.Text = "6-Đơn vị/形態";
            // 
            // txt6
            // 
            this.txt6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt6.Location = new System.Drawing.Point(1012, 159);
            this.txt6.Multiline = true;
            this.txt6.Name = "txt6";
            this.txt6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt6.Size = new System.Drawing.Size(85, 559);
            this.txt6.TabIndex = 6;
            this.txt6.Visible = false;
            this.txt6.TextChanged += new System.EventHandler(this.txt6_TextChanged);
            this.txt6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt6_KeyDown);
            this.txt6.Leave += new System.EventHandler(this.txt6_Leave);
            // 
            // txtlb6
            // 
            this.txtlb6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb6.Enabled = false;
            this.txtlb6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb6.Location = new System.Drawing.Point(988, 159);
            this.txtlb6.Multiline = true;
            this.txtlb6.Name = "txtlb6";
            this.txtlb6.ReadOnly = true;
            this.txtlb6.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb6.Size = new System.Drawing.Size(45, 559);
            this.txtlb6.TabIndex = 186;
            this.txtlb6.TabStop = false;
            this.txtlb6.Visible = false;
            // 
            // lbl_6_chuthich
            // 
            this.lbl_6_chuthich.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_6_chuthich.AutoSize = true;
            this.lbl_6_chuthich.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_6_chuthich.ForeColor = System.Drawing.Color.Red;
            this.lbl_6_chuthich.Location = new System.Drawing.Point(941, 61);
            this.lbl_6_chuthich.Name = "lbl_6_chuthich";
            this.lbl_6_chuthich.Size = new System.Drawing.Size(68, 24);
            this.lbl_6_chuthich.TabIndex = 188;
            this.lbl_6_chuthich.Text = "6-形態";
            // 
            // txtlb3
            // 
            this.txtlb3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb3.Enabled = false;
            this.txtlb3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb3.Location = new System.Drawing.Point(573, 61);
            this.txtlb3.Multiline = true;
            this.txtlb3.Name = "txtlb3";
            this.txtlb3.ReadOnly = true;
            this.txtlb3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb3.Size = new System.Drawing.Size(49, 22);
            this.txtlb3.TabIndex = 189;
            this.txtlb3.TabStop = false;
            this.txtlb3.Visible = false;
            // 
            // txtlb8
            // 
            this.txtlb8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtlb8.Enabled = false;
            this.txtlb8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlb8.Location = new System.Drawing.Point(755, 102);
            this.txtlb8.Name = "txtlb8";
            this.txtlb8.ReadOnly = true;
            this.txtlb8.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtlb8.Size = new System.Drawing.Size(45, 29);
            this.txtlb8.TabIndex = 190;
            this.txtlb8.TabStop = false;
            // 
            // pb_img
            // 
            this.pb_img.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_img.Location = new System.Drawing.Point(3, 12);
            this.pb_img.Name = "pb_img";
            this.pb_img.Size = new System.Drawing.Size(435, 714);
            this.pb_img.TabIndex = 191;
            this.pb_img.TabStop = false;
            // 
            // frmEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 738);
            this.Controls.Add(this.lbl_6_chuthich);
            this.Controls.Add(this.lbl6);
            this.Controls.Add(this.txt6);
            this.Controls.Add(this.txtlb6);
            this.Controls.Add(this.lbl7);
            this.Controls.Add(this.txt7);
            this.Controls.Add(this.txtlb7);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.txt8);
            this.Controls.Add(this.btnsop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblsoluong);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblpage);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.lbl5);
            this.Controls.Add(this.lbl4);
            this.Controls.Add(this.lbl9);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.txt9);
            this.Controls.Add(this.txtlb9);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.txtlb5);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txtlb4);
            this.Controls.Add(this.btnNotgood);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txtlb2);
            this.Controls.Add(this.txtlb8);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txtlb3);
            this.Controls.Add(this.view_Image_TN);
            this.Controls.Add(this.pb_img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmEntry";
            this.Text = "Entry";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntry_FormClosing);
            this.Load += new System.EventHandler(this.frmEntry_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEntry_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmEntry_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pb_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timergetimage;
        private ImageViewerTR.ImageViewerTR view_Image_TN;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txtlb2;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnNotgood;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.TextBox txtlb4;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.TextBox txtlb5;
        private System.Windows.Forms.TextBox txt9;
        private System.Windows.Forms.TextBox txtlb9;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl9;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsoluong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.Button btnsop;
        private System.Windows.Forms.TextBox txt8;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.TextBox txt7;
        private System.Windows.Forms.TextBox txtlb7;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.TextBox txt6;
        private System.Windows.Forms.TextBox txtlb6;
        private System.Windows.Forms.Label lbl_6_chuthich;
        private System.Windows.Forms.TextBox txtlb3;
        private System.Windows.Forms.TextBox txtlb8;
        private System.Windows.Forms.PictureBox pb_img;
    }
}