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

            String query_inventory = "SELECT product_inventory.id as id,reorder,medicine, products.name as product,products.id as pid,volume, quantity, expiration_date,DATE_FORMAT(expiration_date, '%m/%d/%Y') as expformat FROM products, product_inventory WHERE product_inventory.products_id = products.id AND status = 'available' ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);

            dtgvInventory.DataSource = dt_inventory;
            dtgvInventory.Columns["id"].Visible = false;
            dtgvInventory.Columns["pid"].Visible = false;
            dtgvInventory.Columns["reorder"].Visible = false;
            dtgvInventory.Columns["medicine"].Visible = false;
            dtgvInventory.Columns["expformat"].Visible = false;
            dtgvInventory.Columns["product"].HeaderText = "Product";
            dtgvInventory.Columns["quantity"].HeaderText = "Quantity";
            dtgvInventory.Columns["volume"].HeaderText = "Volume";
            dtgvInventory.Columns["expiration_date"].HeaderText = "Expiration Date";

           
            foreach (DataGridViewRow row in this.dtgvInventory.Rows)
            {
                //MessageBox.Show(row.Cells["expformat"].Value.ToString()); row.Cells["expformat"].Value.ToString()
                //DateTime dt1 = DateTime.Parse(row.Cells["expformat"].Value.ToString());
                //DateTime dt2 = DateTime.Now;
                // MessageBox.Show(dt1.ToString());
                //int res = DateTime.Compare(dt1, dt2);
                //if (res >= 1 && dt1.ToString() != "0/0/0000")
                //{
                //    row.DefaultCellStyle.BackColor = Color.Red;
                //}
                //else
                //{
                //    row.DefaultCellStyle.BackColor = Color.LawnGreen;
                //}
               
            }

        }

        public class selected_data
        {
            public static int inventory_id;
            public static int pid;
            public static Boolean reorder;
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
        public static int medval;

        private void reorderBtn_Click(object sender, EventArgs e)
        {
            Add_PO addpo = new Add_PO();
            addpo.previousform = this;
            selected_data.reorder = true;
            this.Hide();
            addpo.Show();

        
        }

        private void dtgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.inventory_id = selected_id;
                selected_data.pid = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["pid"].Value.ToString());
                string name = dtgvInventory.Rows[e.RowIndex].Cells["product"].Value.ToString();
                int quan = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["quantity"].Value.ToString());
                medval = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["medicine"].Value.ToString());
                int reorder = int.Parse(dtgvInventory.Rows[e.RowIndex].Cells["reorder"].Value.ToString());
                if (quan <= reorder)
                {
                    reorderBtn.Visible = true;
                    reorderBtn.Enabled = true;
                }
                else
                {
                    reorderBtn.Visible = false;
                }

                if (name.Contains("Repacked by"))
                {
                    repackBtn.Enabled = false;
                    reorderBtn.Visible = false;
                }
                else
                {
                    repackBtn.Enabled = true;
                    reorderBtn.Visible = true;
                    reorderBtn.Enabled = true;

                }
                    stockoutBtn.Enabled = true;
         
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

            string repacked_name = productTxt.Text + " (Repacked by " + repackBy.Text + " " + unitTxt.Text + " )";

            String query_select = "SELECT * from products where name = '" + repacked_name + "'  AND archived = 'no' ";
            conn.Open();
            MySqlCommand comm_select = new MySqlCommand(query_select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_select);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                // DONT ADD A NEW PROFILE
            }
            else
            {

                //New product
                string query_new = "INSERT INTO products(name,description,price,volume,unit,expirable,date_added,date_modified,archived,reorder,medicine)" +
                                   "VALUES('" + repacked_name + "' ,'" + descTxt.Text + "','" + (decimal.Parse(origpriceTxt.Text) / int.Parse(repackedQuan.Text)) + "'," + repackBy.Value + ",'" + unitTxt.Text + "','" + expirable + "', current_timestamp(),current_timestamp(),'no'," + reorder + ","+ medval +")";
                conn.Open();
                MySqlCommand comm_new = new MySqlCommand(query_new, conn);
                comm_new.ExecuteNonQuery();
                conn.Close();

            }

            string query_inventory_duplicate = "SELECT expiration_date FROM product_inventory WHERE expiration_date = '" + exp + "' AND products_id = (SELECT id FROM products where name = '" + repacked_name + "')";
            conn.Open();
            MySqlCommand comm_inventory_duplicate = new MySqlCommand(query_inventory_duplicate, conn);
            MySqlDataAdapter adp_inventory_duplicate = new MySqlDataAdapter(comm_inventory_duplicate);
            conn.Close();
            DataTable dt_inventory_duplicate = new DataTable();
            adp_inventory_duplicate.Fill(dt_inventory_duplicate);

            if (dt_inventory_duplicate.Rows.Count > 0)
            {
                // Increment Quantity of existing instance
                string query_add_quantity = "UPDATE product_inventory set status = 'available', quantity = quantity + " + Quan.Value + " where products_id = (SELECT id FROM products where name = '" + repacked_name + "') AND  expiration_date = '" + exp + "'";
                conn.Open();
                MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
                comm_add_quantity.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("update ");
            }
            else
            {
                // Add a new instance 
                string query_inventory = "INSERT INTO product_inventory (products_id,quantity,expiration_date,status) VALUES((SELECT max(id) FROM products),'" + Quan.Value + "','" + exp + "', 'available')";
                conn.Open();
                MySqlCommand comm_inventory = new MySqlCommand(query_inventory, conn);
                comm_inventory.ExecuteNonQuery();
                conn.Close();

            }
            /*
            string query_repack = "INSERT INTO inventory_repack (product_inventory_id,product_inventory_products_id,quantity,status,expiration_date) VALUES(" + pid + "," + prod_id + "," + (int)(repackedQuan.Value) + ", 'available','" + exp + "')";
            conn.Open();
            MySqlCommand comm_repack = new MySqlCommand(query_repack, conn);
            comm_repack.ExecuteNonQuery();
            conn.Close();
            */


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

            MessageBox.Show("Item Repacked");

            loadInventoryData();
            repackPanel.Visible = false;

            productTxt.Clear();
            itemVol.Refresh();
            repackBy.Refresh();
            Quan.Refresh();
            repackedQuan.Refresh();
        }

  
    }
}
