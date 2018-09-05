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
    public partial class Add_staff : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;

        public Add_staff()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Add_staff_Load(object sender, EventArgs e)
        {
            bdayTxt.MaxDate = DateTime.Today;
            cmbposition();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
        public void cmbposition()
        {
            String query = "SELECT * FROM position";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

            positionCmb.Items.Clear();
            while (drd.Read())
            {
                positionCmb.Items.Add(drd["name"].ToString());
            }
            conn.Close();
        }

        private void cnumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_staff_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_staff_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_staff_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void cnumTxt_TextChanged_2(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String query = "SELECT * from person,staff WHERE firstname = '" + firstnameTxt.Text + "' AND middlename = '" + middlenameTxt.Text + "' AND lastname ='" + lastnameTxt.Text + "' AND person.id = staff.person_id AND staff.archived = 'no'";

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
                if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "" || usernameTxt.Text == "" || passwordTxt.Text == "" || positionCmb.Text == "")
                {
                    MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    String gen = "";
                    String status = "inactive";

                    if (maleRadio.Checked == true)
                    {
                        gen = "male";
                    }
                    else if (femaleRadio.Checked == true)
                    {
                        gen = "female";
                    }

                    if (statusbox.Checked == true)
                    {
                        status = "active";
                    }
                    else
                    {
                        status = "inactive";
                    }

                    string query_person = "INSERT INTO person(firstname,middlename,lastname,gender,birthdate,address,contact_number,email,date_added,date_modified)" +
                                   "VALUES('" + firstnameTxt.Text + "','" + middlenameTxt.Text + "','" + lastnameTxt.Text + "','" + gen + "','" + bdayTxt.Text + "','" + addressTxt.Text + "','" + cnumTxt.Text + "','" + emailTxt.Text + "',current_timestamp(),current_timestamp())";

                    string query_staff = "INSERT INTO staff(person_id,position_pos_id,username,password,status,archived) VALUES ((SELECT MAX(id) from person),(SELECT pos_id from position WHERE name = '" + positionCmb.Text + "'),'" + usernameTxt.Text + "','" + passwordTxt.Text + "','" + status + "','no')";


                    conn.Open();

                    MySqlCommand comm = new MySqlCommand(query_person, conn);
                    comm.ExecuteNonQuery();
                    MySqlCommand comm_staff = new MySqlCommand(query_staff, conn);
                    comm_staff.ExecuteNonQuery();

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


        private void lastnameTxt_TextChanged(object sender, EventArgs e)
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

        private void confPass_Leave(object sender, EventArgs e)
        {
            if (confPass.Text != passwordTxt.Text)
            {
                MessageBox.Show("Passwords Doesn't Match!");
                confPass.Text = "";
                passwordTxt.Text = "";

            }
        }

        private void passCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (passCbx.Checked == true)
            {
                passwordTxt.PasswordChar = '\0';
                confPass.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = 'ฅ';
                confPass.PasswordChar = 'ฅ';
            }
        }

        private void addpos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pospanel.Visible = true;
            pospanel.Location = new Point(65, 18);
            pospanel.Size = new Size(421, 633);
            lblStaff.Text = "ADD POSITION";
        }

        private void posSave_Click(object sender, EventArgs e)
        { 
            String query = "SELECT * from position where name = '"+ posTxt.Text + "'";

            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Position Already Exists");
            }
            else
            {
                if (posTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string position = posTxt.Text;
                    string query_pos = "INSERT INTO position (name) VALUES('" + position.ToLower() + "')";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query_pos, conn);
                    comm.ExecuteNonQuery();
                    conn.Close();
                    pospanel.Visible = false;
                    lblStaff.Text = "ADD STAFF";
                }
                cmbposition();


            }
         
        }

        private void posCancel_Click(object sender, EventArgs e)
        {
            pospanel.Visible = false;
            lblStaff.Text = "ADD STAFF";


        }
    }
}
