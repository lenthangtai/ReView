using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VCB_TEGAKI
{    
    public partial class frmChangePassword : Form
    {
        DAEntry_Entry daentry = new DAEntry_Entry();
        public frmChangePassword()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtusername.Text.Equals(""))
            { MessageBox.Show("Username is empty", "Information"); return; }
            if (txtpassold.Text.Equals(""))
            { MessageBox.Show("Old password is empty", "Information"); return; }
            if (txtpassnew.Text.Equals(""))
            { MessageBox.Show("New password is empty", "Information"); return; }
            if (txtRepassnew.Text.Equals(""))
            { MessageBox.Show("Re-new password is empty", "Information"); return; }
            if (!txtpassnew.Text.Equals(txtRepassnew.Text.Trim()))
            { MessageBox.Show("Re-new password incorrect", "Information"); return; }
            if (daentry.usr(txtusername.Text.Trim())[0].Equals(""))
            { MessageBox.Show("Username does not exist ", "Information"); return; }
            if (!txtpassold.Text.Trim().Equals(daentry.usr(txtusername.Text.Trim())[1]))
            { MessageBox.Show("Password is incorrect", "Information"); return; }
            daentry.Updatepassword(txtRepassnew.Text.Trim(), txtusername.Text.ToUpper().Trim());
            this.Close();
        }
    }
}
