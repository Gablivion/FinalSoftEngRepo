namespace CaPY_SAD
{
    partial class Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Staff));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dtgvStaff = new System.Windows.Forms.DataGridView();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.archiveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(431, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 40);
            this.label1.TabIndex = 50;
            this.label1.Text = "STAFF";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(929, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 40);
            this.button1.TabIndex = 48;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dtgvStaff
            // 
            this.dtgvStaff.AllowUserToAddRows = false;
            this.dtgvStaff.AllowUserToDeleteRows = false;
            this.dtgvStaff.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvStaff.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvStaff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvStaff.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvStaff.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvStaff.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvStaff.Location = new System.Drawing.Point(35, 109);
            this.dtgvStaff.Name = "dtgvStaff";
            this.dtgvStaff.ReadOnly = true;
            this.dtgvStaff.RowHeadersVisible = false;
            this.dtgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvStaff.Size = new System.Drawing.Size(900, 421);
            this.dtgvStaff.TabIndex = 53;
            this.dtgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvStaff_CellClick);
            this.dtgvStaff.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgvStaff_RowStateChanged);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(156)))), ((int)(((byte)(120)))));
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.Color.Black;
            this.editBtn.Location = new System.Drawing.Point(795, 74);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(54, 33);
            this.editBtn.TabIndex = 55;
            this.editBtn.Text = "VIEW";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(209)))), ((int)(((byte)(187)))));
            this.addBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.ForeColor = System.Drawing.Color.Black;
            this.addBtn.Location = new System.Drawing.Point(739, 74);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(54, 33);
            this.addBtn.TabIndex = 54;
            this.addBtn.Text = "ADD";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // archiveBtn
            // 
            this.archiveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(212)))), ((int)(((byte)(203)))));
            this.archiveBtn.Enabled = false;
            this.archiveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.archiveBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archiveBtn.ForeColor = System.Drawing.Color.Black;
            this.archiveBtn.Location = new System.Drawing.Point(850, 74);
            this.archiveBtn.Name = "archiveBtn";
            this.archiveBtn.Size = new System.Drawing.Size(85, 33);
            this.archiveBtn.TabIndex = 59;
            this.archiveBtn.Text = "ARCHIVE";
            this.archiveBtn.UseVisualStyleBackColor = false;
            this.archiveBtn.Click += new System.EventHandler(this.archiveBtn_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(103, 76);
            this.nameTxt.MaxLength = 45;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(234, 26);
            this.nameTxt.TabIndex = 62;
            this.nameTxt.TextChanged += new System.EventHandler(this.nameTxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(30, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 28);
            this.label3.TabIndex = 63;
            this.label3.Text = "Search:";
            // 
            // Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(971, 560);
            this.ControlBox = false;
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.archiveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dtgvStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.Load += new System.EventHandler(this.Staff_Load);
            this.Click += new System.EventHandler(this.Staff_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Staff_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Staff_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Staff_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dtgvStaff;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button archiveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label3;
    }
}