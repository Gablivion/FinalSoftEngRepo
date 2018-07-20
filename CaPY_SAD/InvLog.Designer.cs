namespace CaPY_SAD
{
    partial class InvLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvLog));
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvLog = new System.Windows.Forms.DataGridView();
            this.quitBtn = new System.Windows.Forms.Button();
            this.logCmb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.endDtp = new System.Windows.Forms.DateTimePicker();
            this.startDtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printBtn = new System.Windows.Forms.Button();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLog)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(352, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 40);
            this.label1.TabIndex = 44;
            this.label1.Text = "INVENTORY LOG";
            // 
            // dtgvLog
            // 
            this.dtgvLog.AllowUserToAddRows = false;
            this.dtgvLog.AllowUserToDeleteRows = false;
            this.dtgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvLog.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvLog.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dtgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvLog.DefaultCellStyle = dataGridViewCellStyle10;
            this.dtgvLog.Location = new System.Drawing.Point(24, 159);
            this.dtgvLog.Name = "dtgvLog";
            this.dtgvLog.ReadOnly = true;
            this.dtgvLog.RowHeadersVisible = false;
            this.dtgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvLog.Size = new System.Drawing.Size(926, 494);
            this.dtgvLog.TabIndex = 45;
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(933, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 83;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click_1);
            // 
            // logCmb
            // 
            this.logCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.logCmb.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logCmb.FormattingEnabled = true;
            this.logCmb.Items.AddRange(new object[] {
            "All",
            "Stock In (Purchased)",
            "Stock In (Refund)",
            "Stock Out (Sales Order)",
            "Stock Out (Manual)",
            "Stock Out (Hospitalization Product)",
            "Stock Out (Repack)"});
            this.logCmb.Location = new System.Drawing.Point(127, 15);
            this.logCmb.Name = "logCmb";
            this.logCmb.Size = new System.Drawing.Size(185, 27);
            this.logCmb.TabIndex = 1;
            this.logCmb.TextChanged += new System.EventHandler(this.logCmb_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(650, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 22);
            this.label5.TabIndex = 108;
            this.label5.Text = "End";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(351, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 22);
            this.label6.TabIndex = 107;
            this.label6.Text = "Start";
            // 
            // endDtp
            // 
            this.endDtp.CustomFormat = "yyyy-MM-dd";
            this.endDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDtp.Location = new System.Drawing.Point(707, 15);
            this.endDtp.Name = "endDtp";
            this.endDtp.Size = new System.Drawing.Size(185, 26);
            this.endDtp.TabIndex = 3;
            this.endDtp.ValueChanged += new System.EventHandler(this.endDtp_ValueChanged);
            // 
            // startDtp
            // 
            this.startDtp.CustomFormat = "yyyy-MM-dd";
            this.startDtp.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDtp.Location = new System.Drawing.Point(408, 15);
            this.startDtp.Name = "startDtp";
            this.startDtp.Size = new System.Drawing.Size(185, 26);
            this.startDtp.TabIndex = 2;
            this.startDtp.ValueChanged += new System.EventHandler(this.endDtp_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(35, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 22);
            this.label2.TabIndex = 109;
            this.label2.Text = "Log Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(96)))), ((int)(((byte)(113)))));
            this.panel1.Controls.Add(this.startDtp);
            this.panel1.Controls.Add(this.endDtp);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.logCmb);
            this.panel1.Location = new System.Drawing.Point(24, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 56);
            this.panel1.TabIndex = 110;
            // 
            // printBtn
            // 
            this.printBtn.BackColor = System.Drawing.Color.White;
            this.printBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.printBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printBtn.Location = new System.Drawing.Point(893, 69);
            this.printBtn.Name = "printBtn";
            this.printBtn.Size = new System.Drawing.Size(57, 27);
            this.printBtn.TabIndex = 4;
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
            // InvLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(975, 678);
            this.ControlBox = false;
            this.Controls.Add(this.printBtn);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.dtgvLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InvLog";
            this.Load += new System.EventHandler(this.InvLog_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.InvLog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.InvLog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.InvLog_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvLog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvLog;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.ComboBox logCmb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker endDtp;
        private System.Windows.Forms.DateTimePicker startDtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button printBtn;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}