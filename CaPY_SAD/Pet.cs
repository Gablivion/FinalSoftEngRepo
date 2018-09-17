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
    public partial class Pet : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        public Pet()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");

            InitializeComponent();
        }

        private void Pet_Load(object sender, EventArgs e)
        {
            loadPetData();
            addBtn.Enabled = true;
            editBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_pet add = new Add_pet();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_pet edit = new Edit_pet();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }


        public class selected_data
        {
            public static int pet_id;
        }

        private void dtgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            archiveBtn.Enabled = true;


            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvPet.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.pet_id = selected_id;
            }
        }

        public void loadPetData()
        {

            String query = "SELECT pets.id, pets.customer_id as cust, name,  concat(person.firstname,' ',person.middlename,' ',person.lastname) as owner, color, species, breed, pets.gender as gen, pets.birthdate as bday, microchip_number, sterilized, pets.date_added as p_added, pets.date_modified as p_modified FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND pets.archived = 'no' AND name LIKE '%" + nameTxt.Text + "%'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvPet.DataSource = dt;
            dtgvPet.Columns["id"].Visible = false;
            dtgvPet.Columns["cust"].Visible = false;
            dtgvPet.Columns["name"].HeaderText = "Name";
            dtgvPet.Columns["color"].HeaderText = "Color";
            dtgvPet.Columns["species"].HeaderText = "Species";
            dtgvPet.Columns["breed"].HeaderText = "Breed";
            dtgvPet.Columns["gen"].HeaderText = "Gender";
            dtgvPet.Columns["bday"].HeaderText = "Birthdate";
            dtgvPet.Columns["microchip_number"].HeaderText = "Microchip Number";
            dtgvPet.Columns["sterilized"].HeaderText = "Sterilized";
            dtgvPet.Columns["owner"].HeaderText = "Owner";
            dtgvPet.Columns["p_added"].HeaderText = "Date Added";
            dtgvPet.Columns["p_modified"].HeaderText = "Date Modified";




        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Pet_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Pet_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Pet_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Pet_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            editBtn.Enabled = false;
            archiveBtn.Enabled = false;
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {

            DialogResult archive;

            archive = MessageBox.Show("Do you want to add this record to archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "Update pets SET archived = 'yes' where id = '" + selected_data.pet_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadPetData();

            }

        }
        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            loadPetData();
        }

        private void dtgvPet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
