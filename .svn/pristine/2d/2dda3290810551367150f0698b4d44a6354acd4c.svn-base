using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VCB_TEGAKI
{
    public partial class SoftwareInfo : Form
    {
        public SoftwareInfo()
        {
            InitializeComponent();
        }

        private void SoftwareInfo_Load(object sender, EventArgs e)
        {
            textBox1.SelectionStart = textBox1.Text.Length + 1;
        }

        private void SoftwareInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
