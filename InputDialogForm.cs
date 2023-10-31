using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PDFwiz
{
    public partial class InputDialogForm : Form
    {
        public string UserInput { get; private set; }

        public InputDialogForm()
        {
            InitializeComponent();
        }

        private void btnCancel_BtnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_BtnClick(object sender, EventArgs e)
        {
            UserInput = tbDocName.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
