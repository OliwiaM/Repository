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
    public partial class frmShowBooking : Form
    {
        private Database db;
        private DataTable Table;
        string InstrumentName;
        //setup variables to hold pupil information
        string firstname, lastname;
        int selection;

        public frmShowBooking(Database db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void frmShowBooking_Load(object sender, EventArgs e)
        {
            BookingDBAccess BDBAccess = new BookingDBAccess (db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);
            PupilDBAccess PDBAccess = new PupilDBAccess(db);
            selection       = cBox.SelectedIndex;
            lbl1.Visible    = false;
            lbl2.Visible    = false;
            btnSearch.Visible    = false;
            txtBox1.Visible = false;
            txtBox2.Visible = false;


        }

        private void CreateTableResults(List<Booking> Bookingresults, List<Instrument> Instrumentresults, List<Pupil> Pupilresults)
        {
            Table = new DataTable();
            Table.Columns.Add("PupilNo");
            Table.Columns.Add("First Name");
            Table.Columns.Add("Last Name");
            Table.Columns.Add("Booking Number");
            Table.Columns.Add("Instrument Name");
            Table.Columns.Add("Number of Lessons");
            Table.Columns.Add("Level");
            Table.Columns.Add("Duration");
            Table.Columns.Add("Fee Paid");
            //label1.Text = Bookingresults.Count.ToString();
            //Loop over Booking list to find relating information and display on screen
            for (int i = 0; i < Bookingresults.Count; i++)
            {
                for (int y = 0; y < Pupilresults.Count; y++)
                {
                    if (Bookingresults[i].PupilNo == Pupilresults[y].PupilNo) 
                    {
                        firstname = Pupilresults[y].pupilFirstName;
                        lastname = Pupilresults[y].pupilLastName;
                    }
                }

                //Find matching Tuition type from tuition list and display it
                for (int x = 0; x < Instrumentresults.Count; x++)
                {
                    if (Bookingresults[i].InstrumentNo == Instrumentresults[x].InstrumentNo) 
                    {
                        InstrumentName = Instrumentresults[x].InstrumentName;
                    }
                }
                Table.Rows.Add(Bookingresults[i].pupilNo, firstname, lastname,  Bookingresults[i].bookingNo, InstrumentName,
                   Bookingresults[i].noOfLessons, Bookingresults[i].level, Bookingresults[i].Duration, Bookingresults[i].initialFee); 
            }
            
            DataGrid.DataSource = Table;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddBooking Booking = new frmAddBooking(db);
            Booking.Show();
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            /*if (DGrid1.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Row selected", "error");
            }
            else if (DGrid1.SelectedRows.Count > 1)
            {
                MessageBox.Show("There are too many rows selected. Only select one please." + "Error");
            }
            else if (DGrid1.SelectedRows.Count == 1)
            {

                int rowNum = DGrid1.SelectedRows[0].Index; //gets row selected by user
                BookingDBAccess BookingAccess = new BookingDBAccess(db);
                int BookingNo = int.Parse(DGrid1.Rows[rowNum].Cells[0].Value.ToString());
                Booking Book = new Booking();
                Book = BookingAccess.getBookingByID(BookingNo);
                BookingAccess.deleteBookingWithID(Book.BookingNo);*/

            }
        

        private void btn1_Click(object sender, EventArgs e)
        {
            //Searches pupil by either pupilNo or LastName
            PupilDBAccess pupilAccess = new PupilDBAccess(db);
            BookingDBAccess BookingAccess = new BookingDBAccess(db);
            List<Pupil> pupils = new List<Pupil>();
            List<Booking> bookings = new List<Booking>();
            List<Instrument> instruments = new List<Instrument>();
            Booking Selected = new Booking();
            if (string.IsNullOrWhiteSpace(txtBox1.Text))
            {
                Selected = BookingAccess.getBookingByPupilID(Convert.ToInt32(txtBox2.Text));
                bookings.Add(Selected);
            } 
            
            else
            {
                Selected = BookingAccess.getBookingByID(Convert.ToInt32(txtBox1.Text));
                bookings.Add(Selected);
            }

            CreateTableResults(bookings,instruments,pupils);           
        
        }

        private void cBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            PupilDBAccess PDBAccess = new PupilDBAccess(db);
            BookingDBAccess BDBAccess = new BookingDBAccess(db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);

            switch (cBox.SelectedIndex)
            {

                case 0: CreateTableResults(BDBAccess.getAllBookings(), IDBAccess.getAllInstruments(), PDBAccess.getAllPupils()); break;
                case 1:     lbl1.Visible    = true;
                            lbl2.Visible    = true;
                            btnSearch.Visible    = true;
                            txtBox1.Visible = true;
                            txtBox2.Visible = true; break;
            }
        }
    }
    }


    

