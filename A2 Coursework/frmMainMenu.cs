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
    public partial class frmMainMenu : Form
    {
        private Database db;

        public frmMainMenu()
        {
            InitializeComponent();
            this.db = new Database();
            //Checks if the database is connected
            if (!db.connect())
            {
                MessageBox.Show("Database connection not opened. Error.");
                Application.Exit();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Closes this form and opens up Private Tuition Menu
            this.Hide();
            frmPrivateTuition PrivateTuition = new frmPrivateTuition(db);
            PrivateTuition.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet.");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet.");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature has not been implemented yet.");
        }

        private void btnShortcut_Click(object sender, EventArgs e)
        {
            //Opens the AddBooking from
            frmAddBooking Booking = new frmAddBooking(db);
            Booking.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Closes the application
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens the help form
            frmHelp Help = new frmHelp();
            Help.Show();
        }
    }
}
