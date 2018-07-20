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
    public partial class View_customer : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;
        public View_customer()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.ShowDialog();
        }

        public int custid = CaPY_SAD.Customer.selected_data.customer_id;
        public static int person_id;
        private void Edit_customer_Load(object sender, EventArgs e)
        {
            loadTransactions();
            String query = "SELECT * FROM person,customers where customers.person_id = person.id AND customers.id = '" + custid + "'";
            
            MySqlCommand comm = new MySqlCommand(query, conn);
            comm.CommandText = query;
            conn.Open();
            MySqlDataReader drd = comm.ExecuteReader();

           
            while (drd.Read())
            {
                person_id  = int.Parse(drd["person_id"].ToString());
                firstnameTxt.Text = (drd["firstname"].ToString());
                middlenameTxt.Text = (drd["middlename"].ToString());
                lastnameTxt.Text = (drd["lastname"].ToString());

                if ((drd["gender"].ToString()) =="male")
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


            }
            conn.Close();

        }

        public void loadTransactions()
        {

            String query_transactions = "SELECT (SELECT concat (firstname,' ',middlename,' ',lastname) FROM customers,person WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer,  (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff, total, transaction_date from transactions,customers WHERE customers.id = transactions.customers_id AND customers.id = "+ custid + "";

            conn.Open();
            MySqlCommand comm_transactions = new MySqlCommand(query_transactions, conn);
            MySqlDataAdapter adp_transactions = new MySqlDataAdapter(comm_transactions);
            
            conn.Close();
            DataTable dt_inventorylog = new DataTable();
            adp_transactions.Fill(dt_inventorylog);

            dtgvTransactions.DataSource = dt_inventorylog;
            dtgvTransactions.Columns["Customer"].HeaderText = "Customer";
            dtgvTransactions.Columns["Staff"].HeaderText = "Staff";
            dtgvTransactions.Columns["total"].HeaderText = "Total";
            dtgvTransactions.Columns["transaction_date"].HeaderText = "Date";
        }

        private void cnumTxt_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(cnumTxt.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers!", "Incorrect Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cnumTxt.Text = cnumTxt.Text.Remove(cnumTxt.Text.Length - 1);
            }

        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Edit_customer_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Edit_customer_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Edit_customer_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = true;
            lastnameTxt.Enabled = true;
            middlenameTxt.Enabled = true;
            maleRadio.Enabled = true;
            femaleRadio.Enabled = true;
            bdayTxt.Enabled = true;
            addressTxt.Enabled = true;
            cnumTxt.Enabled = true;
            emailTxt.Enabled = true;
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;

            editBtn.Enabled = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (firstnameTxt.Text == "" || middlenameTxt.Text == "" || lastnameTxt.Text == "" || maleRadio.Checked == false && femaleRadio.Checked == false || bdayTxt.Text == "" || addressTxt.Text == "" || cnumTxt.Text == "" || emailTxt.Text == "")
            {
                MessageBox.Show("Please fill up all fields!", "Missing Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                string query = "Update person set firstname = '" + firstnameTxt.Text + "' , middlename ='" + middlenameTxt.Text + "', lastname = '" + lastnameTxt.Text + "', gender = '" + gen + "', birthdate = '" + bdayTxt.Text + "', address = '" + addressTxt.Text + "' , contact_number = '" + cnumTxt.Text + "', email = '" + emailTxt.Text + "', date_modified = current_timestamp() where id = '" + person_id + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Edit success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                firstnameTxt.Enabled = false;
                lastnameTxt.Enabled = false;
                middlenameTxt.Enabled = false;
                maleRadio.Enabled = false;
                femaleRadio.Enabled = false;
                bdayTxt.Enabled = false;
                addressTxt.Enabled = false;
                cnumTxt.Enabled = false;
                emailTxt.Enabled = false;
                saveBtn.Enabled = false;
                cancelBtn.Enabled = false;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = false;
            lastnameTxt.Enabled = false;
            middlenameTxt.Enabled = false;
            maleRadio.Enabled = false;
            femaleRadio.Enabled = false;
            bdayTxt.Enabled = false;
            addressTxt.Enabled = false;
            cnumTxt.Enabled = false;
            emailTxt.Enabled = false;
            saveBtn.Enabled = false;
            cancelBtn.Enabled = false;
        }

        private void emailTxt_Leave(object sender, EventArgs e)
        {
            string email = emailTxt.Text;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (!(System.Text.RegularExpressions.Regex.IsMatch(email, pattern)))
            {
                MessageBox.Show("Invalid e-mail address!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
