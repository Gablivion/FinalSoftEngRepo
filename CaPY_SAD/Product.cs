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
    public partial class Product : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        public Product()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            loadProductData();
            addBtn.Enabled = true;
            editBtn.Enabled = false;
            archiveBtn.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_product add = new Add_product();
            add.Show();
            CaPY_SAD.Add_product.form = 1;
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_product edit = new Edit_product();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }

        public class selected_data
        {
            public static int product_id;
        }

        private void dtgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            archiveBtn.Enabled = true;


            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvProducts.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.product_id = selected_id;
            }
        }


        public void loadProductData()
        {

            String query = "SELECT * FROM products WHERE archived = 'no' AND name LIKE '%" + nameTxt.Text + "%'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvProducts.DataSource = dt;
            dtgvProducts.Columns["id"].Visible = false;
            dtgvProducts.Columns["medicine"].Visible = false;
            dtgvProducts.Columns["name"].HeaderText = "Name";
            dtgvProducts.Columns["description"].HeaderText = "Description";
            dtgvProducts.Columns["price"].HeaderText = "Price";
            dtgvProducts.Columns["expirable"].HeaderText = "Expirable";
            dtgvProducts.Columns["reorder"].HeaderText = "Reorder Point";
            dtgvProducts.Columns["date_added"].HeaderText = "Date Added";
            dtgvProducts.Columns["date_modified"].HeaderText = "Date Modified";
            dtgvProducts.Columns["archived"].Visible = false;
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Product_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Product_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Product_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void Product_Click(object sender, EventArgs e)
        {
            addBtn.Enabled = true;
            editBtn.Enabled = false;
            archiveBtn.Enabled = false;
        }

        private void archiveBtn_Click(object sender, EventArgs e)
        {
            DialogResult archive;

            archive = MessageBox.Show("Do really you want to add this record to Archive?", "Archive Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (archive == DialogResult.Yes)
            {

                string query_acrhive = "Update products SET archived = 'yes', date_modified = current_timestamp() where id = '" + selected_data.product_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadProductData();

            }
           


        }


        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            loadProductData();
        }
    }
}
