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
    public partial class AddTrMarkForm : Form
    {
        public AddTrMarkForm()
        {
            InitializeComponent();
        }

        private void btnAddTrMark_Click(object sender, EventArgs e)
        {
            if ((this.textBoxAddTrMark.Text != "") && (this.textBoxAddTrMark.Text.Length < 50))
            {
                TrMark trMark = new TrMark();
                trMark.addTrMark(this.textBoxAddTrMark.Text);
                this.textBoxAddTrMark.Text = "";
            }
        }
    }
}
