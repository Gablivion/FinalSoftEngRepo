﻿namespace CaPY_SAD
{
    partial class Purchasing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Purchasing));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.dtgvPurchaseOrders = new System.Windows.Forms.DataGridView();
            this.dtgvPurchaseOrderLines = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.totalTxt = new System.Windows.Forms.TextBox();
            this.dtgvInv = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.stockInBtn = new System.Windows.Forms.Button();
            this.toInventoryBtn = new System.Windows.Forms.Button();
            this.backOrderlineBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endDtp = new System.Windows.Forms.DateTimePicker();
            this.startDtp = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expirationDtp = new System.Windows.Forms.DateTimePicker();
            this.expirationLabel = new System.Windows.Forms.Label();
            this.printBtn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPurchaseOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPurchaseOrderLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(361, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 40);
            this.label1.TabIndex = 78;
            this.label1.Text = "DELIVERED PRODUCTS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(1024, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 77;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // dtgvPurchaseOrders
            // 
            this.dtgvPurchaseOrders.AccessibleName = "";
            this.dtgvPurchaseOrders.AllowUserToAddRows = false;
            this.dtgvPurchaseOrders.AllowUserToDeleteRows = false;
            this.dtgvPurchaseOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPurchaseOrders.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvPurchaseOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvPurchaseOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPurchaseOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPurchaseOrders.DefaultCellStyle = dataGridViewCellStyle8;
            this.dtgvPurchaseOrders.Location = new System.Drawing.Point(51, 168);
            this.dtgvPurchaseOrders.Name = "dtgvPurchaseOrders";
            this.dtgvPurchaseOrders.ReadOnly = true;
            this.dtgvPurchaseOrders.RowHeadersVisible = false;
            this.dtgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPurchaseOrders.Size = new System.Drawing.Size(965, 258);
            this.dtgvPurchaseOrders.TabIndex = 76;
            this.dtgvPurchaseOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPurchaseOrders_CellClick);
            this.dtgvPurchaseOrders.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgvPurchaseOrders_RowStateChanged);
            // 
            // dtgvPurchaseOrderLines
            // 
            this.dtgvPurchaseOrderLines.AllowUserToAddRows = false;
            this.dtgvPurchaseOrderLines.AllowUserToDeleteRows = false;
            this.dtgvPurchaseOrderLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPurchaseOrderLines.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvPurchaseOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvPurchaseOrderLines.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPurchaseOrderLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgvPurchaseOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPurchaseOrderLines.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgvPurchaseOrderLines.Location = new System.Drawing.Point(51, 484);
            this.dtgvPurchaseOrderLines.MultiSelect = false;
            this.dtgvPurchaseOrderLines.Name = "dtgvPurchaseOrderLines";
            this.dtgvPurchaseOrderLines.ReadOnly = true;
            this.dtgvPurchaseOrderLines.RowHeadersVisible = false;
            this.dtgvPurchaseOrderLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPurchaseOrderLines.Size = new System.Drawing.Size(421, 247);
            this.dtgvPurchaseOrderLines.TabIndex = 81;
            this.dtgvPurchaseOrderLines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPurchaseOrderLines_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(135, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 40);
            this.label2.TabIndex = 84;
            this.label2.Text = "ORDER DETAILS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.Black;
            this.addBtn.Location = new System.Drawing.Point(126, 78);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(102, 27);
            this.addBtn.TabIndex = 85;
            this.addBtn.Text = "VIEW POs";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(692, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 28);
            this.label3.TabIndex = 86;
            this.label3.Text = "Total Expenses";
            // 
            // totalTxt
            // 
            this.totalTxt.Enabled = false;
            this.totalTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTxt.Location = new System.Drawing.Point(840, 78);
            this.totalTxt.Name = "totalTxt";
            this.totalTxt.Size = new System.Drawing.Size(176, 26);
            this.totalTxt.TabIndex = 87;
            this.totalTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtgvInv
            // 
            this.dtgvInv.AllowUserToAddRows = false;
            this.dtgvInv.AllowUserToDeleteRows = false;
            this.dtgvInv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvInv.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvInv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvInv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dtgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvInv.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtgvInv.Location = new System.Drawing.Point(595, 484);
            this.dtgvInv.Name = "dtgvInv";
            this.dtgvInv.ReadOnly = true;
            this.dtgvInv.RowHeadersVisible = false;
            this.dtgvInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInv.Size = new System.Drawing.Size(421, 247);
            this.dtgvInv.TabIndex = 88;
            this.dtgvInv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvInv_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(681, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 40);
            this.label4.TabIndex = 84;
            this.label4.Text = "TO INVENTORY";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stockInBtn
            // 
            this.stockInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.stockInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stockInBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInBtn.ForeColor = System.Drawing.Color.Black;
            this.stockInBtn.Location = new System.Drawing.Point(924, 733);
            this.stockInBtn.Name = "stockInBtn";
            this.stockInBtn.Size = new System.Drawing.Size(92, 28);
            this.stockInBtn.TabIndex = 89;
            this.stockInBtn.Text = "STOCK IN";
            this.stockInBtn.UseVisualStyleBackColor = false;
            this.stockInBtn.Click += new System.EventHandler(this.stockInBtn_Click);
            // 
            // toInventoryBtn
            // 
            this.toInventoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.toInventoryBtn.Enabled = false;
            this.toInventoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.toInventoryBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toInventoryBtn.ForeColor = System.Drawing.Color.Black;
            this.toInventoryBtn.Image = ((System.Drawing.Image)(resources.GetObject("toInventoryBtn.Image")));
            this.toInventoryBtn.Location = new System.Drawing.Point(506, 561);
            this.toInventoryBtn.Name = "toInventoryBtn";
            this.toInventoryBtn.Size = new System.Drawing.Size(54, 28);
            this.toInventoryBtn.TabIndex = 91;
            this.toInventoryBtn.UseVisualStyleBackColor = false;
            this.toInventoryBtn.Click += new System.EventHandler(this.toInventoryBtn_Click);
            // 
            // backOrderlineBtn
            // 
            this.backOrderlineBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.backOrderlineBtn.Enabled = false;
            this.backOrderlineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backOrderlineBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backOrderlineBtn.ForeColor = System.Drawing.Color.Black;
            this.backOrderlineBtn.Image = ((System.Drawing.Image)(resources.GetObject("backOrderlineBtn.Image")));
            this.backOrderlineBtn.Location = new System.Drawing.Point(506, 610);
            this.backOrderlineBtn.Name = "backOrderlineBtn";
            this.backOrderlineBtn.Size = new System.Drawing.Size(54, 28);
            this.backOrderlineBtn.TabIndex = 92;
            this.backOrderlineBtn.UseVisualStyleBackColor = false;
            this.backOrderlineBtn.Click += new System.EventHandler(this.backOrderlineBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(516, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 22);
            this.label5.TabIndex = 100;
            this.label5.Text = "End";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(179, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 22);
            this.label6.TabIndex = 99;
            this.label6.Text = "Start";
            // 
            // endDtp
            // 
            this.endDtp.CustomFormat = "yyyy-MM-dd";
            this.endDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDtp.Location = new System.Drawing.Point(572, 12);
            this.endDtp.Name = "endDtp";
            this.endDtp.Size = new System.Drawing.Size(214, 26);
            this.endDtp.TabIndex = 98;
            this.endDtp.ValueChanged += new System.EventHandler(this.startDtp_ValueChanged);
            // 
            // startDtp
            // 
            this.startDtp.CustomFormat = "yyyy-MM-dd";
            this.startDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDtp.Location = new System.Drawing.Point(235, 12);
            this.startDtp.Name = "startDtp";
            this.startDtp.Size = new System.Drawing.Size(214, 26);
            this.startDtp.TabIndex = 97;
            this.startDtp.ValueChanged += new System.EventHandler(this.startDtp_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(96)))), ((int)(((byte)(113)))));
            this.panel1.Controls.Add(this.startDtp);
            this.panel1.Controls.Add(this.endDtp);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(51, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 53);
            this.panel1.TabIndex = 101;
            // 
            // expirationDtp
            // 
            this.expirationDtp.CustomFormat = "yyyy-MM-dd";
            this.expirationDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirationDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expirationDtp.Location = new System.Drawing.Point(213, 744);
            this.expirationDtp.Name = "expirationDtp";
            this.expirationDtp.Size = new System.Drawing.Size(214, 26);
            this.expirationDtp.TabIndex = 157;
            // 
            // expirationLabel
            // 
            this.expirationLabel.AutoSize = true;
            this.expirationLabel.BackColor = System.Drawing.Color.Transparent;
            this.expirationLabel.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirationLabel.ForeColor = System.Drawing.Color.White;
            this.expirationLabel.Location = new System.Drawing.Point(46, 743);
            this.expirationLabel.Name = "expirationLabel";
            this.expirationLabel.Size = new System.Drawing.Size(146, 28);
            this.expirationLabel.TabIndex = 158;
            this.expirationLabel.Text = "Expiration Date";
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.Color.White;
            this.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(51, 78);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(69, 27);
            this.printBtn.TabIndex = 159;
            this.printBtn.Text = "PRINT";
            this.printBtn.UseVisualStyleBackColor = false;
            this.printBtn.Click += new System.EventHandler(this.printBtn_Click);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // Purchasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1066, 811);
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.expirationDtp);
            this.Controls.Add(this.expirationLabel);
            this.Controls.Add(this.backOrderlineBtn);
            this.Controls.Add(this.toInventoryBtn);
            this.Controls.Add(this.stockInBtn);
            this.Controls.Add(this.dtgvInv);
            this.Controls.Add(this.totalTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtgvPurchaseOrderLines);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.dtgvPurchaseOrders);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Purchasing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchasing";
            this.Load += new System.EventHandler(this.Purchasing_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Purchasing_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Purchasing_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Purchasing_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPurchaseOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPurchaseOrderLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.DataGridView dtgvPurchaseOrders;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvPurchaseOrderLines;
        protected System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox totalTxt;
        private System.Windows.Forms.DataGridView dtgvInv;
        protected System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stockInBtn;
        private System.Windows.Forms.Button toInventoryBtn;
        private System.Windows.Forms.Button backOrderlineBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDtp;
        private System.Windows.Forms.DateTimePicker startDtp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker expirationDtp;
        private System.Windows.Forms.Label expirationLabel;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}