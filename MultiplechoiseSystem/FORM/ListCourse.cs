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
    public partial class ListCourse : UserControl
    {
        public ListCourse()
        {
            InitializeComponent();
        }

        private Panel CourseDetail(string NameCourse,string Lecturer,string DateTest)
        {
            Panel course = new Panel();
            course.Size = new Size(1351, 69);
            course.BackColor = Color.Gainsboro;
            Label name = new Label();
            Label nametech = new Label();
            Label date = new Label();
            Button dotest= new Button();
            Button review = new Button();
            name.Text = NameCourse;
            nametech.Text = Lecturer;
            date.Text = DateTest;

            name.Location = new Point(16, 21);
            name.AutoSize = false;
            name.TextAlign = ContentAlignment.MiddleLeft;
            name.Size = new Size(395, 37);

            nametech.Location = new Point(417, 19);
            nametech.AutoSize = false;
            nametech.TextAlign = ContentAlignment.MiddleCenter;
            nametech.Size = new Size(199, 30);

            date.Location = new Point(622, 19);
            date.AutoSize = false;
            date.TextAlign = ContentAlignment.MiddleCenter;
            date.Size = new Size(345, 30);

            dotest.Text = "Take exam";
            dotest.FlatStyle = FlatStyle.Flat;
            dotest.BackColor = SystemColors.MenuHighlight;
            dotest.Location = new Point(992, 8);
            dotest.Size = new Size(175, 48);

            review.Text = "Review";
            review.FlatStyle = FlatStyle.Flat;
            review.BackColor = Color.Aqua;
            review.Location = new Point(1173, 8);
            review.Size = new Size(175, 48);


            course.Controls.Add(name);
            course.Controls.Add(nametech);
            course.Controls.Add(date);
            course.Controls.Add(dotest);
            course.Controls.Add(review);
            return course;
        }
        private void ListCourse_Load(object sender, EventArgs e)
        {
            for (int i=0; i<10;i++)
            {
                flpListCourse.Controls.Add(CourseDetail("Priciple progaming language", "Mr Duy", "12-10-2020 12-10-AM"));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flpListCourse_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
