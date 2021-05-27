namespace Komfort_1
{
    partial class DelMarkForm
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewDelMark = new System.Windows.Forms.DataGridView();
            this.btnDelMark = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDelMark = new System.Windows.Forms.TextBox();
            this.productDataSet = new Komfort_1.productDataSet();
            this.trMarkBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trMarkTableAdapter = new Komfort_1.productDataSetTableAdapters.TrMarkTableAdapter();
            this.trMarkIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trMarkNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trMarkBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDelMark
            // 
            this.dataGridViewDelMark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDelMark.AutoGenerateColumns = false;
            this.dataGridViewDelMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDelMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trMarkIDDataGridViewTextBoxColumn,
            this.trMarkNameDataGridViewTextBoxColumn});
            this.dataGridViewDelMark.DataSource = this.trMarkBindingSource;
            this.dataGridViewDelMark.Location = new System.Drawing.Point(22, 68);
            this.dataGridViewDelMark.Name = "dataGridViewDelMark";
            this.dataGridViewDelMark.ReadOnly = true;
            this.dataGridViewDelMark.Size = new System.Drawing.Size(474, 420);
            this.dataGridViewDelMark.TabIndex = 7;
            // 
            // btnDelMark
            // 
            this.btnDelMark.Location = new System.Drawing.Point(22, 39);
            this.btnDelMark.Name = "btnDelMark";
            this.btnDelMark.Size = new System.Drawing.Size(474, 23);
            this.btnDelMark.TabIndex = 6;
            this.btnDelMark.Text = "Удалить марку";
            this.btnDelMark.UseVisualStyleBackColor = true;
            this.btnDelMark.Click += new System.EventHandler(this.btnDelMark_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Марка:";
            // 
            // textBoxDelMark
            // 
            this.textBoxDelMark.Location = new System.Drawing.Point(87, 13);
            this.textBoxDelMark.Name = "textBoxDelMark";
            this.textBoxDelMark.Size = new System.Drawing.Size(409, 20);
            this.textBoxDelMark.TabIndex = 4;
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "productDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // trMarkBindingSource
            // 
            this.trMarkBindingSource.DataMember = "TrMark";
            this.trMarkBindingSource.DataSource = this.productDataSet;
            // 
            // trMarkTableAdapter
            // 
            this.trMarkTableAdapter.ClearBeforeFill = true;
            // 
            // trMarkIDDataGridViewTextBoxColumn
            // 
            this.trMarkIDDataGridViewTextBoxColumn.DataPropertyName = "trMarkID";
            this.trMarkIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.trMarkIDDataGridViewTextBoxColumn.Name = "trMarkIDDataGridViewTextBoxColumn";
            this.trMarkIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // trMarkNameDataGridViewTextBoxColumn
            // 
            this.trMarkNameDataGridViewTextBoxColumn.DataPropertyName = "trMarkName";
            this.trMarkNameDataGridViewTextBoxColumn.HeaderText = "Марка";
            this.trMarkNameDataGridViewTextBoxColumn.Name = "trMarkNameDataGridViewTextBoxColumn";
            this.trMarkNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DelMarkForm
            // 
            this.AcceptButton = this.btnDelMark;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 501);
            this.Controls.Add(this.dataGridViewDelMark);
            this.Controls.Add(this.btnDelMark);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDelMark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DelMarkForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление марки";
            this.Load += new System.EventHandler(this.DelMarkForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trMarkBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDelMark;
        private System.Windows.Forms.Button btnDelMark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDelMark;
        private productDataSet productDataSet;
        private System.Windows.Forms.BindingSource trMarkBindingSource;
        private productDataSetTableAdapters.TrMarkTableAdapter trMarkTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn trMarkIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn trMarkNameDataGridViewTextBoxColumn;
    }
}