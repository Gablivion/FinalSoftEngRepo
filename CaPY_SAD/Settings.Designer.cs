namespace CaPY_SAD
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.update_pwordBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.update_unameBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.unameTxt = new System.Windows.Forms.TextBox();
            this.oldpwordTxt = new System.Windows.Forms.TextBox();
            this.newpwordTxt = new System.Windows.Forms.TextBox();
            this.confirm_newpwordTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // update_pwordBtn
            // 
            this.update_pwordBtn.BackColor = System.Drawing.Color.White;
            this.update_pwordBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.update_pwordBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_pwordBtn.ForeColor = System.Drawing.Color.Black;
            this.update_pwordBtn.Location = new System.Drawing.Point(319, 246);
            this.update_pwordBtn.Name = "update_pwordBtn";
            this.update_pwordBtn.Size = new System.Drawing.Size(90, 47);
            this.update_pwordBtn.TabIndex = 6;
            this.update_pwordBtn.Text = "UPDATE";
            this.update_pwordBtn.UseVisualStyleBackColor = false;
            this.update_pwordBtn.Click += new System.EventHandler(this.update_pwordBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(42)))), ((int)(((byte)(15)))));
            this.quitBtn.FlatAppearance.BorderSize = 0;
            this.quitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitBtn.ForeColor = System.Drawing.Color.White;
            this.quitBtn.Image = ((System.Drawing.Image)(resources.GetObject("quitBtn.Image")));
            this.quitBtn.Location = new System.Drawing.Point(408, 0);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(42, 40);
            this.quitBtn.TabIndex = 52;
            this.quitBtn.UseVisualStyleBackColor = false;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tw Cen MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(40, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 37);
            this.label2.TabIndex = 48;
            this.label2.Text = "CHANGE PASSWORD";
            // 
            // update_unameBtn
            // 
            this.update_unameBtn.BackColor = System.Drawing.Color.White;
            this.update_unameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.update_unameBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.update_unameBtn.ForeColor = System.Drawing.Color.Black;
            this.update_unameBtn.Location = new System.Drawing.Point(319, 95);
            this.update_unameBtn.Name = "update_unameBtn";
            this.update_unameBtn.Size = new System.Drawing.Size(88, 26);
            this.update_unameBtn.TabIndex = 2;
            this.update_unameBtn.Text = "UPDATE";
            this.update_unameBtn.UseVisualStyleBackColor = false;
            this.update_unameBtn.Click += new System.EventHandler(this.update_unameBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(40, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 37);
            this.label1.TabIndex = 45;
            this.label1.Text = "CHANGE USERNAME";
            // 
            // unameTxt
            // 
            this.unameTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameTxt.Location = new System.Drawing.Point(47, 95);
            this.unameTxt.MaxLength = 45;
            this.unameTxt.Name = "unameTxt";
            this.unameTxt.Size = new System.Drawing.Size(260, 26);
            this.unameTxt.TabIndex = 1;
            this.unameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // oldpwordTxt
            // 
            this.oldpwordTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldpwordTxt.Location = new System.Drawing.Point(47, 223);
            this.oldpwordTxt.MaxLength = 45;
            this.oldpwordTxt.Name = "oldpwordTxt";
            this.oldpwordTxt.Size = new System.Drawing.Size(260, 26);
            this.oldpwordTxt.TabIndex = 3;
            this.oldpwordTxt.Text = "Old Password";
            this.oldpwordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.oldpwordTxt.Click += new System.EventHandler(this.oldpwordTxt_Click);
            this.oldpwordTxt.Leave += new System.EventHandler(this.oldpwordTxt_Leave);
            // 
            // newpwordTxt
            // 
            this.newpwordTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpwordTxt.Location = new System.Drawing.Point(47, 255);
            this.newpwordTxt.MaxLength = 45;
            this.newpwordTxt.Name = "newpwordTxt";
            this.newpwordTxt.Size = new System.Drawing.Size(260, 26);
            this.newpwordTxt.TabIndex = 4;
            this.newpwordTxt.Text = "New Password";
            this.newpwordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newpwordTxt.Click += new System.EventHandler(this.newpwordTxt_Click);
            this.newpwordTxt.Leave += new System.EventHandler(this.newpwordTxt_Leave);
            // 
            // confirm_newpwordTxt
            // 
            this.confirm_newpwordTxt.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm_newpwordTxt.Location = new System.Drawing.Point(47, 287);
            this.confirm_newpwordTxt.MaxLength = 45;
            this.confirm_newpwordTxt.Name = "confirm_newpwordTxt";
            this.confirm_newpwordTxt.Size = new System.Drawing.Size(260, 26);
            this.confirm_newpwordTxt.TabIndex = 5;
            this.confirm_newpwordTxt.Text = "Retype New Password";
            this.confirm_newpwordTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.confirm_newpwordTxt.Click += new System.EventHandler(this.confirm_newpwordTxt_Click);
            this.confirm_newpwordTxt.Leave += new System.EventHandler(this.confirm_newpwordTxt_Leave);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(451, 358);
            this.ControlBox = false;
            this.Controls.Add(this.confirm_newpwordTxt);
            this.Controls.Add(this.newpwordTxt);
            this.Controls.Add(this.oldpwordTxt);
            this.Controls.Add(this.unameTxt);
            this.Controls.Add(this.update_pwordBtn);
            this.Controls.Add(this.quitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.update_unameBtn);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Settings_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button update_pwordBtn;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button update_unameBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unameTxt;
        private System.Windows.Forms.TextBox oldpwordTxt;
        private System.Windows.Forms.TextBox newpwordTxt;
        private System.Windows.Forms.TextBox confirm_newpwordTxt;
    }
}