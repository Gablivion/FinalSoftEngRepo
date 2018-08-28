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
using System.Drawing.Printing;

namespace CaPY_SAD
{
    public partial class Add_PO : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Add_PO()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }
        // Variable to turn on validations
        Boolean Validation = false;

        DataTable orders = new DataTable();
        int show = 0;
        private void Add_PO_Load(object sender, EventArgs e)
        {
            loadPurchasingData();
            supplierCmbData();
            quanNum.Enabled = false;
            prodpanel.Visible = false;
            prodpanel.Enabled = false;
            //check
            if (show == 0)
            {
                orders.Columns.Add("Name", typeof(string));
                orders.Columns.Add("Price", typeof(string));
                orders.Columns.Add("Quantity", typeof(string));
                orders.Columns.Add("Subtotal", typeof(string));
                show = show + 1;
            }
            if (Inventory.selected_data.reorder == true)
            {
                selected_id = Inventory.selected_data.pid;
                load_prod_details();

            }
    

        }


        //Show supplier Details in Combobox
        public void supplierCmbData()
        {

            String query_suppliers = "SELECT * FROM suppliers";

            MySqlCommand comm_suppliers = new MySqlCommand(query_suppliers, conn);
            comm_suppliers.CommandText = query_suppliers;
            conn.Open();
            MySqlDataReader drd_suppliers = comm_suppliers.ExecuteReader();

            supplierCmb.Items.Clear();
            while (drd_suppliers.Read())
            {
                supplierCmb.Items.Add(drd_suppliers["organization_name"].ToString());
            }
            conn.Close();

        }

        // back to PO form
        private void quitBtn_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            previousform.ShowDialog();
        }

        // if price is changed subtotal will change and quantity will reset
        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(priceTxt.Text, "[^0-9.]") && Validation == true)
            {
                MessageBox.Show("Please enter only numbers!", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTxt.Text = priceTxt.Text.Remove(priceTxt.Text.Length - 1);
            }
            else if (priceTxt.Text == "")
            {
                priceTxt.Text = 0.ToString();
            }
            subtotal();
        }
        // if quantity is changed, subtotal is updated
        private void quanNum_ValueChanged(object sender, EventArgs e)
        {
            subtotal();
        }
        public void subtotal()
        {
            string price = priceTxt.Text;
            decimal parsed_price = decimal.Parse(price);

            string quantity = quanNum.Value.ToString();
            int parsed_quantity = int.Parse(quantity);


            decimal subtotal = parsed_price * parsed_quantity;
            string string_subtotal = subtotal.ToString();

            subtotalTxt.Text = string_subtotal;
        }
      
        // Add product to gridview
        private void addBtn_Click_1(object sender, EventArgs e)
        {

            Boolean Prod_duplicate = false;
            int prod_id = 0;

            // Checking for products already in table
            for (int i = 0; i < dtgvPurchaseOrders.Rows.Count; i++)
            {

                if (prodTxt.Text == dtgvPurchaseOrders.Rows[i].Cells["Name"].Value.ToString())
                {
                    Prod_duplicate = true;
                    prod_id = i;
                }
            }


            if (prodTxt.Text == "" || priceTxt.Text == "" || quanNum.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (priceTxt.Text == "0.00" || priceTxt.Text == "0")
            {
                MessageBox.Show("Price cannot be 0", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (decimal.Parse(priceTxt.Text) >= decimal.Parse(sellingpriceTxt.Text))
            {
                MessageBox.Show("Cost Price cannot be higher than or equal selling price", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (quanNum.Value == 0)
            {
                MessageBox.Show("Please input quantity!", "Missing fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (Prod_duplicate == true)
            {

                string quantity = dtgvPurchaseOrders.Rows[prod_id].Cells["Quantity"].Value.ToString();
                string price = dtgvPurchaseOrders.Rows[prod_id].Cells["Price"].Value.ToString();
                dtgvPurchaseOrders.Rows[prod_id].Cells["Quantity"].Value = Int32.Parse(quanNum.Text) + int.Parse(quantity);

                decimal number = Decimal.Parse(price) * Int32.Parse(dtgvPurchaseOrders.Rows[prod_id].Cells["Quantity"].Value.ToString());
                dtgvPurchaseOrders.Rows[prod_id].Cells[3].Value = number.ToString();
                getTotal();

            }
            else
            {


                orders.Rows.Add(prodTxt.Text, priceTxt.Text, quanNum.Text, subtotalTxt.Text);
                dtgvPurchaseOrders.DataSource = orders;
                getTotal();
            }


        }

        // remove row from gridview
        private void removeBtn_Click_1(object sender, EventArgs e)
        {
            int rowIndex = dtgvPurchaseOrders.CurrentCell.RowIndex;
            dtgvPurchaseOrders.Rows.RemoveAt(rowIndex);
            getTotal();

        }

        // Get total from gridview
        public void getTotal()
        {
            decimal total = 0;

            for (int i = 0; i <= dtgvPurchaseOrders.Rows.Count - 1; i++)
            {

                string subs = dtgvPurchaseOrders.Rows[i].Cells["Subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;


            }
            string total_string = total.ToString();
            totalTxt.Text = total_string;
        }

        // Record to Datbase
        private void checkoutBtn_Click(object sender, EventArgs e)
        {
            if (supplierCmb.Text != "")
            {
                if (dtgvPurchaseOrders.SelectedRows.Count > 0)
                {
                    string query_supplier = "SELECT id FROM suppliers WHERE organization_name ='" + supplierCmb.Text + "'";
                    conn.Open();
                    MySqlCommand comm_supplier = new MySqlCommand(query_supplier, conn);
                    MySqlDataAdapter adp_supplier = new MySqlDataAdapter(comm_supplier);
                    conn.Close();
                    DataTable dt_supplier = new DataTable();
                    adp_supplier.Fill(dt_supplier);

                    string supplier_id = dt_supplier.Rows[0][0].ToString();

                    string query_order = "INSERT INTO purchase_order (suppliers_id,staff_id,total,date,status) VALUES('" + int.Parse(supplier_id) + "','" + CaPY_SAD.Login.UserDisplayDetails.id + "','" + decimal.Parse(totalTxt.Text) + "', current_timestamp(),'ordered')";
                    conn.Open();
                    MySqlCommand comm_order = new MySqlCommand(query_order, conn);
                    comm_order.ExecuteNonQuery();
                    conn.Close();

                    for (int i = 0; i <= dtgvPurchaseOrders.Rows.Count - 1; i++)
                    {
                        string pname = dtgvPurchaseOrders.Rows[i].Cells["Name"].Value.ToString();

                        string query_prods = "SELECT id FROM products WHERE name = '" + pname + "'";
                        conn.Open();
                        MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
                        MySqlDataAdapter adp_prods = new MySqlDataAdapter(comm_prods);
                        conn.Close();
                        DataTable dt_prods = new DataTable();
                        adp_prods.Fill(dt_prods);

                        string prod_id = dt_prods.Rows[0][0].ToString();
                        string prod_price = dtgvPurchaseOrders.Rows[i].Cells["Price"].Value.ToString();
                        string prod_quantity = dtgvPurchaseOrders.Rows[i].Cells["Quantity"].Value.ToString();
                        string prod_subtotal = dtgvPurchaseOrders.Rows[i].Cells["Subtotal"].Value.ToString();
                    
                        string query_order_line = "INSERT INTO purchase_order_line (products_id,purchase_order_id,quantity,price,subtotal,stocked_in,status) VALUES('" + int.Parse(prod_id) + "',(SELECT max(id) FROM purchase_order),'" + int.Parse(prod_quantity) + "','" + decimal.Parse(prod_price) + "','" + decimal.Parse(prod_subtotal) + "','no','ordered')";
                        conn.Open();
                        MySqlCommand comm_order_line = new MySqlCommand(query_order_line, conn);
                        comm_order_line.ExecuteNonQuery();
                        conn.Close();
                

                    }

                    MessageBox.Show("Record saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resetFields();
                    orders.Clear();
                    loadPurchasingData();
                }

                else
                {
                    MessageBox.Show("Please add data to the table before saving!", "No data to be saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Supplier details missing!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        // Shows Product List
        private void prodTxt_MouseClick(object sender, MouseEventArgs e)
        {
           
            if (dtgvAvailProds.Rows.Count < 1)
            {
                MessageBox.Show("No products Available!", "No products available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Add_product add = new Add_product();
                add.Show();
                add.previousform = this;
                this.Hide();
            }
            else
            {
                ShowProducts();
                prodpanel.Size = new Size(432, 376);
                prodpanel.Location = new Point(614, 320);
                prodpanel.Visible = true;
                prodpanel.Enabled = true;
            }

        }
 
        // Hide datagridview if user already chose a product
        public int selected_id;
        private void dtgvAvailProds_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                selected_id = int.Parse(dtgvAvailProds.Rows[e.RowIndex].Cells["id"].Value.ToString());

                prodpanel.Visible = false;
                prodpanel.Enabled = false;
                load_prod_details();
            }
        }
        // Pass Data from products to Datagrid
        public void ShowProducts()
        {
            String query_prods = "SELECT id,name,price,description,expirable FROM products";

            conn.Open();
            MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
            MySqlDataAdapter adp_prods = new MySqlDataAdapter(comm_prods);
            conn.Close();
            DataTable dt_prods = new DataTable();
            adp_prods.Fill(dt_prods);

            dtgvAvailProds.DataSource = dt_prods;
            dtgvAvailProds.Columns["id"].Visible = false;
            dtgvAvailProds.Columns["name"].HeaderText = "Name";
            dtgvAvailProds.Columns["description"].HeaderText = "Description";
            dtgvAvailProds.Columns["price"].HeaderText = "Price";
            dtgvAvailProds.Columns["expirable"].HeaderText = "Expirable";


        }
   
        // Fetching data from selected products to fields
        public void load_prod_details()
        {

            String query_get_products_details = "SELECT id,name,price,description,expirable FROM products where id = "+ selected_id + " ";

            MySqlCommand comm_get_products_details = new MySqlCommand(query_get_products_details, conn);
            comm_get_products_details.CommandText = query_get_products_details;

            conn.Open();
            MySqlDataReader drd_get_products_details = comm_get_products_details.ExecuteReader();
            while (drd_get_products_details.Read())
            {
                prodTxt.Text = drd_get_products_details["name"].ToString();
                priceTxt.Text = "0.00";
                sellingpriceTxt.Text = drd_get_products_details["price"].ToString();
                subtotalTxt.Text = priceTxt.Text;
                quanNum.Value = 1;
                Validation = true;
                quanNum.Enabled = true;
            }
            conn.Close();

        }

        private void addprod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Add_product add = new Add_product();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void Add_PO_VisibleChanged(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            resetFields();
        }

        public void resetFields()
        {
            supplierCmb.Text = "";
            prodTxt.Text = "Click to add Products";
            priceTxt.Text = "0";
            subtotalTxt.Text = "0";
            quanNum.Enabled = false;


        }
     
        public void loadPurchasingData()
        {
           
            String query_purchase_order = "SELECT purchase_order.id as id,DATE_FORMAT(date, '%Y/%m/%d %H:%i %p') as date, organization_name as supplier, concat(person.firstname,' ',person.middlename,' ',person.lastname) as staff, total, purchase_order.status FROM purchase_order, staff, person,suppliers WHERE purchase_order.suppliers_id = suppliers.id AND purchase_order.status = 'ordered' AND purchase_order.staff_id = staff.id AND staff.person_id = person.id ORDER BY date ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_purchase_order, conn);
            MySqlDataAdapter adp_purchase_order = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_purchase_order = new DataTable();
            adp_purchase_order.Fill(dt_purchase_order);

            dtgvPO.DataSource = dt_purchase_order;

            dtgvPO.Columns["id"].Visible = false;
            dtgvPO.Columns["date"].HeaderText = "Date";
            dtgvPO.Columns["supplier"].HeaderText = "Supplier";
            dtgvPO.Columns["staff"].HeaderText = "Staff";
            dtgvPO.Columns["total"].HeaderText = "Total";
            dtgvPO.Columns["status"].HeaderText = "Status";


        }

        private void prodextBtn_Click(object sender, EventArgs e)
        {
            prodpanel.Visible = false;
            prodpanel.Enabled = false;
        }
        public static int orderline_id;
        public static decimal selected_subtotal;
        private void dtgvOrderLine_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                delcancelBtn.Enabled = true;
                deliveredBtn.Enabled = true;
                statPanel.Size = new Size(456, 613);
                statPanel.Location = new Point(601, 61);
                statPanel.Show();
                int selected_id = int.Parse(dtgvOrderLine.Rows[e.RowIndex].Cells["id"].Value.ToString());
                orderline_id = selected_id;
               

                String query_PoLine = "SELECT purchase_order_line.id as id, products.name as prodname, purchase_order_line.price as price, quantity as quantity, subtotal FROM purchase_order_line, products WHERE products_id = products.id AND  purchase_order_line.id = " + orderline_id + " ";
                MySqlCommand comm_PoLine = new MySqlCommand(query_PoLine, conn);
                comm_PoLine.CommandText = query_PoLine;

                conn.Open();
                MySqlDataReader drd_PoLine = comm_PoLine.ExecuteReader();
                while (drd_PoLine.Read())
                {
                    po_idLbl.Text = drd_PoLine["id"].ToString();
                    prodName.Text = drd_PoLine["prodname"].ToString();
                    priceLbl.Text = drd_PoLine["price"].ToString();
                    subLbl.Text = drd_PoLine["subtotal"].ToString();
                    selected_subtotal = decimal.Parse(subLbl.Text);
                    quanLbl.Text = drd_PoLine["quantity"].ToString();
                }
                conn.Close();
               
            }
            else
            {
                statPanel.Hide();
                //something
            }

        }

        public static int po_id;
        private void dtgvPO_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex > -1)
            {
                cancelPOBtn.Enabled = true;
                int selected_id = int.Parse(dtgvPO.Rows[e.RowIndex].Cells["id"].Value.ToString());
                po_id = selected_id;
                loadPOLines();
            }
        }
        public void loadPOLines()
        {  String query_order_line = "SELECT purchase_order_line.id as id, products.name as product, purchase_order_line.price, quantity as quantity, subtotal, status FROM purchase_order_line, products WHERE  products.id = products_id AND  purchase_order_id = " + po_id + "  AND  products.id = purchase_order_line.products_id AND status != 'cancelled' group by id";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query_order_line, conn);
                MySqlDataAdapter adp_order_line = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt_order_line = new DataTable();
                adp_order_line.Fill(dt_order_line);

                dtgvOrderLine.DataSource = dt_order_line;

                dtgvOrderLine.Columns["id"].Visible = false;
                dtgvOrderLine.Columns["product"].HeaderText = "Product Name";
                dtgvOrderLine.Columns["quantity"].HeaderText = "Quantity";
                dtgvOrderLine.Columns["price"].HeaderText = "Price";
                dtgvOrderLine.Columns["subtotal"].HeaderText = "Subtotal";
                dtgvOrderLine.Columns["status"].HeaderText = "Status";
            
        }

        private void deliveredBtn_Click(object sender, EventArgs e)
        {
           
             
            string query_del_update = "UPDATE purchase_order_line SET status = 'delivered'  WHERE id = " + orderline_id + " "; 
            conn.Open();
            MySqlCommand comm_del_update = new MySqlCommand(query_del_update, conn);
            comm_del_update.ExecuteNonQuery();
            conn.Close();

            string query_change_delivered = "UPDATE purchase_order, purchase_order_line SET purchase_order.status = 'delivered' WHERE purchase_order.id = purchase_order_line.purchase_order_id AND purchase_order_line.status = 'delivered'";
            conn.Open();
            MySqlCommand comm_change_delivered = new MySqlCommand(query_change_delivered, conn);
            comm_change_delivered.ExecuteNonQuery();
            conn.Close();

            string query_change_ordered = "UPDATE purchase_order, purchase_order_line SET purchase_order.status = 'ordered'WHERE purchase_order.id = purchase_order_line.purchase_order_id AND purchase_order_line.status = 'ordered'";
            conn.Open();
            MySqlCommand comm_change_ordered = new MySqlCommand(query_change_ordered, conn);
            comm_change_ordered.ExecuteNonQuery();
            conn.Close();



            loadPurchasingData();
            loadPOLines();
            dtgvOrderLine.DataSource = null;
            del_details_reset();
            deliveredBtn.Enabled = false;
        }

        private void delcancelBtn_Click(object sender, EventArgs e)
        {
            
            string query_del_update = "UPDATE purchase_order_line SET status = 'cancelled' WHERE id = " + orderline_id + " ";

            string update_total = "UPDATE purchase_order,purchase_order_line SET purchase_order.total = purchase_order.total - " + selected_subtotal + " WHERE purchase_order.id = purchase_order_id  AND purchase_order.id = " + po_id + " ";

            conn.Open();

            MySqlCommand comm_del_update = new MySqlCommand(query_del_update, conn);
            comm_del_update.ExecuteNonQuery();

            MySqlCommand comm_update_total = new MySqlCommand(update_total, conn);
            comm_update_total.ExecuteNonQuery();

            conn.Close();

       
            string query_change_delivered = "UPDATE purchase_order, purchase_order_line SET purchase_order.status = 'delivered' WHERE purchase_order.id = purchase_order_line.purchase_order_id AND purchase_order_line.status = 'delivered'";
            conn.Open();
            MySqlCommand comm_change_delivered = new MySqlCommand(query_change_delivered, conn);
            comm_change_delivered.ExecuteNonQuery();
            conn.Close();

            string query_change_ordered = "UPDATE purchase_order, purchase_order_line SET purchase_order.status = 'ordered' WHERE purchase_order.id = purchase_order_line.purchase_order_id AND purchase_order_line.status = 'ordered'";
            conn.Open();
            MySqlCommand comm_change_ordered = new MySqlCommand(query_change_ordered, conn);
            comm_change_ordered.ExecuteNonQuery();
            conn.Close();

            loadPurchasingData();
            dtgvOrderLine.DataSource = null;
            delcancelBtn.Enabled = false;
            deliveredBtn.Enabled = false;
            del_details_reset();

            for (int i = 0; i <= dtgvPO.Rows.Count - 1; i++)
            {
                int orderline_index = int.Parse(dtgvPO.Rows[i].Cells["id"].Value.ToString());
                if (dtgvPO.Rows[i].Cells["total"].Value.ToString() == "0.00")
                {

                    string cancel_order_query = "UPDATE purchase_order SET purchase_order.status = 'cancelled' WHERE purchase_order.id = " + orderline_index + " ";
                    conn.Open();
                    MySqlCommand comm_cancel_order = new MySqlCommand(cancel_order_query, conn);
                    comm_cancel_order.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("CANCELLED");
                }

            }

            loadPurchasingData();
            dtgvOrderLine.DataSource = null;
            statPanel.Visible = false;
        }

        private void cancelPOBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel? (You will not be able to rollback these changes)", "Cancel PO", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string cancel_order_query = "UPDATE purchase_order,purchase_order_line SET purchase_order_line.status = 'cancelled', purchase_order.status = 'cancelled' WHERE purchase_order.id = purchase_order_line.purchase_order_id AND purchase_order.id = " + po_id + " ";
                conn.Open();
                MySqlCommand comm_cancel_order = new MySqlCommand(cancel_order_query, conn);
                comm_cancel_order.ExecuteNonQuery();
                conn.Close();
                cancelPOBtn.Enabled = false;
                loadPurchasingData();
                loadPOLines();
            }
            cancelPOBtn.Enabled = false;
            dtgvOrderLine.DataSource = null;
            del_details_reset();
        }

        public void del_details_reset()
        {
            po_idLbl.Text = "-------";
            priceLbl.Text = "-------";
            quanLbl.Text = "-------";
            subLbl.Text = "-------";
            prodName.Text = "-------";
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }

        int printedLines = 0;
        public void function_print()
        {
            dtgvPO.ClearSelection();
            printedLines = 0;


            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 850, 1100);
            printDocument1.DefaultPageSettings.Landscape = true;

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.Show();

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            else
            {
                printPreviewDialog1.Show();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string company = "Fabulous Pets Veterinary";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 250, 50);

            string viewinv = "Purchase Order Report";
            e.Graphics.DrawString(viewinv, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 330, 100);

            e.HasMorePages = false;

            Graphics graphic = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 13);

            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);


            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            float fontHeight = font.GetHeight();

            int startY = 190;
            int offsetY = 0;

            int startX = 1;

            //Headers
            string date = "DATE";
            e.Graphics.DrawString(date, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, startX + 210, startY);

            offsetY += (int)fontHeight + 10;

            string supp = "SUPPLIER";
            e.Graphics.DrawString(supp, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, startX + 355, startY);

            string staff = "STAFF";
            e.Graphics.DrawString(staff, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, startX + 545, startY);

            string total = "TOTAL";
            e.Graphics.DrawString(total, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, startX + 705, startY);

            string status = "STATUS";
            e.Graphics.DrawString(status, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, startX + 833, startY);



            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 1500, 1);

            while (printedLines < dtgvPO.Rows.Count)
            {
                //Date
                graphic.DrawString(dtgvPO.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX + 150, startY + offsetY + 20);
                //Supplier
                graphic.DrawString(dtgvPO.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 370, startY + offsetY + 20);
                //Staff
                graphic.DrawString(dtgvPO.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX + 500, startY + offsetY + 20);
                //Total
                graphic.DrawString(dtgvPO.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX + 710, startY + offsetY + 20);
                //Status
                graphic.DrawString(dtgvPO.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX + 840, startY + offsetY + 20);

                offsetY += (int)fontHeight + 20;

                ++printedLines;

                if (offsetY >= 700)
                {
                    e.HasMorePages = true;
                    offsetY = 0;
                    return;
                }
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            statPanel.Visible = false;
        }
    }

}

