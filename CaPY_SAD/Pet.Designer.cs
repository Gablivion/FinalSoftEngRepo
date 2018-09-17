namespace CaPY_SAD
{
    partial class Pet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvPet = new System.Windows.Forms.DataGridView();
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.archiveBtn = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPet)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1096, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 40);
            this.button1.TabIndex = 45;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(526, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 40);
            this.label2.TabIndex = 54;
            this.label2.Text = "PETS";
            // 
            // dtgvPet
            // 
            this.dtgvPet.AllowUserToAddRows = false;
            this.dtgvPet.AllowUserToDeleteRows = false;
            this.dtgvPet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPet.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvPet.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvPet.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvPet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvPet.Location = new System.Drawing.Point(37, 109);
            this.dtgvPet.Name = "dtgvPet";
            this.dtgvPet.ReadOnly = true;
            this.dtgvPet.RowHeadersVisible = false;
            this.dtgvPet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPet.Size = new System.Drawing.Size(1064, 546);
            this.dtgvPet.TabIndex = 55;
            this.dtgvPet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPet_CellClick);
            this.dtgvPet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPet_CellContentClick);
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(156)))), ((int)(((byte)(120)))));
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.ForeColor = System.Drawing.Color.Black;
            this.editBtn.Location = new System.Drawing.Point(960, 73);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(54, 33);
            this.editBtn.TabIndex = 57;
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
            this.addBtn.Location = new System.Drawing.Point(904, 73);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(54, 33);
            this.addBtn.TabIndex = 56;
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
            this.archiveBtn.Location = new System.Drawing.Point(1016, 73);
            this.archiveBtn.Name = "archiveBtn";
            this.archiveBtn.Size = new System.Drawing.Size(85, 33);
            this.archiveBtn.TabIndex = 58;
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
            this.label3.Location = new System.Drawing.Point(30, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 28);
            this.label3.TabIndex = 63;
            this.label3.Text = "Search:";
            // 
            // Pet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1138, 690);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.archiveBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.dtgvPet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Pet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Pet_Load);
            this.Click += new System.EventHandler(this.Pet_Click);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pet_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pet_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pet_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dtgvPet;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button archiveBtn;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label3;
    }
}