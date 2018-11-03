using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schoolofmusic
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SchoolOfmusic1DataSet.Pupil' table. You can move, or remove it, as needed.
            this.PupilTableAdapter.Fill(this.SchoolOfmusic1DataSet.Pupil);

            this.reportViewer1.RefreshReport();
        }
    }
}
