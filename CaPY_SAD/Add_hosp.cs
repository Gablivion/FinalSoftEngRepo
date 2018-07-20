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
    public partial class Add_hosp : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Add_hosp()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }
        private void Add_hosp_Load(object sender, EventArgs e)
        {

            loadPet();

            String query_cage= "SELECT * FROM cage where id = "+Hosp.selected_data.cage_id+"";

            MySqlCommand comm_cage = new MySqlCommand(query_cage, conn);
            comm_cage.CommandText = query_cage;
            conn.Open();
            MySqlDataReader drd_cage = comm_cage.ExecuteReader();

         
            while (drd_cage.Read())
            {
                cageTxt.Text = drd_cage["name"].ToString();
            }
            conn.Close();


        }


        public void loadPet()
        {

            String query_pet = "SELECT pets.id as id, customers.id as cid, concat(firstname,' ',middlename,' ',lastname) as owner, name FROM pets,customers,person where pets.customer_id = customers.id AND person.id = customers.person_id";

            conn.Open();
            MySqlCommand comm_pet = new MySqlCommand(query_pet, conn);
            MySqlDataAdapter adp_pet = new MySqlDataAdapter(comm_pet);
            conn.Close();
            DataTable dt_pet = new DataTable();
            adp_pet.Fill(dt_pet);

            dtgvPet.DataSource = dt_pet;
            dtgvPet.Columns["id"].Visible = false;
            dtgvPet.Columns["cid"].Visible = false;
            dtgvPet.Columns["name"].HeaderText = "Pet Name";
            dtgvPet.Columns["owner"].HeaderText = "Owner";

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_hosp_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_hosp_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_hosp_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }


        

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (petTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                string query_insert_hosp = "INSERT INTO hospitalization(pets_id,cage_id,date_in,subtotal,status,archived) VALUES ((SELECT id from pets WHERE name = '"+ petTxt.Text +"' AND customer_id = "+ cust_id + "),(SELECT id from cage WHERE name = '"+ cageTxt.Text + "'), current_timestamp(),0,'active','no')";
                conn.Open();
                MySqlCommand comm_insert_hosp = new MySqlCommand(query_insert_hosp, conn);
                comm_insert_hosp.ExecuteNonQuery();
                conn.Close();

                string query_update_cage = "UPDATE cage SET status = 'unavailable' WHERE name = '" + cageTxt.Text + "'";

                conn.Open();
                MySqlCommand comm_update_cage = new MySqlCommand(query_update_cage, conn);
                comm_update_cage.ExecuteNonQuery();
                conn.Close();


                this.Close();
                previousform.ShowDialog();

            }
           
    

        }
        
        private void petTxt_Click(object sender, EventArgs e)
        {
            PetPanel.Visible = true;
            PetPanel.Size = new Size(443, 283);
            PetPanel.Location = new Point(25, 12);
        }

        public static int cust_id;
        private void dtgvPet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvPet.Rows[e.RowIndex].Cells["id"].Value.ToString());
                PetPanel.Visible = false;


                String query_pet = "SELECT customers.id as cid, concat(firstname,' ',middlename,' ',lastname) as owner, name FROM pets,customers,person where pets.customer_id = customers.id AND person.id = customers.person_id AND pets.id =" + selected_id + "";

                MySqlCommand comm_pet = new MySqlCommand(query_pet, conn);
                comm_pet.CommandText = query_pet;
                conn.Open();
                MySqlDataReader drd_pet = comm_pet.ExecuteReader();


                while (drd_pet.Read())
                {
                    ownTxt.Text = drd_pet["owner"].ToString();
                    petTxt.Text = drd_pet["name"].ToString();
                    cust_id = int.Parse(drd_pet["cid"].ToString());
                }
                conn.Close();

            }
        }
    }
}
