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
    public partial class Menu : Form
    {
        public Login previousform { get; set; }

        MySqlConnection conn;

        public Menu()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private Timer tm = new Timer();

        void tm_Tick(object sender, EventArgs e)
        {
            timeTxt.Text = DateTime.Now.ToLongTimeString();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //rPan.Visible = false;
            //sPan.Visible = false;

            salesPanel.Visible = false;
            recordsPanel.Visible = false;

            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = 1000;
            tm.Enabled = true;

            timeTxt.Text = DateTime.Now.ToLongTimeString();
            userTxt.Text = CaPY_SAD.Login.UserDisplayDetails.name;
            posTxt.Text = CaPY_SAD.Login.UserDisplayDetails.position;

            loadRestock();
            loadExpiredProd();
     
        }

        public void loadRestock()
        {

            String query_restock = "SELECT name, description, quantity FROM products, product_inventory WHERE products.id = product_inventory.products_id AND quantity < reorder AND status = 'available'";

            conn.Open();
            MySqlCommand comm_restock = new MySqlCommand(query_restock, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_restock);
            conn.Close();
            DataTable dt = new DataTable();
            if (adp != null)
            {
                adp.Fill(dt);

                dtgvRestock.DataSource = dt;
                dtgvRestock.Columns["name"].HeaderText = "Name";
                dtgvRestock.Columns["description"].HeaderText = "Description";
                dtgvRestock.Columns["quantity"].HeaderText = "Quantity";
            } 
           
        }

        public void loadExpiredProd()
        {

            String query_expiredprod = "SELECT name, description, quantity, expiration_date FROM products, product_inventory WHERE expiration_date <= CURDATE() AND status = 'available' AND expiration_date != 0000 - 00 - 00";

            conn.Open();
            MySqlCommand comm_expiredprod = new MySqlCommand(query_expiredprod, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm_expiredprod);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvExpiredProd.DataSource = dt;
            dtgvExpiredProd.Columns["name"].HeaderText = "Name";
            dtgvExpiredProd.Columns["description"].HeaderText = "Description";
            dtgvExpiredProd.Columns["quantity"].HeaderText = "Quantity";
            dtgvExpiredProd.Columns["expiration_date"].HeaderText = "Expiration Date";
        }

        /*
        public void loadExpired()
        {
            String expired_num;
            String query_expired = "SELECT SUM(quantity) as num FROM product_inventory WHERE expiration_date <= CURDATE() AND status = 'available' AND expiration_date != 0000-00-00";

            MySqlCommand comm_expired = new MySqlCommand(query_expired, conn);
            comm_expired.CommandText = query_expired;

            conn.Open();

            MySqlDataReader drd_suppliers = comm_expired.ExecuteReader();
            
                while (drd_suppliers.Read())
                {
                    expired_num = drd_suppliers["num"].ToString();

                    if (expired_num == "")
                    {
                        expired.Visible = false;
                    }
                    else
                    {
                        expired.Visible = true;
                        expired.Text = expired_num;

                    }

                }

            conn.Close();
        }
        */

        private void recordsBtn_Click(object sender, EventArgs e)
        {
            recordsPanel.Visible = true;
            recordsPanel.Size = new Size(877, 726);
            recordsPanel.Location = new Point(183, 60);

            salesPanel.Visible = false;
        }

        private void inventoryBtn_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            this.Hide();
            inv.Show();
            inv.previousform = this;
        }

        private void purchasingBtn_Click(object sender, EventArgs e)
        {
            Purchasing pur = new Purchasing();
            this.Hide();
            pur.Show();
            pur.previousform = this;
        }

        private void hospBtn_Click(object sender, EventArgs e)
        {
            Hosp hosp = new Hosp();
            hosp.previousform = this;
            this.Hide();
            hosp.Show();
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            Settings user_settings = new Settings();
            user_settings.Show();
            this.Hide();
            user_settings.previousform = this;
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void customerBtn_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            this.Hide();
            cust.Show();
            cust.previousform = this;

            recordsPanel.Visible = false;
        }

        private void petBtn_Click(object sender, EventArgs e)
        {
            Pet pet = new Pet();
            this.Hide();
            pet.Show();
            pet.previousform = this;
        }

        private void productBtn_Click(object sender, EventArgs e)
        {
            Product prod = new Product();
            this.Hide();
            prod.Show();
            prod.previousform = this;
        }

        private void serviceBtn_Click(object sender, EventArgs e)
        {
            Services srv = new Services();
            this.Hide();
            srv.Show();
            srv.previousform = this;
        }

        private void supplierBtn_Click(object sender, EventArgs e)
        {
            Supplier supp = new Supplier();
            this.Hide();
            supp.Show();
            supp.previousform = this;
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            this.Hide();
            staff.Show();
            staff.previousform = this;
        }
        
        private void backBtn_Click(object sender, EventArgs e)
        {
            recordsPanel.Visible = false;
        }

        private void salesBtn_Click(object sender, EventArgs e)
        {
            salesPanel.Visible = true;
            salesPanel.Size = new Size(877, 746);
            salesPanel.Location = new Point(183, 60);

            recordsPanel.Visible = false;
        }

        private void posBtn_Click_1(object sender, EventArgs e)
        {
            POS pos = new POS();
            this.Hide();
            pos.Show();
            pos.previousform = this;
        }

        private void salesreportBtn_Click(object sender, EventArgs e)
        {
            View_sales sales = new View_sales();
            this.Hide();
            sales.Show();
            sales.previousform = this;
        }

        private void back2Btn_Click(object sender, EventArgs e)
        {
            salesPanel.Visible = false;
        }

        private void refundBtn_Click(object sender, EventArgs e)
        {
            Refund refund = new Refund();
            this.Hide();
            refund.Show();
            refund.previousform = this;
        }

        private void refundreportBtn_Click(object sender, EventArgs e)
        {
            View_refund refreport = new View_refund();
            this.Hide();
            refreport.Show();
            refreport.previousform = this;
        }

        private void expired_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have expired products!", "Expired Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_VisibleChanged(object sender, EventArgs e)
        {
           // loadExpired();
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {
            Archive arc = new Archive();
            this.Hide();
            arc.Show();
            arc.previousform = this;
        }


        //Makes form movable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Menu_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Menu_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Menu_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
