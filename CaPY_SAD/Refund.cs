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
    public partial class Refund : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        DataTable orders = new DataTable();
        public Refund()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void Refund_Load(object sender, EventArgs e)
        {
            orders.Columns.Add("id", typeof(string));
            orders.Columns.Add("Expiration", typeof(string));
            orders.Columns.Add("Name", typeof(string));
            orders.Columns.Add("Price", typeof(string));
            orders.Columns.Add("Quantity", typeof(string));
            orders.Columns.Add("Subtotal", typeof(string));

            loadSalesData();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        public static int sorting = 0;

        public void loadSalesData()
        {
            String query_sales = "SELECT sales_order.id as id, transactions_id,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff "
           + ",subtotal,transaction_date FROM transactions,staff,customers,sales_order WHERE transactions.customers_id = customers.id AND transactions.staff_id = staff.id AND sales_order.transactions_id = transactions.id";


            String exec_query;
            conn.Open();
            if (sorting == 0)
            {
                exec_query = query_sales;
                sorting = 1;
            }
            else
            {
               // exec_query = query_sales_sorted;
            }

            MySqlCommand comm = new MySqlCommand(query_sales, conn);
            MySqlDataAdapter adp_sales_order = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt_sales_order = new DataTable();
            adp_sales_order.Fill(dt_sales_order);

            dtgvSalesOrder.DataSource = dt_sales_order;
            dtgvSalesOrder.Columns["id"].Visible = false;
            dtgvSalesOrder.Columns["transactions_id"].Visible = false;
            dtgvSalesOrder.Columns["subtotal"].HeaderText = "Subtotal";
            dtgvSalesOrder.Columns["Customer"].HeaderText = "Customer";
            dtgvSalesOrder.Columns["Staff"].HeaderText = "Staff";
            dtgvSalesOrder.Columns["transaction_date"].HeaderText = "Date";

        }

        
        public static int sales_order_id;
        private void dtgvSalesOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvSalesOrder.Rows[e.RowIndex].Cells["id"].Value.ToString());
                sales_order_id = selected_id;

                String query_customer_encoder = "SELECT sales_order.id as id, transactions_id,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff ,subtotal,transaction_date FROM transactions,staff,customers,sales_order WHERE transactions.customers_id = customers.id AND transactions.staff_id = staff.id AND sales_order.transactions_id = transactions.id AND sales_order.id = " + selected_id + "";
                MySqlCommand comm_customer_encoder = new MySqlCommand(query_customer_encoder, conn);
                comm_customer_encoder.CommandText = query_customer_encoder;
                conn.Open();
                MySqlDataReader drd = comm_customer_encoder.ExecuteReader();


                while (drd.Read())
                {
                    custTxt.Text = drd["Customer"].ToString();
                    EncTxt.Text = drd["Staff"].ToString();
                }
                expiration = "";
                prodTxt.Text = "";
                priceTxt.Text = "";
                quanNum.Maximum = 1000;
                SubtotalTxt.Text = "";
                conn.Close();

                orderline();

            }
        }

        public void orderline()
        {

            String query_order_line = "SELECT sales_order_line.id as id, products.name as product, sales_order_line.price, quantity, subtotal FROM sales_order_line, products WHERE order_id = " + sales_order_id + " AND products.id = sales_order_line.products_id group by sales_order_line.id";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_order_line, conn);
            MySqlDataAdapter adp_order_line = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_order_line = new DataTable();
            adp_order_line.Fill(dt_order_line);

            dtgvOrderline.DataSource = dt_order_line;

            dtgvOrderline.Columns["id"].Visible = false;
            dtgvOrderline.Columns["product"].HeaderText = "Product Name";
            dtgvOrderline.Columns["quantity"].HeaderText = "Quantity";
            dtgvOrderline.Columns["price"].HeaderText = "Price";
            dtgvOrderline.Columns["subtotal"].HeaderText = "Subtotal";
            //dtgvOrderline.Columns["refunded"].HeaderText = "Refunded";
            quanNum.Enabled = false;
            toInventoryBtn.Enabled = false;

        }

        private void toInventoryBtn_Click(object sender, EventArgs e)
        {
            string query_refund= "INSERT INTO sales_refund(sales_order_id, sales_order_line_id, staff_id, customers_id, product, quantity, amount, date) "
                + "VALUES (" + sales_order_id + "," + orderline_id + ", (SELECT staff.id FROM person,staff WHERE staff.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + EncTxt.Text + "%'),(SELECT customers.id FROM person,customers WHERE customers.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + custTxt.Text + "%'),'" + prodTxt.Text + "'," + quanNum.Value + "," + decimal.Parse(SubtotalTxt.Text) + ",current_timestamp())";
            conn.Open();
            MySqlCommand comm_cage = new MySqlCommand(query_refund, conn);
            comm_cage.ExecuteNonQuery();
            conn.Close();

            
            string query_inventory_duplicate = "SELECT expiration_date FROM product_inventory WHERE expiration_date = '" + expiration + "' AND products_id = (SELECT id FROM products where name = '" + prodTxt.Text + "')";
            conn.Open();
            MySqlCommand comm_inventory_duplicate = new MySqlCommand(query_inventory_duplicate, conn);
            MySqlDataAdapter adp_inventory_duplicate = new MySqlDataAdapter(comm_inventory_duplicate);
            conn.Close();
            DataTable dt_inventory_duplicate = new DataTable();
            adp_inventory_duplicate.Fill(dt_inventory_duplicate);

            if (dt_inventory_duplicate.Rows.Count > 0)
            {
                // Increment Quantity of existing instance
                string query_add_quantity = "UPDATE product_inventory set status = 'available', quantity = quantity + " + quanNum.Value + " where products_id = (SELECT id FROM products where name = '" + prodTxt.Text + "') AND  expiration_date = '" + expiration + "'";
                conn.Open();
                MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
                comm_add_quantity.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                // Add a new instance 
                string query_inventory = "INSERT INTO product_inventory (products_id,quantity,expiration_date,status) VALUES((SELECT id FROM products where name = '" + prodTxt.Text + "'),'" + quanNum.Value + "','" + expiration + "', 'available')";
                conn.Open();
                MySqlCommand comm_inventory = new MySqlCommand(query_inventory, conn);
                comm_inventory.ExecuteNonQuery();
                conn.Close();

            }

            // Insert Stock In Log
            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock In (Refund)' , current_timestamp(),'" + prodTxt.Text + "','" + quanNum.Value + "', 'Purchased Item from " + CaPY_SAD.Login.UserDisplayDetails.name + "', " + CaPY_SAD.Login.UserDisplayDetails.id + ")";
            conn.Open();
            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
            comm_log.ExecuteNonQuery();
            conn.Close();

            //Deduct from quantity
            string query_subtract_quantity = "UPDATE sales_order_line set quantity = (quantity - " + quanNum.Value + ") where sales_order_line.id =" + orderline_id + "";
            conn.Open();
            MySqlCommand comm_subtract = new MySqlCommand(query_subtract_quantity, conn);
            comm_subtract.ExecuteNonQuery();
            conn.Close();
            
            MessageBox.Show("Item Refunded and back to the inventory!");
            toInventoryBtn.Enabled = false;
            custTxt.Text = "";
            EncTxt.Text = "";
            expiration = "";
            prodTxt.Text = "";
            priceTxt.Text = "";
            quanNum.Maximum = 1000;
            SubtotalTxt.Text = "";

            loadSalesData();
            orderline();
            
        }

        private void backOrderlineBtn_Click(object sender, EventArgs e)
        {
            custTxt.Text = "";
            EncTxt.Text = "";
            expiration = "";
            prodTxt.Text = "";
            priceTxt.Text = "";
            quanNum.Maximum = 1000;
            SubtotalTxt.Text = "";
        }

        public static string expiration;
        public static int orderline_id;
        private void dtgvOrderline_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvOrderline.Rows[e.RowIndex].Cells["id"].Value.ToString());
                orderline_id = selected_id;
              
                String query_prods = "SELECT DATE_FORMAT(expiration, '%Y/%m/%d') as expiration, name as product, sales_order_line.price as price,quantity,subtotal FROM sales_order_line,products WHERE sales_order_line.products_id = products.id AND sales_order_line.id = " + orderline_id + "";
                MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                comm_prods.CommandText = query_prods;
                conn.Open();
                MySqlDataReader drd_prods = comm_prods.ExecuteReader();


                while (drd_prods.Read())
                {
                    expiration = drd_prods["expiration"].ToString();
                    prodTxt.Text = drd_prods["product"].ToString();
                    priceTxt.Text = drd_prods["price"].ToString();    
                    quanNum.Maximum = int.Parse(drd_prods["quantity"].ToString());
                    SubtotalTxt.Text = priceTxt.Text;

                }
                conn.Close();
                quanNum.Enabled = true;
                toInventoryBtn.Enabled = true;
            }
            else
            {
                toInventoryBtn.Enabled = false;
            }
        }

        private void dtgvRefund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            backOrderlineBtn.Enabled = true;
        }

        private void quanNum_ValueChanged(object sender, EventArgs e)
        {
            decimal subtotal;
            subtotal = quanNum.Value * decimal.Parse(priceTxt.Text);
            SubtotalTxt.Text = subtotal.ToString();
        }

        //Makes form movable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Refund_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Refund_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Refund_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

    }
}
