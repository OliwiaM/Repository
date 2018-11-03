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
    public partial class frmShowPupils : Form
    {
        private Database db;
        private DataTable Table;
        private int numRowsStart = 0;
        private int numRowsBeforeAdd;
        int selection;
        //Pupil Selected;

        public frmShowPupils(Database db)
        {
            this.db = db;
            InitializeComponent();
        }

        private void frmShowPupils_Load(object sender, EventArgs e)
        {
            PupilDBAccess PDBAccess = new PupilDBAccess(db);
            BookingDBAccess BDBAccess = new BookingDBAccess(db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);
            selection = cBox.SelectedIndex;
            lbl1.Visible = false;
            lbl2.Visible = false;
            txtBoxID.Visible = false;
            txtBoxName.Visible = false;
            btn1.Visible = false;
        }

        private void CreateTableResults(List<Pupil> Pupilresults)
        {
            Table = new DataTable();
            Table.Columns.Add("PupilNo");
            Table.Columns.Add("Title");
            Table.Columns.Add("First Name");
            Table.Columns.Add("Last Name");
            Table.Columns.Add("DOB");
            Table.Columns.Add("Address");
            Table.Columns.Add("Post Code");
            Table.Columns.Add("Tel Number");
            Table.Columns.Add("Email");

            DataGrid.DataSource = Table;

            foreach (Pupil pupil in Pupilresults)
            {
                Table.Rows.Add(pupil.pupilNo, pupil.pupilTitle, pupil.pupilFirstName, pupil.PupilLastName, pupil.PupilDOB,
                    pupil.PupilAddress, pupil.PupilPostCode, pupil.PupilTelNo, pupil.PupilEmail);
            }
            numRowsStart = DataGrid.Rows.Count - 2;
            DataGrid.DataSource = Table;
        }

        // Displays the pupil information in a data grid
        private void addpupil(List<Pupil> Pupilresults)
        {
            foreach (Pupil pupil in Pupilresults)
            {
                Table.Rows.Add(pupil.PupilNo, pupil.PupilTitle, pupil.PupilFirstName, pupil.PupilLastName,pupil.PupilDOB, pupil.PupilAddress, pupil.PupilPostCode, pupil.PupilTelNo, pupil.PupilEmail);
            }
            DataGrid.DataSource = Table;
        }

      
        private void frmShowPupils_Load_1(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (DataGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("No Row selected", "error");
            }
            else if (DataGrid.SelectedRows.Count > 1)
            {
                MessageBox.Show("There are too many rows selected. Only select one please." + "Error");
            }
            else if (DataGrid.SelectedRows.Count == 1)
            {

                int rowNum = DataGrid.SelectedRows[0].Index; //gets row selected by user

                PupilDBAccess PupilAccess = new PupilDBAccess(db);
                int pupilNo = int.Parse(DataGrid.Rows[rowNum].Cells[0].Value.ToString());
                Pupil pup = new Pupil();
                pup = PupilAccess.getPupilByPupilNo(pupilNo);
                PupilAccess.DeletePupilWithID(pup.pupilNo);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PupilDBAccess Pdba = new PupilDBAccess(db);
            
            numRowsBeforeAdd = DataGrid.Rows.Count - 2;

            if (numRowsStart == numRowsBeforeAdd)
            {
                MessageBox.Show("You have not added any additional information to this table.", "Error.");
            }

            else if (numRowsBeforeAdd > numRowsStart+1)
            {
                MessageBox.Show("You have tried to add too many rows. Only add one at a time.", "Error.");
            }

            else if (numRowsBeforeAdd == numRowsStart + 1)
            {
                addRowToPupil();
            }
            
            }

        public void addRowToPupil()
        {
            PupilDBAccess Pdba = new PupilDBAccess(db);
            int pupilNo = int.Parse(DataGrid.Rows[numRowsBeforeAdd].Cells[0].Value.ToString());
            String pupilTitle = DataGrid.Rows[numRowsBeforeAdd].Cells[1].Value.ToString();
            String pupilFirstName = DataGrid.Rows[numRowsBeforeAdd].Cells[2].Value.ToString();
            String pupilLastName = DataGrid.Rows[numRowsBeforeAdd].Cells[3].Value.ToString();
            String pupilDOB = DataGrid.Rows[numRowsBeforeAdd].Cells[4].Value.ToString();
            String pupilAddress = DataGrid.Rows[numRowsBeforeAdd].Cells[5].Value.ToString();
            String pupilPostCode = DataGrid.Rows[numRowsBeforeAdd].Cells[6].Value.ToString();
            String pupilTelNo = DataGrid.Rows[numRowsBeforeAdd].Cells[7].Value.ToString();
            String pupilEmail = DataGrid.Rows[numRowsBeforeAdd].Cells[8].Value.ToString();
            Pdba.insertPupil(pupilNo,pupilTitle, pupilFirstName, pupilLastName, pupilDOB, pupilAddress,pupilPostCode, pupilTelNo, pupilEmail);
            MessageBox.Show("The row has been added to the database table Pupil.", "Success.");
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            int num = DataGrid.Rows.Count - 2;
            PupilDBAccess Pdba = new PupilDBAccess(db);
            int pupilNo = int.Parse(DataGrid.Rows[num].Cells[0].Value.ToString());
            string pupilTitle = DataGrid.Rows[num].Cells[1].Value.ToString();
            string pupilFirstName = DataGrid.Rows[num].Cells[2].Value.ToString();
            string pupilLastName = DataGrid.Rows[num].Cells[3].Value.ToString();
            string pupilDOB = DataGrid.Rows[num].Cells[4].Value.ToString();
            string pupilAddress = DataGrid.Rows[num].Cells[5].Value.ToString();
            string pupilPostCode = DataGrid.Rows[num].Cells[6].Value.ToString();
            string pupilTelNo = DataGrid.Rows[num].Cells[7].Value.ToString();
            string pupilEmail = DataGrid.Rows[num].Cells[8].Value.ToString();
            Pdba.updatePupil(pupilNo,pupilTitle, pupilFirstName, pupilLastName, pupilDOB, pupilAddress, pupilPostCode, pupilTelNo,pupilEmail);
            MessageBox.Show("The row in the database has been updated.", "Success.");
            DataGrid.DataSource = null; 
        }

        private void cBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PupilDBAccess PDBAccess = new PupilDBAccess(db);
            BookingDBAccess BDBAccess = new BookingDBAccess(db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);

            switch (cBox.SelectedIndex)
            {
                   
                case 0: CreateTableResults(PDBAccess.getAllPupils()); break;
                case 1: lbl1.Visible = true;
                        lbl2.Visible = true;
                        txtBoxID.Visible = true;
                        txtBoxName.Visible = true;
                        btn1.Visible = true; break;
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            PupilDBAccess PDBAccess = new PupilDBAccess(db);
            BookingDBAccess BDBAccess = new BookingDBAccess(db);
            InstrumentDBAccess IDBAccess = new InstrumentDBAccess(db);
            List<Pupil> pupils = new List<Pupil>();
            Pupil Selected = new Pupil();
            if (string.IsNullOrWhiteSpace(txtBoxID.Text))
            {
                pupils = PDBAccess.getPupilByPupilName(txtBoxName.Text);
            }
                
            else
            {
                Selected = PDBAccess.getPupilByPupilNo(Convert.ToInt32(txtBoxID.Text));
                pupils.Add(Selected);
            }

            CreateTableResults(pupils);
        }

        }
    }


    
          
        

    
    

