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
    public partial class Edit_product : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;

        public Edit_product()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        // Variable to turn on validations
        Boolean Validation = false;

        public int product_id = CaPY_SAD.Product.selected_data.product_id;

        private void Edit_product_Load(object sender, EventArgs e)
        {   
            
            String query = "SELECT * FROM products where id = '" + product_id + "'";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                nameTxt.Text = drd["name"].ToString();
                descTxt.Text = drd["description"].ToString();
                priceTxt.Text = drd["price"].ToString();
                volNum.Text = drd["volume"].ToString();
                unitTxt.Text = drd["unit"].ToString();
                reOrderQuan.Text = drd["reorder"].ToString();
                if (drd["expirable"].ToString() == "yes")
                {
                    expCbox.Checked = true;

                }
                else
                {
                    expCbox.Checked = false;
                }

                if (int.Parse(drd["medicine"].ToString()) == 1)
                {
                    MedCbox.Checked = true;

                }
                else
                {
                    MedCbox.Checked = false;
                }
            }
            conn.Close();

            Validation = true;
     

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }
        

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(priceTxt.Text, "[^0-9.]") && Validation == true)
            {
                MessageBox.Show("Please enter only numbers!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTxt.Text = priceTxt.Text.Remove(priceTxt.Text.Length - 1);
            }
        }


        private void saveBtn_Click(object sender, EventArgs e)
        {

          if (nameTxt.Text == "" || descTxt.Text == "" || priceTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
              

                string expirable;
                int med;
                if (expCbox.Checked == true)
                {
                    expirable = "yes";
                }
                else
                {
                    expirable = "no";
                }

                if (unitTxt.Text == "")
                {
                    unitTxt.Text = "N/A";
                }

                if (MedCbox.Checked == true)
                {
                    med = 1;
                }
                else
                {
                    med = 0;
                }

                string query = "UPDATE products set name = '" + nameTxt.Text + "' , description ='" + descTxt.Text + "', price = '" + priceTxt.Text + "',volume = "+ volNum.Value + ",unit = '" + unitTxt.Text + "', expirable = '" + expirable + "',reorder = "+reOrderQuan.Value+" , date_modified = current_timestamp(), medicine = "+med+" where id = '" + product_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                this.Close();
                previousform.ShowDialog();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }
    }
}
