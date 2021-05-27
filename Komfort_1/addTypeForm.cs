using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Komfort_1
{
    public partial class addTypeForm : Form
    {
        public addTypeForm()
        {
            InitializeComponent();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            if ((this.textBox1.Text != "") && (this.textBox1.Text.Length <50))
            {
                Type t = new Type();
                t.addType(this.textBox1.Text);
                this.textBox1.Text = "";
            }
        }
    }
}
