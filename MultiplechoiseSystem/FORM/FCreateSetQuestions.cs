using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplechoiseSystem.DAO;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.FORM
{
    public partial class FCreateSetQuestions : Form
    {
        private string idCourse;
        private List<QuestionDTO> lstAdd = new List<QuestionDTO>();
        public FCreateSetQuestions(string idcourse)
        {
            
            InitializeComponent();
            idCourse = idcourse;
        }
        private Panel createPanelQuestion(QuestionDTO question,int stt)
        {
            Panel panel = new Panel();
            Label lbSTT = new Label();
            CheckBox cbSelect = new CheckBox();
            Button btnEye = new Button();
            Label lbQuestion = new Label();
            ComboBox cbIsMandantory = new ComboBox();

            panel.BackColor = System.Drawing.Color.LightCyan;
            panel.Size = new System.Drawing.Size(1433, 52);

            cbSelect.CheckedChanged += cbSelect_Checkedchanged;
            cbSelect.Tag = question;
            cbSelect.Location = new System.Drawing.Point(48, 21);
            cbSelect.Text = "";

            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEye.Image = global::MultiplechoiseSystem.Properties.Resources.eye;
            btnEye.Location = new System.Drawing.Point(72, 10);
            btnEye.Size = new System.Drawing.Size(37, 35);
        
            btnEye.Click += btnEye_Click;
            btnEye.Tag = question;

            lbQuestion.Location = new System.Drawing.Point(115, 15);
            lbQuestion.Size = new System.Drawing.Size(1119, 30);
            lbQuestion.Text = question.qText.Trim();
            lbQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            lbSTT.Location = new System.Drawing.Point(3, 17);
            lbSTT.Text = stt.ToString();

            cbIsMandantory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            cbIsMandantory.BackColor = System.Drawing.Color.LightCyan;
            cbIsMandantory.SelectedIndexChanged += cbIsMandantorySelectedIndexChanged;
            cbIsMandantory.Tag = question;
           
            cbIsMandantory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbIsMandantory.FormattingEnabled = true;
            cbIsMandantory.Items.AddRange(new object[] {
            "Must do",
            "Can not do"});
            cbIsMandantory.Location = new System.Drawing.Point(1240, 10);
         
            cbIsMandantory.Size = new System.Drawing.Size(186, 35);
           

            panel.Controls.Add(cbSelect);
            panel.Controls.Add(lbSTT);
            panel.Controls.Add(btnEye);
            panel.Controls.Add(lbQuestion);
            panel.Controls.Add(cbIsMandantory);
            btnEye.BringToFront();
            lbQuestion.BringToFront();
            return panel;
        }

        private void cbIsMandantorySelectedIndexChanged(object sender, EventArgs e)
        {
            QuestionDTO question = (sender as ComboBox).Tag as QuestionDTO;
            ComboBox cb1 = (sender as ComboBox);
            if( cb1.SelectedIndex==0)
            {
               foreach ( QuestionDTO i in lstAdd)
                {
                    if (i.qID==question.qID)
                    {
                        i.Option = 1;
                        return;
                    }
                }
            }
            else
            {
                foreach (QuestionDTO i in lstAdd)
                {
                    if (i.qID == question.qID)
                    {
                        i.Option = 0;
                        return;
                    }
                }
            }
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            QuestionDTO question = (sender as Button).Tag as QuestionDTO;
            FShowQuestion showQuestion = new FShowQuestion(question.qID);
            showQuestion.ShowDialog();
            
        }

        private void cbSelect_Checkedchanged(object sender, EventArgs e)
        {
            QuestionDTO t = (sender as CheckBox).Tag as QuestionDTO;
            CheckBox tt = (sender as CheckBox);
            if (tt.Checked)
            {
                foreach (QuestionDTO i in lstAdd)
                {
                    if(t.qID==i.qID)
                    {
                        return;
                    }
                }
                lstAdd.Add(t);
               
            }
           else
            {
                
                 lstAdd.Remove(t);
                    
            }
        }
        private void LoadExamName()
        {
            string query = $"Select * from Exam where CourseID='{idCourse}' AND DATEDIFF(day, TestDay,GETDATE())<0";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            List<string> examName = new List<string>();
            foreach(DataRow i in result.Rows)
            {
                examName.Add(i["eID"].ToString().Trim());
            }

            cbExamName.DataSource = examName.ToList();
        }
        private void LoadQuestion()
        {
            flp_question.Controls.Clear();
            int stt = 1;
            foreach (QuestionDTO i in QuenstionDAO.Instance.loadListQuestionByCourseIDtoCreateSetQuestion(idCourse,cbExamName.Text))
            {
                flp_question.Controls.Add(createPanelQuestion(i, stt));
                stt++;
            }
            string query = $"Select * from SHOWQUESTION where courseID='{idCourse}' and examID='{cbExamName.Text}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            try
            {
                lbLastTimeUpdate.Text = "Last updated time: " + ((DateTime)result.Rows[0]["LastTimeUpdate"]).ToString("dd/MM/yyyy h:mm tt");
            }
            catch
            {
                lbLastTimeUpdate.Text = "";
            }

        }
        private void FCreateSetQuestions_Load(object sender, EventArgs e)
        {
            
            LoadExamName();
            
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flp_question_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int stt = 1;
            foreach (QuestionDTO i in lstAdd)
            {
                string query = $"INSERT INTO SHOWQUESTION (sNO,questionID,examID,courseID,QuestionOption) VALUES ({stt},'{i.qID}','{cbExamName.Text}','{i.courseID}',{i.Option})";
                stt++;
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            Alert("Success !", FAlert.emType.success);
            LoadQuestion();


        }

        void Alert(string msg = "Success !", FAlert.emType type = FAlert.emType.success)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }

        private void cbExamName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadQuestion();
            loadTest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pn_displayTest.Visible = true;
            flp_question.Size = new Size(1467, 340);
            pnCreateTest.Visible = true;
            loadTest();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnCreateTest.Visible = false;
            Alert("Success !", FAlert.emType.success);
        }

        private Panel pnTest(TestDTO test)
        {
            Panel panel = new Panel();
            Label lbNametest = new Label();
            Button btnDelete = new Button();
            Button btnView = new Button();
            panel.BackColor = System.Drawing.Color.LightCyan;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Size = new Size(281, 49);

            lbNametest.Location = new System.Drawing.Point(89, 9);
            lbNametest.Size = new System.Drawing.Size(192, 30);
            lbNametest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lbNametest.Text = test.code;

            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Image = global::MultiplechoiseSystem.Properties.Resources.trash_can_30px;
            btnDelete.Location = new System.Drawing.Point(46, 7);
            btnDelete.Size = new System.Drawing.Size(37, 35);
            btnDelete.Click += btnDelete_Click;
            btnDelete.Tag = test;

            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnView.Image = global::MultiplechoiseSystem.Properties.Resources.eye;
            btnView.Location = new System.Drawing.Point(3, 7);
            btnView.Size = new System.Drawing.Size(37, 35);
            btnView.Click += btnView_Click;
            btnView.Tag = test;


            panel.Controls.Add(btnView);
            panel.Controls.Add(btnDelete);
            panel.Controls.Add(lbNametest);
            return panel;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            TestDTO test = (sender as Button).Tag as TestDTO;
            string query = $"DELETE test where Code='{test.code}'";
            try
            {
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
                return;
            }
            loadTest();
            Alert("Success !", FAlert.emType.success);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            TestDTO test = (sender as Button).Tag as TestDTO;
            FTest f = new FTest(test.code,test.courseID, test.examID, false);
            f.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pn_displayTest.Visible = false;
            flp_question.Size = new Size(1467, 659);
        }
        private void loadTest()
        {
            flp_test.Controls.Clear();
            List<TestDTO> lst = TestDAO.Instance.getListTestByExamID_courseID(cbExamName.Text, idCourse);
            foreach(TestDTO i in lst)
            {
                flp_test.Controls.Add(pnTest(i));
            }
        }
        private Random random = new Random();
        private List<int> randomList(int n)
        {
            List<int> lst = new List<int>();
            
            while(lst.Count!=n)
            {
                int number = random.Next(0, n);
                if (! lst.Contains(number))
                {
                    lst.Add(number);
                }
                  
            }
           
            return lst;
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            string[] key = { "A", "B", "C", "D" ,"E" };

            List<QuestionDTO> lst = QuenstionDAO.Instance.LoadListShowQuestionWithAnswers(cbExamName.Text, idCourse);
            for (int i = 0; i < int.Parse(numTest.Value.ToString()); i++)
            {
                string code = txtFormatCode.Text + i.ToString();
                string query = $"INSERT INTO TEST (Code,examID,courseID,DateApprove,DateConfirm) VALUES ('{code}','{cbExamName.Text}','{idCourse}',GETDATE(),GETDATE())";
               
                    DataProvider.Instance.ExecuteNonQuery(query);
                    
                    List<int> randomQuestion = randomList(lst.Count);
                    for (int index=0; index < lst.Count;index++)
                    {
                        List<int> randomAnswer = randomList(lst[randomQuestion[index]].answers.Count);
                        for (int indexAnswer=0; indexAnswer<randomAnswer.Count;indexAnswer++)
                        {
                        query = $"INSERT INTO CREATE_TEST_QUESTION values ({indexAnswer},'{key[indexAnswer].ToString()}','{idCourse}','{code}','{cbExamName.Text}','{lst[randomQuestion[index]].NO}','{lst[randomQuestion[index]].qID}','{lst[randomQuestion[index]].answers[randomAnswer[indexAnswer]].key}')";
                        DataProvider.Instance.ExecuteNonQuery(query);
                        }
                    }
                    
                   
                 


                 
            }


            loadTest();
            Alert("Success ! ", FAlert.emType.success);
        }
    }
}
