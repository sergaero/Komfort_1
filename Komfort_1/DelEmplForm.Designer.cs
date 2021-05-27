namespace Komfort_1
{
    partial class DelEmplForm
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
            this.dataGridViewDelEmpl = new System.Windows.Forms.DataGridView();
            this.btnDelEmpl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDelEmpl = new System.Windows.Forms.TextBox();
            this.productDataSet = new Komfort_1.productDataSet();
            this.productDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.employeeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employeeTableAdapter = new Komfort_1.productDataSetTableAdapters.EmployeeTableAdapter();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeFIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeePositionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelEmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDelEmpl
            // 
            this.dataGridViewDelEmpl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDelEmpl.AutoGenerateColumns = false;
            this.dataGridViewDelEmpl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDelEmpl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeFIODataGridViewTextBoxColumn,
            this.employeePositionDataGridViewTextBoxColumn});
            this.dataGridViewDelEmpl.DataSource = this.employeeBindingSource;
            this.dataGridViewDelEmpl.Location = new System.Drawing.Point(24, 59);
            this.dataGridViewDelEmpl.Name = "dataGridViewDelEmpl";
            this.dataGridViewDelEmpl.ReadOnly = true;
            this.dataGridViewDelEmpl.Size = new System.Drawing.Size(602, 420);
            this.dataGridViewDelEmpl.TabIndex = 7;
            // 
            // btnDelEmpl
            // 
            this.btnDelEmpl.Location = new System.Drawing.Point(24, 30);
            this.btnDelEmpl.Name = "btnDelEmpl";
            this.btnDelEmpl.Size = new System.Drawing.Size(474, 23);
            this.btnDelEmpl.TabIndex = 6;
            this.btnDelEmpl.Text = "Удалить сотрудника";
            this.btnDelEmpl.UseVisualStyleBackColor = true;
            this.btnDelEmpl.Click += new System.EventHandler(this.btnDelEmpl_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Код сотрудника:";
            // 
            // textBoxDelEmpl
            // 
            this.textBoxDelEmpl.Location = new System.Drawing.Point(112, 4);
            this.textBoxDelEmpl.Name = "textBoxDelEmpl";
            this.textBoxDelEmpl.Size = new System.Drawing.Size(386, 20);
            this.textBoxDelEmpl.TabIndex = 4;
            // 
            // productDataSet
            // 
            this.productDataSet.DataSetName = "productDataSet";
            this.productDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productDataSetBindingSource
            // 
            this.productDataSetBindingSource.DataSource = this.productDataSet;
            this.productDataSetBindingSource.Position = 0;
            // 
            // productDataSetBindingSource1
            // 
            this.productDataSetBindingSource1.DataSource = this.productDataSet;
            this.productDataSetBindingSource1.Position = 0;
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataMember = "Employee";
            this.employeeBindingSource.DataSource = this.productDataSet;
            // 
            // employeeTableAdapter
            // 
            this.employeeTableAdapter.ClearBeforeFill = true;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "employeeID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeFIODataGridViewTextBoxColumn
            // 
            this.employeeFIODataGridViewTextBoxColumn.DataPropertyName = "employeeFIO";
            this.employeeFIODataGridViewTextBoxColumn.HeaderText = "ФИО";
            this.employeeFIODataGridViewTextBoxColumn.Name = "employeeFIODataGridViewTextBoxColumn";
            this.employeeFIODataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeFIODataGridViewTextBoxColumn.Width = 300;
            // 
            // employeePositionDataGridViewTextBoxColumn
            // 
            this.employeePositionDataGridViewTextBoxColumn.DataPropertyName = "employeePosition";
            this.employeePositionDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.employeePositionDataGridViewTextBoxColumn.Name = "employeePositionDataGridViewTextBoxColumn";
            this.employeePositionDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeePositionDataGridViewTextBoxColumn.Width = 150;
            // 
            // DelEmplForm
            // 
            this.AcceptButton = this.btnDelEmpl;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 482);
            this.Controls.Add(this.dataGridViewDelEmpl);
            this.Controls.Add(this.btnDelEmpl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDelEmpl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DelEmplForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удаление сотрудника";
            this.Load += new System.EventHandler(this.DelEmplForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelEmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productDataSetBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDelEmpl;
        private System.Windows.Forms.Button btnDelEmpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDelEmpl;
        private System.Windows.Forms.BindingSource productDataSetBindingSource1;
        private productDataSet productDataSet;
        private System.Windows.Forms.BindingSource productDataSetBindingSource;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private productDataSetTableAdapters.EmployeeTableAdapter employeeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeePositionDataGridViewTextBoxColumn;
    }
}