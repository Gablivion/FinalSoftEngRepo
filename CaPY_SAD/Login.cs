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
    public partial class Login : Form
    {
        
        MySqlConnection conn;
        public Login()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        public class UserDisplayDetails
        {
            public static string name;
            public static string username;
            public static string password;
            public static int id;
            public static string position;

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String user = usrTxt.Text;
            String pass = passTxt.Text;
            String query = "SELECT * FROM staff, person, position WHERE position.pos_id = staff.position_pos_id AND person_id = person.id AND USERNAME = '" + user + "' AND PASSWORD = '" + pass + "'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                int id = int.Parse(dt.Rows[0][0].ToString());
                string fname = dt.Rows[0]["firstname"].ToString();
                string mname = dt.Rows[0]["middlename"].ToString();
                string lname = dt.Rows[0]["lastname"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string password = dt.Rows[0]["password"].ToString();
                string pos = dt.Rows[0]["name"].ToString();

                UserDisplayDetails.position = pos;
                UserDisplayDetails.id = id;
                UserDisplayDetails.name = fname + " " + mname + " " + lname;
                UserDisplayDetails.username = username;
                UserDisplayDetails.password = password;

                Menu menu = new Menu();
                menu.previousform = this;
                menu.Show();
                this.Hide();

                MessageBox.Show("Welcome " + UserDisplayDetails.name + "!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Incorrect username or password!", "Incorrect credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void passCbx_CheckedChanged(object sender, EventArgs e)
        {

            if (passCbx.Checked == true)
            {
                passTxt.PasswordChar = '\0';
            
            }
            else
            {
                passTxt.PasswordChar = 'ฅ';
               
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
