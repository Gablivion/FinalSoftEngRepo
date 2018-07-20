namespace CaPY_SAD
{
    partial class Stock_out
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stock_out));
            this.Reason = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.remarksTxt = new System.Windows.Forms.TextBox();
            this.QuantityTxt = new System.Windows.Forms.NumericUpDown();
            this.productTxt = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // Reason
            // 
            this.Reason.AutoSize = true;
            this.Reason.BackColor = System.Drawing.Color.Transparent;
            this.Reason.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reason.ForeColor = System.Drawing.Color.White;
            this.Reason.Location = new System.Drawing.Point(49, 133);
            this.Reason.Name = "Reason";
            this.Reason.Size = new System.Drawing.Size(89, 28);
            this.Reason.TabIndex = 92;
            this.Reason.Text = "Quantity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(49, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 91;
            this.label2.Text = "Product";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(123, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 40);
            this.label1.TabIndex = 90;
            this.label1.Text = "STOCK OUT";
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.White;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(396, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 99;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tw Cen MT Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 28);
            this.label3.TabIndex = 102;
            this.label3.Text = "Remarks";
            // 
            // remarksTxt
            // 
            this.remarksTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remarksTxt.Location = new System.Drawing.Point(173, 170);
            this.remarksTxt.Multiline = true;
            this.remarksTxt.Name = "remarksTxt";
            this.remarksTxt.Size = new System.Drawing.Size(217, 119);
            this.remarksTxt.TabIndex = 3;
            // 
            // QuantityTxt
            // 
            this.QuantityTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuantityTxt.Location = new System.Drawing.Point(173, 134);
            this.QuantityTxt.Name = "QuantityTxt";
            this.QuantityTxt.Size = new System.Drawing.Size(217, 26);
            this.QuantityTxt.TabIndex = 2;
            // 
            // productTxt
            // 
            this.productTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productTxt.Location = new System.Drawing.Point(173, 100);
            this.productTxt.MaxLength = 45;
            this.productTxt.Name = "productTxt";
            this.productTxt.Size = new System.Drawing.Size(217, 26);
            this.productTxt.TabIndex = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.White;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.Black;
            this.saveBtn.Location = new System.Drawing.Point(133, 317);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(77, 34);
            this.saveBtn.TabIndex = 103;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.White;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.Color.Black;
            this.cancelBtn.Location = new System.Drawing.Point(229, 317);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(77, 34);
            this.cancelBtn.TabIndex = 104;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Stock_out
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.CancelButton = this.quitBtn;
            this.ClientSize = new System.Drawing.Size(438, 380);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.productTxt);
            this.Controls.Add(this.QuantityTxt);
            this.Controls.Add(this.remarksTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.Reason);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stock_out";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Stock_out_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuantityTxt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Reason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox remarksTxt;
        private System.Windows.Forms.NumericUpDown QuantityTxt;
        private System.Windows.Forms.TextBox productTxt;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}