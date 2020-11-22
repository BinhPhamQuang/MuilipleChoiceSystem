using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplechoiseSystem.FORM;
namespace MultiplechoiseSystem.FORM
{
    public partial class FMains : Form
    {
        ListCourse listCourse;
        UCEnroll ucenroll;
        FAlert Alert = new FAlert();
        public FMains()
        {
            InitializeComponent();
            timer1.Start();
            lbdate.Text = DateTime.Now.ToString("D");
             
            listCourse = new ListCourse();
            ucenroll = new UCEnroll();
                
            panel_main.Controls.Add(listCourse);
            panel_main.Controls.Add(ucenroll);



            listCourse.BringToFront();
        }

        private void FMains_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text=DateTime.Now.ToString("t");
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            FEditProfile f = new FEditProfile();
            this.Hide();
                f.ShowDialog();
            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            
            listCourse.BringToFront();
        }

        private void listCourse1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ucenroll.BringToFront();
        }
    }
}
