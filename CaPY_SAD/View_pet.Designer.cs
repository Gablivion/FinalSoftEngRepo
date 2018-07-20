namespace CaPY_SAD
{
    partial class View_pet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_pet));
            this.editBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.colorTxt = new System.Windows.Forms.TextBox();
            this.breedTxt = new System.Windows.Forms.TextBox();
            this.speciesTxt = new System.Windows.Forms.TextBox();
            this.micronumTxt = new System.Windows.Forms.TextBox();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.ownerCmb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sterilizedBox = new MaterialSkin.Controls.MaterialCheckBox();
            this.bdayTxt = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.femaleRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.maleRadio = new MaterialSkin.Controls.MaterialRadioButton();
            this.saveBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cancelBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // editBtn
            // 
            this.editBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(156)))), ((int)(((byte)(120)))));
            this.editBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(781, 64);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(53, 34);
            this.editBtn.TabIndex = 153;
            this.editBtn.Text = "EDIT";
            this.editBtn.UseVisualStyleBackColor = false;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 368);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(822, 359);
            this.dataGridView1.TabIndex = 152;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tw Cen MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(294, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(272, 43);
            this.label10.TabIndex = 150;
            this.label10.Text = "TRANSACTIONS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(313, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 43);
            this.label1.TabIndex = 151;
            this.label1.Text = "PET PROFILE";
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(818, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 149;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // colorTxt
            // 
            this.colorTxt.Enabled = false;
            this.colorTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorTxt.Location = new System.Drawing.Point(600, 169);
            this.colorTxt.MaxLength = 45;
            this.colorTxt.Name = "colorTxt";
            this.colorTxt.Size = new System.Drawing.Size(234, 26);
            this.colorTxt.TabIndex = 160;
            // 
            // breedTxt
            // 
            this.breedTxt.Enabled = false;
            this.breedTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.breedTxt.Location = new System.Drawing.Point(177, 233);
            this.breedTxt.MaxLength = 45;
            this.breedTxt.Name = "breedTxt";
            this.breedTxt.Size = new System.Drawing.Size(234, 26);
            this.breedTxt.TabIndex = 158;
            // 
            // speciesTxt
            // 
            this.speciesTxt.Enabled = false;
            this.speciesTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speciesTxt.Location = new System.Drawing.Point(177, 201);
            this.speciesTxt.MaxLength = 45;
            this.speciesTxt.Name = "speciesTxt";
            this.speciesTxt.Size = new System.Drawing.Size(234, 26);
            this.speciesTxt.TabIndex = 157;
            // 
            // micronumTxt
            // 
            this.micronumTxt.Enabled = false;
            this.micronumTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.micronumTxt.Location = new System.Drawing.Point(177, 169);
            this.micronumTxt.MaxLength = 45;
            this.micronumTxt.Name = "micronumTxt";
            this.micronumTxt.Size = new System.Drawing.Size(234, 26);
            this.micronumTxt.TabIndex = 156;
            // 
            // nameTxt
            // 
            this.nameTxt.Enabled = false;
            this.nameTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(177, 137);
            this.nameTxt.MaxLength = 45;
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(234, 26);
            this.nameTxt.TabIndex = 155;
            // 
            // ownerCmb
            // 
            this.ownerCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ownerCmb.Enabled = false;
            this.ownerCmb.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ownerCmb.FormattingEnabled = true;
            this.ownerCmb.Location = new System.Drawing.Point(177, 103);
            this.ownerCmb.Name = "ownerCmb";
            this.ownerCmb.Size = new System.Drawing.Size(234, 28);
            this.ownerCmb.TabIndex = 154;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 28);
            this.label2.TabIndex = 170;
            this.label2.Text = "Owner";
            // 
            // sterilizedBox
            // 
            this.sterilizedBox.AutoSize = true;
            this.sterilizedBox.Depth = 0;
            this.sterilizedBox.Enabled = false;
            this.sterilizedBox.Font = new System.Drawing.Font("Roboto", 10F);
            this.sterilizedBox.Location = new System.Drawing.Point(604, 201);
            this.sterilizedBox.Margin = new System.Windows.Forms.Padding(0);
            this.sterilizedBox.MouseLocation = new System.Drawing.Point(-1, -1);
            this.sterilizedBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.sterilizedBox.Name = "sterilizedBox";
            this.sterilizedBox.Ripple = true;
            this.sterilizedBox.Size = new System.Drawing.Size(88, 30);
            this.sterilizedBox.TabIndex = 161;
            this.sterilizedBox.Text = "Sterilized";
            this.sterilizedBox.UseVisualStyleBackColor = true;
            // 
            // bdayTxt
            // 
            this.bdayTxt.CustomFormat = "yyyy-MM-dd";
            this.bdayTxt.Enabled = false;
            this.bdayTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bdayTxt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.bdayTxt.Location = new System.Drawing.Point(600, 103);
            this.bdayTxt.Name = "bdayTxt";
            this.bdayTxt.Size = new System.Drawing.Size(234, 26);
            this.bdayTxt.TabIndex = 159;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(425, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 28);
            this.label6.TabIndex = 169;
            this.label6.Text = "Gender";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(425, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 28);
            this.label5.TabIndex = 168;
            this.label5.Text = "Birthday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(425, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 28);
            this.label4.TabIndex = 167;
            this.label4.Text = "Sterilization status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(425, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 28);
            this.label3.TabIndex = 166;
            this.label3.Text = "Color";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(27, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 28);
            this.label9.TabIndex = 165;
            this.label9.Text = "Breed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(27, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 28);
            this.label8.TabIndex = 164;
            this.label8.Text = "Species";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(27, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 28);
            this.label7.TabIndex = 163;
            this.label7.Text = "Microchip #";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(27, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 28);
            this.label11.TabIndex = 162;
            this.label11.Text = "Name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.femaleRadio);
            this.panel1.Controls.Add(this.maleRadio);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(600, 136);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 33);
            this.panel1.TabIndex = 171;
            // 
            // femaleRadio
            // 
            this.femaleRadio.AutoSize = true;
            this.femaleRadio.Depth = 0;
            this.femaleRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.femaleRadio.Location = new System.Drawing.Point(69, 1);
            this.femaleRadio.Margin = new System.Windows.Forms.Padding(0);
            this.femaleRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.femaleRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.femaleRadio.Name = "femaleRadio";
            this.femaleRadio.Ripple = true;
            this.femaleRadio.Size = new System.Drawing.Size(74, 30);
            this.femaleRadio.TabIndex = 8;
            this.femaleRadio.TabStop = true;
            this.femaleRadio.Text = "Female";
            this.femaleRadio.UseVisualStyleBackColor = true;
            // 
            // maleRadio
            // 
            this.maleRadio.AutoSize = true;
            this.maleRadio.Depth = 0;
            this.maleRadio.Font = new System.Drawing.Font("Roboto", 10F);
            this.maleRadio.Location = new System.Drawing.Point(4, 1);
            this.maleRadio.Margin = new System.Windows.Forms.Padding(0);
            this.maleRadio.MouseLocation = new System.Drawing.Point(-1, -1);
            this.maleRadio.MouseState = MaterialSkin.MouseState.HOVER;
            this.maleRadio.Name = "maleRadio";
            this.maleRadio.Ripple = true;
            this.maleRadio.Size = new System.Drawing.Size(59, 30);
            this.maleRadio.TabIndex = 7;
            this.maleRadio.TabStop = true;
            this.maleRadio.Text = "Male";
            this.maleRadio.UseVisualStyleBackColor = true;
            // 
            // saveBtn
            // 
            this.saveBtn.Depth = 0;
            this.saveBtn.Location = new System.Drawing.Point(343, 274);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Primary = true;
            this.saveBtn.Size = new System.Drawing.Size(75, 33);
            this.saveBtn.TabIndex = 172;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Depth = 0;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(442, 274);
            this.cancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Primary = true;
            this.cancelBtn.Size = new System.Drawing.Size(75, 33);
            this.cancelBtn.TabIndex = 172;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // View_pet
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(860, 744);
            this.ControlBox = false;
            this.Controls.Add(this.sterilizedBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.colorTxt);
            this.Controls.Add(this.breedTxt);
            this.Controls.Add(this.speciesTxt);
            this.Controls.Add(this.micronumTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.ownerCmb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bdayTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View_pet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View_pet";
            this.Load += new System.EventHandler(this.View_pet_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.View_pet_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.View_pet_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.View_pet_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.TextBox colorTxt;
        private System.Windows.Forms.TextBox breedTxt;
        private System.Windows.Forms.TextBox speciesTxt;
        private System.Windows.Forms.TextBox micronumTxt;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.ComboBox ownerCmb;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialCheckBox sterilizedBox;
        private System.Windows.Forms.DateTimePicker bdayTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRadioButton femaleRadio;
        private MaterialSkin.Controls.MaterialRadioButton maleRadio;
        private MaterialSkin.Controls.MaterialRaisedButton saveBtn;
        private MaterialSkin.Controls.MaterialRaisedButton cancelBtn;
    }
}