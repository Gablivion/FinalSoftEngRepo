namespace CaPY_SAD
{
    partial class Add_cage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_cage));
            this.statusCmb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.saveBtn = new MaterialSkin.Controls.MaterialFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.quitBtn = new System.Windows.Forms.Button();
            this.descTxt = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.SuspendLayout();
            // 
            // statusCmb
            // 
            this.statusCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusCmb.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusCmb.FormattingEnabled = true;
            this.statusCmb.Items.AddRange(new object[] {
            "Occupied",
            "Unoccupied",
            "Under Maintenance"});
            this.statusCmb.Location = new System.Drawing.Point(141, 151);
            this.statusCmb.Name = "statusCmb";
            this.statusCmb.Size = new System.Drawing.Size(191, 25);
            this.statusCmb.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 167;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(19, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 23);
            this.label2.TabIndex = 165;
            this.label2.Text = "Description";
            // 
            // cancelBtn
            // 
            this.cancelBtn.AutoSize = true;
            this.cancelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.cancelBtn.Depth = 0;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(181, 227);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.cancelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Primary = false;
            this.cancelBtn.Size = new System.Drawing.Size(64, 36);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.AutoSize = true;
            this.saveBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveBtn.Depth = 0;
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveBtn.Location = new System.Drawing.Point(105, 227);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.saveBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Primary = false;
            this.saveBtn.Size = new System.Drawing.Size(46, 36);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(92, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 34);
            this.label1.TabIndex = 164;
            this.label1.Text = "ADD CAGE";
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.Transparent;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(307, 1);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 163;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // descTxt
            // 
            this.descTxt.Depth = 0;
            this.descTxt.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descTxt.Hint = "";
            this.descTxt.Location = new System.Drawing.Point(141, 122);
            this.descTxt.MouseState = MaterialSkin.MouseState.HOVER;
            this.descTxt.Name = "descTxt";
            this.descTxt.PasswordChar = '\0';
            this.descTxt.SelectedText = "";
            this.descTxt.SelectionLength = 0;
            this.descTxt.SelectionStart = 0;
            this.descTxt.Size = new System.Drawing.Size(191, 23);
            this.descTxt.TabIndex = 1;
            this.descTxt.UseSystemPasswordChar = false;
            // 
            // Add_cage
            // 
            this.AcceptButton = this.saveBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(103)))), ((int)(((byte)(85)))));
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.descTxt);
            this.Controls.Add(this.statusCmb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_cage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add_cage";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Add_cage_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Add_cage_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Add_cage_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox statusCmb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialFlatButton cancelBtn;
        private MaterialSkin.Controls.MaterialFlatButton saveBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button quitBtn;
        private MaterialSkin.Controls.MaterialSingleLineTextField descTxt;
    }
}