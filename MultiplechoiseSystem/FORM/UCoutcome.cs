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
    public partial class UCoutcome : UserControl
    {
        public UCoutcome()
        {
            InitializeComponent();
        }
        Panel panelCourse(CourseDTO course,int stt)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.LightCyan;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Size = new System.Drawing.Size(1349, 60);

            Label labelCourse = new Label();
            labelCourse.Location = new System.Drawing.Point(21, 13);
            labelCourse.Size = new System.Drawing.Size(1031, 30);
            labelCourse.Text = stt.ToString()+"          "+course.CourseID+"           "+course.CourseName;
            labelCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Button btnClick = new Button();
            btnClick.BackColor = System.Drawing.Color.SkyBlue;
            btnClick.FlatAppearance.BorderSize = 0;
            btnClick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClick.Location = new System.Drawing.Point(1058, -3);
            btnClick.Size = new System.Drawing.Size(291, 63);
            btnClick.Text = "view";
            btnClick.UseVisualStyleBackColor = false;
            btnClick.Click += btnClick_Click;
            btnClick.Tag = course;

            panel.Controls.Add(btnClick);
            panel.Controls.Add(labelCourse);
            return panel;
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            CourseDTO course = (sender as Button).Tag as CourseDTO;
            flpOutcomes.Size = new Size(1383, 489);
            panelOCdetail.Visible = true;
            LoadListOC(course.CourseID);
            idtemp = course.CourseID;
        }
        private void LoadListOC(string courseid)
        {
            flpListOC.Controls.Clear();
            foreach (CourseOutcomesDTO i in CourseOutcomesDAO.Instance.getListOCbyCourseID(courseid))
            {
                flpListOC.Controls.Add(panelOutcomes(i));
            }
        }
        private static string idtemp;
        Panel panelOutcomes(CourseOutcomesDTO courseOC)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.LightCyan;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Size = new System.Drawing.Size(1346, 38);

            Button btnEdit = new Button();
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Image = global::MultiplechoiseSystem.Properties.Resources.editQuestion;
            btnEdit.Location = new System.Drawing.Point(3, 0);
            btnEdit.Size = new System.Drawing.Size(37, 35);
            btnEdit.UseVisualStyleBackColor = true;

            Button btnDelete = new Button();
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Image = global::MultiplechoiseSystem.Properties.Resources.trash_can_30px;
            btnDelete.Location = new System.Drawing.Point(46, 0);
            btnDelete.Size = new System.Drawing.Size(37, 35);
            btnDelete.UseVisualStyleBackColor = true;

            Label lbDescription = new Label();
            lbDescription.Font = new System.Drawing.Font("Century Gothic", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbDescription.Location = new System.Drawing.Point(89, 3);

            lbDescription.Size = new System.Drawing.Size(1254, 30);

            lbDescription.Text = courseOC.Code + "    " + courseOC.description;
            lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            panel.Controls.Add(btnDelete);
            panel.Controls.Add(lbDescription);
            panel.Controls.Add(btnEdit);
            return panel;
        }
        private void LoadListCourse()
        {
            flpOutcomes.Controls.Clear();
            flpOutcomes.Size = new Size(1383, 770);
            int stt = 1;
            foreach(CourseDTO i in UserDAO.Instance.getCourseOfManager())
            {
                flpOutcomes.Controls.Add(panelCourse(i,stt));
                    stt++;
            }
        }
        private void UCoutcome_Load(object sender, EventArgs e)
        {
            LoadListCourse();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void Alert(string msg, FAlert.emType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private void btnAddOC_Click(object sender, EventArgs e)
        {
            string query = $"insert into COURSE_OUTCOMES VALUES ('{txtCodeCO.Text}','{idtemp}','{txtDescriptionOC.Text}')";
            Alert("Success !", FAlert.emType.success);
            DataProvider.Instance.ExecuteNonQuery(query);
            txtDescriptionOC.Text = "";
            txtCodeCO.Text = "";
            LoadListOC(idtemp);
        }
    }
}
