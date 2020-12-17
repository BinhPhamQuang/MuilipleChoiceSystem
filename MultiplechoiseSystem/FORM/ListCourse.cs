using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplechoiseSystem.FORM;
using MultiplechoiseSystem.DTO;
using MultiplechoiseSystem.DAO;
namespace MultiplechoiseSystem.FORM
{
    public partial class ListCourse : UserControl
    {
        public EventHandler BtnViewClick;
        public ListCourse()
        {
            InitializeComponent();
            

        }
        private Button ExamDetail(ExamDTO examname)
        {
            Button b = new Button();
            b.FlatStyle = FlatStyle.Flat;
            b.Size = new Size(141, 40);
            b.Text = examname.examID;
            b.Click += view_Click;
            b.Tag = examname;

            return b;
        }
        private Panel CourseDetail(CourseDTO c )
        {
            Panel course = new Panel();
            course.Size = new Size(1164, 69);
            course.BackColor = SystemColors.InactiveCaption;
            Label name = new Label();
            Label nametech = new Label();
            Label date = new Label();
            Button dotest = new Button();
            
            name.Text = c.CourseID+"            "+c.CourseName;
            nametech.Text = c.LecturerName;
            date.Text =  "";

            name.Location = new Point(16, 21);
            name.AutoSize = false;
            name.TextAlign = ContentAlignment.MiddleLeft;
            name.Size = new Size(507, 37);

            nametech.Location = new Point(583, 19);
            nametech.AutoSize = false;
            nametech.TextAlign = ContentAlignment.MiddleCenter;
            nametech.Size = new Size(350, 30);
            

            date.Location = new Point(622, 19);
            date.AutoSize = false;
            date.TextAlign = ContentAlignment.MiddleCenter;
            date.Size = new Size(345, 30);

            dotest.Text = "View";
            dotest.FlatStyle = FlatStyle.Flat;
            dotest.BackColor = SystemColors.ActiveCaption;
            dotest.FlatAppearance.BorderSize = 0;
            dotest.Location = new Point(939, 0);
            dotest.Size = new Size(225, 69);
            dotest.Click += viewExam_Click;
      
            dotest.Tag = c;
            course.Controls.Add(name);
            
            
            course.Controls.Add(dotest);

            if (c.idheader == UserDTO.Instance.userID)
            {
                Button btnCreateSetQuestion = new Button();
                btnCreateSetQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
                btnCreateSetQuestion.FlatAppearance.BorderSize = 0;
                btnCreateSetQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnCreateSetQuestion.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btnCreateSetQuestion.Location = new System.Drawing.Point(598, 0);

                btnCreateSetQuestion.Size = new System.Drawing.Size(336, 69);
                btnCreateSetQuestion.TabIndex = 4;
                btnCreateSetQuestion.Text = "Create set of questions";
                btnCreateSetQuestion.BringToFront();
                btnCreateSetQuestion.Click += btnCreateSetQuestion_Click;
                btnCreateSetQuestion.Tag = c;
                course.Controls.Add(btnCreateSetQuestion);
            }

            else
            {
                if(c.idmanager== UserDTO.Instance.userID)
                {
                    Button btnCreateSetQuestion = new Button();
                    btnCreateSetQuestion.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    btnCreateSetQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnCreateSetQuestion.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btnCreateSetQuestion.Location = new System.Drawing.Point(598, 0);
                    btnCreateSetQuestion.FlatAppearance.BorderSize = 0;
                    btnCreateSetQuestion.Size = new System.Drawing.Size(336, 69);
                    btnCreateSetQuestion.TabIndex = 4;
                    btnCreateSetQuestion.Text = "Create exams";
                    btnCreateSetQuestion.BringToFront();
                    btnCreateSetQuestion.Click += btnCreateExam_Click;
                    btnCreateSetQuestion.Tag = c;
                    course.Controls.Add(btnCreateSetQuestion);
                }
                else
                    course.Controls.Add(nametech);
            }

            return course;
        }
        private string idtemp;
        private void btnCreateExam_Click(object sender, EventArgs e)
        {
            CourseDTO c = (sender as Button).Tag as CourseDTO;
            idtemp = c.CourseID;
            flpListCourse.Size = new Size(1192, 625);
            panelCreateExam.Visible = true;
        }

        private void btnCreateSetQuestion_Click(object sender, EventArgs e)
        {
            CourseDTO course = (sender as Button).Tag as CourseDTO;
            FCreateSetQuestions f = new FCreateSetQuestions(course.CourseID);
            f.ShowDialog();
        }

        private void viewExam_Click(object sender, EventArgs e)
        {
      
            flpExam.Controls.Clear();
            CourseDTO course = (sender as Button).Tag as CourseDTO;
            UserDTO.Instance.courseSelected = course;
            foreach (ExamDTO i in CourseDAO.Instance.getExam(course.CourseID))
            {
                flpExam.Controls.Add(ExamDetail(i));
            }
        }

        private void view_Click(object sender, EventArgs e)
        {
             
            UserDTO.Instance.examSelected = (sender as Button).Tag as ExamDTO;
            if (this.BtnViewClick != null)
            {
                this.BtnViewClick(this, e);
            }
        }
        // neu la giang vien thi ko hien thi ngay thi. va se hien thi cac môn mà mình phụ trách chính.
        
        private void ListCourse_Load(object sender, EventArgs e)
        {
            flpListCourse.Size = new Size(1192, 768);
            if (UserDTO.Instance.UserType == UserDTO.Instance.Student)
            {
                foreach (CourseDTO i in UserDAO.Instance.getCourse())
                {
                    flpListCourse.Controls.Add(CourseDetail(i));
                }
            }
            if (UserDTO.Instance.UserType== UserDTO.Instance.Lecturer)
            {
                foreach (CourseDTO i in UserDAO.Instance.getCourseTeachByTeacher())
                {
                    flpListCourse.Controls.Add(CourseDetail(i));
                }
            }
            else
            {
                lb_header.Text = "";
                foreach (CourseDTO i in UserDAO.Instance.getCourseOfManager())
                {
                    flpListCourse.Controls.Add(CourseDetail(i));
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flpListCourse_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panelCreateExam.Visible = false;
        }

        private void txtNameExam_TextChanged(object sender, EventArgs e)
        {

        }
        void Alert(string msg, FAlert.emType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string formatdate = $"{dateTest.Value.Year.ToString()}-{dateTest.Value.Month.ToString()}-{dateTest.Value.Day.ToString()} {cbHour.Text}:{numMinutes.Value.ToString()}:00";
            string query = $"Insert into EXAM values ('{txtNameExam.Text}','{formatdate}','{idtemp}',2020,{numTimeTest.Value}) ";
            DataProvider.Instance.ExecuteNonQuery(query);
            btnClose_Click(sender, e);
            Alert("Success !", FAlert.emType.success);
        }
    }
}
