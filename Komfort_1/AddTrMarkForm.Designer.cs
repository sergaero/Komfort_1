namespace Komfort_1
{
    partial class AddTrMarkForm
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
            this.textBoxAddTrMark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddTrMark = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddTrMark
            // 
            this.textBoxAddTrMark.Location = new System.Drawing.Point(187, 21);
            this.textBoxAddTrMark.Name = "textBoxAddTrMark";
            this.textBoxAddTrMark.Size = new System.Drawing.Size(451, 20);
            this.textBoxAddTrMark.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите название марки";
            // 
            // btnAddTrMark
            // 
            this.btnAddTrMark.Location = new System.Drawing.Point(45, 79);
            this.btnAddTrMark.Name = "btnAddTrMark";
            this.btnAddTrMark.Size = new System.Drawing.Size(594, 23);
            this.btnAddTrMark.TabIndex = 3;
            this.btnAddTrMark.Text = "Добавить марку";
            this.btnAddTrMark.UseVisualStyleBackColor = true;
            this.btnAddTrMark.Click += new System.EventHandler(this.btnAddTrMark_Click);
            // 
            // AddTrMarkForm
            // 
            this.AcceptButton = this.btnAddTrMark;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 122);
            this.Controls.Add(this.textBoxAddTrMark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddTrMark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddTrMarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление Марки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddTrMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTrMark;
    }
}