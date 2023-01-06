using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VCB_TEGAKI;

namespace VCB_Entry.Lastcheck
{
    public partial class frm_table_export : Form
    {
        public frm_table_export()
        {
            InitializeComponent();
        }
        public DataTable dt_export;
        
        private void frm_table_export_Load(object sender, EventArgs e)
        {
            grid_Export.DataSource = null;
            grid_Export.DataSource = dt_export;
            gridV_Export.BestFitColumns();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            LC_New_plus_NNC.bool_check_logic = true;
            this.Close();
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            LC_New_plus_NNC.bool_check_logic = false; this.Close();
        }
    }
    

}
