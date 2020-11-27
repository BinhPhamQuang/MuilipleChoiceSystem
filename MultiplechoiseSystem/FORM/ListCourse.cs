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
            course.BackColor = Color.Gainsboro;
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
            dotest.BackColor = SystemColors.MenuHighlight;
            dotest.Location = new Point(939, 10);
            dotest.Size = new Size(210, 48);
            dotest.Click += viewExam_Click;
            dotest.Tag = c.CourseID;
            course.Controls.Add(name);
            course.Controls.Add(nametech);
            
            course.Controls.Add(dotest);

            return course;
        }

        private void viewExam_Click(object sender, EventArgs e)
        {
            flpExam.Controls.Clear();
            string courseid = (sender as Button).Tag as string;
            foreach(ExamDTO i in CourseDAO.Instance.getExam(courseid))
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
            foreach(CourseDTO i in UserDAO.Instance.getCourse())
            {
                flpListCourse.Controls.Add(CourseDetail(i));
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
    }
}
