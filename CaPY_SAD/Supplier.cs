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
    public partial class Supplier : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Supplier()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            loadSupplierData();
            addBtn.Enabled = true;
            editBtn.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_supplier add = new Add_supplier();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_supplier edit = new Edit_supplier();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }


        public void loadSupplierData()
        {
            String query = "SELECT * FROM person,suppliers WHERE suppliers.person_id = person.id AND archived = 'no'  AND concat(firstname, ' ', middlename, ' ', lastname) LIKE '%" + nameTxt.Text + "%'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvSuppliers.DataSource = dt;
            dtgvSuppliers.Columns["id"].Visible = false;
            dtgvSuppliers.Columns["id1"].Visible = false;
            dtgvSuppliers.Columns["archived"].Visible = false;
            dtgvSuppliers.Columns["person_id"].Visible = false;
            dtgvSuppliers.Columns["firstname"].HeaderText = "Firstname";
            dtgvSuppliers.Columns["middlename"].HeaderText = "Middlename";
            dtgvSuppliers.Columns["lastname"].HeaderText = "Lastname";
            dtgvSuppliers.Columns["gender"].HeaderText = "Gender";
            dtgvSuppliers.Columns["birthdate"].HeaderText = "Birthdate";
            dtgvSuppliers.Columns["address"].HeaderText = "Address";
            dtgvSuppliers.Columns["contact_number"].HeaderText = "Contact Number";
            dtgvSuppliers.Columns["email"].HeaderText = "Email";
            dtgvSuppliers.Columns["organization_name"].HeaderText = "Organization";
            dtgvSuppliers.Columns["date_added"].HeaderText = "Date Added";
            dtgvSuppliers.Columns["date_modified"].HeaderText = "Date Modified";


        }



        public class selected_data
        {
            public static int supplier_id;
        }

        private void dtgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            archiveBtn.Enabled = true;


            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvSuppliers.Rows[e.RowIndex].Cells["id1"].Value.ToString());
                selected_data.supplier_id = selected_id;
            }
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Supplier_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Supplier_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Supplier_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Supplier_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            editBtn.Enabled = false;
            archiveBtn.Enabled = false;
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {

            DialogResult archive;

            archive = MessageBox.Show("Do really you want to add this record to archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "Update suppliers SET archived = 'yes' where id = '" + selected_data.supplier_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadSupplierData();

            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            loadSupplierData();
        }
    }
}
