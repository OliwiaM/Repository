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
    public partial class frmShowTutors : Form
    {
        private Database db;
        private DataTable Table;
        string firstname, lastname, tuitionType;
        private int numRowsStart = 0;
        private int numRowsBeforeAdd;

        public frmShowTutors(Database db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void frmStaffMenu_Load(object sender, EventArgs e)
        {
            TutorDBAccess TDBAccess = new TutorDBAccess(db);
            CreateTableResults(TDBAccess.getAllTutors());

        }

        private void CreateTableResults(List<Staff> Staffresults)
        {
            Table = new DataTable();
            Table.Columns.Add("TutorNo");
            Table.Columns.Add("Title");
            Table.Columns.Add("First Name");
            Table.Columns.Add("Last Name");
            Table.Columns.Add("Tel Number");
            Table.Columns.Add("Email");
            Table.Columns.Add("Instrument");

            DGrid1.DataSource = Table;

            foreach (Staff tutor in Staffresults)
            {
                Table.Rows.Add(tutor.tutorNo, tutor.tutorTitle, tutor.tutorFirstName, tutor.tutorLastName, tutor.tutorTelNo, tutor.tutorEmail);
            }
            DGrid1.DataSource = Table;
            numRowsStart = DGrid1.Rows.Count - 2;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            PupilDBAccess Pdba = new PupilDBAccess(db);

            numRowsBeforeAdd = DGrid1.Rows.Count - 2;

            if (numRowsStart == numRowsBeforeAdd)
            {
                MessageBox.Show("You have not added any additional information to this table.", "Error.");
            }

            else if (numRowsBeforeAdd > numRowsStart + 1)
            {
                MessageBox.Show("You have tried to add too many rows. Only add one at a time.", "Error.");
            }

            else if (numRowsBeforeAdd == numRowsStart + 1)
            {
                addRowToTutor();
            }
        }

        public void addRowToTutor()
        {
            TutorDBAccess Tdba = new TutorDBAccess(db);
            int tutorNo = int.Parse(DGrid1.Rows[numRowsBeforeAdd].Cells[0].Value.ToString());
            String tutorTitle = DGrid1.Rows[numRowsBeforeAdd].Cells[1].Value.ToString();
            String tutorFirstName = DGrid1.Rows[numRowsBeforeAdd].Cells[2].Value.ToString();
            String tutorLastName = DGrid1.Rows[numRowsBeforeAdd].Cells[3].Value.ToString();
            String tutorTelNo = DGrid1.Rows[numRowsBeforeAdd].Cells[4].Value.ToString();
            String tutorEmail = DGrid1.Rows[numRowsBeforeAdd].Cells[5].Value.ToString();
            Tdba.insertTutor(tutorNo, tutorTitle, tutorFirstName, tutorLastName, tutorTelNo, tutorEmail);
            MessageBox.Show("The row has been added to the database table Department.", "Success.");
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            TutorDBAccess TDBAccess = new TutorDBAccess(db);
            int num = DGrid1.Rows.Count - 2;
            TutorDBAccess Tdba = new TutorDBAccess(db);
            int tutorNo = int.Parse(DGrid1.Rows[num].Cells[0].Value.ToString());
            String tutorTitle = DGrid1.Rows[num].Cells[1].Value.ToString();
            String tutorFirstName = DGrid1.Rows[num].Cells[2].Value.ToString();
            String tutorLastName = DGrid1.Rows[num].Cells[3].Value.ToString();
            String tutorTelNo = DGrid1.Rows[num].Cells[4].Value.ToString();
            String tutorEmail = DGrid1.Rows[num].Cells[5].Value.ToString();
            Tdba.updateTutor(tutorNo, tutorTitle, tutorFirstName, tutorLastName, tutorTelNo, tutorEmail);
            MessageBox.Show("The row in the database has been updated.", "Success.");
            DGrid1.DataSource = null;
            CreateTableResults(TDBAccess.getAllTutors());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TutorDBAccess TDBAccess = new TutorDBAccess(db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);
            List<Staff> tutors = new List<Staff>();
            Staff Selected = new Staff();
            Selected = TDBAccess.getTutorByTutorNo(Convert.ToInt32(txtBox1.Text));
            tutors.Add(Selected);
    
            CreateTableResults(tutors);
        }
        }
    }





        
    

