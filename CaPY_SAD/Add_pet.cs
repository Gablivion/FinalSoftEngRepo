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
    public partial class Add_pet : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;

        public Add_pet()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Add_pet_Load(object sender, EventArgs e)
        {
            bdayTxt.MaxDate = DateTime.Today;
            ownercmbData();

        }

        public void ownercmbData()
        {
            String query = "SELECT concat(firstname,' ',middlename,' ',lastname) as owner FROM person,customers WHERE customers.person_id = person.id";



            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            ownerCmb.Items.Clear();
            while (drd.Read())
            {
                ownerCmb.Items.Add(drd["owner"].ToString());
            }
            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();

        }
        
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_pet_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_pet_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_pet_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String query_select = "SELECT * FROM pets,person,customers where customers.person_id = person.id AND customers.id = pets.customer_id AND name = '"+nameTxt.Text+"' AND concat(person.firstname,' ',person.middlename,' ',person.lastname) = '"+ownerCmb.Text+"' ;";

            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query_select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Pet with the same name for this owner already has a record!", "Existing Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nameTxt.Text == "" || speciesTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || breedTxt.Text == "" || bdayTxt.Text == "" || colorTxt.Text == "" || ownerCmb.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String gen = "";
                    String sterilized = "no";
                    string chipno = "";

                    if (maleRadio.Checked == true)
                    {
                        gen = "male";
                    }
                    else if (femaleRadio.Checked == true)
                    {
                        gen = "female";
                    }

                    if (sterilizedbox.Checked == true)
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

                    string query = "INSERT INTO pets(customer_id,name,color,species,breed,gender,birthdate,microchip_number,sterilized,date_added,date_modified,archived)" +
                                   "VALUES((select customers.id from customers, person where customers.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + ownerCmb.Text + "%'),'" + nameTxt.Text + "','" + colorTxt.Text + "','" + speciesTxt.Text + "','" + breedTxt.Text + "','" + gen + "','" + bdayTxt.Text + "','" + chipno + "','" + sterilized + "',current_timestamp(),current_timestamp(),'no')";
                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.Close();
                    previousform.ShowDialog();

                }

            }
           
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
    }
}

 
