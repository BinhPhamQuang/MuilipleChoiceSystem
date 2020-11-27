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
using MultiplechoiseSystem.DAO;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.FORM
{
    public partial class UCEnroll : UserControl
    {
         
        public UCEnroll()
        {
            InitializeComponent();
            AutoCompleteSearch();
        }
        void Alert(string msg="Success !", FAlert.emType type = FAlert.emType.success)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private Panel EnrollCourse(int stt,CourseDTO C)
        {
            Panel course = new Panel();
            course.Size = new Size(1351, 69);
            course.BackColor = Color.Gainsboro;
            Label name = new Label();
            Label nametech = new Label();
            Label date = new Label();
            Label STT = new Label();
            Label CourseID = new Label();
            STT.Location = new Point(3, 25);
            STT.Location = new Point(3, 25);
            STT.Text = stt.ToString();
            Button dotest = new Button();
            Button review = new Button();
            name.Text =C.CourseID+"               "+ C.CourseName;
            nametech.Text = C.LecturerName;
            date.Text = "";


           

            name.Location = new Point(55, 21);
            name.AutoSize = false;
            name.TextAlign = ContentAlignment.MiddleLeft;
            name.Size = new Size(505, 37);

            nametech.Location = new Point(550, 21);
            nametech.AutoSize = false;
            nametech.TextAlign = ContentAlignment.MiddleCenter;
            nametech.Size = new Size(524, 30);

            date.Location = new Point(622, 19);
            date.AutoSize = false;
            date.TextAlign = ContentAlignment.MiddleCenter;
            date.Size = new Size(345, 30);
 

            review.Text = "Enroll";
            review.FlatStyle = FlatStyle.Flat;
            review.BackColor = Color.MediumAquamarine;
            review.Location = new Point(1173, 8);
            review.Size = new Size(175, 48);
            review.Click += enroll_Click;
            review.Tag = C;

            course.Controls.Add(name);
            course.Controls.Add(nametech);
            course.Controls.Add(STT);
            course.Controls.Add(review);
            
            return course;
        }
     
        private void enroll_Click(object sender, EventArgs e)
        {
            CourseDTO t = (sender as Button).Tag as CourseDTO;
            string query = $"INSERT INTO STUDY VALUES ('{UserDTO.Instance.userID}','{t.CourseID}')";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query);
                Alert();
            }
            catch(Exception a)
            {
                Alert("Error !", FAlert.emType.error);
            }
           
        }
        private void showAllcourse()
        {
            int stt = 1;
            flpListCourse.Controls.Clear();
            foreach (CourseDTO i in CourseDAO.Instance.getAllCourse())
            {
                flpListCourse.Controls.Add(EnrollCourse(stt,i));
                stt++;
            }
        }
        private void UCEnroll_Load(object sender, EventArgs e)
        {

            showAllcourse();
        }

        private void AutoCompleteSearch()
        {
            string query = @"Select courseID from COURSE";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            //use LINQ method syntax to pull the Title field from a DT into a string array...
            string[] postSource = data
                                .AsEnumerable()
                                .Select<System.Data.DataRow, String>(x => x.Field<String>("courseID").Trim())
                                .ToArray();
            source.AddRange(postSource);

            tbCourseID.AutoCompleteCustomSource = source;
            tbCourseID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbCourseID.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            flpListCourse.Controls.Clear(); int stt = 1;
            foreach (CourseDTO i in CourseDAO.Instance.getAllCourseByID(tbCourseID.Text))
            {
                flpListCourse.Controls.Add(EnrollCourse(stt,i));
                stt++;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            showAllcourse();
        }
    }
}
