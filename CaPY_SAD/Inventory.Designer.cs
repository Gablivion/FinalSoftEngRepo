namespace CaPY_SAD
{
    partial class Inventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.stockoutBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.logBtn = new System.Windows.Forms.Button();
            this.repackBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainInv = new System.Windows.Forms.TabPage();
            this.dtgvInventory = new System.Windows.Forms.DataGridView();
            this.RepackInv = new System.Windows.Forms.TabPage();
            this.dtgvRepack = new System.Windows.Forms.DataGridView();
            this.repackPanel = new System.Windows.Forms.Panel();
            this.productTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.repackBy = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.repackedQuan = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.itemVol = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.saveRepackBtn = new System.Windows.Forms.Button();
            this.Quan = new System.Windows.Forms.NumericUpDown();
            this.cancelRepackBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.addLabel = new System.Windows.Forms.Label();
            this.reorderBtn = new System.Windows.Forms.Button();
            this.expirableTxt = new System.Windows.Forms.Label();
            this.unitTxt = new System.Windows.Forms.Label();
            this.descTxt = new System.Windows.Forms.Label();
            this.reorderTxt = new System.Windows.Forms.Label();
            this.origpriceTxt = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.MainInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInventory)).BeginInit();
            this.RepackInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRepack)).BeginInit();
            this.repackPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repackBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackedQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(420, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 40);
            this.label1.TabIndex = 74;
            this.label1.Text = "INVENTORY";
            // 
            // stockoutBtn
            // 
            this.stockoutBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(156)))), ((int)(((byte)(120)))));
            this.stockoutBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stockoutBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockoutBtn.ForeColor = System.Drawing.Color.Black;
            this.stockoutBtn.Location = new System.Drawing.Point(732, 76);
            this.stockoutBtn.Name = "stockoutBtn";
            this.stockoutBtn.Size = new System.Drawing.Size(92, 42);
            this.stockoutBtn.TabIndex = 75;
            this.stockoutBtn.Text = "STOCK OUT";
            this.stockoutBtn.UseVisualStyleBackColor = false;
            this.stockoutBtn.Click += new System.EventHandler(this.stockoutBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(929, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 76;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // logBtn
            // 
            this.logBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.logBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logBtn.ForeColor = System.Drawing.Color.Black;
            this.logBtn.Location = new System.Drawing.Point(833, 76);
            this.logBtn.Name = "logBtn";
            this.logBtn.Size = new System.Drawing.Size(126, 42);
            this.logBtn.TabIndex = 77;
            this.logBtn.Text = "INVENTORY LOGS";
            this.logBtn.UseVisualStyleBackColor = false;
            this.logBtn.Click += new System.EventHandler(this.logBtn_Click);
            // 
            // repackBtn
            // 
            this.repackBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(156)))), ((int)(((byte)(120)))));
            this.repackBtn.Enabled = false;
            this.repackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.repackBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repackBtn.ForeColor = System.Drawing.Color.Black;
            this.repackBtn.Location = new System.Drawing.Point(630, 76);
            this.repackBtn.Name = "repackBtn";
            this.repackBtn.Size = new System.Drawing.Size(92, 42);
            this.repackBtn.TabIndex = 78;
            this.repackBtn.Text = "Repack";
            this.repackBtn.UseVisualStyleBackColor = false;
            this.repackBtn.Click += new System.EventHandler(this.repackBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MainInv);
            this.tabControl1.Controls.Add(this.RepackInv);
            this.tabControl1.Location = new System.Drawing.Point(12, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(947, 450);
            this.tabControl1.TabIndex = 79;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MainInv
            // 
            this.MainInv.Controls.Add(this.dtgvInventory);
            this.MainInv.Location = new System.Drawing.Point(4, 22);
            this.MainInv.Name = "MainInv";
            this.MainInv.Padding = new System.Windows.Forms.Padding(3);
            this.MainInv.Size = new System.Drawing.Size(939, 424);
            this.MainInv.TabIndex = 0;
            this.MainInv.Text = "Main Inventory";
            this.MainInv.UseVisualStyleBackColor = true;
            // 
            // dtgvInventory
            // 
            this.dtgvInventory.AllowUserToAddRows = false;
            this.dtgvInventory.AllowUserToDeleteRows = false;
            this.dtgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvInventory.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvInventory.Location = new System.Drawing.Point(3, 0);
            this.dtgvInventory.Name = "dtgvInventory";
            this.dtgvInventory.ReadOnly = true;
            this.dtgvInventory.RowHeadersVisible = false;
            this.dtgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInventory.Size = new System.Drawing.Size(933, 424);
            this.dtgvInventory.TabIndex = 66;
            this.dtgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvInventory_CellClick);
            // 
            // RepackInv
            // 
            this.RepackInv.Controls.Add(this.dtgvRepack);
            this.RepackInv.Location = new System.Drawing.Point(4, 22);
            this.RepackInv.Name = "RepackInv";
            this.RepackInv.Padding = new System.Windows.Forms.Padding(3);
            this.RepackInv.Size = new System.Drawing.Size(939, 424);
            this.RepackInv.TabIndex = 1;
            this.RepackInv.Text = "Repack Inventory";
            this.RepackInv.UseVisualStyleBackColor = true;
            // 
            // dtgvRepack
            // 
            this.dtgvRepack.AllowUserToAddRows = false;
            this.dtgvRepack.AllowUserToDeleteRows = false;
            this.dtgvRepack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvRepack.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvRepack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvRepack.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvRepack.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtgvRepack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvRepack.DefaultCellStyle = dataGridViewCellStyle4;
            this.dtgvRepack.Location = new System.Drawing.Point(3, 0);
            this.dtgvRepack.Name = "dtgvRepack";
            this.dtgvRepack.ReadOnly = true;
            this.dtgvRepack.RowHeadersVisible = false;
            this.dtgvRepack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvRepack.Size = new System.Drawing.Size(933, 424);
            this.dtgvRepack.TabIndex = 67;
            // 
            // repackPanel
            // 
            this.repackPanel.Controls.Add(this.origpriceTxt);
            this.repackPanel.Controls.Add(this.reorderTxt);
            this.repackPanel.Controls.Add(this.descTxt);
            this.repackPanel.Controls.Add(this.unitTxt);
            this.repackPanel.Controls.Add(this.expirableTxt);
            this.repackPanel.Controls.Add(this.productTxt);
            this.repackPanel.Controls.Add(this.label6);
            this.repackPanel.Controls.Add(this.repackBy);
            this.repackPanel.Controls.Add(this.label5);
            this.repackPanel.Controls.Add(this.repackedQuan);
            this.repackPanel.Controls.Add(this.label3);
            this.repackPanel.Controls.Add(this.itemVol);
            this.repackPanel.Controls.Add(this.label2);
            this.repackPanel.Controls.Add(this.saveRepackBtn);
            this.repackPanel.Controls.Add(this.Quan);
            this.repackPanel.Controls.Add(this.cancelRepackBtn);
            this.repackPanel.Controls.Add(this.label4);
            this.repackPanel.Controls.Add(this.addLabel);
            this.repackPanel.Location = new System.Drawing.Point(12, 12);
            this.repackPanel.Name = "repackPanel";
            this.repackPanel.Size = new System.Drawing.Size(947, 540);
            this.repackPanel.TabIndex = 161;
            this.repackPanel.Visible = false;
            // 
            // productTxt
            // 
            this.productTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTxt.Location = new System.Drawing.Point(451, 112);
            this.productTxt.MaxLength = 45;
            this.productTxt.Name = "productTxt";
            this.productTxt.Size = new System.Drawing.Size(179, 27);
            this.productTxt.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(248, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "Product Name";
            // 
            // repackBy
            // 
            this.repackBy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repackBy.Location = new System.Drawing.Point(451, 188);
            this.repackBy.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.repackBy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repackBy.Name = "repackBy";
            this.repackBy.Size = new System.Drawing.Size(178, 27);
            this.repackBy.TabIndex = 15;
            this.repackBy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.repackBy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repackBy.ValueChanged += new System.EventHandler(this.Quan_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(248, 187);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(103, 28);
            this.label5.TabIndex = 14;
            this.label5.Text = "Repack by";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // repackedQuan
            // 
            this.repackedQuan.Enabled = false;
            this.repackedQuan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repackedQuan.Location = new System.Drawing.Point(450, 260);
            this.repackedQuan.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.repackedQuan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repackedQuan.Name = "repackedQuan";
            this.repackedQuan.Size = new System.Drawing.Size(178, 27);
            this.repackedQuan.TabIndex = 13;
            this.repackedQuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.repackedQuan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(248, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Repacked Quantity";
            // 
            // itemVol
            // 
            this.itemVol.Enabled = false;
            this.itemVol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemVol.Location = new System.Drawing.Point(451, 151);
            this.itemVol.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.itemVol.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.itemVol.Name = "itemVol";
            this.itemVol.Size = new System.Drawing.Size(178, 27);
            this.itemVol.TabIndex = 11;
            this.itemVol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.itemVol.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(248, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Item Volume";
            // 
            // saveRepackBtn
            // 
            this.saveRepackBtn.BackColor = System.Drawing.Color.White;
            this.saveRepackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveRepackBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRepackBtn.Location = new System.Drawing.Point(415, 345);
            this.saveRepackBtn.Name = "saveRepackBtn";
            this.saveRepackBtn.Size = new System.Drawing.Size(87, 38);
            this.saveRepackBtn.TabIndex = 9;
            this.saveRepackBtn.Text = "SAVE";
            this.saveRepackBtn.UseVisualStyleBackColor = false;
            this.saveRepackBtn.Click += new System.EventHandler(this.saveRepackBtn_Click);
            // 
            // Quan
            // 
            this.Quan.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quan.Location = new System.Drawing.Point(451, 223);
            this.Quan.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Quan.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quan.Name = "Quan";
            this.Quan.Size = new System.Drawing.Size(178, 27);
            this.Quan.TabIndex = 7;
            this.Quan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Quan.ValueChanged += new System.EventHandler(this.Quan_ValueChanged);
            // 
            // cancelRepackBtn
            // 
            this.cancelRepackBtn.BackColor = System.Drawing.Color.White;
            this.cancelRepackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelRepackBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelRepackBtn.Location = new System.Drawing.Point(508, 345);
            this.cancelRepackBtn.Name = "cancelRepackBtn";
            this.cancelRepackBtn.Size = new System.Drawing.Size(87, 38);
            this.cancelRepackBtn.TabIndex = 6;
            this.cancelRepackBtn.Text = "CANCEL";
            this.cancelRepackBtn.UseVisualStyleBackColor = false;
            this.cancelRepackBtn.Click += new System.EventHandler(this.cancelRepackBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(248, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Quantity";
            // 
            // addLabel
            // 
            this.addLabel.AutoSize = true;
            this.addLabel.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addLabel.ForeColor = System.Drawing.Color.White;
            this.addLabel.Location = new System.Drawing.Point(408, 36);
            this.addLabel.Name = "addLabel";
            this.addLabel.Size = new System.Drawing.Size(236, 40);
            this.addLabel.TabIndex = 0;
            this.addLabel.Text = "REPACK ITEMS";
            // 
            // reorderBtn
            // 
            this.reorderBtn.BackColor = System.Drawing.Color.Red;
            this.reorderBtn.Enabled = false;
            this.reorderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reorderBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderBtn.ForeColor = System.Drawing.Color.Black;
            this.reorderBtn.Location = new System.Drawing.Point(530, 75);
            this.reorderBtn.Name = "reorderBtn";
            this.reorderBtn.Size = new System.Drawing.Size(92, 42);
            this.reorderBtn.TabIndex = 162;
            this.reorderBtn.Text = "ReOrder";
            this.reorderBtn.UseVisualStyleBackColor = false;
            this.reorderBtn.Visible = false;
            // 
            // expirableTxt
            // 
            this.expirableTxt.AutoSize = true;
            this.expirableTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirableTxt.ForeColor = System.Drawing.Color.White;
            this.expirableTxt.Location = new System.Drawing.Point(674, 222);
            this.expirableTxt.Name = "expirableTxt";
            this.expirableTxt.Size = new System.Drawing.Size(96, 28);
            this.expirableTxt.TabIndex = 18;
            this.expirableTxt.Text = "Expirable";
            this.expirableTxt.Visible = false;
            // 
            // unitTxt
            // 
            this.unitTxt.AutoSize = true;
            this.unitTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitTxt.ForeColor = System.Drawing.Color.White;
            this.unitTxt.Location = new System.Drawing.Point(674, 176);
            this.unitTxt.Name = "unitTxt";
            this.unitTxt.Size = new System.Drawing.Size(48, 28);
            this.unitTxt.TabIndex = 19;
            this.unitTxt.Text = "Unit";
            this.unitTxt.Visible = false;
            // 
            // descTxt
            // 
            this.descTxt.AutoSize = true;
            this.descTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTxt.ForeColor = System.Drawing.Color.White;
            this.descTxt.Location = new System.Drawing.Point(674, 130);
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(52, 28);
            this.descTxt.TabIndex = 20;
            this.descTxt.Text = "Desc";
            this.descTxt.Visible = false;
            // 
            // reorderTxt
            // 
            this.reorderTxt.AutoSize = true;
            this.reorderTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderTxt.ForeColor = System.Drawing.Color.White;
            this.reorderTxt.Location = new System.Drawing.Point(674, 271);
            this.reorderTxt.Name = "reorderTxt";
            this.reorderTxt.Size = new System.Drawing.Size(82, 28);
            this.reorderTxt.TabIndex = 23;
            this.reorderTxt.Text = "Reorder";
            this.reorderTxt.Visible = false;
            // 
            // origpriceTxt
            // 
            this.origpriceTxt.AutoSize = true;
            this.origpriceTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origpriceTxt.ForeColor = System.Drawing.Color.White;
            this.origpriceTxt.Location = new System.Drawing.Point(674, 312);
            this.origpriceTxt.Name = "origpriceTxt";
            this.origpriceTxt.Size = new System.Drawing.Size(99, 28);
            this.origpriceTxt.TabIndex = 24;
            this.origpriceTxt.Text = "Orig price";
            this.origpriceTxt.Visible = false;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(971, 564);
            this.ControlBox = false;
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.repackPanel);
            this.Controls.Add(this.reorderBtn);
            this.Controls.Add(this.repackBtn);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.stockoutBtn);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory";
            this.Load += new System.EventHandler(this.Inventory_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Inventory_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Inventory_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Inventory_MouseUp);
            this.tabControl1.ResumeLayout(false);
            this.MainInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInventory)).EndInit();
            this.RepackInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRepack)).EndInit();
            this.repackPanel.ResumeLayout(false);
            this.repackPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repackBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repackedQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Quan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button stockoutBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Button logBtn;
        private System.Windows.Forms.Button repackBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainInv;
        private System.Windows.Forms.DataGridView dtgvInventory;
        private System.Windows.Forms.TabPage RepackInv;
        private System.Windows.Forms.DataGridView dtgvRepack;
        private System.Windows.Forms.Panel repackPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown repackBy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown repackedQuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown itemVol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveRepackBtn;
        private System.Windows.Forms.NumericUpDown Quan;
        private System.Windows.Forms.Button cancelRepackBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label addLabel;
        private System.Windows.Forms.TextBox productTxt;
        private System.Windows.Forms.Button reorderBtn;
        private System.Windows.Forms.Label descTxt;
        private System.Windows.Forms.Label unitTxt;
        private System.Windows.Forms.Label expirableTxt;
        private System.Windows.Forms.Label reorderTxt;
        private System.Windows.Forms.Label origpriceTxt;
    }
}