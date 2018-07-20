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
    public partial class Settings : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Settings()
        {

            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        int changes = 0;
        private void update_unameBtn_Click(object sender, EventArgs e)
        {
           

            if (changes <= 0)
            {
                if (unameTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (unameTxt.Text.ToLower() == CaPY_SAD.Login.UserDisplayDetails.username.ToLower())
                    {
                        MessageBox.Show("You retained your old usermame, " + unameTxt.Text + "!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                    else
                    {
                        String squery = "SELECT * FROM staff WHERE username = '" + unameTxt.Text + "'";


                        conn.Open();
                        MySqlCommand comm1 = new MySqlCommand(squery, conn);
                        MySqlDataAdapter adp = new MySqlDataAdapter(comm1);
                        conn.Close();
                        DataTable dt = new DataTable();
                        adp.Fill(dt);

                        if (dt.Rows.Count == 1)
                        {

                            MessageBox.Show("Username already exists!", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {
                            string upquery = "Update staff set username = '" + unameTxt.Text + "' where id = '" + CaPY_SAD.Login.UserDisplayDetails.id + "'";
                            conn.Open();
                            MySqlCommand comm2 = new MySqlCommand(upquery, conn);
                            comm2.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("You may now login as " + unameTxt.Text + "! Please logout to see changes.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            changes = changes + 1;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You can only change your username once per login!", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       

        }

        private void update_pwordBtn_Click(object sender, EventArgs e)
        {
            if (oldpwordTxt.Text == "Old Password" || newpwordTxt.Text == "New Password" || confirm_newpwordTxt.Text == "Retype New Password")
            {
                MessageBox.Show("Please fill up all the data", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (oldpwordTxt.Text == CaPY_SAD.Login.UserDisplayDetails.password)
                {
                    if (newpwordTxt.Text == confirm_newpwordTxt.Text)
                    {
                        string upquery = "Update staff set password = '" + newpwordTxt.Text + "' where id = '" + CaPY_SAD.Login.UserDisplayDetails.id + "'";
                        conn.Open();
                        MySqlCommand comm2 = new MySqlCommand(upquery, conn);
                        comm2.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Password changed! Please logout to see changes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match!", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Enter your old password correctly!", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Settings_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Settings_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Settings_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void oldpwordTxt_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void newpwordTxt_TextChanged(object sender, EventArgs e)
        {
        }
        private void confirm_newpwordTxt_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void oldpwordTxt_Leave(object sender, EventArgs e)
        {
            if (oldpwordTxt.Text == "")
            {
                oldpwordTxt.Text = "Old Password";
            }
        }

        private void newpwordTxt_Leave(object sender, EventArgs e)
        {
            if (newpwordTxt.Text == "")
            {
                newpwordTxt.Text = "New Password";
            }
        }

        private void confirm_newpwordTxt_Leave(object sender, EventArgs e)
        {
            if (confirm_newpwordTxt.Text == "")
            {
                confirm_newpwordTxt.Text = "Retype New Password";
            }
        }

        private void oldpwordTxt_Click(object sender, EventArgs e)
        {
            oldpwordTxt.Text = "";
        }

        private void newpwordTxt_Click(object sender, EventArgs e)
        {

            newpwordTxt.Text = "";
        }
        private void confirm_newpwordTxt_Click(object sender, EventArgs e)
        {
            confirm_newpwordTxt.Text = "";
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            unameTxt.Text = CaPY_SAD.Login.UserDisplayDetails.username;
        }
    }
}
