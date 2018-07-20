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
    public partial class Stock_out : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Stock_out()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            previousform.ShowDialog();

        }

        public int inventory_id = CaPY_SAD.Inventory.selected_data.inventory_id;

        public static int pid;
        private void Stock_out_Load(object sender, EventArgs e)
        {
            String query = "SELECT product_inventory.id as pid, products.name as name , product_inventory.quantity as quantity FROM products, product_inventory where products.id = product_inventory.products_id AND product_inventory.id = '" + inventory_id + "'";



            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                pid = int.Parse((drd["pid"].ToString()));
                productTxt.Text = (drd["name"].ToString());
                QuantityTxt.Maximum = int.Parse(drd["quantity"].ToString());
            }
            conn.Close();

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string query_subtract_quantity = "UPDATE product_inventory set quantity = quantity - " + int.Parse(QuantityTxt.Text) + " where product_inventory.id = '" + pid + "'";
            conn.Open();
            MySqlCommand comm_subtract_quantity = new MySqlCommand(query_subtract_quantity, conn);
            comm_subtract_quantity.ExecuteNonQuery();
            conn.Close();

            string remarks;
            if (remarksTxt.Text == "")
            {
                remarks = "None";
            }
            else
            {
                remarks = remarksTxt.Text;
            }

            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Manual)' , current_timestamp(),'" + productTxt.Text + "','" + QuantityTxt.Text + "', '" + remarks + "', " + CaPY_SAD.Login.UserDisplayDetails.id + ")";
            conn.Open();
            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
            comm_log.ExecuteNonQuery();
            conn.Close();

            string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
            conn.Open();
            MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
            comm_updateavail.ExecuteNonQuery();
            conn.Close();

            this.Close();
            previousform.ShowDialog();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }
    }
    
}
