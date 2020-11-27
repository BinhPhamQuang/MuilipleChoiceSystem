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

            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEye.Image = global::MultiplechoiseSystem.Properties.Resources.eye ;
            btnEye.Location = new System.Drawing.Point(3, 7);
             
            btnEye.Size = new System.Drawing.Size(37, 35);

            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Image = global::MultiplechoiseSystem.Properties.Resources.editQuestion;
            btnEdit.Location = new System.Drawing.Point(46, 8);
                    btnEdit.Size = new System.Drawing.Size(37, 35);

            Label courseID = new Label();
            Label questionText = new Label();
            Label Lecturer = new Label();
            Label DateCreated = new Label();

            courseID.Location = new Point(3, 11);
            questionText.Location = new Point(99, 12);
            Lecturer.Location = new Point(827, 11);
            DateCreated.Location = new Point(1106, 11);

            questionText.Size = new Size(722, 30);

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
            

            result.Controls.Add(btnEye);
            result.Controls.Add(questionText);
            result.Controls.Add(Lecturer);
            result.Controls.Add(DateCreated);
            result.Controls.Add(btnEdit);
            if (isManage==false)
            {
                btnEdit.Visible = false;
            }
            return result;
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
            LoadAllQuestion();
            Alert("Success !",FAlert.emType.success);
            btnClear_Click(sender, e);

                

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
            btnReturn.Visible = false;
            LoadAllQuestion();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            btnReturn.Visible = true;
        }

        private void btnCreateQuesttion_Click(object sender, EventArgs e)
        {
            flp_question.Size = new Size(1389, 392);
            panel_createQuestion.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            panel_createQuestion.Visible = false;
            flp_question.Size = new Size(1389, 820);
        }
    }
}
