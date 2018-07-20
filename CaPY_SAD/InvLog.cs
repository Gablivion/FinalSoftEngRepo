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
    public partial class InvLog : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public InvLog()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        private void InvLog_Load(object sender, EventArgs e)
        {
            loadLogData();
          
        }

        public void loadLogData()
        {

            String query_inventorylog = "SELECT id,date,process_type,product,quantity,remarks,(SELECT concat(firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = staff_id) as staff FROM inventory_log ";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(query_inventorylog, conn);
            MySqlDataAdapter adp_inventorylog = new MySqlDataAdapter(comm);
            conn.Close();
            DataTable dt_inventorylog = new DataTable();
            adp_inventorylog.Fill(dt_inventorylog);
          
            dtgvLog.DataSource = dt_inventorylog;
            dtgvLog.Columns["id"].Visible = false;
            dtgvLog.Columns["date"].HeaderText = "Date";
            dtgvLog.Columns["process_type"].HeaderText = "Process";
            dtgvLog.Columns["product"].HeaderText = "Product";
            dtgvLog.Columns["quantity"].HeaderText = "Quantity";
            dtgvLog.Columns["remarks"].HeaderText = "Remarks";
            dtgvLog.Columns["staff"].HeaderText = "Staff";
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void InvLog_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void InvLog_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void InvLog_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void quitBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void sortData()
        {
            if (logCmb.Text != "")
            {
                String run_query;
                String query_inventorylog_sort = "SELECT id,date,process_type,product,quantity,remarks,(SELECT concat(firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = staff_id) as staff FROM inventory_log WHERE date(date) BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "' AND process_type = '" + logCmb.Text + "'";
                String query_inventorylog_all = "SELECT id,date,process_type,product,quantity,remarks,(SELECT concat(firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = staff_id) as staff FROM inventory_log WHERE date(date) BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";

                if (logCmb.Text == "All")
                {
                    run_query = query_inventorylog_all;
                }
                else
                {
                    run_query = query_inventorylog_sort;
                }

                conn.Open();
                MySqlCommand comm_sort = new MySqlCommand(run_query, conn);
                MySqlDataAdapter adp_inventorylog_sort = new MySqlDataAdapter(comm_sort);
                conn.Close();


                DataTable dt_inventorylog_sort = new DataTable();
                adp_inventorylog_sort.Fill(dt_inventorylog_sort);

                dtgvLog.DataSource = dt_inventorylog_sort;
                dtgvLog.Columns["id"].Visible = false;
                dtgvLog.Columns["date"].HeaderText = "Date";
                dtgvLog.Columns["process_type"].HeaderText = "Process";
                dtgvLog.Columns["product"].HeaderText = "Product";
                dtgvLog.Columns["quantity"].HeaderText = "Quantity";
                dtgvLog.Columns["remarks"].HeaderText = "Remarks";
                dtgvLog.Columns["staff"].HeaderText = "Staff";

            }
            else
            {
                MessageBox.Show("Please select log type!", "Select Log Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          

        }

        private void endDtp_ValueChanged(object sender, EventArgs e)
        {
            sortData();
        }

        private void logCmb_TextChanged(object sender, EventArgs e)
        {
            sortData();

        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }

        int printedLines = 0;
        public void function_print()
        {
            dtgvLog.ClearSelection();
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

            string viewinv = "Inventory Log";
            e.Graphics.DrawString(viewinv, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 425, 100);

            e.HasMorePages = false;

            Graphics graphic = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 10);

            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);
            

            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            float fontHeight = font.GetHeight();

            int startY = 190;
            int offsetY = 0;

            int startX = 1;

            //Headers
            string date = "DATE";
            e.Graphics.DrawString(date, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 120, startY);

            offsetY += (int)fontHeight + 10;

            string process = "PROCESS";
            e.Graphics.DrawString(process, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 275, startY);

            string prod = "PRODUCT";
            e.Graphics.DrawString(prod, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 430, startY);

            string qty = "QTY";
            e.Graphics.DrawString(qty, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 535, startY);

            string remarks = "REMARKS";
            e.Graphics.DrawString(remarks, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 680, startY);

            string staff = "STAFF";
            e.Graphics.DrawString(staff, new Font("Arial", 13, FontStyle.Bold), Brushes.Black, startX + 930, startY);


            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 1500, 1);

            while (printedLines < dtgvLog.Rows.Count)
            {
                //Date
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX + 65, startY + offsetY + 20);
                //Process
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 250, startY + offsetY + 20);
                //Product
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX + 440, startY + offsetY + 20);
                //Quantity
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX + 550, startY + offsetY + 20);
                //Remarks
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX + 600, startY + offsetY + 20);
                //Staff
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[6].FormattedValue.ToString(), font, brush, startX + 900, startY + offsetY + 20);

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
