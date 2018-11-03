using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schoolofmusic.DBAccess;
using Schoolofmusic.objects;

namespace Schoolofmusic
{
    public partial class frmAddBooking : Form
    {
        private Database db;
        public int pupNo, lessons, tuitNo, age, empleyNo, weeks, instrumentNo, Initialfee;
        Pupil Selected;
        bool fee, Duration;
        List<Instrument> TuitionArea = new List<Instrument>();
        double total, subtotal, discount, weekly, Discount;
        bool special = false;
        string level;
        DateTime newBookingDates;
        DateTime Date = new DateTime();
        Booking newBooking = new Booking();
        private DataTable table;

        public frmAddBooking(Database db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void frmAddBooking_Load(object sender, EventArgs e)
        {
            
            
            InstrumentDBAccess TuitionAccess = new InstrumentDBAccess(db);
            TuitionArea = TuitionAccess.getAllInstruments();

            // Add tuition to tuition combo box
            for (int i = 0; i < TuitionArea.Count; i++)
            {
                comboBox1.Items.Add(TuitionArea[i].InstrumentName);
            }

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Checks whether the lesson duration chosen is 30 mins or 60 mins
            if (comboBox3.Text == "30mins")
            {
                Duration = false;
            }
            else
            {
                Duration = true;
            }
            
            //Checks if the pupil paid the initial fee
            if (checkBox5.Checked == true)
            {
                fee = true;
                Initialfee = 0;
            }
            else
            {
                fee = false;
                Initialfee = 30;
            }
            
            //Checks the level chosen and assigns weekly fees
            switch (comboBox2.SelectedIndex)
            {
                case 0: level = "Beginner"; weekly = 12; break;
                case 1: level = "Intermediate"; weekly = 15; break;
                case 2: level = "Advanced"; weekly = 18; break;
                case 3: level = "Diploma"; weekly = 20; break;
            }
            
            // Checks if special circumstances box is checked
            if (checkBox6.Checked == true)
            {
                special = true;
            }
                // Calculates the fees
            else if (checkBox6.Checked == false)
            {
                special = false;

                if (checkBox1.Checked == true)
                {
                    lessons = 10;
                    discount = 0;
                }

                if (checkBox2.Checked == true)
                {
                    lessons = 20;
                    discount = 5;
                }

                if (checkBox3.Checked == true)
                {
                    lessons = 30;
                    discount = 10;
                }
            }
            // Assigns discount when special circumstances are present
            if (age > 60 || special == true)
            {
                discount = 20;
            }
            // Calculates the fee
            Discount = (weekly*lessons)/100 * discount;
            subtotal = Initialfee + (weekly*lessons);
            total = subtotal - Discount;
            label8.Text = Initialfee.ToString();
            label6.Text = subtotal.ToString();
            lblDiscount.Text = Discount.ToString();
            lblAmount.Text = weekly.ToString();
            lblTotal.Text = total.ToString(); 
        }
        // Sets the level
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn2_Click(object sender, EventArgs e)
        {
          
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            //Searches pupil by either pupilNo or LastName
            PupilDBAccess pupilAccess = new PupilDBAccess(db);
            List<Pupil> pupils = new List<Pupil>();
            if (string.IsNullOrWhiteSpace(PupilNotxt.Text))
            {
                pupils = pupilAccess.getPupilByPupilName(Nametxt.Text);
            }
            else
            {
                Selected = pupilAccess.getPupilByPupilNo(Convert.ToInt32(PupilNotxt.Text));
                pupils.Add(Selected);
            }
            // Creates table with pupil information
            table = new DataTable();
            table.Columns.Add("PupilNo");
            table.Columns.Add("First Name");
            table.Columns.Add("Last Name");
            addpupil(pupils);
            
        }
        // Displays the pupil information in a data grid
        private void addpupil(List<Pupil> Pupilresults)
        {
            foreach (Pupil pupil in Pupilresults)
            {
                table.Rows.Add(pupil.PupilNo,pupil.PupilFirstName, pupil.PupilLastName);
            }
            DataGrid.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {   // populates the labels with information about pupil
                if (DataGrid.SelectedRows.Count == 1)
                {
                    BookingDBAccess BA = new BookingDBAccess(db);
                    List<Booking> Booked = new List<Booking>();
                    Booked = BA.getAllBookings();
                    int rowNum = DataGrid.SelectedRows[0].Index;
                    int id = int.Parse(DataGrid.Rows[rowNum].Cells[0].Value.ToString());
                    PupilDBAccess pupilAccess = new PupilDBAccess(db);
                    Selected = pupilAccess.getPupilByPupilNo(id);
                    lblPupilNo.Text = Selected.PupilNo.ToString();
                    lblTitle.Text = Selected.PupilTitle;
                    lblFirstName.Text = Selected.PupilFirstName;
                    lblLastName.Text = Selected.PupilLastName;
                    lblDOB.Text = Selected.PupilDOB.ToString("d/MM/yyyy");
                    int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                    string date = DateTime.Now.ToShortDateString();
                    int dob = int.Parse(Selected.PupilDOB.ToString("yyyyMMdd"));
                    int age = (now - dob) / 10000;
                    lblAge.Text = age.ToString();
                    //fix this to autoNumber
                    lblBookingNo.Text = Convert.ToString(Booked[Booked.Count() - 1].bookingNo + 1);
                    timer1.Start();
                    lblDate.Text = date;
                    groupBox4.Enabled = false;
                    groupBox5.Enabled = false;
                    groupBox6.Enabled = false;
                    groupBox1.Enabled = true;
                    groupBox2.Enabled = true;
                    groupBox3.Enabled = true;
                }
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }

        // Allows the user to select the tuition type
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: instrumentNo = 1; break;
                case 1: instrumentNo = 2; break;
                case 2: instrumentNo = 3; break;
                case 3: instrumentNo = 4; break;
                case 4: instrumentNo = 5; break;
            }
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            //Validates if all of the required options were selected
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("To proceed you must select tuition type, lesson level and duration. ");
            }
            else
            {
                try
                {   //Inserts booking
                    int BookingNo = Convert.ToInt32(lblBookingNo.Text);
                    int NoOfLessons = lessons;
                    int instrumentNo = comboBox1.SelectedIndex;
                    
                    newBooking.BookingNo = BookingNo;
                    newBooking.Duration = Duration;
                    newBooking.PupilNo = int.Parse(lblPupilNo.Text);
                    BookingDBAccess BookingAccess = new BookingDBAccess(db);
                    BookingAccess.insertBooking(BookingNo, int.Parse(lblPupilNo.Text), instrumentNo, NoOfLessons, level, Duration, fee);

                    //Informs the user that booking was created and checks if user wants to block book instantly
                    DialogResult dialogResult = MessageBox.Show("Would you like to Block Book your lessons now?","Booking Created.", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Enables groupboxes related to block booking lessons
                        groupBox4.Enabled = true;
                        groupBox5.Enabled = true;
                        groupBox6.Enabled = true;

                        //Disables buttons related to booking
                        btnSearch.Enabled = false;
                        btnSelectPupil.Enabled = false;
                        btn2.Enabled = false;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        this.Hide();
                        frmPrivateTuition PTuition = new frmPrivateTuition(db);
                        PTuition.Show();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    cBoxTimeSlot.Items.Clear();
                    cBoxTimeSlot.Items.Add("9:00am to 9:30am");
                    cBoxTimeSlot.Items.Add("9:30am to 10:00am");
                    cBoxTimeSlot.Items.Add("10:00am to 10:30am");
                    cBoxTimeSlot.Items.Add("10:30am to 11:00am");
                    cBoxTimeSlot.Items.Add("11:00am to 11:30am");
                    cBoxTimeSlot.Items.Add("11:30am to 12:00pm");
                    cBoxTimeSlot.Items.Add("12:00pm to 12:30pm");
                    cBoxTimeSlot.Items.Add("12:30pm to 1:00pm");
                    cBoxTimeSlot.Items.Add("1:00pm to 1:30pm");
                    cBoxTimeSlot.Items.Add("1:30pm to 2:00pm");
                    cBoxTimeSlot.Items.Add("2:00pm to 2:30pm");
                    cBoxTimeSlot.Items.Add("2:30pm to 3:00pm");
                    cBoxTimeSlot.Items.Add("3:00pm to 3:30pm");
                    cBoxTimeSlot.Items.Add("3:30pm to 4:00pm");
                    cBoxTimeSlot.Items.Add("4:00pm to 4:30pm");
                    cBoxTimeSlot.Items.Add("4:30pm to 5:00pm");
                    cBoxTimeSlot.Items.Add("5:00pm to 5:30pm");
                    cBoxTimeSlot.Items.Add("5:30pm to 6:00pm");
                    cBoxTimeSlot.Items.Add("6:00pm to 6:30pm");
                    cBoxTimeSlot.Items.Add("6:30pm to 7:00pm");
                    cBoxTimeSlot.Items.Add("7:00pm to 7:30pm");
                    cBoxTimeSlot.Items.Add("7:30pm to 8:00pm");
                    cBoxTimeSlot.Items.Add("8:00pm to 8:30pm");
                    cBoxTimeSlot.Items.Add("8:30pm to 9:00pm");
                
                /*else
                {
                    cBoxTimeSlot.Items.Clear();
                    cBoxTimeSlot.Items.Add("9:00am to 10:00am");
                    cBoxTimeSlot.Items.Add("10:00am to 11:00am");
                    cBoxTimeSlot.Items.Add("11:00am to 12:00pm");
                    cBoxTimeSlot.Items.Add("12:00pm to 1:00pm");
                    cBoxTimeSlot.Items.Add("1:00pm to 2:00pm");
                    cBoxTimeSlot.Items.Add("2:00pm to 3:00pm");
                    cBoxTimeSlot.Items.Add("3:00pm to 4:00pm");
                    cBoxTimeSlot.Items.Add("4:00pm to 5:00pm");
                    cBoxTimeSlot.Items.Add("5:00pm to 6:00pm");
                    cBoxTimeSlot.Items.Add("6:00pm to 7:00pm");
                    cBoxTimeSlot.Items.Add("7:00pm to 8:00pm");
                    cBoxTimeSlot.Items.Add("8:00pm to 9:00pm");
                }*/
                // catch (Exception ex)
                //{
                // MessageBox.Show(ex.Message);
                // }
            }
        }

        private void check_CheckedChanged(object sender, MouseEventArgs e)
        {
            //Checks the number of lessons selected
            CheckBox cBox = sender as CheckBox;
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
            }
            if (checkBox3.Checked == true)
            {
                checkBox3.Checked = false;
            }
           
            cBox.Checked = true;
        }

        private void btn3_Click(object sender, EventArgs e)
        {   
            //Closes this form and opens Private Tuition Menu
            this.Hide();
            frmPrivateTuition PrivateTuition = new frmPrivateTuition(db);
            PrivateTuition.Show();
        }

        private void btnBlockBook_Click(object sender, EventArgs e)
        {

            groupBox4.Enabled = true;
            groupBox5.Enabled = true;
            groupBox6.Enabled = true;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;      
            groupBox3.Enabled = false;
            timer2.Start();
        }

        private void btnCreateBooking_Click(object sender, EventArgs e)
        {
            
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Saturday || dateTimePicker1.Value.DayOfWeek == DayOfWeek.Sunday || dateTimePicker1.Value.ToString("MMMM") == "June" || dateTimePicker1.Value.ToString("MMMM") == "July")
            {
                MessageBox.Show("Please select a week day");
            }
            else
            {
                if (dateTimePicker1.Value.DayOfWeek == DayOfWeek.Friday)
                {
                    if (comboBox3.Text == "30mins")
                    {
                        cBoxTimeSlot.Items.RemoveAt(cBoxTimeSlot.Items.Count-1);
                        cBoxTimeSlot.Items.RemoveAt(cBoxTimeSlot.Items.Count-1);
                    }
                }
            }
        }

        private void cBoxTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if its 60mins cannot pick last position
            if (cBoxTimeSlot.SelectedIndex == cBoxTimeSlot.Items.Count-1)
            {
                MessageBox.Show("Only 30 mins are available. Choose another time slot.");
            }
            else
            {
            BlockBookingDBAccess LA = new BlockBookingDBAccess(db);
            List<Room> FreeRooms = new List<Room>();
            List<Staff> FreeTutors = new List<Staff>();
            int amountOfLessons; 
            if(newBooking.Duration == true )//if 60 mins
            {
                amountOfLessons = newBooking.NoOfLessons /2;
            }
            else{
            amountOfLessons = newBooking.NoOfLessons;
            }
            DateTime lessonDate = dateTimePicker1.Value.Date;
            for (int i = 0; i < amountOfLessons; i++)
            {
                FreeRooms = LA.getAvailableRooms(lessonDate, cBoxTimeSlot.SelectedIndex);
                if (newBooking.Duration == true)//if 60 mins
                {
                    //add 1 to the timeslot and insert again
                    FreeRooms = LA.getAvailableRooms(lessonDate, cBoxTimeSlot.SelectedIndex+1);
                }
                lessonDate = lessonDate.AddDays(7);
            }
            for (int i = 0; i < amountOfLessons; i++)
            {
                FreeTutors = LA.getAvailableTutors(lessonDate, cBoxTimeSlot.SelectedIndex);
                if (newBooking.Duration == true)//if 60 mins
                {
                    //add 1 to the timeslot and insert again
                    FreeTutors = LA.getAvailableTutors(lessonDate, cBoxTimeSlot.SelectedIndex + 1);
                }
            }
            }
        }
    }
}