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
    public partial class Edit_staff : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public Edit_staff()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }

        public int staff_id = CaPY_SAD.Staff.selected_data.staff_id;

        public static int person_id;
        private void Edit_staff_Load(object sender, EventArgs e)
        {
            if(CaPY_SAD.Login.UserDisplayDetails.position == "staff")
            {
                editBtn.Enabled = false;
                usernameLabel.Visible = false;
                passwordLabel.Visible = false;
                usernameTxt.Visible = false;
                passwordTxt.Visible = false;
                confPass.Visible = false;
                conflabel.Visible = false;
                passCbx.Visible = false;
            }

            loadTransactions();
            loadPurchasingTransactions();
            loadInvTransactions();  
            bdayTxt.MaxDate = DateTime.Today;
            String query = "SELECT * FROM staff,position,person where position.pos_id = staff.position_pos_id AND staff.person_id = person.id AND staff.id = '" + staff_id + "'";



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
                positionCmb.Text = (drd["name"].ToString());
                usernameTxt.Text = (drd["username"].ToString());
                passwordTxt.Text = (drd["password"].ToString());
                confPass.Text = passwordTxt.Text;

                if ((drd["status"].ToString()) == "active")
                {
                    statusbox.Checked = true;

                }
                else if ((drd["status"].ToString()) == "inactive")
                {
                    statusbox.Checked = false;
                }
              

            }
            conn.Close();

        }
        public void loadTransactions()
        {

            String query_transactions = "SELECT  (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM customers,person WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer,total, transaction_date from transactions,staff WHERE staff.id = transactions.staff_id AND staff.id = " + staff_id + "";

            conn.Open();
            MySqlCommand comm_transactions = new MySqlCommand(query_transactions, conn);
            MySqlDataAdapter adp_transactions = new MySqlDataAdapter(comm_transactions);

            conn.Close();
            DataTable dt_transaction = new DataTable();
            adp_transactions.Fill(dt_transaction);

            dtgvTransactions.DataSource = dt_transaction;
            dtgvTransactions.Columns["Customer"].HeaderText = "Customer";
            dtgvTransactions.Columns["Staff"].HeaderText = "Staff";
            dtgvTransactions.Columns["total"].HeaderText = "Total";
            dtgvTransactions.Columns["transaction_date"].HeaderText = "Date";
        }
        public void loadInvTransactions()
        {

            String query_invtransactions = "SELECT (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = staff_id) as Staff, product, quantity,  process_type, date FROM inventory_log WHERE staff_id = " + staff_id + "";
            conn.Open();
            MySqlCommand comm_invtransactions = new MySqlCommand(query_invtransactions, conn);
            MySqlDataAdapter adp_invtransactions = new MySqlDataAdapter(comm_invtransactions);

            conn.Close();
            DataTable dt_invtransaction = new DataTable();
            adp_invtransactions.Fill(dt_invtransaction);

            dtgvInv.DataSource = dt_invtransaction;
            dtgvInv.Columns["Staff"].HeaderText = "Staff";
            dtgvInv.Columns["product"].HeaderText = "Product";
            dtgvInv.Columns["process_type"].HeaderText = "Type";
            dtgvInv.Columns["quantity"].HeaderText = "Quantity";
            dtgvInv.Columns["date"].HeaderText = "Date";
        }

        public void loadPurchasingTransactions()
        {

            String query_transactions = "SELECT (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = purchase_order.staff_id) as Staff,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM suppliers,person WHERE suppliers.person_id = person.id AND suppliers.id = purchase_order.suppliers_id) as Supplier,total,date FROM purchase_order,staff where purchase_order.staff_id = staff.id AND staff.id = " + staff_id + "";
            conn.Open();
            MySqlCommand comm_transactions = new MySqlCommand(query_transactions, conn);
            MySqlDataAdapter adp_transactions = new MySqlDataAdapter(comm_transactions);

            conn.Close();
            DataTable dt_transaction = new DataTable();
            adp_transactions.Fill(dt_transaction);

            dtgvPurchasing.DataSource = dt_transaction;
            dtgvPurchasing.Columns["Staff"].HeaderText = "Staff";
            dtgvPurchasing.Columns["Supplier"].HeaderText = "Supplier";
            dtgvPurchasing.Columns["total"].HeaderText = "Total";
            dtgvPurchasing.Columns["date"].HeaderText = "Date";
        }




        private void cnumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers", "Incorrect input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            positionCmb.Enabled = true;
            usernameTxt.Enabled = true;
            passwordTxt.Enabled = true;
            statusbox.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            confPass.Enabled = true;
        }
        

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String gen = "";
                string status = "inactive";

                if (maleRadio.Checked == true)
                {
                    gen = "male";
                }
                else if (femaleRadio.Checked == true)
                {
                    gen = "female";
                }

                if (statusbox.Checked == true)
                {
                    status = "active";
                }
                else
                {
                    status = "inactive";
                }
           
                string query_staff = "UPDATE person SET firstname = '" + firstnameTxt.Text + "' , middlename ='" + middlenameTxt.Text + "', lastname = '" + lastnameTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "', address = '" + addressTxt.Text + "' , contact_number = '" + cnumTxt.Text + "', email = '" + emailTxt.Text + "' , date_modified = current_timestamp() where id = '" + person_id + "'";
                string query_person = "UPDATE staff SET (SELECT pos_id FROM position WHERE position_pos_id = '"+ positionCmb.Text +"') , username = '" + usernameTxt.Text + "' , password = '" + passwordTxt.Text + "' , status = '" + status + "' WHERE id = " + staff_id + "";

                conn.Open();
                MySqlCommand comm_person = new MySqlCommand(query_person, conn);
                comm_person.ExecuteNonQuery();

                MySqlCommand comm_staff = new MySqlCommand(query_staff, conn);
                comm_staff.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Success", "Edit success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                firstnameTxt.Enabled = false;
                middlenameTxt.Enabled = false;
                lastnameTxt.Enabled = false;
                maleRadio.Enabled = false;
                femaleRadio.Enabled = false;
                bdayTxt.Enabled = false;
                addressTxt.Enabled = false;
                cnumTxt.Enabled = false;
                emailTxt.Enabled = false;
                positionCmb.Enabled = false;
                usernameTxt.Enabled = false;
                passwordTxt.Enabled = false;
                statusbox.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;
                confPass.Enabled = false;
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
            positionCmb.Enabled = false;
            usernameTxt.Enabled = false;
            passwordTxt.Enabled = false;
            statusbox.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
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

        private void firstnameTxt_TextChanged(object sender, EventArgs e)
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

        private void confPass_Leave(object sender, EventArgs e)
        {
            if (confPass.Text != passwordTxt.Text)
            {
                MessageBox.Show("Passwords Doesn't Match!");
                confPass.Text = "";
                passwordTxt.Text = "";

            }
        }

        private void passCbx_CheckedChanged(object sender, EventArgs e)
        {
            if (passCbx.Checked == true)
            {
                passwordTxt.PasswordChar = '\0';
                confPass.PasswordChar = '\0';
            }
            else
            {
                passwordTxt.PasswordChar = 'ฅ';
                confPass.PasswordChar = 'ฅ';
            }
        }
    }
}
