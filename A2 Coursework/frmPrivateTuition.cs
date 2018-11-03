using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schoolofmusic.objects;
using Schoolofmusic.DBAccess;

namespace Schoolofmusic
{
    public partial class frmPrivateTuition : Form
    {
        private Database db;

        public frmPrivateTuition(Database db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            frmShowPupils ShowPupils = new frmShowPupils(db);
            ShowPupils.Show();
        }

        private void frmPrivateTuition_Load(object sender, EventArgs e)
        {

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            frmShowTutors newStaff = new frmShowTutors(db);
            newStaff.Show();
        }

        private void btn8_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet.");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            frmReport Report = new frmReport();
            Report.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmShowBooking newBooking = new frmShowBooking(db);
            newBooking.Show();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            // Hides this form and opens MainMenu form
            this.Hide();
            frmMainMenu MainMenu = new frmMainMenu();
            MainMenu.Show();
        }
    }
}
