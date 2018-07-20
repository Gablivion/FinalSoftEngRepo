using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MySql.Data.MySqlClient;


namespace CaPY_SAD
{
    public partial class Add_customer : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Add_customer()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void Add_customer_Load(object sender, EventArgs e)
        {
            bdayTxt.MaxDate = DateTime.Today;
    
        }
        
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_customer_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_customer_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_customer_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void cnumTxt_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String query = "SELECT * from person,customers WHERE firstname = '"+firstnameTxt.Text+"' AND middlename = '"+middlenameTxt.Text+"' AND lastname ='"+lastnameTxt.Text+ "'  AND person.id = customers.person_id AND customers.archived = 'no'";

            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Person already has a record!", "Existing Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    string query_person = "INSERT INTO person(firstname,middlename,lastname,gender,birthdate,address,contact_number,email,date_added,date_modified) VALUES('" + firstnameTxt.Text + "','" + middlenameTxt.Text + "','" + lastnameTxt.Text + "','" + gen + "','" + bdayTxt.Text + "','" + addressTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "',current_timestamp(),current_timestamp())";
                    string query_customer = "INSERT INTO customers(person_id, archived) VALUES ((SELECT MAX(id) FROM person),'no')";

                    conn.Open();
                    MySqlCommand comm_person = new MySqlCommand(query_person, conn);
                    comm_person.ExecuteNonQuery();

                    MySqlCommand comm_customer = new MySqlCommand(query_customer, conn);
                    comm_customer.ExecuteNonQuery();

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
                MessageBox.Show("Invalid e-mail address!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
