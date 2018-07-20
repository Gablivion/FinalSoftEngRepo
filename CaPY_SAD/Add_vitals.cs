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
    public partial class Add_vitals : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Add_vitals()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_vitals_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_vitals_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_vitals_MouseUp(object sender, MouseEventArgs e)
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
            if (appetiteCmb.Text == "" || attitudeCmb.Text == "" || bowelCmb.Text == "" || coughingCmb.Text == "" || drinkingCmb.Text == "" || urinationCmb.Text == "" || vomitingCmb.Text == "" || bdayTxt.Text == "" || heartrateTxt.Text == "" || resperateTxt.Text == "" || tempTxt.Text == "" || weightTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query_add_vital= "INSERT INTO daily_vitals(hospitalization_id,date,weight,temperature,heart_rate,respiratory_rate,appetite_status,attitude_status,bowel_status,coughing_status,drinking_status,urination_status,vomiting_status) "
                    + "VALUES ("+Hosp.selected_data.hosp_id+ ",current_timestamp(), '" + weightTxt.Text + "','" + tempTxt.Text + "','" + heartrateTxt.Text + "','" + resperateTxt.Text + "','" + appetiteCmb.Text + "','" + attitudeCmb.Text + "','" + bowelCmb.Text + "','" + coughingCmb.Text + "','" + drinkingCmb.Text + "','" + urinationCmb.Text + "','" + vomitingCmb.Text + "')";

                conn.Open();
                MySqlCommand comm_person = new MySqlCommand(query_add_vital, conn);
                comm_person.ExecuteNonQuery();
                

                this.Close();
                previousform.Show();

               
            }

        }
    }
}
