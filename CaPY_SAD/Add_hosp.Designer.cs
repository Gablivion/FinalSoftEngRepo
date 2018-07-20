namespace CaPY_SAD
{
    partial class Add_hosp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_hosp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cageTxt = new System.Windows.Forms.TextBox();
            this.petTxt = new System.Windows.Forms.TextBox();
            this.dtgvPet = new System.Windows.Forms.DataGridView();
            this.PetPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ownTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPet)).BeginInit();
            this.PetPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 28);
            this.label2.TabIndex = 108;
            this.label2.Text = "Pet";
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(451, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 106;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.White;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(257, 319);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(77, 34);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.White;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(159, 319);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(77, 34);
            this.saveBtn.TabIndex = 4;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(109, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 40);
            this.label3.TabIndex = 107;
            this.label3.Text = "HOSPITALIZE PET";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(43, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 28);
            this.label4.TabIndex = 110;
            this.label4.Text = " Cage Name";
            // 
            // cageTxt
            // 
            this.cageTxt.Enabled = false;
            this.cageTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cageTxt.Location = new System.Drawing.Point(183, 157);
            this.cageTxt.Name = "cageTxt";
            this.cageTxt.Size = new System.Drawing.Size(267, 27);
            this.cageTxt.TabIndex = 111;
            // 
            // petTxt
            // 
            this.petTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.petTxt.Location = new System.Drawing.Point(183, 204);
            this.petTxt.Name = "petTxt";
            this.petTxt.ReadOnly = true;
            this.petTxt.Size = new System.Drawing.Size(267, 27);
            this.petTxt.TabIndex = 112;
            this.petTxt.Text = "Click to Add Pet";
            this.petTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.petTxt.Click += new System.EventHandler(this.petTxt_Click);
            // 
            // dtgvPet
            // 
            this.dtgvPet.AccessibleName = "";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvPet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvPet.Location = new System.Drawing.Point(3, 52);
            this.dtgvPet.Name = "dtgvPet";
            this.dtgvPet.ReadOnly = true;
            this.dtgvPet.RowHeadersVisible = false;
            this.dtgvPet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPet.Size = new System.Drawing.Size(437, 229);
            this.dtgvPet.TabIndex = 113;
            this.dtgvPet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvPet_CellClick);
            // 
            // PetPanel
            // 
            this.PetPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.PetPanel.Controls.Add(this.label5);
            this.PetPanel.Controls.Add(this.dtgvPet);
            this.PetPanel.Location = new System.Drawing.Point(25, 12);
            this.PetPanel.Name = "PetPanel";
            this.PetPanel.Size = new System.Drawing.Size(443, 283);
            this.PetPanel.TabIndex = 115;
            this.PetPanel.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(178, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 40);
            this.label5.TabIndex = 116;
            this.label5.Text = "PETS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(51, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 28);
            this.label6.TabIndex = 116;
            this.label6.Text = "Owner";
            // 
            // ownTxt
            // 
            this.ownTxt.Enabled = false;
            this.ownTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownTxt.Location = new System.Drawing.Point(183, 249);
            this.ownTxt.Name = "ownTxt";
            this.ownTxt.Size = new System.Drawing.Size(267, 27);
            this.ownTxt.TabIndex = 117;
            // 
            // Add_hosp
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(493, 377);
            this.ControlBox = false;
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.PetPanel);
            this.Controls.Add(this.ownTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.petTxt);
            this.Controls.Add(this.cageTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Add_hosp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Add_hosp_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Add_hosp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_hosp_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Add_hosp_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPet)).EndInit();
            this.PetPanel.ResumeLayout(false);
            this.PetPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cageTxt;
        private System.Windows.Forms.TextBox petTxt;
        private System.Windows.Forms.DataGridView dtgvPet;
        private System.Windows.Forms.Panel PetPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ownTxt;
    }
}