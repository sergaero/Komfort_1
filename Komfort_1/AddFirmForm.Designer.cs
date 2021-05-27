namespace Komfort_1
{
    partial class AddFirmForm
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
            this.BtnAddFirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirmName = new System.Windows.Forms.TextBox();
            this.textBoxFirmCountry = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnAddFirm
            // 
            this.BtnAddFirm.Location = new System.Drawing.Point(59, 92);
            this.BtnAddFirm.Name = "BtnAddFirm";
            this.BtnAddFirm.Size = new System.Drawing.Size(602, 23);
            this.BtnAddFirm.TabIndex = 0;
            this.BtnAddFirm.Text = "Добавить фирму";
            this.BtnAddFirm.UseVisualStyleBackColor = true;
            this.BtnAddFirm.Click += new System.EventHandler(this.BtnAddFirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фирма:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Страна:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxFirmName
            // 
            this.textBoxFirmName.Location = new System.Drawing.Point(109, 38);
            this.textBoxFirmName.Name = "textBoxFirmName";
            this.textBoxFirmName.Size = new System.Drawing.Size(215, 20);
            this.textBoxFirmName.TabIndex = 3;
            this.textBoxFirmName.TextChanged += new System.EventHandler(this.textBoxFirmName_TextChanged);
            // 
            // textBoxFirmCountry
            // 
            this.textBoxFirmCountry.Location = new System.Drawing.Point(446, 38);
            this.textBoxFirmCountry.Name = "textBoxFirmCountry";
            this.textBoxFirmCountry.Size = new System.Drawing.Size(215, 20);
            this.textBoxFirmCountry.TabIndex = 4;
            this.textBoxFirmCountry.TextChanged += new System.EventHandler(this.textBoxFirmCountry_TextChanged);
            // 
            // AddFirmForm
            // 
            this.AcceptButton = this.BtnAddFirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 136);
            this.Controls.Add(this.textBoxFirmCountry);
            this.Controls.Add(this.textBoxFirmName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAddFirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddFirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добаавление фирмы";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAddFirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxFirmName;
        private System.Windows.Forms.TextBox textBoxFirmCountry;
    }
}