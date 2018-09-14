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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.stockoutBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.logBtn = new System.Windows.Forms.Button();
            this.repackBtn = new System.Windows.Forms.Button();
            this.dtgvInventory = new System.Windows.Forms.DataGridView();
            this.repackPanel = new System.Windows.Forms.Panel();
            this.origpriceTxt = new System.Windows.Forms.Label();
            this.reorderTxt = new System.Windows.Forms.Label();
            this.descTxt = new System.Windows.Forms.Label();
            this.unitTxt = new System.Windows.Forms.Label();
            this.expirableTxt = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInventory)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(471, 32);
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
            this.stockoutBtn.Location = new System.Drawing.Point(873, 103);
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
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(1096, 0);
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
            this.logBtn.Location = new System.Drawing.Point(974, 103);
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
            this.repackBtn.Location = new System.Drawing.Point(771, 103);
            this.repackBtn.Name = "repackBtn";
            this.repackBtn.Size = new System.Drawing.Size(92, 42);
            this.repackBtn.TabIndex = 78;
            this.repackBtn.Text = "REPACK";
            this.repackBtn.UseVisualStyleBackColor = false;
            this.repackBtn.Click += new System.EventHandler(this.repackBtn_Click);
            // 
            // dtgvInventory
            // 
            this.dtgvInventory.AllowUserToAddRows = false;
            this.dtgvInventory.AllowUserToDeleteRows = false;
            this.dtgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvInventory.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvInventory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dtgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvInventory.DefaultCellStyle = dataGridViewCellStyle6;
            this.dtgvInventory.Location = new System.Drawing.Point(39, 151);
            this.dtgvInventory.Name = "dtgvInventory";
            this.dtgvInventory.ReadOnly = true;
            this.dtgvInventory.RowHeadersVisible = false;
            this.dtgvInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvInventory.Size = new System.Drawing.Size(1061, 502);
            this.dtgvInventory.TabIndex = 66;
            this.dtgvInventory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvInventory_CellClick);
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
            this.repackPanel.Location = new System.Drawing.Point(171, 50);
            this.repackPanel.Name = "repackPanel";
            this.repackPanel.Size = new System.Drawing.Size(64, 40);
            this.repackPanel.TabIndex = 161;
            this.repackPanel.Visible = false;
            // 
            // origpriceTxt
            // 
            this.origpriceTxt.AutoSize = true;
            this.origpriceTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.origpriceTxt.ForeColor = System.Drawing.Color.White;
            this.origpriceTxt.Location = new System.Drawing.Point(889, 432);
            this.origpriceTxt.Name = "origpriceTxt";
            this.origpriceTxt.Size = new System.Drawing.Size(99, 28);
            this.origpriceTxt.TabIndex = 24;
            this.origpriceTxt.Text = "Orig price";
            this.origpriceTxt.Visible = false;
            // 
            // reorderTxt
            // 
            this.reorderTxt.AutoSize = true;
            this.reorderTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reorderTxt.ForeColor = System.Drawing.Color.White;
            this.reorderTxt.Location = new System.Drawing.Point(889, 404);
            this.reorderTxt.Name = "reorderTxt";
            this.reorderTxt.Size = new System.Drawing.Size(82, 28);
            this.reorderTxt.TabIndex = 23;
            this.reorderTxt.Text = "Reorder";
            this.reorderTxt.Visible = false;
            // 
            // descTxt
            // 
            this.descTxt.AutoSize = true;
            this.descTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTxt.ForeColor = System.Drawing.Color.White;
            this.descTxt.Location = new System.Drawing.Point(889, 304);
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(52, 28);
            this.descTxt.TabIndex = 20;
            this.descTxt.Text = "Desc";
            this.descTxt.Visible = false;
            // 
            // unitTxt
            // 
            this.unitTxt.AutoSize = true;
            this.unitTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unitTxt.ForeColor = System.Drawing.Color.White;
            this.unitTxt.Location = new System.Drawing.Point(889, 339);
            this.unitTxt.Name = "unitTxt";
            this.unitTxt.Size = new System.Drawing.Size(48, 28);
            this.unitTxt.TabIndex = 19;
            this.unitTxt.Text = "Unit";
            this.unitTxt.Visible = false;
            // 
            // expirableTxt
            // 
            this.expirableTxt.AutoSize = true;
            this.expirableTxt.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expirableTxt.ForeColor = System.Drawing.Color.White;
            this.expirableTxt.Location = new System.Drawing.Point(889, 367);
            this.expirableTxt.Name = "expirableTxt";
            this.expirableTxt.Size = new System.Drawing.Size(96, 28);
            this.expirableTxt.TabIndex = 18;
            this.expirableTxt.Text = "Expirable";
            this.expirableTxt.Visible = false;
            // 
            // productTxt
            // 
            this.productTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTxt.Location = new System.Drawing.Point(565, 207);
            this.productTxt.MaxLength = 45;
            this.productTxt.Name = "productTxt";
            this.productTxt.Size = new System.Drawing.Size(222, 27);
            this.productTxt.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed Extra Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(351, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 28);
            this.label6.TabIndex = 16;
            this.label6.Text = "Product Name";
            // 
            // repackBy
            // 
            this.repackBy.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repackBy.Location = new System.Drawing.Point(565, 283);
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
            this.repackBy.Size = new System.Drawing.Size(221, 27);
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
            this.label5.Location = new System.Drawing.Point(351, 282);
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
            this.repackedQuan.Location = new System.Drawing.Point(564, 355);
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
            this.repackedQuan.Size = new System.Drawing.Size(221, 27);
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
            this.label3.Location = new System.Drawing.Point(351, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Repacked Quantity";
            // 
            // itemVol
            // 
            this.itemVol.Enabled = false;
            this.itemVol.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemVol.Location = new System.Drawing.Point(565, 246);
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
            this.itemVol.Size = new System.Drawing.Size(221, 27);
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
            this.label2.Location = new System.Drawing.Point(351, 245);
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
            this.saveRepackBtn.Location = new System.Drawing.Point(469, 448);
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
            this.Quan.Location = new System.Drawing.Point(565, 318);
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
            this.Quan.Size = new System.Drawing.Size(221, 27);
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
            this.cancelRepackBtn.Location = new System.Drawing.Point(582, 448);
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
            this.label4.Location = new System.Drawing.Point(351, 317);
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
            this.addLabel.Location = new System.Drawing.Point(451, 62);
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
            this.reorderBtn.Location = new System.Drawing.Point(671, 102);
            this.reorderBtn.Name = "reorderBtn";
            this.reorderBtn.Size = new System.Drawing.Size(92, 42);
            this.reorderBtn.TabIndex = 162;
            this.reorderBtn.Text = "REORDER";
            this.reorderBtn.UseVisualStyleBackColor = false;
            this.reorderBtn.Visible = false;
            this.reorderBtn.Click += new System.EventHandler(this.reorderBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(42, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(22, 17);
            this.panel1.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Lime;
            this.panel2.Location = new System.Drawing.Point(150, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 17);
            this.panel2.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(70, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 16);
            this.label7.TabIndex = 163;
            this.label7.Text = "Low Stocks";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(182, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 164;
            this.label8.Text = "Sufficient";
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1138, 690);
            this.ControlBox = false;
            this.Controls.Add(this.repackPanel);
            this.Controls.Add(this.dtgvInventory);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reorderBtn);
            this.Controls.Add(this.repackBtn);
            this.Controls.Add(this.logBtn);
            this.Controls.Add(this.stockoutBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitBtn);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgvInventory)).EndInit();
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
        private System.Windows.Forms.DataGridView dtgvInventory;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}