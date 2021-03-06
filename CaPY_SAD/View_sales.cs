﻿using System;
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
    public partial class View_sales : Form
    {
        public Form previousform { get; set; }
        MySqlConnection conn;

        public View_sales()
        {
            conn = new MySqlConnection("SERVER=localhost; DATABASE=fabpets; uid = root; pwd = root; Allow Zero Datetime=True ");
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }
        private void View_sales_Load(object sender, EventArgs e)
        {

            loadSalesData();
            
        }
        public static decimal total_sales;
        private void dtgvLog_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
        }
        //Data Set for Report
        DataSet sales = new DataSet();
        public static int sorting = 0;
        public void loadSalesData()
        {
      
            
            String query_sales = "SELECT sales_order.id as id, transactions_id,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff "
           + ",subtotal,transaction_date FROM transactions,staff,customers,sales_order WHERE transactions.customers_id = customers.id AND transactions.staff_id = staff.id AND sales_order.transactions_id = transactions.id";


            String query_sales_sorted = "SELECT sales_order.id as id, transactions_id,(SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,customers WHERE customers.person_id = person.id AND customers.id = transactions.customers_id) as Customer, (SELECT concat (firstname,' ',middlename,' ',lastname) FROM person,staff WHERE staff.person_id = person.id AND staff.id = transactions.staff_id) as Staff "
                + ",subtotal,transaction_date FROM transactions,staff,customers,sales_order WHERE transactions.customers_id = customers.id AND transactions.staff_id = staff.id AND sales_order.transactions_id = transactions.id AND date(transaction_date) BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";

          
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
            dtgvLog.Columns["transactions_id"].Visible = false;
            dtgvLog.Columns["subtotal"].HeaderText = "Subtotal";
            dtgvLog.Columns["Customer"].HeaderText = "Customer";
            dtgvLog.Columns["Staff"].HeaderText = "Staff";
            dtgvLog.Columns["transaction_date"].HeaderText = "Date";

            decimal total = 0;

            for (int i = 0; i <= dtgvLog.Rows.Count - 1; i++)
            {

                string subs = dtgvLog.Rows[i].Cells["subtotal"].Value.ToString();

                decimal decimal_sub = decimal.Parse(subs);

                total = total + decimal_sub;


            }

            sales_tot.Text = total.ToString();
            Expenses();


        }
        public static decimal expense;
        public void Expenses()
        {
            decimal p_expense;
            decimal r_expense;


            String query_p_exp = "SELECT DATE_FORMAT(date, '%Y/%m/%d %H:%i %p') as p_date, sum(total) as p_total FROM purchase_order, staff, person,suppliers WHERE purchase_order.suppliers_id = suppliers.id AND purchase_order.staff_id = staff.id AND staff.person_id = person.id  AND date(date) BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";

            conn.Open();
            MySqlCommand comm_p = new MySqlCommand(query_p_exp, conn);
            MySqlDataAdapter adp_p = new MySqlDataAdapter(comm_p);
            conn.Close();
            DataTable dt_p = new DataTable();
            adp_p.Fill(dt_p);
            if (dt_p.Rows[0]["p_total"].ToString() != "")
            {
                
                p_expense = decimal.Parse(dt_p.Rows[0]["p_total"].ToString());
            }
            else
            {
                p_expense = 0;
            }
            
            String query_r_exp = "SELECT DATE_FORMAT(date, '%Y/%m/%d %H:%i %p') as r_date, sum(amount*quantity) as r_total FROM sales_refund WHERE DATE(date) BETWEEN '" + startDtp.Text + "' AND '" + endDtp.Text + "'";
            conn.Open();
            MySqlCommand comm_r = new MySqlCommand(query_r_exp, conn);
            MySqlDataAdapter adp_r = new MySqlDataAdapter(comm_r);
            conn.Close();
            DataTable dt_r = new DataTable();
            adp_r.Fill(dt_r);

            if (dt_r.Rows[0]["r_total"].ToString() != "")
            {
                r_expense = decimal.Parse(dt_r.Rows[0]["r_total"].ToString());
            }
            else
            {
                r_expense = 0;
            }
   
            expense = r_expense + p_expense;
        }
        private void startDtp_ValueChanged(object sender, EventArgs e)
        {
            if (startDtp.Value < endDtp.Value)
            {
                loadSalesData();
            }
            else
            {
                MessageBox.Show("Invalid Start/End Date");
            }
       
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

            string viewsales = "Sales Report";
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
            string cust = "CUSTOMER";
            e.Graphics.DrawString(cust, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 65, startY);
            
            offsetY += (int)fontHeight + 10;

            string staff = "STAFF";
            e.Graphics.DrawString(staff, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 290, startY);

            string total = "TOTAL";
            e.Graphics.DrawString(total, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 460, startY);

            string date = "DATE";
            e.Graphics.DrawString(date, new Font("Arial", 14, FontStyle.Bold), Brushes.Black, startX + 640, startY);
            

            //Border
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);

            
            while (printedLines < dtgvLog.Rows.Count)
            {
               
                //Customer
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[2].FormattedValue.ToString(), font, brush, startX + 60, startY + offsetY + 20);
                //Staff
                graphic.DrawString(dtgvLog.Rows[printedLines].Cells[3].FormattedValue.ToString(), font, brush, startX  + 240, startY + offsetY + 20);
                //Total
                graphic.DrawString( dtgvLog.Rows[printedLines].Cells[4].FormattedValue.ToString(), font, brush, startX  + 460, startY + offsetY + 20);
                //Date
                graphic.DrawString( dtgvLog.Rows[printedLines].Cells[5].FormattedValue.ToString(), font, brush, startX  + 570, startY + offsetY + 20);
               
                offsetY += (int)fontHeight + 20;
               

                ++printedLines;
               
                if (offsetY >= 700)
                {
                    
                    e.HasMorePages = true;
                    offsetY = 0;
                    return;
                }
                
            }

            offsetY += (int)fontHeight + 50;
            e.Graphics.DrawRectangle(Pens.Black, startX, startY + offsetY, 840, 1);
            offsetY += (int)fontHeight + 30;

            string sale = "Total Sales: ";
            e.Graphics.DrawString(sale, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 300, startY + offsetY);
            
            string sales_total = "Php " + sales_tot.Text;
            e.Graphics.DrawString(sales_total, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 570, startY + offsetY);

            offsetY += (int)fontHeight + 30;
            string exp = "Total Expense: ";
            e.Graphics.DrawString(exp, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 300, startY + offsetY);

            string expensess = "Php " + expense.ToString();
            e.Graphics.DrawString(expensess, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 570, startY + offsetY);

            decimal profit = decimal.Parse(sales_tot.Text) - expense;

            offsetY += (int)fontHeight + 30;
            string prof = "Total Profit: ";
            e.Graphics.DrawString(prof, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 300, startY + offsetY);

            string stringprofit = "Php " + profit.ToString();
            e.Graphics.DrawString(stringprofit, new Font("Arial", 20, FontStyle.Bold), Brushes.Black, startX + 570, startY + offsetY);

        }
        

        private void resetBtn_Click(object sender, EventArgs e)
        {
            sorting = 0;
            loadSalesData();
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

    }
}
