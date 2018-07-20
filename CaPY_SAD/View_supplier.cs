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
    public partial class View_supplier : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public View_supplier()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_supplier edit = new Edit_supplier();
            this.Hide();
            edit.Show();
            edit.previousform = this;

            firstnameTxt.Enabled = true;
            middlenameTxt.Enabled = true;
            lastnameTxt.Enabled = true;
            firstnameTxt.Enabled = true;
            femaleRadio.Enabled = true;
            maleRadio.Enabled = true;
            bdayTxt.Enabled = true;
            addressTxt.Enabled = true;
            emailTxt.Enabled = true;
            cnumTxt.Enabled = true;
            organizationTxt.Enabled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "" || organizationTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String gen = "";

                if (maleRadio.Checked == true)
                {
                    gen = "male";
                }
                else if (femaleRadio.Checked == true)
                {
                    gen = "female";
                }

                string query = "Update person set firstname = '" + firstnameTxt.Text + "' , middlename ='" + middlenameTxt.Text + "', lastname = '" + lastnameTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "', address = '" + addressTxt.Text + "' , contact_number = '" + cnumTxt.Text + "', email = '" + emailTxt.Text + "', date_modified = current_timestamp() where id = '" + person_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Edit success!");

                firstnameTxt.Enabled = false;
                lastnameTxt.Enabled = false;
                middlenameTxt.Enabled = false;
                maleRadio.Enabled = false;
                femaleRadio.Enabled = false;
                bdayTxt.Enabled = false;
                addressTxt.Enabled = false;
                cnumTxt.Enabled = false;
                emailTxt.Enabled = false;
                organizationTxt.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = false;
            lastnameTxt.Enabled = false;
            middlenameTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            bdayTxt.Enabled = false;
            addressTxt.Enabled = false;
            cnumTxt.Enabled = false;
            emailTxt.Enabled = false;
            organizationTxt.Enabled = false;
        }

        public int supplier_id = CaPY_SAD.Supplier.selected_data.supplier_id;
        public static int person_id;

        private void View_supplier_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM person,suppliers where suppliers.person_id = person.id AND suppliers.id = '" + supplier_id + "'";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                person_id = int.Parse(drd["person_id"].ToString());
                firstnameTxt.Text = (drd["firstname"].ToString());
                middlenameTxt.Text = (drd["middlename"].ToString());
                lastnameTxt.Text = (drd["lastname"].ToString());

                if ((drd["gender"].ToString()) == "male")
                {
                    maleRadio.Checked = true;

                }
                else if ((drd["gender"].ToString()) == "female")
                {
                    femaleRadio.Checked = true;
                }

                bdayTxt.Text = (drd["birthdate"].ToString());
                addressTxt.Text = (drd["address"].ToString());
                cnumTxt.Text = (drd["contact_number"].ToString());
                emailTxt.Text = (drd["email"].ToString());
                organizationTxt.Text = (drd["organization_name"].ToString());


            }
            conn.Close();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void View_supplier_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void View_supplier_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void View_supplier_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
