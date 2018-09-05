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

        private void resetBtn_Click(object sender, EventArgs e)
        {
            sorting = 0;
            loadSalesData();
        }
        private void renderedresetBtn_Click(object sender, EventArgs e)
        {
            selected = 0;
            loadServRendered();
        }

        private void startDtp_ValueChanged(object sender, EventArgs e)
        {
            loadSalesData();
        }

        private void endDtp_ValueChanged(object sender, EventArgs e)
        {
            loadSalesData();
        }


        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();

        }

        private void servBtn_Click(object sender, EventArgs e)
        {
            function_print_services();
        }

      

        //Data Set for Report
        DataSet sales = new DataSet();
        public static int sorting = 0;
        public void loadSalesData()
        {


            String query_sales = "SELECT hospitalization.id as id, (SELECT name from pets where pets.id = pets_id) as pet,(SELECT name from cage where cage.id = cage_id) as Cage, subtotal,date_in, status from hospitalization";

            String query_sales_selected = "SELECT hospitalization.id as id, (SELECT name from pets where pets.id = pets_id) as pet,(SELECT name from cage where cage.id = cage_id) as Cage, subtotal,date_in, status from hospitalization WHERE date_in BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";


            String exec_query;
            conn.Open();
            if (sorting == 0)
            {
                exec_query = query_sales;
                sorting = 1;
            }
            else
            {
                exec_query = query_sales_selected;
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
        
        public void loadServRendered()
        {


            String query_sales = "SELECT id,hospitalization_id,(SELECT name FROM services WHERE services.id = services_id) as Services, (SELECT name FROM pets WHERE pets.id = pets_id) as Pet, service_price FROM service_transaction";
            String query_sales_sorted = "SELECT id,hospitalization_id,(SELECT name FROM services WHERE services.id = services_id) as Services, (SELECT name FROM pets WHERE pets.id = pets_id) as Pet, service_price FROM service_transaction WHERE hospitalization_id =" + selected_serv +"";

            String exec_query;
            conn.Open();
            if (selected == 0)
            {
                exec_query = query_sales;
                
            }
            else 
            {
                exec_query = query_sales_sorted;
            }

            MySqlCommand comm_servren = new MySqlCommand(exec_query, conn);
            MySqlDataAdapter adp_servren = new MySqlDataAdapter(comm_servren);

            conn.Close();
            DataTable dt_servren = new DataTable();
            adp_servren.Fill(dt_servren);

            dtgvServRenLog.DataSource = dt_servren;
            dtgvServRenLog.Columns["id"].Visible = false;
            dtgvServRenLog.Columns["hospitalization_id"].Visible = false;
            dtgvServRenLog.Columns["Services"].HeaderText = "Services";
            dtgvServRenLog.Columns["Pet"].HeaderText = "Pet";
            dtgvServRenLog.Columns["service_price"].HeaderText = "Service Price";

        }



        int printedLines = 0;
        int printedLines2 = 0;
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


        public void function_print_services()
        {
            dtgvServRenLog.ClearSelection();
            printedLines2 = 0;


            printDocument2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 850, 1100);

            PrintPreviewDialog printPreviewDialog2 = new PrintPreviewDialog();
            printPreviewDialog2.Document = printDocument2;
            //printPreviewDialog2.Show();

            if (printDialog2.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }
            else
            {
                printPreviewDialog2.Show();
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Header
            string company = "Fabulous Pets Veterinary";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 130, 50);

            string viewsales = "Services Transancations Report";
            e.Graphics.DrawString(viewsales, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, 310, 100);
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
        

   

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
          
            //Header
            string company = "Fabulous Pets Veterinary";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 130, 50);

            string viewsales = "Services Rendered Report";
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
            e.Graphics.DrawString(cust, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 100, startY);

            offsetY += (int)fontHeight + 10;

            string staff = "SERVICES";
            e.Graphics.DrawString(staff, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 300, startY);

            string total = "SERVICE FEE";
            e.Graphics.DrawString(total, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 600, startY);

          

            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);


            while (printedLines2 < dtgvServRenLog.Rows.Count)
            {

                //PEt
                graphic.DrawString(dtgvServRenLog.Rows[printedLines2].Cells[3].FormattedValue.ToString(), font, brush, startX + 100, startY + offsetY + 20);
                //Services
                graphic.DrawString(dtgvServRenLog.Rows[printedLines2].Cells[2].FormattedValue.ToString(), font, brush, startX + 300, startY + offsetY + 20);
                //fee
                graphic.DrawString(dtgvServRenLog.Rows[printedLines2].Cells[4].FormattedValue.ToString(), font, brush, startX + 600, startY + offsetY + 20);
                

                offsetY += (int)fontHeight + 20;



                ++printedLines2;

                if (offsetY >= 700)
                {
                    e.HasMorePages = true;
                    offsetY = 0;
                    return;
                }
            }

        }








        private void printPreviewDialog2_Load(object sender, EventArgs e)
        {

        }
        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
        public static int selected_serv;
        public static int selected = 0;
        private void dtgvLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                selected_serv = int.Parse(dtgvLog.Rows[e.RowIndex].Cells["id"].Value.ToString());
                selected = 1;
                loadServRendered();
            }
               
        }

        private void View_Service_Reports_Load(object sender, EventArgs e)
        {
            sorting = 0;
            loadSalesData();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }
    }
}
