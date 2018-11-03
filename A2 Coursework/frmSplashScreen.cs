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
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            ProgressBar.Value = 0; //sets the value to 0
        }
        

        private void picBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.ProgressBar.Increment(20); //increases the value of progress bar by 20
            if (ProgressBar.Value == 100)
            {
                timer1.Stop(); //stops the timer
                // Closes splash screen and opens the main menu form once the progress bar value reaches 100
                this.Hide();
                frmMainMenu MainMenu = new frmMainMenu();  
                MainMenu.Show();
            }
        }
    }

        
    }

