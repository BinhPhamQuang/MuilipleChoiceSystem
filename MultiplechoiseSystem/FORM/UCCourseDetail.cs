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
using LiveCharts;
using LiveCharts.Wpf;

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
        private Panel createFrameResult(SheetDTO sheet)
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

            Fullname.Text = sheet.Fullname;
            Fullname.AutoSize = false;
            Fullname.Location = new Point(58, 24);
            Fullname.Size = new Size(390, 30);
            Fullname.TextAlign = ContentAlignment.MiddleCenter;

            dateDo.Text =sheet.DateTake.ToString("dd/MM/yyyy h:mm tt");
            dateDo.Location = new Point(510, 24);
            dateDo.AutoSize = false;
            dateDo.TextAlign = ContentAlignment.MiddleLeft;
            dateDo.Size = new Size(404, 30);

            scoreTest.Text = sheet.Marks;
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
            detail.Tag = sheet;
            

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
            SheetDTO sheet = (sender as Button).Tag as SheetDTO;
            string query = $"select codetest from SHEET_ANSWER where userID='{sheet.userID}' and examID='{sheet.examID}' and courseID='{sheet.courseID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
      
            string codeexam = result.Rows[0]["codeTest"].ToString();
            FTest1 f = new FTest1(codeexam, UserDTO.Instance.examSelected.courseID, UserDTO.Instance.examSelected.examID, sheet.userID , true);
            f.Show();
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
             
                CheckStatusReview();
             
            
         
             
        }
        private void CheckStatusReview()
        {
            string query = $"select * from SHEET_ANSWER where examID='{UserDTO.Instance.examSelected.examID}' and CourseID='{UserDTO.Instance.examSelected.courseID}' and userID='{UserDTO.Instance.userID}'";
            DataTable a=DataProvider.Instance.ExecuteQuery(query);
            if (a.Rows.Count == 0 && UserDTO.Instance.UserType == UserDTO.Instance.Student)
                btnDo.Visible = true;
            else
            {
                if (UserDTO.Instance.UserType == UserDTO.Instance.Student)
                    foreach( SheetDTO i in SheetAnswerDAO.Instance.getSheetAnswerByIduser(UserDTO.Instance.examSelected.examID, UserDTO.Instance.examSelected.courseID, UserDTO.Instance.userID))
                    {
                        flp_result.Controls.Add(createFrameResult(i));
                    }
                else
                {
                    foreach (SheetDTO i in SheetAnswerDAO.Instance.getAllSheetAnswer(UserDTO.Instance.examSelected.examID, UserDTO.Instance.examSelected.courseID))
                    {
                        flp_result.Controls.Add(createFrameResult(i));
                    }
                }
            }
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
            try
            {
                List<TestDTO> lst = TestDAO.Instance.getListTestByExamID_courseID(UserDTO.Instance.examSelected.examID, UserDTO.Instance.examSelected.courseID);

                string codeexam = lst[random.Next(0, lst.Count)].code;
                FTest1 f = new FTest1(codeexam, UserDTO.Instance.examSelected.courseID, UserDTO.Instance.examSelected.examID, UserDTO.Instance.userID, false);
                btnDo.Visible = false;
                f.ShowDialog();
                CheckStatusReview();
            }
            catch(Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }
        Func<ChartPoint,string> labelPoint= chartpoint => string.Format("{0} ({1:P})", chartpoint.Y , chartpoint.Participation);
        private void Analysis()
        {
            SeriesCollection series = new SeriesCollection();
            string query = $"select MARKS, COUNT(*) AS C from sheet_answer where courseID='{UserDTO.Instance.examSelected.courseID}' and examID='{UserDTO.Instance.examSelected.examID}' GROUP BY Marks";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                series.Add(new PieSeries() {Title=i["Marks"].ToString().Trim(),Values=new ChartValues<int> { (int)i["c"]},DataLabels=true, LabelPoint=labelPoint });

            }
            pieChart1.Series = series;
        }
        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            panel_analys.Visible = true;
            Analysis();
        }

        private void btnCLoseAnalys_Click(object sender, EventArgs e)
        {
            panel_analys.Visible = false;
        }
    }
}
