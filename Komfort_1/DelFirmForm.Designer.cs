namespace Komfort_1
{
    partial class DelFirmForm
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
            this.textBoxDelFirm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelFirm = new System.Windows.Forms.Button();
            this.dataGridViewDelFirm = new System.Windows.Forms.DataGridView();
            this.firmIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSet = new Komfort_1.productDataSet();
            this.firmTableAdapter = new Komfort_1.productDataSetTableAdapters.FirmTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelFirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDelFirm
            // 
            this.textBoxDelFirm.Location = new System.Drawing.Point(85, 14);
            this.textBoxDelFirm.Name = "textBoxDelFirm";
            this.textBoxDelFirm.Size = new System.Drawing.Size(409, 20);
            this.textBoxDelFirm.TabIndex = 0;
            this.textBoxDelFirm.TextChanged += new System.EventHandler(this.textBoxDelFirm_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Фирма:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnDelFirm
            // 
            this.btnDelFirm.Location = new System.Drawing.Point(20, 40);
            this.btnDelFirm.Name = "btnDelFirm";
            this.btnDelFirm.Size = new System.Drawing.Size(474, 23);
            this.btnDelFirm.TabIndex = 2;
            this.btnDelFirm.Text = "Удалить фирму";
            this.btnDelFirm.UseVisualStyleBackColor = true;
            this.btnDelFirm.Click += new System.EventHandler(this.btnDelFirm_Click);
            // 
            // dataGridViewDelFirm
            // 
            this.dataGridViewDelFirm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDelFirm.AutoGenerateColumns = false;
            this.dataGridViewDelFirm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDelFirm.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firmIDDataGridViewTextBoxColumn,
            this.firmNameDataGridViewTextBoxColumn,
            this.firmCountryDataGridViewTextBoxColumn});
            this.dataGridViewDelFirm.DataSource = this.firmBindingSource;
            this.dataGridViewDelFirm.Location = new System.Drawing.Point(20, 69);
            this.dataGridViewDelFirm.Name = "dataGridViewDelFirm";
            this.dataGridViewDelFirm.ReadOnly = true;
            this.dataGridViewDelFirm.Size = new System.Drawing.Size(474, 420);
            this.dataGridViewDelFirm.TabIndex = 3;
            this.dataGridViewDelFirm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDelFirm_CellContentClick);
            // 
            // firmIDDataGridViewTextBoxColumn
            // 
            this.firmIDDataGridViewTextBoxColumn.DataPropertyName = "firmID";
            this.firmIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.firmIDDataGridViewTextBoxColumn.Name = "firmIDDataGridViewTextBoxColumn";
            this.firmIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firmNameDataGridViewTextBoxColumn
            // 
            this.firmNameDataGridViewTextBoxColumn.DataPropertyName = "firmName";
            this.firmNameDataGridViewTextBoxColumn.HeaderText = "Фирма";
            this.firmNameDataGridViewTextBoxColumn.Name = "firmNameDataGridViewTextBoxColumn";
            this.firmNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.firmNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // firmCountryDataGridViewTextBoxColumn
            // 
            this.firmCountryDataGridViewTextBoxColumn.DataPropertyName = "firmCountry";
            this.firmCountryDataGridViewTextBoxColumn.HeaderText = "Страна";
            this.firmCountryDataGridViewTextBoxColumn.Name = "firmCountryDataGridViewTextBoxColumn";
            this.firmCountryDataGridViewTextBoxColumn.ReadOnly = true;
            this.firmCountryDataGridViewTextBoxColumn.Width = 150;
            // 
            // firmBindingSource
            // 
            this.firmBindingSource.DataMember = "Firm";
            this.firmBindingSource.DataSource = this.productDataSetBindingSource;
            // 
            // productDataSetBindingSource
            // 
            this.productDataSetBindingSource.DataSource = this.productDataSet;
            this.productDataSetBindingSource.Position = 0;
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "productDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // firmTableAdapter
            // 
            this.firmTableAdapter.ClearBeforeFill = true;
            // 
            // DelFirmForm
            // 
            this.AcceptButton = this.btnDelFirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 501);
            this.Controls.Add(this.dataGridViewDelFirm);
            this.Controls.Add(this.btnDelFirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDelFirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DelFirmForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление фирмы";
            this.Load += new System.EventHandler(this.DelFirmForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelFirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.firmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDelFirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelFirm;
        private System.Windows.Forms.DataGridView dataGridViewDelFirm;
        private System.Windows.Forms.BindingSource productDataSetBindingSource;
        private productDataSet productDataSet;
        private System.Windows.Forms.BindingSource firmBindingSource;
        private productDataSetTableAdapters.FirmTableAdapter firmTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firmCountryDataGridViewTextBoxColumn;
    }
}