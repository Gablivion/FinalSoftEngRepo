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

    public partial class View_pet : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public View_pet()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            ownerCmb.Enabled = true;
            nameTxt.Enabled = true;
            micronumTxt.Enabled = true;
            speciesTxt.Enabled = true;
            breedTxt.Enabled = true;
            bdayTxt.Enabled = true;
            maleRadio.Enabled = true;
            femaleRadio.Enabled = true;
            colorTxt.Enabled = true;
            sterilizedBox.Enabled = true;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ownerCmb.Enabled = false;
            nameTxt.Enabled = false;
            micronumTxt.Enabled = false;
            speciesTxt.Enabled = false;
            breedTxt.Enabled = false;
            bdayTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            colorTxt.Enabled = false;
            sterilizedBox.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nameTxt.Text == "" || speciesTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || breedTxt.Text == "" || bdayTxt.Text == "" || colorTxt.Text == "" || ownerCmb.Text == "")
            {
                MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String gen = "";
                String sterilized = "no";
                String chipno = "";

                if (maleRadio.Checked == true)
                {
                    gen = "male";
                }
                else if (femaleRadio.Checked == true)
                {
                    gen = "female";
                }

                if (sterilizedBox.Checked == true)
                {
                    sterilized = "yes";
                }
                else
                {
                    sterilized = "no";
                }

                if (micronumTxt.Text == "")
                {
                    chipno = "N/A";

                }
                else
                {
                    chipno = micronumTxt.Text;

                }

                string query = "UPDATE pets SET customer_id = (select customers.id from customers, person where customers.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + ownerCmb.Text + "%'), name = '" + nameTxt.Text + "' , color = '" + colorTxt.Text + "' , species = '" + speciesTxt.Text + "', breed = '" + breedTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "' , microchip_number = '" + chipno + "' , sterilized = '" + sterilized + "', date_modified = current_timestamp()  where id =  '" + pet_id + "' ";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
            }

            ownerCmb.Enabled = false;
            nameTxt.Enabled = false;
            micronumTxt.Enabled = false;
            speciesTxt.Enabled = false;
            breedTxt.Enabled = false;
            bdayTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            colorTxt.Enabled = false;
            sterilizedBox.Enabled = false;
        }

        // Makes Form Movable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void View_pet_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void View_pet_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void View_pet_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        public void ownercmbData()
        {
            String query = "SELECT concat(firstname,' ',middlename,' ',lastname) as owner FROM person,customers WHERE customers.person_id = person.id";
            
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                ownerCmb.Items.Add(drd["owner"].ToString());
            }
            conn.Close();
        }

        public int pet_id = CaPY_SAD.Pet.selected_data.pet_id;

        private void View_pet_Load(object sender, EventArgs e)
        {
            ownercmbData();
            
            String query = "SELECT pets.id, name, color, species, breed, pets.gender as gen, pets.birthdate as bday, microchip_number, sterilized, concat(firstname,' ',middlename,' ',lastname) as owner FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND pets.id = '" + pet_id + "'";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            while (drd.Read())
            {
                ownerCmb.Text = (drd["owner"].ToString());
                nameTxt.Text = (drd["name"].ToString());
                colorTxt.Text = (drd["color"].ToString());
                speciesTxt.Text = (drd["species"].ToString());

                if ((drd["gen"].ToString()) == "male")
                {
                    maleRadio.Checked = true;

                }
                else if ((drd["gen"].ToString()) == "female")
                {
                    femaleRadio.Checked = true;
                }


                if ((drd["sterilized"].ToString()) == "yes")
                {
                    sterilizedBox.Checked = true;

                }
                else
                {
                    femaleRadio.Checked = false;
                }


                bdayTxt.Text = (drd["bday"].ToString());
                breedTxt.Text = (drd["breed"].ToString());
                micronumTxt.Text = (drd["microchip_number"].ToString());
            }
            conn.Close();
            loadAllergies();
        }

        public void loadAllergies()
        {
            String query_allergies = "SELECT pet_allergy,recorded_on from allergies WHERE pets_id = " + pet_id + "";

            conn.Open();
            MySqlCommand comm_allergies = new MySqlCommand(query_allergies, conn);
            MySqlDataAdapter adp_allergies = new MySqlDataAdapter(comm_allergies);
            conn.Close();
            DataTable dt_allergies = new DataTable();
            adp_allergies.Fill(dt_allergies);


            dtgvAllergies.DataSource = dt_allergies;
            dtgvAllergies.Columns["pet_allergy"].HeaderText = "Allergies";
            dtgvAllergies.Columns["recorded_on"].HeaderText = "Date Recpor";
        }
    }
}
