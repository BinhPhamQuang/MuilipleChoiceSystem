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
using MultiplechoiseSystem.DAO;
namespace MultiplechoiseSystem.FORM
{
    public partial class UCCourseDetail : UserControl
    {
        public EventHandler BtnCloseClick;
         
        public UCCourseDetail()
        {
            InitializeComponent();
            
            AutoCompleteSearch();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_namecourse_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           if (this.BtnCloseClick != null)
            {
                this.BtnCloseClick(this, e);
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

            txtSearchResult.AutoCompleteCustomSource = source;
            txtSearchResult.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtSearchResult.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        private void pn_result_st_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchResult.Clear();
        }
        private int COUNT_NO =1;
        private Panel createFrameResult(string id,string name,double scores, string date)
        {
            Panel p = new Panel();
            p.Size = new Size(1365, 70);
            p.BackColor = SystemColors.InactiveCaption;

            Label NO = new Label();
            Label Fullname = new Label();
            Label dateDo = new Label();
            Label scoreTest = new Label();
            Button detail = new Button();

         
            NO.Text = COUNT_NO.ToString();
            NO.Location = new Point(5, 24);

            Fullname.Text = name;
            Fullname.AutoSize = false;
            Fullname.Location = new Point(58, 24);
            Fullname.Size = new Size(390, 30);
            Fullname.TextAlign = ContentAlignment.MiddleCenter;

            dateDo.Text =date;
            dateDo.Location = new Point(510, 24);
            dateDo.AutoSize = false;
            dateDo.TextAlign = ContentAlignment.MiddleLeft;
            dateDo.Size = new Size(404, 30);

            scoreTest.Text = scores.ToString();
            scoreTest.Location = new Point(956, 24);
            scoreTest.AutoSize = false;
            scoreTest.Size = new Size(121, 30);
            scoreTest.TextAlign = ContentAlignment.MiddleCenter;

            detail.Text = "Detail";
            detail.Location = new Point(1167, 0);
            detail.Size = new Size(218, 70);
            detail.FlatStyle = FlatStyle.Flat;
            detail.FlatAppearance.BorderSize = 0;
            detail.BackColor = System.Drawing.SystemColors.ActiveCaption;
        
 
    
 
            detail.Click += Btndetail_Click;
            

            COUNT_NO += 1;
            p.Controls.Add(NO);
            p.Controls.Add(Fullname);
            p.Controls.Add(dateDo);
            p.Controls.Add(scoreTest);
            p.Controls.Add(detail);
            return p;
        }

        private void Btndetail_Click(object sender, EventArgs e)
        {
            
        }

        private void DisplayManagerFunction()
        {   
            
            if (UserDTO.Instance.UserType.Trim()== UserDTO.Instance.Student)
            {
                pn_search.Visible = false;
                pn_manage.Visible = false;
                
            }
            else
            {
                pn_search.Visible = true;
                pn_manage.Visible = true;
            }
            
        }

        private void Displaylabel()
        {
            lb_namecourse.Text = UserDTO.Instance.examSelected.examID+"         "+ UserDTO.Instance.examSelected.courseName;
            lbTimeTest.Text = UserDTO.Instance.examSelected.ExamTime+" minutes";
            label3.Text = UserDTO.Instance.examSelected.testDate.ToString();
            lbnguoirade.Text = UserDTO.Instance.examSelected.teacherCreate;
        }
        private void UCCourseDetail_Load(object sender, EventArgs e)
        {
            DisplayManagerFunction();
            Displaylabel();
            if( UserDTO.Instance.UserType==UserDTO.Instance.Student)
                CheckStatusReview();
             
        }
        private void CheckStatusReview()
        {
            string query = $"select * from SHEET_ANSWER where examID='Final' and CourseID='CO2003' and userID='1'";
            DataTable a=DataProvider.Instance.ExecuteQuery(query);
            if (a.Rows.Count == 0)
                btnDo.Visible = true;
        }


        private void flp_result_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void bnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            Random random = new Random();
        
            List<TestDTO> lst = TestDAO.Instance.getListTestByExamID_courseID(UserDTO.Instance.examSelected.examID, UserDTO.Instance.examSelected.courseID);

            string codeexam = lst[random.Next(0, lst.Count)].code;
            FTest f = new FTest(codeexam,UserDTO.Instance.examSelected.courseID, UserDTO.Instance.examSelected.examID,false);
           f.ShowDialog();
        }
    }
}
