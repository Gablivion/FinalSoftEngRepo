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
    public partial class POS : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public POS()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        DataTable orders = new DataTable();
        DataTable services = new DataTable();
        private void POS_Load(object sender, EventArgs e)
        {
            service();
            quantityTxt.Enabled = false;
            removeBtn.Enabled = false;

            encoderName.Text = CaPY_SAD.Login.UserDisplayDetails.name;

            DateTime now = DateTime.Today;
            encodedDate.Text = now.ToString("MM/dd/yy");

            orders.Columns.Add("id", typeof(string));
            orders.Columns.Add("Expiration", typeof(string));
            orders.Columns.Add("Name", typeof(string));
            orders.Columns.Add("Price", typeof(string));
            orders.Columns.Add("Quantity", typeof(string));
            orders.Columns.Add("Subtotal", typeof(string));

            //services.Columns.Add("serv_id", typeof(string));
            //services.Columns.Add("pet_id", typeof(string));
            //services.Columns.Add("Service", typeof(string));
            //services.Columns.Add("Pet", typeof(string));
            //services.Columns.Add("Price", typeof(string));

            if (Hosp.selected_data.checkout == true)
            {
                hosppayPanel.Visible = true;
                hosppayPanel.Enabled = true;
                hosppayPanel.Size = new Size(1078, 472);
                hosppayPanel.Location = new Point(2, 0);
                prodaddPanel.Enabled = false;
                customerTxt.Enabled = false;
                customerTxt.Text = Hosp.selected_data.custname;
            }
            else
            {
                hosppayPanel.Visible = false;
                hosppayPanel.Enabled = false;
                prodaddPanel.Enabled = true;
                customerTxt.Enabled = true;
            }
        }



        //Check out Orders
        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            if (dtgvOrders.SelectedRows.Count > 0 && customerTxt.Text != "" || dtgvAcServ.SelectedRows.Count > 0 && customerTxt.Text != "")
            {
                paypanel.Visible = true;
                paypanel.Enabled = true;
                paypanel.Size = new Size(1056, 319);
                paypanel.Location = new Point(10, 471);

                paytotalTxt.Text = totalTxt.Text;
                custpayTxt.Text = customerTxt.Text;

            }
            else
            {
                MessageBox.Show("Missing customer and product/service details!", "No data to be saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        //Exit
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        //Cancel Process
        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            paypanel.Visible = false;
            paypanel.Enabled = false;

            addBtn.Visible = true;
            removeBtn.Visible = true;
            resetBtn.Visible = true;
        }



        //Fetch Data from inventory and place it to text fields
        public string expiration;

        public void load_inventory_details()
        {

            String query_get_inventory_details = "SELECT product_inventory.id as id, products.name as product, products.price as price, quantity, DATE_FORMAT(expiration_date, '%Y/%m/%d') as expiration_date FROM products, product_inventory WHERE product_inventory.products_id = products.id AND  product_inventory.id  = " + selected_id + " ";

            MySqlCommand comm_get_inventory_details = new MySqlCommand(query_get_inventory_details, conn);
            comm_get_inventory_details.CommandText = query_get_inventory_details;

            conn.Open();
            MySqlDataReader drd_get_inventory_details = comm_get_inventory_details.ExecuteReader();


            while (drd_get_inventory_details.Read())
            {
                prodTxt.Text = (drd_get_inventory_details["product"].ToString());
                priceTxt.Text = (drd_get_inventory_details["price"].ToString());
                quantityTxt.Maximum = int.Parse(drd_get_inventory_details["quantity"].ToString());
                expiration = drd_get_inventory_details["expiration_date"].ToString();
                quantityTxt.Enabled = true;
                quantityTxt.Value = 1;
                subTotalTxt.Text = priceTxt.Text;
            }
            conn.Close();
        }



        // Pass Data from inventory to Datagrid
        public void ShowInventoryData()
        {
            String query_inventory = "SELECT product_inventory.id as id, products.name as product, quantity,  DATE_FORMAT(expiration_date, '%Y/%m/%d') as expiration_date FROM products, product_inventory WHERE (expiration_date = '0000/00/00' OR expiration_date > CURDATE()) AND product_inventory.products_id = products.id AND status = 'available'  ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventory, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventory = new DataTable();
            adp_inventory.Fill(dt_inventory);


            dtgvAvailProds.DataSource = dt_inventory;
            dtgvAvailProds.Columns["id"].Visible = false;
            dtgvAvailProds.Columns["product"].HeaderText = "Product";
            dtgvAvailProds.Columns["quantity"].HeaderText = "Quantity";
            dtgvAvailProds.Columns["expiration_date"].HeaderText = "Expiration Date";


        }

        public int selected_id;
        // Datagrid for Available Products in Inventory
        private void dtgvAvailProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected_id = int.Parse(dtgvAvailProds.Rows[e.RowIndex].Cells["id"].Value.ToString());

                prodpanel.Visible = false;
                prodpanel.Enabled = false;
                load_inventory_details();
            }
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(priceTxt.Text, "[^0-9.]"))
            {
                MessageBox.Show("Please enter only numbers!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTxt.Text = priceTxt.Text.Remove(priceTxt.Text.Length - 1);
            }

            subTotalTxt.Text = priceTxt.Text;
            quantityTxt.Value = 1;

        }

        //Add Desired Order to order line
        private void addBtn_Click(object sender, EventArgs e)
        {
            //Texbox in Payment containing customer name
            custpayTxt.Text = customerTxt.Text;

            Boolean Prod_duplicate = false;
            int prod_id = 0;

            // Checking for products already in table
            for (int i = 0; i < dtgvOrders.Rows.Count; i++)
            {

                if (selected_id == int.Parse(dtgvOrders.Rows[i].Cells["id"].Value.ToString()))
                {
                    Prod_duplicate = true;
                    prod_id = i;
                }
            }


            if (prodTxt.Text == "" || priceTxt.Text == "" || quantityTxt.Text == "" || subTotalTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Prod_duplicate == true)
            {
                if (quantityTxt.Maximum < (quantityTxt.Value + int.Parse(dtgvOrders.Rows[prod_id].Cells["Quantity"].Value.ToString())))
                {

                    MessageBox.Show("Not enough in inventory!", "Insufficient Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    // Update Quantity in Gridview
                    string quantity = dtgvOrders.Rows[prod_id].Cells["Quantity"].Value.ToString();
                    string price = dtgvOrders.Rows[prod_id].Cells["Price"].Value.ToString();
                    dtgvOrders.Rows[prod_id].Cells["Quantity"].Value = Int32.Parse(quantityTxt.Text) + int.Parse(quantity);

                    decimal number = Decimal.Parse(price) * Int32.Parse(dtgvOrders.Rows[prod_id].Cells["Quantity"].Value.ToString());
                    dtgvOrders.Rows[prod_id].Cells["Subtotal"].Value = number.ToString();
                    getTotal();
                }

            }
            else
            {
                // Insert product detials in Gridview
                orders.Rows.Add(selected_id, expiration, prodTxt.Text, priceTxt.Text, quantityTxt.Text, subTotalTxt.Text);
                dtgvOrders.DataSource = orders;
                dtgvOrders.Columns["id"].Visible = false;

                getTotal();
            }

        }
        public static decimal total;
        // Get Total from gridview
        public void getTotal()
        {
            total = 0;
            decimal final_total = decimal.Parse(totalTxt.Text);
           
            for (int i = 0; i <= dtgvOrders.Rows.Count - 1; i++)
            {
                string subs = dtgvOrders.Rows[i].Cells["Subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total  = total + decimal_sub;

            }

            for (int i = 0; i <= dtgvAcServ.Rows.Count - 1; i++)
            {

                string subs = dtgvAcServ.Rows[i].Cells["Price"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;

            }


            string total_string = total.ToString();
            totalTxt.Text = total_string;
        }


        // If quantity is changed data will verify if quatity is the maximum and will update subtotal
        private void quantityTxt_ValueChanged(object sender, EventArgs e)
        {

            string price = priceTxt.Text;
            decimal parsed_price = decimal.Parse(price);

            string quantity = quantityTxt.Value.ToString();
            int parsed_quantity = int.Parse(quantity);


            decimal subtotal = parsed_price * parsed_quantity;
            string string_subtotal = subtotal.ToString();

            subTotalTxt.Text = string_subtotal;

            if (parsed_quantity == quantityTxt.Maximum)
            {
                quantityTxt.ForeColor = System.Drawing.Color.Red;

            }
            else
            {
                quantityTxt.ForeColor = System.Drawing.Color.Black;
            }

        }

        // Reset Fields
        private void resetBtn_Click_1(object sender, EventArgs e)
        {
            resetFields();
            removeBtn.Enabled = false;
        }

        //reset field functions
        public void resetFields()
        {
            customerTxt.Text = "";
            customerTxt.Enabled = true;
            prodTxt.Text = "Click to add Products";
            priceTxt.Text = "Price";
            subTotalTxt.Clear();
            totalTxt.Text = "0";
            quantityTxt.Enabled = false;
        }

        // On Input on money, will calculate change
        private void moneyTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(moneyTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                moneyTxt.Text = "0";
            }
            else if (moneyTxt.Text == "")
            {
                moneyTxt.Text = "0";
            }
            else
            {
                decimal change = decimal.Parse(moneyTxt.Text) - decimal.Parse(paytotalTxt.Text);
                changeTxt.Text = change.ToString();
            }


        }

        //Insert Records into Database
        private void payBtn_Click_1(object sender, EventArgs e)
        {

            DialogResult paymentDialog;

            if (moneyTxt.Text != "" && decimal.Parse(moneyTxt.Text) >= decimal.Parse(totalTxt.Text))
            {

                paymentDialog = MessageBox.Show("Total: " + decimal.Parse(paytotalTxt.Text) + "\n Amount Given:" + decimal.Parse(moneyTxt.Text) + "\n Change: " + decimal.Parse(changeTxt.Text), "Total", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
              


                if (paymentDialog == DialogResult.Yes)
                {
                    if (Hosp.selected_data.checkout == true)
                    {
                        string query_checkout = "UPDATE hospitalization SET status = 'discharged' WHERE  id =  " + Hosp.selected_data.hosp_id + "";

                        conn.Open();
                        MySqlCommand comm_checkout = new MySqlCommand(query_checkout, conn);
                        comm_checkout.ExecuteNonQuery();
                        conn.Close();

                        string query_update_cage = "UPDATE cage SET status = 'available' WHERE  id = (SELECT cage_id FROM hospitalization WHERE id  = " + Hosp.selected_data.hosp_id + ")";

                        conn.Open();
                        MySqlCommand comm_update_cage = new MySqlCommand(query_update_cage, conn);
                        comm_update_cage.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Discharged", "Cage Vacated!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        previousform.Show();
                    }
                    else
                    {
                        // Query to check if customer is already a customer
                        String query_IsCustomer = "SELECT person.id FROM person,customers WHERE concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + customerTxt.Text + "%' AND customers.person_id = person.id;";

                        conn.Open();
                        MySqlCommand comm_IsCustomer = new MySqlCommand(query_IsCustomer, conn);
                        MySqlDataAdapter adp_IsCustomer = new MySqlDataAdapter(comm_IsCustomer);
                        conn.Close();
                        DataTable dt_IsCustomer = new DataTable();
                        adp_IsCustomer.Fill(dt_IsCustomer);

                        if (dt_IsCustomer.Rows.Count == 0)
                        {

                            string query_customer = "INSERT INTO customers(person_id,archived) VALUES ((SELECT person.id FROM person WHERE concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + customerTxt.Text + "%'), 'no')";
                            conn.Open();
                            MySqlCommand comm_customer = new MySqlCommand(query_customer, conn);
                            comm_customer.ExecuteNonQuery();

                            conn.Close();

                        }



                        String query_insert_transactions = "INSERT INTO transactions(staff_id, customers_id, transaction_date, total) VALUES ((SELECT staff.id FROM person,staff WHERE staff.person_id = person.id AND concat(firstname,' ',middlename,' ',lastname) Like '%" + encoderName.Text + "%'), (SELECT customers.id FROM person,customers WHERE person.id = customers.person_id AND concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + customerTxt.Text + "%'),current_timestamp()," + decimal.Parse(totalTxt.Text) + ")";
                        conn.Open();
                        MySqlCommand comm_insert_transaction = new MySqlCommand(query_insert_transactions, conn);
                        comm_insert_transaction.ExecuteNonQuery();
                        MySqlDataAdapter adp_insert_transaction = new MySqlDataAdapter(comm_insert_transaction);
                        conn.Close();


                        String query_insert_sales_order = "INSERT INTO sales_order(transactions_id, subtotal) VALUES((SELECT max(id) FROM transactions),'" + totalTxt.Text + "')";
                        conn.Open();
                        MySqlCommand comm_sales_order = new MySqlCommand(query_insert_sales_order, conn);
                        comm_sales_order.ExecuteNonQuery();
                        MySqlDataAdapter adp_insert_sales_order = new MySqlDataAdapter(comm_sales_order);
                        conn.Close();


                        for (int i = 0; i <= dtgvOrders.Rows.Count - 1; i++)
                        {


                            string pname = dtgvOrders.Rows[i].Cells["Name"].Value.ToString();

                            string query_prods = "SELECT id FROM products WHERE name = '" + pname + "'";
                            conn.Open();
                            MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                            MySqlDataAdapter adp_prods = new MySqlDataAdapter(comm_prods);
                            conn.Close();
                            DataTable dt_prods = new DataTable();
                            adp_prods.Fill(dt_prods);
                            string prod_id = dt_prods.Rows[0][0].ToString();

                            string inv_id = dtgvOrders.Rows[i].Cells["id"].Value.ToString();
                            string prod_price = dtgvOrders.Rows[i].Cells["Price"].Value.ToString();
                            string prod_quantity = dtgvOrders.Rows[i].Cells["Quantity"].Value.ToString();
                            string prod_subtotal = dtgvOrders.Rows[i].Cells["Subtotal"].Value.ToString();
                            string expiration_string = dtgvOrders.Rows[i].Cells["Expiration"].Value.ToString();

                            string query_sales_order_line = "INSERT INTO sales_order_line (order_id,products_id,quantity,price,subtotal,expiration,refunded) VALUES((SELECT max(id) FROM sales_order),'" + int.Parse(prod_id) + "','" + int.Parse(prod_quantity) + "','" + decimal.Parse(prod_price) + "','" + decimal.Parse(prod_subtotal) + "','" + expiration_string + "', 'no')";
                            conn.Open();
                            MySqlCommand comm_sales_order_line = new MySqlCommand(query_sales_order_line, conn);
                            comm_sales_order_line.ExecuteNonQuery();
                            conn.Close();

                            string query_add_quantity = "UPDATE product_inventory SET quantity = quantity - " + int.Parse(quantityTxt.Text) + " WHERE id = " + int.Parse(inv_id) + " ";
                            conn.Open();
                            MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
                            comm_add_quantity.ExecuteNonQuery();
                            conn.Close();

                            string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock Out (Sales Order)' , current_timestamp(),'" + prodTxt.Text + "','" + quantityTxt.Text + "', 'Purchased by " + custpayTxt.Text + "', (SELECT staff.id FROM person,staff WHERE person.id = staff.person_id AND concat(firstname,' ', middlename,' ',lastname) = '" + encoderName.Text + "'))";
                            conn.Open();
                            MySqlCommand comm_log = new MySqlCommand(query_log, conn);
                            comm_log.ExecuteNonQuery();
                            conn.Close();

                            string query_updateavail = "UPDATE product_inventory SET status = 'unavailable' WHERE quantity <= 0";
                            conn.Open();
                            MySqlCommand comm_updateavail = new MySqlCommand(query_updateavail, conn);
                            comm_updateavail.ExecuteNonQuery();
                            conn.Close();

                            resetFields();
                            custpayTxt.Text = "";
                            paytotalTxt.Text = "0";
                            moneyTxt.Text = "0";
                            changeTxt.Text = "0";
                            paypanel.Visible = false;
                            paypanel.Enabled = false;
                            orders.Clear();
                        }


                    }

                    //if (dtgvAcServ.Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= dtgvAcServ.Rows.Count - 1; i++)
                    //    {

                    //        int serv_id = int.Parse(dtgvAcServ.Rows[i].Cells["serv_id"].Value.ToString());
                    //        int pet_id = int.Parse(dtgvAcServ.Rows[i].Cells["pet_id"].Value.ToString());
                    //        string serv_price = dtgvAcServ.Rows[i].Cells["Price"].Value.ToString();

                    //        string query_service_transaction = "INSERT INTO service_transaction (services_id,transactions_id,service_price,pets_id) VALUES ( " + serv_id + ",(SELECT max(id) FROM transactions), " + serv_price + "," + pet_id +")";

                    //        conn.Open();
                    //        MySqlCommand comm_service_transaction = new MySqlCommand(query_service_transaction, conn);
                    //        comm_service_transaction.ExecuteNonQuery();
                    //        conn.Close();

                    //    }
                    //}
                 
                }
            }

            else
            {
                MessageBox.Show("Amount is not sufficient!", "No Payment Recorded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        // Will show Available products on Inventory
        private void prodTxt_MouseClick(object sender, MouseEventArgs e)
        {
            ShowInventoryData();

            if (dtgvAvailProds.Rows.Count < 1)
            {
                MessageBox.Show("No products available!", "No products in inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                prodpanel.Visible = true;
                prodpanel.Enabled = true;
                prodpanel.Size = new Size(625, 292);
                prodpanel.Location = new Point(14, 9);
            }
        }

        public void ShowCustomerData()
        {
            String query_customer = "SELECT id, concat(firstname,' ',middlename,' ',lastname) as customer FROM person WHERE concat(firstname,' ',middlename,' ',lastname) LIKE '%" + customerTxt.Text + "%'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_customer, conn);
            MySqlDataAdapter adp_inventory = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_customer = new DataTable();
            adp_inventory.Fill(dt_customer);

            if (dt_customer.Rows.Count < 1)
            {
                MessageBox.Show("Person does not exist!", "Not in Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dtgvCustomer.DataSource = dt_customer;
                dtgvCustomer.Columns["id"].Visible = false;
                dtgvCustomer.Columns["customer"].HeaderText = "Customer Name";
                custpanel.Visible = true;
                custpanel.Enabled = true;
                custpanel.Size = new Size(625, 292);
                custpanel.Location = new Point(14, 9);

            }


        }
        public static string customer_id;
        public void load_customer()
        {
            
            String query_customer = "SELECT concat(firstname,' ',middlename,' ',lastname) as Customer FROM person WHERE id = " + selected_customer + "";

            MySqlCommand comm_customer = new MySqlCommand(query_customer, conn);
            comm_customer.CommandText = query_customer;

            conn.Open();
            MySqlDataReader drd_customer = comm_customer.ExecuteReader();


            while (drd_customer.Read())
            {
                customerTxt.Text = (drd_customer["Customer"].ToString());
              
            }
            conn.Close();
          
        }
        //load pet of selected customer
     

        public static int selected_customer;
        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected_customer = int.Parse(dtgvCustomer.Rows[e.RowIndex].Cells["id"].Value.ToString());

                custpanel.Visible = false;
                custpanel.Enabled = false;
                customerTxt.Enabled = false;
                load_customer();
            }

        }



        private void searchBtn_Click(object sender, EventArgs e)
        {
            ShowCustomerData();
        }

        // Form Movements
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void POS_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        private void POS_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void POS_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void salesBtn_Click(object sender, EventArgs e)
        {
            View_sales sales = new View_sales();
            sales.Show();
            sales.previousform = this;
            this.Hide();
        }


        private void servicesBtn_Click(object sender, EventArgs e)
        {

            //servPanel.Visible = true;
            //servPanel.Enabled = true;
            //servPanel.Size = new Size(1001, 362);
            //servPanel.Location = new Point(40, 15);

        }
       
      
        public static int selected_serv;
        private void dtgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex > -1)
            {
                    dtgvServices.Enabled = true;

                    selected_serv = int.Parse(dtgvServices.Rows[e.RowIndex].Cells["id"].Value.ToString());

                    prodpanel.Visible = false;
                    prodpanel.Enabled = false;
                    servPanel.Visible = false;
                   
                    load_service_acquired();
                    getTotal();
             
            }
            else
            {
                MessageBox.Show("Please select a service!");
            }
         
        }

        public void service()
        {
            String query_serv = "SELECT id, name, description, price FROM services";

            conn.Open();
            MySqlCommand comm_serve = new MySqlCommand(query_serv, conn);
            MySqlDataAdapter adp_serve = new MySqlDataAdapter(comm_serve);
            conn.Close();
            DataTable dt_serve = new DataTable();
            adp_serve.Fill(dt_serve);


            dtgvServices.DataSource = dt_serve;
            dtgvServices.Columns["id"].Visible = false;
            dtgvServices.Columns["name"].HeaderText = "Name";
            dtgvServices.Columns["description"].HeaderText = "Description";
            dtgvServices.Columns["price"].HeaderText = "Price";
            
        }
        public static int selected_pet_id;
        public static string selected_pet_name;
     

        private void backserviceBtn_Click(object sender, EventArgs e)
        {
            servPanel.Visible = false;
        }

        public void load_service_acquired()
        {
            int id;
            string serv_name;
            decimal serv_price;

            String query_get_service_details = "SELECT id,name,price FROM services WHERE id = "+ selected_serv + "";
            MySqlCommand comm_get_service_details = new MySqlCommand(query_get_service_details, conn);
            comm_get_service_details.CommandText = query_get_service_details;

            conn.Open();
            MySqlDataReader drd_get_service_details = comm_get_service_details.ExecuteReader();

            while (drd_get_service_details.Read())
            {
                id = int.Parse(drd_get_service_details["id"].ToString());
                serv_name = drd_get_service_details["name"].ToString();
                serv_price = decimal.Parse(drd_get_service_details["price"].ToString());

                services.Rows.Add(id, selected_pet_id, serv_name, selected_pet_name, serv_price);
                dtgvAcServ.DataSource = services;
                dtgvAcServ.Columns["serv_id"].Visible = false;
                dtgvAcServ.Columns["pet_id"].Visible = false;

            }

            conn.Close();
        }

        private void dtgvAcServ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            toRemove = "service";
            dtgvOrders.Enabled = false;
            addBtn.Enabled = false;
            resetBtn.Enabled = false;
            checkoutBtn.Enabled = false;
            removeBtn.Enabled = true;

        }

        public static string toRemove;
        private void POS_Click(object sender, EventArgs e)
        {
            toRemove = "none";
            removeBtn.Enabled = false;
            addBtn.Enabled = true;
            resetBtn.Enabled = true;
            checkoutBtn.Enabled = true;
            dtgvAcServ.Enabled = true;
            dtgvOrders.Enabled = true;
        }

        private void dtgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            toRemove = "order";
            removeBtn.Enabled = true;
            dtgvAcServ.Enabled = false;
            addBtn.Enabled = false;
            resetBtn.Enabled = false;
            checkoutBtn.Enabled = false;
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (toRemove == "order")
            {
                if (dtgvOrders.Rows.Count < 0)
                {
                    MessageBox.Show("Nothing to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int rowIndex = dtgvOrders.CurrentCell.RowIndex;
                    dtgvOrders.Rows.RemoveAt(rowIndex);
                    getTotal();
                }

            }

            else if (toRemove == "service")
            {
                if (dtgvAcServ.Rows.Count < 0)
                {
                    MessageBox.Show("Nothing to remove!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int rowIndex2 = dtgvAcServ.CurrentCell.RowIndex;
                    dtgvAcServ.Rows.RemoveAt(rowIndex2);
                    getTotal();
                }
            }
           
            removeBtn.Enabled = false;
            addBtn.Enabled = true;
            checkoutBtn.Enabled = true;
            resetBtn.Enabled = true;
            dtgvAcServ.Enabled = true;
            dtgvOrders.Enabled = true;

        }

        private void hosppayBtn_Click(object sender, EventArgs e)
        {
            hosppayPanel.Visible = false;
        }
    }
}
