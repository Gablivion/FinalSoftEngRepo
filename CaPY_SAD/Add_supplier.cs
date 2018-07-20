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
    public partial class Add_supplier : Form
    {

        public Form previousform { get; set; }

        MySqlConnection conn;

        public Add_supplier()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Add_supplier_Load(object sender, EventArgs e)
        {
            bdayTxt.MaxDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
        
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_supplier_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_supplier_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_supplier_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void cnumTxt_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String query = "SELECT * from person,suppliers WHERE firstname = '" + firstnameTxt.Text + "' AND middlename = '" + middlenameTxt.Text + "' AND lastname ='" + lastnameTxt.Text + "' AND person.id = suppliers.person_id AND suppliers.archived = 'no'";

            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Person Already Has a Record");
            }
            else
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

                    string query_person = "INSERT INTO person(firstname,middlename,lastname,gender,birthdate,address,contact_number,email,date_added,date_modified) VALUES('" + firstnameTxt.Text + "','" + middlenameTxt.Text + "','" + lastnameTxt.Text + "','" + gen + "','" + bdayTxt.Text + "','" + addressTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "', current_timestamp(), current_timestamp() )";
                    string query_supplier = "INSERT INTO suppliers (person_id,organization_name, archived) VALUES((SELECT MAX(id) FROM person),'" + organizationTxt.Text + "','no')";

                    conn.Open();
                    MySqlCommand comm_person = new MySqlCommand(query_person, conn);
                    comm_person.ExecuteNonQuery();

                    MySqlCommand comm_supplier = new MySqlCommand(query_supplier, conn);
                    comm_supplier.ExecuteNonQuery();

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

        private void emailTxt_Leave(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!(System.Text.RegularExpressions.Regex.IsMatch(email, pattern)))
            {
                MessageBox.Show("Not a valid Email address ");
                emailTxt.Text = "";
            }
        }

        private void firstnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(firstnameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                firstnameTxt.Text = firstnameTxt.Text.Remove(firstnameTxt.Text.Length - 1);
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(middlenameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                middlenameTxt.Text = middlenameTxt.Text.Remove(middlenameTxt.Text.Length - 1);
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(lastnameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                lastnameTxt.Text = lastnameTxt.Text.Remove(lastnameTxt.Text.Length - 1);
            }
        }
    }
}
