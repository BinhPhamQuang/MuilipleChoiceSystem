﻿using System;
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

    public partial class FTest1 : Form
    {

        private List<SelectedAnswer> lstSeleteced = new List<SelectedAnswer>();
        private static bool isReview = false;
        private int counter = 10;
        private string codeExam;
        private string courseID;
        private string examID;
        private string userID;
        public FTest1(string CodeExam, string CourseID, string ExamID, string UserID, bool review)
        {
            InitializeComponent();
            codeExam = CodeExam;
            courseID = CourseID;
            examID = ExamID;
            isReview = review;
            userID = UserID;
        }
        private System.Windows.Forms.Timer aTimer;
        private System.Windows.Forms.Timer secondTimer;
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flp_question_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadTimeTest()
        {
            aTimer = new System.Windows.Forms.Timer();
            secondTimer = new System.Windows.Forms.Timer();
            aTimer.Tick += new EventHandler(aTimer_Tick);
            secondTimer.Tick += new EventHandler(secondTimer_Tick);
            aTimer.Interval = 1000 * 60; // 1 second
            secondTimer.Interval = 1000;
            if (isReview == false)
            {
                aTimer.Start();
                secondTimer.Start();
            }
            lb_second.Text = countMinutes.ToString();
            lb_minutes.Text = counter.ToString();
        }
        private int countMinutes = 59;
        private void secondTimer_Tick(object sender, EventArgs e)
        {
            countMinutes--;

            if (countMinutes == 0)
                countMinutes = 59;


            lb_second.Text = countMinutes.ToString();
        }

        private void FTest1_Load(object sender, EventArgs e)
        {
            if (UserDTO.Instance.UserType == UserDTO.Instance.Student)
            {
                buttonExit.Visible = false;
            }
            LoadTitle();

            LoadQuestions();
            LoadTimeTest();
            if (isReview==false)
            {
                btnCLose.Visible = false;
                btnSubmit.Visible = true;
            }

        }
        private void LoadTitle()
        {
            string query = $"select * from exam join course on exam.CourseId= course.courseID where exam.CourseID='{courseID}' and eID='{examID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            counter = (int)result.Rows[0]["ExamTime"] - 1;
            lb_namecourse.Text = result.Rows[0]["CourseName"].ToString().Trim();
            lbCodeTest.Text = result.Rows[0]["eID"].ToString().Trim();

        }
        private Random random = new Random();
        private List<int> randomList(int n)
        {
            List<int> lst = new List<int>();

            while (lst.Count != n)
            {
                int number = random.Next(0, n);
                if (!lst.Contains(number))
                {
                    lst.Add(number);
                }

            }

            return lst;
        }
        private void LoadQuestions()
        {

            flp_question.Controls.Clear();
            List<QuestionDTO> lst = QuenstionDAO.Instance.LoadListQuestionOfTest(codeExam, examID, courseID);
            int stt = 1;
            List<int> randomQuestion = randomList(lst.Count);
            for (int i = 0; i < lst.Count; i++)
            {
                flp_question.Controls.Add(layoutQuestion(lst[randomQuestion[i]], stt, 0));
                stt++;
            }


        }
        private void aTimer_Tick(object sender, EventArgs e)

        {

            counter--;

            if (counter == 0)
            {
                aTimer.Stop();
                secondTimer.Stop();
            }

            lb_minutes.Text = counter.ToString();

        }
        private Panel layoutQuestion(QuestionDTO question, int stt, int isCorrect)
        {
            Panel panel = new Panel();
            panel.AutoSize = true;
            panel.BackColor = Color.Gainsboro;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Size = new System.Drawing.Size(1618, 334);

            RichTextBox richQuestion = new RichTextBox();
            richQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richQuestion.Cursor = System.Windows.Forms.Cursors.Arrow;
            richQuestion.BackColor = Color.LightGray;
            richQuestion.EnableAutoDragDrop = true;
            richQuestion.Location = new System.Drawing.Point(150, 9);
            richQuestion.ReadOnly = true;
            richQuestion.Size = new System.Drawing.Size(1465, 107);
            richQuestion.Text = question.qText;


            Label lbQuestion = new Label();
            lbQuestion.AutoSize = true;
            lbQuestion.Location = new System.Drawing.Point(3, 9);
            lbQuestion.Size = new System.Drawing.Size(140, 30);
            lbQuestion.Text = "Question " + stt.ToString();

            Button btnComplete = new Button();
            btnComplete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            btnComplete.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            btnComplete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            btnComplete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            btnComplete.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnComplete.Location = new System.Drawing.Point(0, 301);
            btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnComplete.BackColor = SystemColors.ActiveCaption;
            btnComplete.Click += btnCompleteQuestion_Click;
            List<object> lstObject = new List<object>();
            lstObject.Add(question);
            lstObject.Add(stt);
            btnComplete.Tag = lstObject;

            btnComplete.Size = new System.Drawing.Size(147, 34);

            btnComplete.Text = "Complete";
            btnComplete.UseVisualStyleBackColor = true;

            if (isReview == true)
            {
                Button btnReport = new Button();
                btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
                btnReport.FlatAppearance.BorderSize = 0;
                btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnReport.Image = global::MultiplechoiseSystem.Properties.Resources.flag;
                btnReport.Location = new System.Drawing.Point(0, 301);
                btnReport.Size = new System.Drawing.Size(27, 30);
                btnReport.UseVisualStyleBackColor = true;
                btnReport.Click += btnReport_Click;
                btnReport.Tag = question;

                Label lbCorrect = new Label();
                lbCorrect.AutoSize = true;

                lbCorrect.Location = new System.Drawing.Point(3, 39);

                lbCorrect.Size = new System.Drawing.Size(118, 30);
                lbCorrect.ForeColor = System.Drawing.Color.LimeGreen;
                lbCorrect.Text = "Correct !";

                if (isCorrect == 0)
                {
                    lbCorrect.ForeColor = System.Drawing.Color.Red;
                    lbCorrect.Text = "Wrong !";
                }
                Panel pnNode = new Panel();
                pnNode.Location = new System.Drawing.Point(81, 93);
                pnNode.Size = new System.Drawing.Size(453, 232);

                Button btnNote = new Button();
                btnNote.FlatAppearance.BorderSize = 0;
                btnNote.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnNote.Image = global::MultiplechoiseSystem.Properties.Resources.note_50px;
                btnNote.Location = new System.Drawing.Point(3, 292);
                btnNote.Click += btnNode_click;
                btnNote.Tag =  new object[] { pnNode, question.qID };
                btnNote.Size = new System.Drawing.Size(57, 48);


                

                RichTextBox richNote = new RichTextBox();
                richNote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                richNote.Location = new System.Drawing.Point(3, 30);
                richNote.Size = new System.Drawing.Size(444, 165);
                richNote.Text = "";
                pnNode.Controls.Add(richNote);

                Button btnSave = new Button();
                btnSave.FlatAppearance.BorderSize = 0;
                btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnSave.Image = global::MultiplechoiseSystem.Properties.Resources.save_30px;
                btnSave.Location = new System.Drawing.Point(414, 199);

                btnSave.Size = new System.Drawing.Size(36, 28);
                btnSave.UseVisualStyleBackColor = true;
                btnSave.Click += btnExitNote_Click;
                btnSave.Tag = pnNode;
                Button btnExit = new Button();
                btnExit.FlatAppearance.BorderSize = 0;
                btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btnExit.Image = global::MultiplechoiseSystem.Properties.Resources.close_window_30px;
                btnExit.Location = new System.Drawing.Point(424, 0);
                btnExit.Click += btnExitNote_Click;
                btnExit.Tag = pnNode;

                btnExit.Size = new System.Drawing.Size(29, 30);

                pnNode.Visible = false;
                pnNode.Controls.Add(btnSave);
                pnNode.Controls.Add(btnExit);
                    
                panel.Controls.Add(btnNote);
                panel.Controls.Add(pnNode);
                //panel.Controls.Add(lbCodeTest);
            }
            int NumOfAnswer = 1; int NumOfRightAnswer = 0;
            foreach (Answer i in question.answers)
            {
                NumOfAnswer += 1;
                NumOfRightAnswer += i.inCorrect;
            }
            if (NumOfRightAnswer > 1)
            {
                FlowLayoutPanel p;
                p = checkBoxAnswer(question.answers);
                panel.Controls.Add(p);
            }
            else
            {
                FlowLayoutPanel p;
                p = cbBoxAnswer(question.answers);

                panel.Controls.Add(p);
            }
            panel.Controls.Add(richQuestion);
            panel.Controls.Add(lbQuestion);
            //panel.Controls.Add(btnComplete);
            return panel;
        }

        private void btnExitNote_Click(object sender, EventArgs e)
        {
            Panel panel = (sender as Button).Tag as Panel;
            panel.Visible = false;
        }

        private void btnNode_click(object sender, EventArgs e)
        {
            object[] obj = (sender as Button).Tag as object[];
            Panel panel = (Panel)(obj[0]);
            panel.Visible = true;
        }

        private void btnCompleteQuestion_Click(object sender, EventArgs e)
        {
            List<object> lst = (sender as Button).Tag as List<object>;
            MessageBox.Show(lst[1].ToString());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not finish !");
        }

        FlowLayoutPanel checkBoxAnswer(List<Answer> lstAnswer)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AllowDrop = true;
            panel.Location = new System.Drawing.Point(150, 133);
            panel.Size = new System.Drawing.Size(1465, 153);
            int count = 1;
            foreach (Answer i in lstAnswer)
            {
                CheckBox check = new CheckBox();
                check.AutoSize = false;
                check.Size = new Size(1462, 33);
                check.Text = i.text;
                check.CheckedChanged += cbBoxAnswer_CheckChanged;
                check.Tag = i;
                count++;
                panel.Controls.Add(check);
                if (isReview==true)
                {
                    if (isIn(i.key, QuenstionDAO.Instance.answerSelected(userID, examID, courseID, i.questionID)))
                    {
                        check.Checked = true;
                        if (i.inCorrect == 0)
                        {
                            check.BackColor = Color.Crimson;

                        }
                    }
                        check.Enabled = false;
                    if (i.inCorrect == 1)
                    check.BackColor = Color.LightGreen;
                }
                    
                if (lstAnswer.Count == 5)
                {
                    panel.Size = new Size(1465, 198);
                }
            }
            return panel;
        }
        private bool SearchQuestionID(string qID)
        {
            foreach (SelectedAnswer i in lstSeleteced)
            {

                if (i.idquestion == qID)
                    return true;
            }
            return false;
        }
        private void UpdateAnswer(string qID, Answer answer)
        {
            foreach (SelectedAnswer i in lstSeleteced)
            {
                if (i.idquestion == qID)
                {
                    foreach (Answer j in i.seletected)
                    {
                        if (j.key == answer.key)
                        {
                            i.seletected.Remove(j);
                            return;
                        }


                    }
                    i.seletected.Add(answer);

                    return;
                }
            }
        }
        private void cbBoxAnswer_CheckChanged(object sender, EventArgs e)
        {

            Answer answer = (sender as CheckBox).Tag as Answer;
            if (SearchQuestionID(answer.questionID) == true)
            {
                UpdateAnswer(answer.questionID, answer);

            }
            else
            {
                SelectedAnswer i = new SelectedAnswer();
                i.idquestion = answer.questionID;
                i.seletected.Add(answer);
                lstSeleteced.Add(i);

            }

        }
        bool isIn( string key, List<Answer> answers)
        {
              foreach (Answer i in answers)
            {
                if (key == i.key)
                    return true;
            }
            return false;
        }
           
        FlowLayoutPanel cbBoxAnswer(List<Answer> lstAnswer)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.AllowDrop = true;
            panel.Location = new System.Drawing.Point(150, 133);
            panel.Size = new System.Drawing.Size(1465, 153);

            int count = 1;
            foreach (Answer i in lstAnswer)
            {
                RadioButton check = new RadioButton();
                check.AutoSize = false;
                check.Size = new Size(1462, 33);
                check.Text = i.text;
                check.CheckedChanged += RadioAnswer_CheckChanged;
                check.Tag = i;
                count++;
                panel.Controls.Add(check);
                if (isReview == true)
                {
                    if (isIn(i.key, QuenstionDAO.Instance.answerSelected(userID, examID, courseID, i.questionID)))
                    {
                        check.Checked = true;
                        if (i.inCorrect==0)
                        {
                            check.BackColor = Color.Crimson;

                        }
                  

                    }
                    check.Enabled = false;
                    if (i.inCorrect == 1)
                        check.BackColor = Color.LightGreen;
                }
                if (lstAnswer.Count == 5)
                {
                    panel.Size = new Size(1465, 198);
                }
            }


            return panel;
        }

        private void RadioAnswer_CheckChanged(object sender, EventArgs e)
        {   
            Answer answer = (sender as RadioButton).Tag as Answer;
            if (SearchQuestionID(answer.questionID) == true)
            {
                UpdateAnswer(answer.questionID, answer);

            }
            else
            {
                SelectedAnswer i = new SelectedAnswer();
                i.idquestion = answer.questionID;
                i.seletected.Add(answer);
                lstSeleteced.Add(i);

            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (UserDTO.Instance.UserType != UserDTO.Instance.Student)
            {
                this.Close();
                return;
            }
            int wrong = 0;
            foreach (SelectedAnswer i in lstSeleteced)
            {
                foreach (Answer j in i.seletected)
                {
                    if (j.inCorrect == 0)
                    {
                        wrong += 1;
                        break;
                    }
                }
            }
            Alert();
               
            double marks = 10 - (10.0 * wrong) / lstSeleteced.Count;
            string query = $"insert into SHEET_ANSWER values ('{1}','{UserDTO.Instance.userID}','{codeExam}','{examID}','{courseID}',GETDATE(),{marks},'{marks.ToString("0.00")}' )";
            DataProvider.Instance.ExecuteQuery(query);
            int count = 1;
            foreach (SelectedAnswer i in lstSeleteced)
            {
                
                foreach (Answer j in i.seletected)
                {
                    count++;
                    query = $"insert into ANSWER_ORDER VALUES ('{1}','{UserDTO.Instance.userID}','{codeExam}','{examID}','{courseID}',{count},'{i.idquestion}','{j.key}')";
                    DataProvider.Instance.ExecuteNonQuery(query);
                }
            }
            
            this.Close();


        }

        void Alert(string msg = "Success !", FAlert.emType type = FAlert.emType.success)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flp_question_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
