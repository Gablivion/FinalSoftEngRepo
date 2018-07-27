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
    public partial class Inventory : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Inventory()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            stockoutBtn.Enabled = false;
            loadInventoryData();
            repackProdsLoad();

        }

        private void stockoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Stock_out stock_out = new Stock_out();
            stock_out.previousform = this;
            stock_out.Show();

        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }


        public void loadInventoryData()
        {

            String query_inventory = "SELECT product_inventory.id as id,reorder, products.name as product,volume, quantity, expiration_date FROM products, product_inventory WHERE product_inventory.products_id = products.id AND status = 'available' ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);

            dtgvInventory.DataSource = dt_inventory;
            dtgvInventory.Columns["id"].Visible = false;
            dtgvInventory.Columns["reorder"].Visible = false;
            dtgvInventory.Columns["product"].HeaderText = "Product";
            dtgvInventory.Columns["quantity"].HeaderText = "Quantity";
            dtgvInventory.Columns["volume"].HeaderText = "Volume";
            dtgvInventory.Columns["expiration_date"].HeaderText = "Expiration Date";

           
            foreach (DataGridViewRow row in this.dtgvInventory.Rows)
            {
                if (int.Parse(row.Cells["quantity"].Value.ToString()) <= int.Parse(row.Cells["reorder"].Value.ToString()))
                {
                    row.DefaultCellStyle.BackColor = Color.Red;   
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LawnGreen;
                }
            }

        }

        public class selected_data
        {
            public static int inventory_id;
        }
        
    

        private void logBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            InvLog log = new InvLog();
            log.previousform = this;
            log.Show();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Inventory_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Inventory_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Inventory_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        public static int pid;
        public static string exp;
        public static int prod_id;
        public static string desc, unit, expirable, reorder, price;

        public void repackDetails()
        {
            String query = "SELECT products.id as prod_id, product_inventory.id as pid, products.name as name , product_inventory.quantity as quantity, volume, DATE_FORMAT(expiration_date, '%Y/%m/%d') as expiration, description, unit, expirable, reorder, price FROM products, product_inventory where products.id = product_inventory.products_id AND product_inventory.id = '" + selected_data.inventory_id + "'";
            
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;


            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                prod_id = int.Parse(drd["prod_id"].ToString());
                pid = int.Parse(drd["pid"].ToString());
                productTxt.Text = drd["name"].ToString();
                Quan.Maximum = int.Parse(drd["quantity"].ToString());
                itemVol.Text = drd["volume"].ToString();
                exp = drd["expiration"].ToString();

                desc = drd["description"].ToString();
                unit = drd["unit"].ToString();
                expirable = drd["expirable"].ToString();
                reorder = drd["reorder"].ToString();
                price = drd["price"].ToString();

                descTxt.Text = desc;
                unitTxt.Text = unit;
                expirableTxt.Text = expirable;
                origpriceTxt.Text = price;
            }
            conn.Close();


        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                repackBtn.Visible = true;
            
            }
            else
            {
                repackBtn.Visible = false;
            }
        }

        private void repackBtn_Click(object sender, EventArgs e)
        {
            repackDetails();
            repackPanel.Visible = true;

            repackPanel.Size = new Size(947, 540);
            repackPanel.Location = new Point(12, 12);
            
        }

        private void cancelRepackBtn_Click(object sender, EventArgs e)
        {
            repackPanel.Visible = false;
        }

        private void dtgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.inventory_id = selected_id;

                int quan = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["quantity"].Value.ToString());
                int reorder = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["reorder"].Value.ToString());
                if (quan <= reorder)
                {
                    reorderBtn.Visible = true;
                }
                else
                {
                    reorderBtn.Visible = false;
                }
              

                stockoutBtn.Enabled = true;
                repackBtn.Enabled = true;

            }
        }


        public void repacked()
        {
           
            if ((itemVol.Value / repackBy.Value) < 1)
            {
                repackBy.Value = 1;
            }
            else
            {
                repackedQuan.Value = (itemVol.Value / repackBy.Value) * Quan.Value;
            }
            
        }

        private void Quan_ValueChanged(object sender, EventArgs e)
        {
            repacked();
        }
       
        private void saveRepackBtn_Click(object sender, EventArgs e)
        {
            string query_repack = "INSERT INTO inventory_repack (product_inventory_id,product_inventory_products_id,quantity,status,expiration_date) VALUES(" + pid + "," + prod_id + "," + (int)(repackedQuan.Value) + ", 'available','" + exp + "')";
            conn.Open();
            MySqlCommand comm_repack = new MySqlCommand(query_repack, conn);
            comm_repack.ExecuteNonQuery();
            conn.Close();

            string query_subtract_quantity = "UPDATE product_inventory set quantity = quantity - " + int.Parse(Quan.Text) + " where product_inventory.id = '" + pid + "'";
            conn.Open();
            MySqlCommand comm_subtract_quantity = new MySqlCommand(query_subtract_quantity, conn);
            comm_subtract_quantity.ExecuteNonQuery();
            conn.Close();
      
            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Repack)' , current_timestamp(),'" + productTxt.Text + "','" + Quan.Text + "', 'For Shelf', " + CaPY_SAD.Login.UserDisplayDetails.id + ")";
            conn.Open();
            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
            comm_log.ExecuteNonQuery();
            conn.Close();

            string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
            conn.Open();
            MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
            comm_updateavail.ExecuteNonQuery();
            conn.Close();

            //New product
            string query_new = "INSERT INTO products(name,description,price,volume,unit,expirable,date_added,date_modified,archived,reorder)" +
                               "VALUES('" + productTxt.Text + " (Repacked)','" + descTxt.Text + "','" + (decimal.Parse(origpriceTxt.Text)/int.Parse(repackedQuan.Text)) + "'," + repackBy.Value + ",'" + unitTxt.Text + "','" + expirable + "', current_timestamp(),current_timestamp(),'no'," + reorder + ")";
            conn.Open();
            MySqlCommand comm_new = new MySqlCommand(query_new, conn);
            comm_new.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Item Stocked out to Shelf");

            repackProdsLoad();
            loadInventoryData();
            repackPanel.Visible = false;

            productTxt.Clear();
            itemVol.Refresh();
            repackBy.Refresh();
            Quan.Refresh();
            repackedQuan.Refresh();
        }

        public void repackProdsLoad()
        {
            String query_repinventory = " SELECT inventory_repack.id as id,product_inventory_id,name,quantity, expiration_date from inventory_repack,products WHERE product_inventory_products_id = products.id";
            conn.Open();
            MySqlCommand comm_rep = new MySqlCommand(query_repinventory, conn);
            MySqlDataAdapter adp_repinventory = new MySqlDataAdapter(comm_rep);
            conn.Close();
            DataTable dt_repinventory = new DataTable();
            adp_repinventory.Fill(dt_repinventory);

            dtgvRepack.DataSource = dt_repinventory;
            dtgvRepack.Columns["id"].Visible = false;
            dtgvRepack.Columns["product_inventory_id"].Visible = false;
            dtgvRepack.Columns["name"].HeaderText = "Product";
            dtgvRepack.Columns["quantity"].HeaderText = "Quantity";
            dtgvRepack.Columns["expiration_date"].HeaderText = "Expiration Date";

        }
    }
}
