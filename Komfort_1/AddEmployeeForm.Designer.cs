namespace Komfort_1
{
    partial class AddEmployeeForm
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
            this.textBoxAddPos = new System.Windows.Forms.TextBox();
            this.textBoxAddFIO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAddEmpl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddPos
            // 
            this.textBoxAddPos.Location = new System.Drawing.Point(502, 15);
            this.textBoxAddPos.Name = "textBoxAddPos";
            this.textBoxAddPos.Size = new System.Drawing.Size(270, 20);
            this.textBoxAddPos.TabIndex = 9;
            // 
            // textBoxAddFIO
            // 
            this.textBoxAddFIO.Location = new System.Drawing.Point(55, 15);
            this.textBoxAddFIO.Name = "textBoxAddFIO";
            this.textBoxAddFIO.Size = new System.Drawing.Size(367, 20);
            this.textBoxAddFIO.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(428, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Должность:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО:";
            // 
            // BtnAddEmpl
            // 
            this.BtnAddEmpl.Location = new System.Drawing.Point(15, 54);
            this.BtnAddEmpl.Name = "BtnAddEmpl";
            this.BtnAddEmpl.Size = new System.Drawing.Size(757, 23);
            this.BtnAddEmpl.TabIndex = 5;
            this.BtnAddEmpl.Text = "Добавить сотрудника";
            this.BtnAddEmpl.UseVisualStyleBackColor = true;
            this.BtnAddEmpl.Click += new System.EventHandler(this.BtnAddEmpl_Click);
            // 
            // AddEmployeeForm
            // 
            this.AcceptButton = this.BtnAddEmpl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 97);
            this.Controls.Add(this.textBoxAddPos);
            this.Controls.Add(this.textBoxAddFIO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAddEmpl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddEmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление сотрудника";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddPos;
        private System.Windows.Forms.TextBox textBoxAddFIO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAddEmpl;
    }
}