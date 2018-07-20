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

    public partial class Customer : Form
    {
        public Form previousform { get; set; }

        MySqlConnection conn;

        public Customer()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
           
            InitializeComponent();
          
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            loadCustomerData();
            addBtn.Enabled = true;
            viewBtn.Enabled = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_customer add = new Add_customer();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            View_customer edit = new View_customer();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }

        public void loadCustomerData()
        {

            String query = "SELECT * FROM customers, person WHERE customers.person_id = person.id AND archived = 'no' AND concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + nameTxt.Text + "%'";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);          
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvCustomer.DataSource = dt;
            dtgvCustomer.Columns["id"].Visible = false;
            dtgvCustomer.Columns["id1"].Visible = false;
            dtgvCustomer.Columns["person_id"].Visible = false;
            dtgvCustomer.Columns["firstname"].HeaderText = "Firstname";
            dtgvCustomer.Columns["middlename"].HeaderText = "Middlename";
            dtgvCustomer.Columns["lastname"].HeaderText = "Lastname";
            dtgvCustomer.Columns["gender"].HeaderText = "Gender";
            dtgvCustomer.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvCustomer.Columns["address"].HeaderText = "Address";
            dtgvCustomer.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvCustomer.Columns["email"].HeaderText = "Email";
            dtgvCustomer.Columns["date_added"].HeaderText = "Date Added";
            dtgvCustomer.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvCustomer.Columns["archived"].Visible = false;

        }

        public class selected_data
        {
            public static int customer_id;
        }

        private void dtgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            viewBtn.Enabled = true;
            archiveBtn.Enabled = true;


            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvCustomer.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.customer_id = selected_id;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Customer_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Customer_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Customer_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Customer_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            viewBtn.Enabled = false;
            archiveBtn.Enabled = false;

        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {

            DialogResult archive;

            archive = MessageBox.Show("Do you want to add this record to Archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "Update customers SET archived = 'yes' where id = '" + selected_data.customer_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadCustomerData();

            }
        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {   
            loadCustomerData();
        }
    }
}
