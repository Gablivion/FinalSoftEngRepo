using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CaPY_SAD
{
    public partial class Staff : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Staff()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");

            InitializeComponent();
        }


        private void Staff_Load(object sender, EventArgs e)
        {
            loadStaffData();
            if (CaPY_SAD.Login.UserDisplayDetails.position == "staff")
            {
        
                addBtn.Enabled = false;
                editBtn.Enabled = false;
                archiveBtn.Enabled = false;

            }

            else
            {
     
                addBtn.Enabled = true;
                editBtn.Enabled = false;
                archiveBtn.Enabled = false;

            }
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            previousform.Show();
            this.Hide();
        }


        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_staff add = new Add_staff();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_staff edit = new Edit_staff();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }

        public void loadStaffData()
        {
            String query = "SELECT * FROM person,position,staff WHERE staff.position_pos_id = position.pos_id AND staff.person_id = person.id AND archived = 'no'  AND concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + nameTxt.Text + "%'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvStaff.DataSource = dt;
            dtgvStaff.Columns["id"].Visible = false;
            dtgvStaff.Columns["id1"].Visible = false;
            dtgvStaff.Columns["pos_id"].Visible = false;
            dtgvStaff.Columns["position_pos_id"].Visible = false;
            dtgvStaff.Columns["person_id"].Visible = false;
            dtgvStaff.Columns["archived"].Visible = false;
            dtgvStaff.Columns["firstname"].HeaderText = "Firstname";
            dtgvStaff.Columns["middlename"].HeaderText = "Middlename";
            dtgvStaff.Columns["lastname"].HeaderText = "Lastname";
            dtgvStaff.Columns["gender"].HeaderText = "Gender";
            dtgvStaff.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvStaff.Columns["address"].HeaderText = "Address";
            dtgvStaff.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvStaff.Columns["email"].HeaderText = "Email";
            dtgvStaff.Columns["name"].HeaderText = "Position";
            dtgvStaff.Columns["username"].Visible = false;
            dtgvStaff.Columns["password"].Visible = false;
            dtgvStaff.Columns["date_added"].HeaderText = "Date Added";
            dtgvStaff.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvStaff.Columns["status"].HeaderText = "Status";


        }

        public class selected_data
        {
            public static int staff_id;
        }

        private void dtgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CaPY_SAD.Login.UserDisplayDetails.position == "staff")
            {
                addBtn.Enabled = false;
                editBtn.Enabled = true;
                archiveBtn.Enabled = false;
            }

            else
            {
                addBtn.Enabled = false;
                editBtn.Enabled = true;
                archiveBtn.Enabled = true;
            }

         

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvStaff.Rows[e.RowIndex].Cells["id1"].Value.ToString());
                selected_data.staff_id = selected_id;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Staff_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Staff_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Staff_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dtgvStaff_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgvStaff.Rows)
            {
                if (row.Cells["status"].Value.ToString() == "active")
                {
                    row.DefaultCellStyle.BackColor = Color.LawnGreen;

                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void Staff_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            editBtn.Enabled = false;
            archiveBtn.Enabled = false;
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {

            DialogResult archive;

            archive = MessageBox.Show("Do really you want to add this record to archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "UPDATE staff SET archived = 'yes' where id = '" + selected_data.staff_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadStaffData();

            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            loadStaffData();
        }
    }
}
