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
    public partial class Services : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public Services()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root");
            InitializeComponent();
        }
        private void Services_Load(object sender, EventArgs e)
        {
            loadServiceData();
            addBtn.Enabled = true;
            editBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Add_service add = new Add_service();
            add.Show();
            add.previousform = this;
            this.Hide();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            Edit_service edit = new Edit_service();
            edit.Show();
            edit.previousform = this;
            this.Hide();
        }

        public class selected_data
        {
            public static int service_id;
        }
        private void dtgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            addBtn.Enabled = false;
            editBtn.Enabled = true;
            archiveBtn.Enabled = true;

            if (e.RowIndex > -1)
            {
                int selected_id = int.Parse(dtgvService.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected_data.service_id = selected_id;
            }
        }

        public void loadServiceData()
        {

            String query = "SELECT * FROM services WHERE archived = 'no'AND name LIKE '%" + nameTxt.Text + "%'";


            conn.Open();
            MySqlCommand comm = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dtgvService.DataSource = dt;
            dtgvService.Columns["id"].Visible = false;
            dtgvService.Columns["archived"].Visible = false;
            dtgvService.Columns["name"].HeaderText = "Name";
            dtgvService.Columns["description"].HeaderText = "Description";
            dtgvService.Columns["price"].HeaderText = "Price";
            dtgvService.Columns["status"].HeaderText = "Availability";
            dtgvService.Columns["date_added"].HeaderText = "Date Added";
            dtgvService.Columns["date_modified"].HeaderText = "Date Modified";


        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Services_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Services_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Services_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void dtgvService_ColumnStateChanged(object sender, DataGridViewColumnStateChangedEventArgs e)
        {

        }

        private void dtgvService_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            foreach (DataGridViewRow row in this.dtgvService.Rows)
            {
                if (row.Cells["status"].Value.ToString() == "available")
                {
                    row.DefaultCellStyle.BackColor = Color.LawnGreen;

                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void Services_Click(object sender, EventArgs e)
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

                string query_acrhive = "Update services SET archived = 'yes' where id = '" + selected_data.service_id + "'";

                conn.Open();
                MySqlCommand comm_archive = new MySqlCommand(query_acrhive, conn);
                comm_archive.ExecuteNonQuery();
                conn.Close();
                loadServiceData();

            }

        }

        private void nameTxt_TextChanged(object sender, EventArgs e)
        {
            loadServiceData();
        }
    }
}
