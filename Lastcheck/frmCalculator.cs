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
    public partial class frmCalculator : Form
    {
        public frmCalculator()
        {
            InitializeComponent();
        }

        private void txt1A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt1B.Focus();
            if (e.KeyCode == Keys.Down)
                txt2A.Focus();
        }

        private void txt1B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt1A.Focus();
            if (e.KeyCode == Keys.Down)
                txt2B.Focus();
            
        }

        private void txt2A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt2B.Focus();
            if (e.KeyCode == Keys.Down)
                txt3A.Focus();
            if (e.KeyCode == Keys.Up)
                txt1A.Focus();
        }

        private void txt2B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt2A.Focus();
            if (e.KeyCode == Keys.Down)
                txt3B.Focus();
            if (e.KeyCode == Keys.Up)
                txt1B.Focus();
        }

        private void txt3A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt3B.Focus();
            if (e.KeyCode == Keys.Down)
                txt4A.Focus();
            if (e.KeyCode == Keys.Up)
                txt2A.Focus();
        }

        private void txt3B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt3A.Focus();
            if (e.KeyCode == Keys.Down)
                txt4B.Focus();
            if (e.KeyCode == Keys.Up)
                txt2B.Focus();
        }

        private void txt4A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt4B.Focus();
            if (e.KeyCode == Keys.Down)
                txt5A.Focus();
            if (e.KeyCode == Keys.Up)
                txt3A.Focus();
        }

        private void txt5A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt5B.Focus();
            if (e.KeyCode == Keys.Down)
                txt6A.Focus();
            if (e.KeyCode == Keys.Up)
                txt4A.Focus();
        }

        private void txt6A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt6B.Focus();
            if (e.KeyCode == Keys.Down)
                txt7A.Focus();
            if (e.KeyCode == Keys.Up)
                txt5A.Focus();
        }

        private void txt7A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt7B.Focus();
            if (e.KeyCode == Keys.Down)
                txt8A.Focus();
            if (e.KeyCode == Keys.Up)
                txt6A.Focus();
        }

        private void txt8A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt8B.Focus();
            if (e.KeyCode == Keys.Down)
                txt9A.Focus();
            if (e.KeyCode == Keys.Up)
                txt7A.Focus();
        }

        private void txt9A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                txt9B.Focus();      
            if (e.KeyCode == Keys.Up)
                txt8A.Focus();
        }

        private void txt4B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt4A.Focus();
            if (e.KeyCode == Keys.Down)
                txt5B.Focus();
            if (e.KeyCode == Keys.Up)
                txt3B.Focus();
        }

        private void txt5B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt5A.Focus();
            if (e.KeyCode == Keys.Down)
                txt6B.Focus();
            if (e.KeyCode == Keys.Up)
                txt4B.Focus();
        }

        private void txt6B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt6A.Focus();
            if (e.KeyCode == Keys.Down)
                txt7B.Focus();
            if (e.KeyCode == Keys.Up)
                txt5B.Focus();
        }

        private void txt7B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt7A.Focus();
            if (e.KeyCode == Keys.Down)
                txt8B.Focus();
            if (e.KeyCode == Keys.Up)
                txt6B.Focus();
        }

        private void txt8B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt8A.Focus();
            if (e.KeyCode == Keys.Down)
                txt9B.Focus();
            if (e.KeyCode == Keys.Up)
                txt7B.Focus();
        }

        private void txt9B_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                txt9A.Focus();         
            if (e.KeyCode == Keys.Up)
                txt8B.Focus();
        }

        private void frmCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double vlout1A=0;double vlout2A=0;double vlout3A=0;double vlout4A=0;double vlout5A=0;double vlout6A=0; double vlout7A=0;double vlout8A=0;double vlout9A=0;
                 double vlout1B=0;double vlout2B=0;double vlout3B=0;double vlout4B=0;double vlout5B=0;double vlout6B=0; double vlout7B=0;double vlout8B=0;double vlout9B=0;
                double.TryParse(txt1A.Text,out vlout1A);
                 double.TryParse(txt2A.Text,out vlout2A);
                 double.TryParse(txt3A.Text,out vlout3A);
                 double.TryParse(txt4A.Text,out vlout4A);
                 double.TryParse(txt5A.Text,out vlout5A);
                 double.TryParse(txt6A.Text,out vlout6A);
                 double.TryParse(txt7A.Text,out vlout7A);
                 double.TryParse(txt8A.Text,out vlout8A);
                 double.TryParse(txt9A.Text,out vlout9A);
                 double.TryParse(txt1B.Text, out vlout1B);
                 double.TryParse(txt2B.Text, out vlout2B);
                 double.TryParse(txt3B.Text, out vlout3B);
                 double.TryParse(txt4B.Text, out vlout4B);
                 double.TryParse(txt5B.Text, out vlout5B);
                 double.TryParse(txt6B.Text, out vlout6B);
                 double.TryParse(txt7B.Text, out vlout7B);
                 double.TryParse(txt8B.Text, out vlout8B);
                 double.TryParse(txt9B.Text, out vlout9B);
                 lblTong.Text = ((vlout1A * vlout1B) + (vlout2A * vlout2B) + (vlout3A * vlout3B) + (vlout4A *vlout4B) + 
                     (vlout5A * vlout5B) + (vlout6A * vlout6B) + (vlout7A * vlout7B) + (vlout8A * vlout8B) +(vlout9A * vlout9B)).ToString();
              

            }
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
