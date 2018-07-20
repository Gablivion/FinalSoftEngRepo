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
    public partial class Edit_supplier : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Edit_supplier()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }


        public static int person_id;
        private void Edit_supplier_Load(object sender, EventArgs e)
        {
            loadPurchasingTransactions();
            bdayTxt.MaxDate = DateTime.Today;

            String query = "SELECT * FROM person,suppliers WHERE suppliers.person_id = person.id AND suppliers.id = " + supplier_id + "";

            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();
 

            while (drd.Read())
            {
                person_id = int.Parse(drd["person_id"].ToString());
                firstnameTxt.Text = (drd["firstname"].ToString());
                middlenameTxt.Text = (drd["middlename"].ToString());
                lastnameTxt.Text = (drd["lastname"].ToString());

                if ((drd["gender"].ToString()) == "male")
                {
                    maleRadio.Checked = true;

                }
                else if ((drd["gender"].ToString()) == "female")
                {
                    femaleRadio.Checked = true;
                }

                bdayTxt.Text = (drd["birthdate"].ToString());
                addressTxt.Text = (drd["address"].ToString());
                cnumTxt.Text = (drd["contact_number"].ToString());
                emailTxt.Text = (drd["email"].ToString());
                organizationTxt.Text = (drd["organization_name"].ToString());


            }
            conn.Close();


        }

      

        public void loadPurchasingTransactions()
        {

            String query_transactions = "SELECT purchase_order.id as id,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM suppliers,person WHERE suppliers.person_id = person.id AND suppliers.id = purchase_order.suppliers_id) as Supplier,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = purchase_order.staff_id) as Staff,total,date FROM purchase_order,suppliers where purchase_order.suppliers_id = suppliers.id AND suppliers.id = " + supplier_id + "";
            conn.Open();
            MySqlCommand comm_transactions = new MySqlCommand(query_transactions, conn);
            MySqlDataAdapter adp_transactions = new MySqlDataAdapter(comm_transactions);

            conn.Close();
            DataTable dt_transaction = new DataTable();
            adp_transactions.Fill(dt_transaction);

            dtgvPurchase.DataSource = dt_transaction;
            dtgvPurchase.Columns["id"].Visible = false;
            dtgvPurchase.Columns["Staff"].HeaderText = "Staff";
            dtgvPurchase.Columns["Supplier"].HeaderText = "Supplier";
            dtgvPurchase.Columns["total"].HeaderText = "Total";
            dtgvPurchase.Columns["date"].HeaderText = "Date";
        }
        public int supplier_id = CaPY_SAD.Supplier.selected_data.supplier_id;

        private void cnumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = true;
            middlenameTxt.Enabled = true;
            lastnameTxt.Enabled = true;
            maleRadio.Enabled = true;
            femaleRadio.Enabled = true;
            bdayTxt.Enabled = true;
            addressTxt.Enabled = true;
            cnumTxt.Enabled = true;
            emailTxt.Enabled = true;
            organizationTxt.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "" || organizationTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String gen = "";

                if (maleRadio.Checked == true)
                {
                    gen = "male";
                }
                else if (femaleRadio.Checked == true)
                {
                    gen = "female";
                }

                string query_person = "UPDATE person SET firstname = '" + firstnameTxt.Text + "' , middlename ='" + middlenameTxt.Text + "', lastname = '" + lastnameTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "', address = '" + addressTxt.Text + "' , contact_number = '" + cnumTxt.Text + "', email = '" + emailTxt.Text + "', date_modified = current_timestamp() where id = " + person_id + "";
                string query_supplier = "UPDATE suppliers SET organization_name = '" + organizationTxt.Text + "'  where id =" + supplier_id + "";
                conn.Open();
                MySqlCommand comm_person = new MySqlCommand(query_person, conn);
                comm_person.ExecuteNonQuery();

                MySqlCommand comm_supplier = new MySqlCommand(query_supplier, conn);
                comm_supplier.ExecuteNonQuery();

                conn.Close();


                firstnameTxt.Enabled = false;
                middlenameTxt.Enabled = false;
                lastnameTxt.Enabled = false;
                maleRadio.Enabled = false;
                femaleRadio.Enabled = false;
                bdayTxt.Enabled = false;
                addressTxt.Enabled = false;
                cnumTxt.Enabled = false;
                emailTxt.Enabled = false;
                organizationTxt.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = false;
            middlenameTxt.Enabled = false;
            lastnameTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            bdayTxt.Enabled = false;
            addressTxt.Enabled = false;
            cnumTxt.Enabled = false;
            emailTxt.Enabled = false;
            organizationTxt.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        private void dtgvPurchase_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int purchase_order_id;

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvPurchase.Rows[e.RowIndex].Cells["id"].Value.ToString());
                purchase_order_id = selected_id;

                String query_order_line = "SELECT purchase_order_line.id as id, DATE_FORMAT(expiration, '%Y/%m/%d') as expiration, products.name as product, purchase_order_line.price, quantity as quantity, subtotal FROM purchase_order_line, products WHERE purchase_order_id = " + purchase_order_id + "  AND  products.id = purchase_order_line.products_id group by id";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query_order_line, conn);
                MySqlDataAdapter adp_order_line = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt_order_line = new DataTable();
                adp_order_line.Fill(dt_order_line);

                dtgvOrderline.DataSource = dt_order_line;

                dtgvOrderline.Columns["id"].Visible = false;
                dtgvOrderline.Columns["expiration"].HeaderText = "Expiration Date";
                dtgvOrderline.Columns["product"].HeaderText = "Product Name";
                dtgvOrderline.Columns["quantity"].HeaderText = "Quantity";
                dtgvOrderline.Columns["price"].HeaderText = "Price";
                dtgvOrderline.Columns["subtotal"].HeaderText = "Subtotal";
            }
        }

        private void emailTxt_Leave(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!(System.Text.RegularExpressions.Regex.IsMatch(email, pattern)))
            {
                MessageBox.Show("Not a valid Email address ");
                emailTxt.Text = "";
            }
        }

        private void lastnameTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(firstnameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                firstnameTxt.Text = firstnameTxt.Text.Remove(firstnameTxt.Text.Length - 1);
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(middlenameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                middlenameTxt.Text = middlenameTxt.Text.Remove(middlenameTxt.Text.Length - 1);
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(lastnameTxt.Text, "[^a-zA-Z-ñÑ ]"))
            {
                MessageBox.Show("Invalid Input");
                lastnameTxt.Text = lastnameTxt.Text.Remove(lastnameTxt.Text.Length - 1);
            }
        }
    }
}
