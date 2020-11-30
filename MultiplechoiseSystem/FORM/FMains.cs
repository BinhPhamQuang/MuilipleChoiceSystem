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
using MultiplechoiseSystem.DAO;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.FORM
{
    public partial class FMains : Form
    {
        ListCourse listCourse;
        UCEnroll ucenroll;
        UCCourseDetail CourseDetail;
        UCEditInfo ucEditInfo;
     //   UserDTO user;

        public FMains()
        {
            InitializeComponent();
            timer1.Start();
            lbdate.Text = DateTime.Now.ToString("D");
             
            listCourse = new ListCourse();
            ucenroll = new UCEnroll();
                
            panel_main.Controls.Add(listCourse);
            panel_main.Controls.Add(ucenroll);


            listCourse.BtnViewClick += new EventHandler(BtnCourseViewDetailClick);


            listCourse.BringToFront();
        }
        void Alert(string msg, FAlert.emType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private void DisplayInfo()
        {
            lbname.Text = UserDTO.Instance.FirstName + " " + UserDTO.Instance.LastName;
            if (UserDTO.Instance.UserType == UserDTO.Instance.Student)
            {
                lbType.Text = "Student";
                button1.Visible = true;
                button1.TextAlign = ContentAlignment.MiddleCenter;
                button1.Text = "Enroll";
                btnCreateQuestion.Visible = false;
            }
            if (UserDTO.Instance.UserType == UserDTO.Instance.Lecturer)
            {
                lbType.Text = "Lecturer";
                button1.Visible = false;
               
                btnCreateQuestion.Visible = true;
            }
            if (UserDTO.Instance.UserType == UserDTO.Instance.Manager)
            {
                lbType.Text = "Manager";
                button1.TextAlign = ContentAlignment.MiddleRight;
                button1.Text = "Outcomes";
                button1.Visible = true;
                btnCreateQuestion.Visible = false;
                btnCreateQuestion.Text = "Approve tests";
                btnCreateQuestion.Visible = true;
            }
            lbDepartment.Text = UserDTO.Instance.DepartmentName;

        }
        private void FMains_Load(object sender, EventArgs e)
        {
            DisplayInfo();
             
        }

         
        protected void BtnCourseViewDetailClick(object sender, EventArgs e)
        {

             
            CourseDetail = new UCCourseDetail();
            panel_main.Controls.Add(CourseDetail);
            CourseDetail.BringToFront();
            CourseDetail.BtnCloseClick += new EventHandler(BtnCourseDetailClose);
        }

        protected void BtnCourseDetailClose(object sender, EventArgs e)
        {
            panel_main.Controls.Remove(CourseDetail);
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
                 ucEditInfo =new UCEditInfo();
            panel_main.Controls.Add(ucEditInfo);
            ucEditInfo.BtnConfirmClick += new EventHandler(UCEditInfoConfirmClick);
            ucEditInfo.BtnCloseClick += new EventHandler(UCEditInfoCloseClick);
            ucEditInfo.BringToFront();
            
        }
        protected void UCEditInfoConfirmClick(object sender, EventArgs e)
        {
            Alert("Success !", FAlert.emType.success);
            panel_main.Controls.Remove(ucEditInfo);
        }
        protected void UCEditInfoCloseClick(object sender, EventArgs e)
        {
            
            panel_main.Controls.Remove(ucEditInfo);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            btnCourse.BackColor = Color.FromArgb(0, 0, 64);
            button1.BackColor = Color.FromArgb(16, 54, 100);
            btnCreateQuestion.BackColor = Color.FromArgb(16, 54, 100);
            listCourse.BringToFront();
        }

        private void listCourse1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCourse.BackColor = Color.FromArgb(16, 54, 100);
            button1.BackColor = Color.FromArgb(0, 0, 64);
            btnCreateQuestion.BackColor = Color.FromArgb(16, 54, 100);
            if (UserDTO.Instance.UserType == UserDTO.Instance.Student)
            {
                ucenroll.BringToFront();
            }
            else
            {
                if (UserDTO.Instance.UserType ==UserDTO.Instance.Manager)
                {
                    UCoutcome f = new UCoutcome();
                    panel_main.Controls.Add(f);
                    f.BringToFront();
                }
            }
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
            lbTime.Text = DateTime.Now.ToString("t");
        }

        private void btnCreateQuestion_Click(object sender, EventArgs e)
        {
            btnCourse.BackColor = Color.FromArgb(16,54,100);
            button1.BackColor = Color.FromArgb(16, 54, 100);
            btnCreateQuestion.BackColor = Color.FromArgb(0, 0, 64);
            if (UserDTO.Instance.UserType == UserDTO.Instance.Manager)
            {
                FConfirmTest f = new FConfirmTest();
                panel_main.Controls.Add(f);
                f.BringToFront();
            }
            else
            {
                btnCreateQuestion.BackColor = Color.FromArgb(0, 0, 64);
                button1.BackColor = Color.FromArgb(16, 54, 100);
                btnCourse.BackColor = Color.FromArgb(16, 54, 100);
                UCinsertQuestion uCinsertQuestion = new UCinsertQuestion();
                panel_main.Controls.Add(uCinsertQuestion);
                uCinsertQuestion.BringToFront();
            }
        }
    }
}
