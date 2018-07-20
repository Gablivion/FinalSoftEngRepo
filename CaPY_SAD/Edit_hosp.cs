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
    public partial class Edit_hosp : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Edit_hosp()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Edit_hosp_Load(object sender, EventArgs e)
        {

            PetCmbData();
            CageCmbData();
            String query_cage = "SELECT name, (SELECT name FROM pets,hospitalization WHERE pets_id = pets.id AND hospitalization.id = 1) as pet FROM cage,hospitalization WHERE cage.id = cage_id AND hospitalization.id = "+ Hosp.selected_data.hosp_id +"";

            MySqlCommand comm_cage = new MySqlCommand(query_cage, conn);
            comm_cage.CommandText = query_cage;
            conn.Open();
            MySqlDataReader drd_cage = comm_cage.ExecuteReader();


            while (drd_cage.Read())
            {
                cageCmb.Text = drd_cage["name"].ToString();
                petCmb.Text = drd_cage["pet"].ToString();
            }
            conn.Close();
        }
        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Edit_hosp_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        public void PetCmbData()
        {

            String query_pet_show = "SELECT * FROM pets";

            MySqlCommand comm_pet_show = new MySqlCommand(query_pet_show, conn);
            comm_pet_show.CommandText = query_pet_show;
            conn.Open();
            MySqlDataReader drd_pet_show = comm_pet_show.ExecuteReader();
            
            petCmb.Items.Clear();
            while (drd_pet_show.Read())
            {
                petCmb.Items.Add(drd_pet_show["name"].ToString());
            }

            conn.Close();

        }

        public void CageCmbData()
        {
            String query_cage = "SELECT * FROM cage where status = 'available'";

            MySqlCommand comm_pet_show = new MySqlCommand(query_cage, conn);
            comm_pet_show.CommandText = query_cage;
            conn.Open();
            MySqlDataReader drd_pet_show = comm_pet_show.ExecuteReader();

            cageCmb.Items.Clear();
            while (drd_pet_show.Read())
            {
                cageCmb.Items.Add(drd_pet_show["name"].ToString());
            }

            conn.Close();
        }

        private void Edit_hosp_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Edit_hosp_MouseUp(object sender, MouseEventArgs e)
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

            string query_update_hosp = "UPDATE hospitalization SET pets_id = (SELECT id FROM pets WHERE name = '"+petCmb.Text+ "') , cage_id = (SELECT id FROM cage WHERE cage_description = '" + cageCmb.Text + "')  WHERE  id = " + Hosp.selected_data.hosp_id + "";

            conn.Open();
            MySqlCommand comm_update_hosp = new MySqlCommand(query_update_hosp, conn);
            comm_update_hosp.ExecuteNonQuery();
            conn.Close();
            this.Close();
            previousform.Show();

        }
    }
}
