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
        private Panel EnrollCourse(string NameCourse, string Lecturer, string DateTest)
        {
            Panel course = new Panel();
            course.Size = new Size(1351, 69);
            course.BackColor = Color.Gainsboro;
            Label name = new Label();
            Label nametech = new Label();
            Label date = new Label();
            Button dotest = new Button();
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
 

            review.Text = "Enroll";
            review.FlatStyle = FlatStyle.Flat;
            review.BackColor = Color.MediumAquamarine;
            review.Location = new Point(1173, 8);
            review.Size = new Size(175, 48);
            review.Click += enroll_Click;

            course.Controls.Add(name);
            course.Controls.Add(nametech);
            course.Controls.Add(date);
 
            course.Controls.Add(review);
            return course;
        }
     
        private void enroll_Click(object sender, EventArgs e)
        {
            Alert();
        }

        private void UCEnroll_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                flpListCourse.Controls.Add(EnrollCourse("Priciple progaming language", "Mr Duy", "12-10-2020 12-10-AM"));
            }
        }

        private void AutoCompleteSearch()
        {
            string query = @"Select courseID from COURSE";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            //use LINQ method syntax to pull the Title field from a DT into a string array...
            string[] postSource = data
                                .AsEnumerable()
                                .Select<System.Data.DataRow, String>(x => x.Field<String>("courseID"))
                                .ToArray();
            source.AddRange(postSource);

            tbCourseID.AutoCompleteCustomSource = source;
            tbCourseID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tbCourseID.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
