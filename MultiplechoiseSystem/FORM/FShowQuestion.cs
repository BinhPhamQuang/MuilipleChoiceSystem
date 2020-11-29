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
    public partial class FShowQuestion : Form
    {
        private string Idquestion;
        public FShowQuestion(string idquestion)
        {
            Idquestion = idquestion;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private RichTextBox RichAnswer(string text, int iscorrect)
        {
            RichTextBox richTextBox3 = new RichTextBox();
            richTextBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            richTextBox3.Location = new System.Drawing.Point(3, 9);
           
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new System.Drawing.Size(972, 33);
           
            richTextBox3.Text = text;
            if (iscorrect == 1)
            {
                richTextBox3.ForeColor = Color.MediumSeaGreen;
            }
            else
                richTextBox3.ForeColor = Color.Crimson;
            return richTextBox3;
        }
        private void FShowQuestion_Load(object sender, EventArgs e)
        {
            QuestionDTO question = QuenstionDAO.Instance.LoadQuestionByID(Idquestion);
            richQuestion.Text = question.qText;
            foreach (Answer i in question.answers)
            {
                flp_answers.Controls.Add(RichAnswer(i.text, i.inCorrect));
            }
        }

        private void flp_answers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
