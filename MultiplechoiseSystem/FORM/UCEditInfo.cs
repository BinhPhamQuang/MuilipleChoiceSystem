using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplechoiseSystem.DTO;
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

        private void UCEditInfo_Load(object sender, EventArgs e)
        {
            txtFistName.Text = UserDTO.Instance.FirstName;
            txtlastName.Text = UserDTO.Instance.LastName;
            if (UserDTO.Instance.sex == "M")
            {
                lbSex.Text = "Male";

            }
            else
                lbSex.Text = "FeMale";
            
            tbUsernam.Text = UserDTO.Instance.Username;
            tbPassword.Text = UserDTO.Instance.password;
            try
            {

                tbAddress.Text = UserDTO.Instance.Address;
                dateOfBirth.Value = UserDTO.Instance.DateOfBirth;
            }
            catch(Exception a)
            {

            }
        }
    }
}
