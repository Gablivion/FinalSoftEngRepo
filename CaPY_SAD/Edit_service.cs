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
    public partial class Edit_service : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Edit_service()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        // Variable to turn on validations
        Boolean Validation = false;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }


        public int service_id = CaPY_SAD.Services.selected_data.service_id;
        private void Edit_service_Load(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            EditBtn.Enabled = false;
            loadServiceProds();
            loadprodCmbData();

            String query = "SELECT * FROM services where id = '" + service_id + "'";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                nameTxt.Text = (drd["name"].ToString());
                descTxt.Text = (drd["description"].ToString());
                priceTxt.Text = (drd["price"].ToString());
                bpriceTxt.Text = (drd["base_price"].ToString());

                if ((drd["status"].ToString()) == "available")
                {
                    availCbox.Checked = true;

                }
                else
                {
                    availCbox.Checked = false;
                }
            }
            conn.Close();
        }

        public void loadServiceProds()
        {
            String query_service= "SELECT service_products.id as id, products.name as prod, products.price as price ,products.price * quantity as subtotal, quantity FROM services,products,service_products WHERE service_products.products_id = products.id AND services_id = services.id AND services.id = " + service_id + " ";

            conn.Open();
            MySqlCommand comm_services = new MySqlCommand(query_service, conn);
            MySqlDataAdapter adp_services = new MySqlDataAdapter(comm_services);
            conn.Close();
            DataTable dt_services = new DataTable();
            adp_services.Fill(dt_services);

            dtgvServicesProd.DataSource = dt_services;
            dtgvServicesProd.Columns["id"].Visible = false;
            dtgvServicesProd.Columns["prod"].HeaderText = "Product";
            dtgvServicesProd.Columns["quantity"].HeaderText = "Quantity";
            dtgvServicesProd.Columns["price"].HeaderText = "Price";
            dtgvServicesProd.Columns["subtotal"].HeaderText = "Subtotal";

        }
        

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(priceTxt.Text, "[^0-9.]") && Validation == true)
            {
                MessageBox.Show("Please enter only numbers!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTxt.Text = priceTxt.Text.Remove(priceTxt.Text.Length - 1);
            }
        }
        
        // indicates if add or edit
        String Type;

        private void addBtn_Click(object sender, EventArgs e)
        {
            dtgvServicesProd.Enabled = false;
            prodPanel.Visible = true;
            prodPanel.Enabled = true;
            prodPanel.Size = new Size(472, 553);
            prodPanel.Location = new Point(32, 0);

            Type = "Add";
            load_service_details();

        }


        public static decimal prod_price;
        public void load_service_details()
        {
            String query = "SELECT products.name as prod, quantity, products.price as price from services,products,service_products WHERE service_products.products_id = products.id AND services_id = services.id AND services.id =" + service_id + "";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();


            while (drd.Read())
            {
                nameCmb.Text = drd["prod"].ToString();
                quantityTxt.Text = drd["quantity"].ToString();
                prod_price = decimal.Parse(drd["price"].ToString());
            }
            conn.Close();
        }
      
        private void EditBtn_Click(object sender, EventArgs e)
        {
            prodPanel.Visible = true;
            prodPanel.Enabled = true;
            prodPanel.Size = new Size(485, 505);
            prodPanel.Location = new Point(0, 0);
            Type = "Edit";

            load_service_details();


        }
        private void cancelprodBtn_Click(object sender, EventArgs e)
        {
            nameCmb.Text = "";
            quantityTxt.Text = "";
            prodPanel.Visible = false;
            prodPanel.Enabled = false;
            addBtn.Enabled = true;
            EditBtn.Enabled = false;
            dtgvServicesProd.Enabled = true;
         
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            
            if (nameTxt.Text == "" || descTxt.Text == "" || priceTxt.Text == "")
            {
                
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string available;

                if (availCbox.Checked == true)
                {
                    available = "available";
                }
                else
                {
                    available = "unavailable";

                }
                string query = "Update services set name = '" + nameTxt.Text + "' , description ='" + descTxt.Text + "', base_price = '" + bpriceTxt.Text + "',status = '" + available + "' ,date_modified = current_timestamp() where id = '" + service_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                servtotal();

                this.Close();
                previousform.ShowDialog();

            }
          
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            nameTxt.Enabled = false;
            descTxt.Enabled = false;
            priceTxt.Enabled = false;
            availCbox.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        public void loadprodCmbData()
        {
            String query_prods = "SELECT * FROM products";

            MySqlCommand comm_prods = new MySqlCommand(query_prods, conn);
            comm_prods.CommandText = query_prods;
            conn.Open();
            MySqlDataReader drd_prods = comm_prods.ExecuteReader();

            nameCmb.Items.Clear();
            while (drd_prods.Read())
            {
                nameCmb.Items.Add(drd_prods["name"].ToString());
            }
            conn.Close();

        }
       
        private void addprodBtn_Click(object sender, EventArgs e)
        {
            if (Type == "Add")
            {

                if (nameCmb.Text == "" || quantityTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query_add = "INSERT INTO service_products(services_id,products_id,quantity)" +
                                            "VALUES(" + service_id + ",(SELECT id FROM products WHERE name = '" + nameCmb.Text + "'),'" + quantityTxt.Text + "')";

                    conn.Open();
                    MySqlCommand comm_add = new MySqlCommand(query_add, conn);
                    comm_add.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Product added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nameCmb.Text = "";
                    quantityTxt.Text = "";

                    prodPanel.Visible = false;
                    prodPanel.Enabled = false;

                }
          
                
            }
            else if (Type == "Edit")
            {
                if (nameCmb.Text == "" || quantityTxt.Text == "")
                {
                    MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query_edit = "UPDATE service_products SET products_id = (SELECT id FROM products WHERE name = '" + nameCmb.Text + "'), quantity = " + quantityTxt.Text + " WHERE id = " + serviceprod_id + "";

                    conn.Open();
                    MySqlCommand comm_edit = new MySqlCommand(query_edit, conn);
                    comm_edit.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("Product edited!", "Edit Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    nameCmb.Text = "";
                    quantityTxt.Text = "";
                    prodPanel.Visible = false;
                    prodPanel.Enabled = false;
                }

          
            }

            servtotal();
            
        }

        public static int serviceprod_id;
        private void dtgvServicesProd_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            EditBtn.Enabled = true;

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvServicesProd.Rows[e.RowIndex].Cells["id"].Value.ToString());
                serviceprod_id = selected_id;
            }
        }

        public void servtotal()
        {
            decimal current_price = decimal.Parse(bpriceTxt.Text);
            decimal new_price;
            decimal total = 0;

            for (int i = 0; i <= dtgvServicesProd.Rows.Count - 1; i++)
            {
                string subs = dtgvServicesProd.Rows[i].Cells["subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total += decimal_sub;

            }

            new_price = current_price + total;
            priceTxt.Text = new_price.ToString();

            string query_update_price = "UPDATE services SET price = '" + new_price + "'  where id = " + service_id + "";
            conn.Open();
            MySqlCommand comm_query_update_price = new MySqlCommand(query_update_price, conn);
            comm_query_update_price.ExecuteNonQuery();
            conn.Close();

            nameCmb.Text = "";
            addBtn.Enabled = true;
            EditBtn.Enabled = false;
            dtgvServicesProd.Enabled = true;

        }

        private void prodPanel_VisibleChanged(object sender, EventArgs e)
        {
            loadServiceProds();
            load_service_details();
        }

        private void editserviceBtn_Click(object sender, EventArgs e)
        {
            nameTxt.Enabled = true;
            descTxt.Enabled = true;
            availCbox.Enabled = true;
            bpriceTxt.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            editserviceBtn.Enabled = false;
        
        }
    }
}
