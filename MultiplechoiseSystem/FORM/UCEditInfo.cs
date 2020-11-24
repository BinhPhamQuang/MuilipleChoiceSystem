using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiplechoiseSystem.FORM
{
    public partial class UCEditInfo : UserControl
    {
        public EventHandler BtnConfirmClick;
        public EventHandler BtnCloseClick;
        public UCEditInfo()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.BtnCloseClick!=null)
                {
                this.BtnCloseClick(this, e);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.BtnConfirmClick != null)
            {
                this.BtnConfirmClick(this, e);
            }
        }
    }
}
