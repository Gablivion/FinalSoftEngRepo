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
    public partial class Add_service : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        public Add_service()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
        
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_service_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_service_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_service_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void priceTxt_TextChanged_1(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(priceTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTxt.Text = priceTxt.Text.Remove(priceTxt.Text.Length - 1);
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            String query_select = "SELECT * from services where name = '" + nameTxt.Text + "' and description = '" + descTxt.Text + "' AND archived = 'no' ";
            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query_select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Product with the same name and description already has a record!", "Existing Record", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (nameTxt.Text == "" || descTxt.Text == "" || priceTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all the data!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {


                    string query = "INSERT INTO services(name,description,base_price,price,status,date_added,date_modified,archived)" +
                                   "VALUES('" + nameTxt.Text + "','" + descTxt.Text + "','" + priceTxt.Text + "','" + priceTxt.Text + "','available',current_timestamp(), current_timestamp(),'no')";
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
