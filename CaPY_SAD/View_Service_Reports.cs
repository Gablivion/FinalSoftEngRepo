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
    public partial class View_Service_Reports : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public View_Service_Reports()
        {

            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();

        }

        //Data Set for Report
        DataSet sales = new DataSet();
        public static int sorting = 0;
        public void loadSalesData()
        {


            String query_sales = "SELECT hospitalization.id as id, (SELECT name from pets where pets.id = pets_id) as pet,(SELECT name from cage where cage.id = cage_id) as Cage, subtotal,date_in, status from hospitalization";

            String query_sales_sorted = "SELECT hospitalization.id as id, (SELECT name from pets where pets.id = pets_id) as pet,(SELECT name from cage where cage.id = cage_id) as Cage, subtotal,date_in, status from hospitalization WHERE date_in BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";


            String exec_query;
            conn.Open();
            if (sorting == 0)
            {
                exec_query = query_sales;
                sorting = 1;
            }
            else
            {
                exec_query = query_sales_sorted;
            }

            MySqlCommand comm = new MySqlCommand(exec_query, conn);
            MySqlDataAdapter adp_sales_order = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt_sales_order = new DataTable();
            adp_sales_order.Fill(dt_sales_order);

            dtgvLog.DataSource = dt_sales_order;
            dtgvLog.Columns["id"].Visible = false;
            dtgvLog.Columns["pet"].HeaderText = "Pet";
            dtgvLog.Columns["cage"].HeaderText = "Customer";
            dtgvLog.Columns["subtotal"].HeaderText = "Subtotal";
            dtgvLog.Columns["date_in"].HeaderText = "Date Admitted";
            dtgvLog.Columns["status"].HeaderText = "Status";

        }


        int printedLines = 0;

        public void function_print()
        {
            dtgvLog.ClearSelection();
            printedLines = 0;


            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 850, 1100);

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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Header
            string company = "Fabulous Pets Veterinary";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 130, 50);

            string viewsales = "Services Report";
            e.Graphics.DrawString(viewsales, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 310, 100);
            //Header

            e.HasMorePages = false;

            Graphics graphic = e.Graphics;
            SolidBrush brush = new SolidBrush(Color.Black);

            Font font = new Font("Arial", 13);

            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);

            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;


            float fontHeight = font.GetHeight();

            int startY = 220;
            int offsetY = 0;


            int startX = 1;

            //Headers
            string cust = "PET";
            e.Graphics.DrawString(cust, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 65, startY);

            offsetY += (int)fontHeight + 10;

            string staff = "CAGE";
            e.Graphics.DrawString(staff, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 200, startY);

            string total = "SUBTOTAL";
            e.Graphics.DrawString(total, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 350, startY);

            string date = "ADMISSION DATE";
            e.Graphics.DrawString(date, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 500, startY);

            string stat = "STATUS";
            e.Graphics.DrawString(stat, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 730, startY);


            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);


            while (printedLines < dtgvLog.Rows.Count)
            {

                //Customer
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[1].FormattedValue.ToString(), font, brush, startX + 65, startY + offsetY + 20);
                //Staff
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 200, startY + offsetY + 20);
                //Total
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX + 350, startY + offsetY + 20);
                //Date
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX + 500, startY + offsetY + 20);

                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX + 730, startY + offsetY + 20);

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

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }


        //Makes form draggable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void View_sales_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void View_sales_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void View_sales_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void startDtp_ValueChanged(object sender, EventArgs e)
        {
            loadSalesData();
        }

        private void endDtp_ValueChanged(object sender, EventArgs e)
        {
            loadSalesData();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            sorting = 0;
            loadSalesData();
        }
    }
}
