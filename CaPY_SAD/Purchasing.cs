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
    public partial class Purchasing : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        public Purchasing()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=true");
            InitializeComponent();
        }

        DataTable toInventory = new DataTable();

        private void Purchasing_Load(object sender, EventArgs e)
        {
            loadPurchasingData();

            //Check if columns are already Loaded
            if (!toInventory.Columns.Contains("Expiration Date") || !toInventory.Columns.Contains("Name") || !toInventory.Columns.Contains("Quantity") || !toInventory.Columns.Contains("po_id") || !toInventory.Columns.Contains("pol_id"))
            {
                toInventory.Columns.Add("Expiration Date", typeof(string));
                toInventory.Columns.Add("Name", typeof(string));
                toInventory.Columns.Add("Quantity", typeof(string));
                toInventory.Columns.Add("po_id", typeof(int));
                toInventory.Columns.Add("pol_id", typeof(int));
                dtgvInv.DataSource = toInventory;
                dtgvInv.Columns["po_id"].Visible = false;
                dtgvInv.Columns["pol_id"].Visible = false;

            }


        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {

        }

        public void loadPurchasingData()
        {
            String query_purchase_order = "SELECT purchase_order.id as id,DATE_FORMAT(date, '%Y/%m/%d %H:%i %p') as date, organization_name as supplier, concat(person.firstname,' ',person.middlename,' ',person.lastname) as staff, total, purchase_order.status as status FROM purchase_order, staff, person,suppliers WHERE purchase_order.suppliers_id = suppliers.id AND purchase_order.status = 'delivered' AND purchase_order.staff_id = staff.id AND staff.person_id = person.id ORDER BY date ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_purchase_order, conn);
            MySqlDataAdapter adp_purchase_order = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_purchase_order = new DataTable();
            adp_purchase_order.Fill(dt_purchase_order);

            dtgvPurchaseOrders.DataSource = dt_purchase_order;

            dtgvPurchaseOrders.Columns["id"].Visible = false;
            dtgvPurchaseOrders.Columns["date"].HeaderText = "Date";
            dtgvPurchaseOrders.Columns["supplier"].HeaderText = "Supplier";
            dtgvPurchaseOrders.Columns["staff"].HeaderText = "Staff";
            dtgvPurchaseOrders.Columns["total"].HeaderText = "Total";
            dtgvPurchaseOrders.Columns["status"].HeaderText = "Status";

        }
        public class purchase
        {
            public static decimal p_total;
        }
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
            purchase.p_total = total;
            totalTxt.Text = total_string;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_PO add_po = new Add_PO();
            add_po.Show();
            add_po.previousform = this;
            this.Hide();
        }


        private void dtgvPurchaseOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int purchase_order_id;

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvPurchaseOrders.Rows[e.RowIndex].Cells["id"].Value.ToString());
                purchase_order_id = selected_id;

                String query_order_line = "SELECT purchase_order_line.id as id, products.name as product, purchase_order_line.price, quantity as quantity, subtotal,purchase_order_line.status as status FROM purchase_order_line, products WHERE purchase_order_id = " + selected_id + " AND purchase_order_line.status = 'delivered' AND products.id = purchase_order_line.products_id group by id";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query_order_line, conn);
                MySqlDataAdapter adp_order_line = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt_order_line = new DataTable();
                adp_order_line.Fill(dt_order_line);

                dtgvPurchaseOrderLines.DataSource = dt_order_line;

                dtgvPurchaseOrderLines.Columns["id"].Visible = false;
                dtgvPurchaseOrderLines.Columns["product"].HeaderText = "Product Name";
                dtgvPurchaseOrderLines.Columns["quantity"].HeaderText = "Quantity";
                dtgvPurchaseOrderLines.Columns["price"].HeaderText = "Price";
                dtgvPurchaseOrderLines.Columns["subtotal"].HeaderText = "Subtotal";
                dtgvPurchaseOrderLines.Columns["status"].HeaderText = "Status";
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Purchasing_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Purchasing_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Purchasing_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dtgvPurchaseOrders_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            decimal total = 0;

            for (int i = 0; i <= dtgvPurchaseOrders.Rows.Count - 1; i++)
            {

                string subs = dtgvPurchaseOrders.Rows[i].Cells["Total"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;


            }
            string total_string = total.ToString();
            totalTxt.Text = total_string;

        }


    

        private void backOrderlineBtn_Click(object sender, EventArgs e)
        {

            if (dtgvInv.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Nothing to remove!", "Nothing to remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
                backOrderlineBtn.Enabled = false;
            }
            else
            {
                int rowIndex = dtgvInv.CurrentCell.RowIndex;
                dtgvInv.Rows.RemoveAt(rowIndex);
            }

        }

        
        public static int orderline_id;
        private void dtgvPurchaseOrderLines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           




            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvPurchaseOrderLines.Rows[e.RowIndex].Cells["id"].Value.ToString());
                orderline_id = selected_id;

                String query_check_expirable = "SELECT expirable FROM products, purchase_order_line WHERE products_id = products.id AND purchase_order_line.id =" + selected_id + " ";

                MySqlCommand comm_check_expirable = new MySqlCommand(query_check_expirable, conn);
                comm_check_expirable.CommandText = query_check_expirable;

                conn.Open();
                MySqlDataReader drd_check_expirable = comm_check_expirable.ExecuteReader();

                while (drd_check_expirable.Read())
                {
                    string exp_stat = (drd_check_expirable["expirable"].ToString());
                    if (exp_stat == "yes")
                    {
                        expirationDtp.Visible = true;
                        expirationLabel.Visible = true;
                    }
                    else
                    {
                        expirationDtp.Visible = false;
                        expirationLabel.Visible = false;
                    }
                }
                conn.Close();

                toInventoryBtn.Enabled = true;
            }
            else
            {
                toInventoryBtn.Enabled = false;
            }
        }

        private void toInventoryBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Is Expiration Date Entered Correct?", "Expiration Date", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                int id;
                int products_id;
                string product_name;
                int purchase_order_id;
                int quantity;
                string expiration;
                Boolean stocked_in = false;

                // Purchase Order line validation to be inserted into inventory
                String query_orderline = "SELECT purchase_order_line.id as id, products.name as product, products_id, purchase_order_id, quantity FROM products, purchase_order_line WHERE purchase_order_line.products_id = products.id AND  purchase_order_line.id = " + orderline_id + "";
                MySqlCommand comm_orderline = new MySqlCommand(query_orderline, conn);
                comm_orderline.CommandText = query_orderline;

                //Query to check if the product is already stocked in
                String query_dupes = "SELECT purchase_order_line.id FROM purchase_order_line WHERE stocked_in = 'yes' AND  purchase_order_line.id = " + orderline_id + "";

                conn.Open();
                MySqlCommand comm_dupes = new MySqlCommand(query_dupes, conn);
                MySqlDataAdapter adp_dupes = new MySqlDataAdapter(comm_dupes);
                DataTable dt_dupes = new DataTable();
                adp_dupes.Fill(dt_dupes);
                conn.Close();

                // MessageBox.Show(dt_dupes.Rows.Count.ToString());
                if (dt_dupes.Rows.Count < 1)
                {


                    conn.Open();
                    MySqlDataReader drd_orderline = comm_orderline.ExecuteReader();
                    while (drd_orderline.Read())
                    {
                        id = int.Parse(drd_orderline["id"].ToString());
                        expiration = expirationDtp.Text;
                        products_id = int.Parse(drd_orderline["products_id"].ToString());
                        product_name = drd_orderline["product"].ToString();
                        purchase_order_id = int.Parse(drd_orderline["purchase_order_id"].ToString());
                        quantity = int.Parse(drd_orderline["quantity"].ToString());

                        for (int i = 0; i < dtgvInv.Rows.Count; i++)
                        {
                            if (id == int.Parse(dtgvInv.Rows[i].Cells["pol_id"].Value.ToString()) && purchase_order_id == int.Parse(dtgvInv.Rows[i].Cells["po_id"].Value.ToString()) && quantity <= int.Parse(dtgvInv.Rows[i].Cells["quantity"].Value.ToString()))
                            {
                                stocked_in = true;
                            }

                        }
                        if (stocked_in == false)
                        {
                            // If product is not expirable expiration set expiration as 0000-00-00 by default
                            if (expirationDtp.Visible == false)
                            {
                                expiration = "0000-00-00";
                            }
                            else
                            {
                                expiration = expirationDtp.Text;
                            }

                            toInventory.Rows.Add(expiration, product_name, quantity, purchase_order_id, id);
                        }
                        else
                        {
                            MessageBox.Show("All number of items for this products already added!", "Already added", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

                    conn.Close();

                }
                else
                {
                    MessageBox.Show("These products are already stocked in!", "Already stocked in", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
       


        }

        private void stockInBtn_Click(object sender, EventArgs e)
        {
            int purchase_order_id;
            int purchase_orderline_id;
            int quantity;
            string expiration;
            string prod_name;

            if (dtgvInv.Rows.Count < 1)
            {
                MessageBox.Show("Nothing to stock in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                for (int i = 0; i < dtgvInv.Rows.Count; i++)
                {
                    purchase_order_id = int.Parse(dtgvInv.Rows[i].Cells["po_id"].Value.ToString());
                    purchase_orderline_id = int.Parse(dtgvInv.Rows[i].Cells["pol_id"].Value.ToString());
                    expiration = dtgvInv.Rows[i].Cells["expiration date"].Value.ToString();
                    prod_name = dtgvInv.Rows[i].Cells["name"].Value.ToString();
                    quantity = int.Parse(dtgvInv.Rows[i].Cells["quantity"].Value.ToString());

                    string query_inventory_duplicate = "SELECT expiration_date FROM product_inventory WHERE expiration_date = '" + expiration + "' AND products_id = (SELECT id FROM products where name = '" + prod_name + "')";
                    conn.Open();
                    MySqlCommand comm_inventory_duplicate = new MySqlCommand(query_inventory_duplicate, conn);
                    MySqlDataAdapter adp_inventory_duplicate = new MySqlDataAdapter(comm_inventory_duplicate);
                    conn.Close();
                    DataTable dt_inventory_duplicate = new DataTable();
                    adp_inventory_duplicate.Fill(dt_inventory_duplicate);

                    if (dt_inventory_duplicate.Rows.Count > 0)
                    {
                        // Increment Quantity of existing instance
                        string query_add_quantity = "UPDATE product_inventory set status = 'available', quantity = quantity + " + quantity + " where products_id = (SELECT id FROM products where name = '" + prod_name + "') AND  expiration_date = '" + expiration + "'";
                        conn.Open();
                        MySqlCommand comm_add_quantity = new MySqlCommand(query_add_quantity, conn);
                        comm_add_quantity.ExecuteNonQuery();
                        conn.Close();

                    }
                    else
                    {
                        // Add a new instance 
                        string query_inventory = "INSERT INTO product_inventory (products_id,quantity,expiration_date,status) VALUES((SELECT id FROM products where name = '" + prod_name + "'),'" + quantity + "','" + expiration + "', 'available')";
                        conn.Open();
                        MySqlCommand comm_inventory = new MySqlCommand(query_inventory, conn);
                        comm_inventory.ExecuteNonQuery();
                        conn.Close();

                    }

                    // Tag as stocked in
                    string query_stockin_stat = "UPDATE purchase_order_line SET stocked_in = 'yes' WHERE purchase_order_id = " + purchase_order_id + " AND id = " + purchase_orderline_id + " ";

                    conn.Open();
                    MySqlCommand comm_stockin_stat = new MySqlCommand(query_stockin_stat, conn);
                    comm_stockin_stat.ExecuteNonQuery();
                    conn.Close();

                    // Insert Stock In Log
                    string query_log = "INSERT INTO inventory_log (process_type,date,product,quantity,remarks,staff_id) VALUES('Stock In (Purchased)' , current_timestamp(),'" + prod_name + "','" + quantity + "', 'Purchased Item from "+CaPY_SAD.Login.UserDisplayDetails.name+"', "+ CaPY_SAD.Login.UserDisplayDetails.id + ")";
                    conn.Open();
                    MySqlCommand comm_log = new MySqlCommand(query_log, conn);
                    comm_log.ExecuteNonQuery();
                    conn.Close();

                }

                MessageBox.Show("Products successfully stocked in!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                toInventory.Clear();

            }

           

        }

        private void startDtp_ValueChanged(object sender, EventArgs e)
        {
            SortData();
        }


        public void SortData()
        {
            String query_purchase_order = "SELECT purchase_order.id as id, DATE_FORMAT(date, '%Y/%m/%d %H:%i %p') as date, organization_name as supplier, concat(person.firstname,' ',person.middlename,' ',person.lastname) as staff, total FROM purchase_order, staff, person,suppliers WHERE purchase_order.suppliers_id = suppliers.id AND purchase_order.staff_id = staff.id AND staff.person_id = person.id AND date(date) BETWEEN '"+ startDtp.Text +"' AND '"+ endDtp.Text + "' ORDER BY date ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_purchase_order, conn);
            MySqlDataAdapter adp_purchase_order = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_purchase_order = new DataTable();
            adp_purchase_order.Fill(dt_purchase_order);

            dtgvPurchaseOrders.DataSource = dt_purchase_order;

            dtgvPurchaseOrders.Columns["id"].Visible = false;
            dtgvPurchaseOrders.Columns["date"].HeaderText = "Date";
            dtgvPurchaseOrders.Columns["supplier"].HeaderText = "Supplier";
            dtgvPurchaseOrders.Columns["staff"].HeaderText = "Staff";
            dtgvPurchaseOrders.Columns["total"].HeaderText = "Total";

        }

        private void dtgvInv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            backOrderlineBtn.Enabled = true;
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }


        int printedLines = 0;
        public void function_print()
        {
            dtgvPurchaseOrders.ClearSelection();
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

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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

            while (printedLines < dtgvPurchaseOrders.Rows.Count)
            {
                //Date
                graphic.DrawString(dtgvPurchaseOrders.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX + 150, startY + offsetY + 20);
                //Supplier
                graphic.DrawString(dtgvPurchaseOrders.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 370, startY + offsetY + 20);
                //Staff
                graphic.DrawString(dtgvPurchaseOrders.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX + 500, startY + offsetY + 20);
                //Total
                graphic.DrawString(dtgvPurchaseOrders.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX + 710, startY + offsetY + 20);
                //Status
                graphic.DrawString(dtgvPurchaseOrders.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX + 840, startY + offsetY + 20);
                
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


    }
}
 

