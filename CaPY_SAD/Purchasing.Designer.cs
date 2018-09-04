namespace CaPY_SAD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label1.Location = new System.Drawing.Point(331, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 40);
            this.label1.TabIndex = 78;
            this.label1.Text = "Delivered Products";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(891, 0);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPurchaseOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvPurchaseOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPurchaseOrders.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvPurchaseOrders.Location = new System.Drawing.Point(38, 147);
            this.dtgvPurchaseOrders.Name = "dtgvPurchaseOrders";
            this.dtgvPurchaseOrders.ReadOnly = true;
            this.dtgvPurchaseOrders.RowHeadersVisible = false;
            this.dtgvPurchaseOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPurchaseOrders.Size = new System.Drawing.Size(856, 258);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPurchaseOrderLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvPurchaseOrderLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPurchaseOrderLines.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvPurchaseOrderLines.Location = new System.Drawing.Point(26, 495);
            this.dtgvPurchaseOrderLines.MultiSelect = false;
            this.dtgvPurchaseOrderLines.Name = "dtgvPurchaseOrderLines";
            this.dtgvPurchaseOrderLines.ReadOnly = true;
            this.dtgvPurchaseOrderLines.RowHeadersVisible = false;
            this.dtgvPurchaseOrderLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPurchaseOrderLines.Size = new System.Drawing.Size(379, 227);
            this.dtgvPurchaseOrderLines.TabIndex = 81;
            this.dtgvPurchaseOrderLines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPurchaseOrderLines_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(95, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 40);
            this.label2.TabIndex = 84;
            this.label2.Text = "Order Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.Black;
            this.addBtn.Location = new System.Drawing.Point(38, 48);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(215, 34);
            this.addBtn.TabIndex = 85;
            this.addBtn.Text = "View Purchase Orders";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(570, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 28);
            this.label3.TabIndex = 86;
            this.label3.Text = "Total Expenses";
            // 
            // totalTxt
            // 
            this.totalTxt.Enabled = false;
            this.totalTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTxt.Location = new System.Drawing.Point(718, 415);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvInv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvInv.Location = new System.Drawing.Point(528, 495);
            this.dtgvInv.Name = "dtgvInv";
            this.dtgvInv.ReadOnly = true;
            this.dtgvInv.RowHeadersVisible = false;
            this.dtgvInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInv.Size = new System.Drawing.Size(379, 227);
            this.dtgvInv.TabIndex = 88;
            this.dtgvInv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvInv_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(619, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 40);
            this.label4.TabIndex = 84;
            this.label4.Text = "To Inventory";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // stockInBtn
            // 
            this.stockInBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.stockInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stockInBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInBtn.ForeColor = System.Drawing.Color.Black;
            this.stockInBtn.Location = new System.Drawing.Point(814, 724);
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
            this.toInventoryBtn.Location = new System.Drawing.Point(443, 579);
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
            this.backOrderlineBtn.Location = new System.Drawing.Point(443, 628);
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
            this.label5.Location = new System.Drawing.Point(462, 14);
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
            this.label6.Location = new System.Drawing.Point(125, 14);
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
            this.endDtp.Location = new System.Drawing.Point(518, 12);
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
            this.startDtp.Location = new System.Drawing.Point(181, 12);
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
            this.panel1.Location = new System.Drawing.Point(38, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(856, 53);
            this.panel1.TabIndex = 101;
            // 
            // expirationDtp
            // 
            this.expirationDtp.CustomFormat = "yyyy-MM-dd";
            this.expirationDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirationDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.expirationDtp.Location = new System.Drawing.Point(191, 744);
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
            this.expirationLabel.Location = new System.Drawing.Point(21, 741);
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
            this.printBtn.Location = new System.Drawing.Point(806, 55);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(88, 27);
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
            this.ClientSize = new System.Drawing.Size(933, 785);
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