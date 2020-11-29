using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiplechoiseSystem.DAO;
using MultiplechoiseSystem.DTO;
namespace MultiplechoiseSystem.FORM
{
    public partial class UCinsertQuestion : UserControl
    {

        public UCinsertQuestion()
        {
            InitializeComponent();
        }
        void Alert(string msg, FAlert.emType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private static bool isManage = false;
        private void flp_question_Paint(object sender, PaintEventArgs e)
        {

        }

        private Panel ShowQuestion(QuestionDTO question )
        {
            Panel result = new Panel();
            result.Size = new Size(1353, 52);
            result.BackColor = Color.Gainsboro;
            Button btnEye = new Button();
            Button btnEdit = new Button();


            Button btnRecycleBin = new Button();

            btnRecycleBin.FlatAppearance.BorderSize = 0;
            btnRecycleBin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRecycleBin.Image = global::MultiplechoiseSystem.Properties.Resources.trash_can_30px;
            btnRecycleBin.Location = new System.Drawing.Point(89, 7);
            btnRecycleBin.Click += btnReccycleBin_Click;
            btnRecycleBin.Tag = question;

            btnRecycleBin.Size = new System.Drawing.Size(37, 35);

            btnRecycleBin.UseVisualStyleBackColor = true;

            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEye.Image = global::MultiplechoiseSystem.Properties.Resources.eye ;
            btnEye.Location = new System.Drawing.Point(3, 7);
             
            btnEye.Size = new System.Drawing.Size(37, 35);
            btnEye.Click += btnEye_Click;
            btnEye.Tag = question;

            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Image = global::MultiplechoiseSystem.Properties.Resources.editQuestion;
            btnEdit.Location = new System.Drawing.Point(46, 8);
            btnEdit.Size = new System.Drawing.Size(37, 35);
            btnEdit.Click += btnEdit_Click;
            btnEdit.Tag = question;

            Label courseID = new Label();
            Label questionText = new Label();
            Label Lecturer = new Label();
            Label DateCreated = new Label();

            courseID.Location = new Point(3, 11);
            questionText.Location = new Point(122, 12);
            Lecturer.Location = new Point(827, 11);
            DateCreated.Location = new Point(1106, 11);

            questionText.Size = new Size(699, 30);

            questionText.AutoSize = false;
            Lecturer.AutoSize = false;
            DateCreated.AutoSize = false;
            DateCreated.Size = new Size(244, 30);

            questionText.TextAlign = ContentAlignment.MiddleLeft;
            Lecturer.TextAlign = ContentAlignment.MiddleLeft;
            DateCreated.TextAlign = ContentAlignment.MiddleRight;

            questionText.Text =question.courseID+"    "+question.qText;
            courseID.Text = question.courseID;
            Lecturer.Text = question.lecturername;
            DateCreated.Text = question.datecreated.ToString("dd/MM/yyyy h:mm tt");
            btnEdit.Visible = true;
            btnRecycleBin.Visible = true;
          

            result.Controls.Add(btnEye);
            result.Controls.Add(questionText);
            result.Controls.Add(Lecturer);
            result.Controls.Add(DateCreated);
            result.Controls.Add(btnEdit);
            result.Controls.Add(btnRecycleBin);
            if (isManage==false)
            {
              
                btnEdit.Visible = false;
                btnRecycleBin.Visible = false;
                questionText.Size = new Size(775,  30);
                questionText.Location = new Point(46, 12);
            }
            return result;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            QuestionDTO question = (sender as Button).Tag as QuestionDTO;
            flp_question.Size = new Size(1389, 392);
            panel_createQuestion.Visible = true;

            question = QuenstionDAO.Instance.LoadQuestionByID(question.qID);
            richQuestion.Text = question.qText;
            richA.Text = question.answers[0].text;
            if (question.answers[0].inCorrect == 1)
                checkA.Checked = true;
            richA.Text = question.answers[0].text;
            if (question.answers[0].inCorrect == 1)
                checkA.Checked = true;

            richB.Text = question.answers[1].text;
            if (question.answers[1].inCorrect == 1)
                checkB.Checked = true;

            richC.Text = question.answers[2].text;
            if (question.answers[2].inCorrect == 1)
                checkC.Checked = true;

            richD.Text = question.answers[3].text;
            if (question.answers[3].inCorrect == 1)
                checkD.Checked = true;

            try
            {
                richE.Text = question.answers[4].text;
                if (question.answers[4].inCorrect == 1)
                    checkE.Checked = true;
            }
            catch
            {
               
            }


        }

        private void btnReccycleBin_Click(object sender, EventArgs e)
        {
            QuestionDTO question = (sender as Button).Tag as QuestionDTO;
            string query = $"Delete  QUESTION where qID={question.qID}";
            DataProvider.Instance.ExecuteNonQuery(query);
            LoadMyQuestion();
            Alert("Success !", FAlert.emType.success);
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            QuestionDTO question = (sender as Button).Tag as QuestionDTO;
            FShowQuestion showQuestion = new FShowQuestion(question.qID);
            showQuestion.ShowDialog();
        }

        private void LoadAllQuestion()
        {
            flp_question.Controls.Clear();
            string query = $"select * from QUESTION JOIN SYSTEMUSER on userID= uID  WHERE courseID in (select courseID from teach where userID='{UserDTO.Instance.userID}')";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow i in result.Rows)
            {
                QuestionDTO question = new QuestionDTO();
                question.courseID = i["courseID"].ToString().Trim();
                question.lecturername = i["LastName"].ToString().Trim() + " " + i["FirstName"].ToString().Trim();
                question.datecreated = (DateTime)i["DateCreated"];
                question.qText = i["qText"].ToString().Replace("\n"," ");
                question.qID = i["qID"].ToString().Trim();
                flp_question.Controls.Add(ShowQuestion(question));
            }


        }
        private void LoadMyQuestion()
        {
            flp_question.Controls.Clear();
            string query = $"select * from QUESTION  where userID= '{UserDTO.Instance.userID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow i in result.Rows)
            {
                QuestionDTO question = new QuestionDTO();
                question.courseID = i["courseID"].ToString().Trim();
                question.lecturername = UserDTO.Instance.FirstName + " " + UserDTO.Instance.LastName;
                question.datecreated = (DateTime)i["DateCreated"];
                question.qText = i["qText"].ToString().Replace("\n", " ");
                question.qID = i["qID"].ToString().Trim();
                flp_question.Controls.Add(ShowQuestion(question));
            }
        }
        private void UCinsertQuestion_Load(object sender, EventArgs e)
        {
            
           
            LoadListCOurseID();
            AutoCompleteSearch();
            LoadAllQuestion();
        }
        private void LoadListCOurseID()
        {
            string query = $"Select courseID from teach where userID= '{UserDTO.Instance.userID}' ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            List<string> t = new List<string>();
            foreach (DataRow i in result.Rows)
            {
                t.Add(i["courseID"].ToString());
            }
            cbIDcourse.DataSource = t.ToList();
        }
    
        private void AutoCompleteSearch()
        {
            string query = $"Select courseID from teach where userID= '{UserDTO.Instance.userID}' ";
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
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
                    }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            richA.Text = "";
            richB.Text = "";
            richC.Text = "";
            richD.Text = "";
            richE.Text = "";
            richQuestion.Text = "";
            checkA.Checked = false ;
            checkB.Checked = false;
            checkC.Checked = false;
            checkD.Checked = false;
            checkE.Checked = false;
        }

        private void richB_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnenter_Click(object sender, EventArgs e)
        {   
            if( richC.Text.Length==0)
            {
                MessageBox.Show("The question must have at least 4 answers!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ( (checkA.Checked || checkB.Checked || checkC.Checked || checkD.Checked || checkE.Checked) == false)
            {
                MessageBox.Show("The question must have at least one correct answer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            QuestionDTO question = new QuestionDTO();
            question.courseID = cbIDcourse.Text;
            question.userID = UserDTO.Instance.userID;
            question.qText = richQuestion.Text;
            Answer a = new Answer();
            Answer b = new Answer();
            Answer c = new Answer();
            Answer d = new Answer();
            Answer ee = new Answer();
            a.key = "a";
            a.text = richA.Text;
            if (checkA.Checked==true)
            {
                a.inCorrect = 1;
            }

            b.key = "b";
            b.text = richB.Text;
            if (checkB.Checked == true)
            {
                b.inCorrect = 1;
            }

            c.key = "c";
            c.text = richC.Text;
            if (checkC.Checked == true)
            {
                c.inCorrect = 1;
            }

            d.key = "d";
            d.text = richD.Text;
            if (checkD.Checked == true)
            {
                d.inCorrect = 1;
            }

            ee.key = "e";
            ee.text = richE.Text;
            if (checkD.Checked == true)
            {
                ee.inCorrect = 1;
            }

            question.answers.Add(a);
            question.answers.Add(b);
            question.answers.Add(c);
            question.answers.Add(d);
            if( richE.Text.Length!=0)
                question.answers.Add(ee);

            QuenstionDAO.Instance.insertQuestion(question);
            if (isManage == false)
                LoadAllQuestion();
            else
                LoadMyQuestion();
            Alert("Success !",FAlert.emType.success);
            btnClear_Click(sender, e);

                

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnShowAll.BackColor = Color.DeepSkyBlue;
            btnCreateQuesttion.BackColor = Color.DeepSkyBlue;
            btnManage.BackColor = Color.DeepSkyBlue;
            btnReturn.Visible = true;
            flp_question.Controls.Clear();
            if (tbCourseID.Text.Length != 0)
            {


                string query = $"select * from QUESTION JOIN SYSTEMUSER on userID= uID  WHERE courseID in (select courseID from teach where userID='{UserDTO.Instance.userID}' and courseID='{tbCourseID.Text}' )";
                DataTable result = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow i in result.Rows)
                {
                    QuestionDTO question = new QuestionDTO();
                    question.courseID = i["courseID"].ToString().Trim();
                    question.lecturername = i["LastName"].ToString().Trim() + " " + i["FirstName"].ToString().Trim();
                    question.datecreated = (DateTime)i["DateCreated"];
                    question.qText = i["qText"].ToString().Replace("\n", " ");
                    flp_question.Controls.Add(ShowQuestion(question));
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            btnShowAll.BackColor = Color.SteelBlue;
            btnCreateQuesttion.BackColor = Color.DeepSkyBlue;
            btnManage.BackColor = Color.DeepSkyBlue;
            btnReturn.Visible = false;
            isManage = false;
            LoadAllQuestion();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            btnShowAll.BackColor = Color.DeepSkyBlue;
            btnCreateQuesttion.BackColor = Color.DeepSkyBlue;
            btnManage.BackColor = Color.SteelBlue;
            isManage = true;
            btnReturn.Visible = true;
            LoadMyQuestion();
            
        }

        private void btnCreateQuesttion_Click(object sender, EventArgs e)
        {
            btnClear_Click(sender, e);
            flp_question.Size = new Size(1389, 392);
            panel_createQuestion.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panel_createQuestion.Visible = false;
            flp_question.Size = new Size(1389, 820);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void btnAddCO_Click(object sender, EventArgs e)
        {
            panel_outcome.Visible = true;
            foreach (CourseOutcomeDTO i in CourseDAO.Instance.getOutcome(cbIDcourse.Text))
            {
                flp_loadOC.Controls.Add(cbOutcome(i.cID+"  "+i.text));
            }
        
           

        }
        private CheckBox cbOutcome(string text)
        {
            CheckBox chx = new CheckBox();
            chx.Text = text;
            chx.AutoSize = false;
            chx.Size = new Size(1148, 41);
            chx.BackColor = Color.SkyBlue;
            return chx;
        }
        private void btnExitOC_Click(object sender, EventArgs e)
        {
            panel_outcome.Visible = false;
        }

        private void btnOKOC_Click(object sender, EventArgs e)
        {
            panel_outcome.Visible = false;
            Alert("Success !", FAlert.emType.success);

        }

        private void flp_loadOC_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
