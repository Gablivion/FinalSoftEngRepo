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
    public partial class View_refund : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;
        public View_refund()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        public static int sorting = 0;
        public void loadrefunds()
        {
            String query_refund = "SELECT (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = sales_refund.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = sales_refund.staff_id) as Staff ,product,quantity,amount,date FROM sales_refund";

            String query_refund_sorted = "SELECT (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = sales_refund.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = sales_refund.staff_id) as Staff ,product,quantity,amount,date FROM sales_refund WHERE date BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";


            String exec_query;
            conn.Open();
            if (sorting == 0)
            {
                exec_query = query_refund;
                sorting = 1;
          
            }
            else
            {
                exec_query = query_refund_sorted;
            }

            MySqlCommand comm = new MySqlCommand(exec_query, conn);
            MySqlDataAdapter adp_sales_order = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt_sales_refund = new DataTable();
            adp_sales_order.Fill(dt_sales_refund);

            dtgvRefund.DataSource = dt_sales_refund;

            dtgvRefund.Columns["Staff"].HeaderText = "Staff";
            dtgvRefund.Columns["Customer"].HeaderText = "Customer";
            dtgvRefund.Columns["Staff"].HeaderText = "Staff";
            dtgvRefund.Columns["product"].HeaderText = "Product";
            dtgvRefund.Columns["quantity"].HeaderText = "Quantity";
            dtgvRefund.Columns["amount"].HeaderText = "Amounts";
            dtgvRefund.Columns["date"].HeaderText = "Date";



        }

        private void View_refund_Load(object sender, EventArgs e)
        {
            loadrefunds();
        }

        private void endDtp_ValueChanged(object sender, EventArgs e)
        {
            loadrefunds();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            sorting = 0;
            loadrefunds();
        }

        private void printBtn_Click(object sender, EventArgs e)
        {
            function_print();
        }
      
        int printedLines = 0;

        public void function_print()
        {
            dtgvRefund.ClearSelection();
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

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            //Header
            string company = "Fabulous Pets Veterinary";
            e.Graphics.DrawString(company, new Font("Arial", 35, FontStyle.Bold), Brushes.Black, 130, 50);

            string viewsales = "Refund Report";
            e.Graphics.DrawString(viewsales, new Font("Arial", 28, FontStyle.Bold), Brushes.Black, 295, 100);
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
            string prod = "PRODUCT";
            e.Graphics.DrawString(prod, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 97, startY);

            offsetY += (int)fontHeight + 10;

            string qty = "QUANTITY";
            e.Graphics.DrawString(qty, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 260, startY);

            string total = "TOTAL";
            e.Graphics.DrawString(total, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 425, startY);

            string date = "DATE";
            e.Graphics.DrawString(date, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 610, startY);


            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);

            while (printedLines < dtgvRefund.Rows.Count)
            {
                //Product
                graphic.DrawString(dtgvRefund.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 100, startY + offsetY + 20);
                //Quantity
                graphic.DrawString(dtgvRefund.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX + 300, startY + offsetY + 20);
                //Total
                graphic.DrawString(dtgvRefund.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX + 425, startY + offsetY + 20);
                //Date
                graphic.DrawString(dtgvRefund.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX + 540, startY + offsetY + 20);


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

        //Makes form draggable
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void View_refund_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void View_refund_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void View_refund_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
    
}
