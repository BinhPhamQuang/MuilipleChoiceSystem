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
    public partial class FConfirmTest : UserControl
    {
        public FConfirmTest()
        {
            InitializeComponent();
        }
        private void LoadListTest()
        {
            List<TestDTO> lst = TestDAO.Instance.getListFullTestbyManager(UserDTO.Instance.userID);
            foreach( TestDTO i in lst)
            {
                flpConfirmTest.Controls.Add(PanelTest(i));
            }
        }
        private void FConfirmTest_Load(object sender, EventArgs e)
        {
            LoadListTest();
        }
        private Panel PanelTest(TestDTO test)
        {
            Panel panel = new Panel();
            panel.BackColor = System.Drawing.Color.LightCyan;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Size = new System.Drawing.Size(1349, 60);

            Button btnEye = new Button();
            btnEye.FlatAppearance.BorderSize = 0;
            btnEye.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEye.Image = global::MultiplechoiseSystem.Properties.Resources.eye;
            btnEye.Location = new System.Drawing.Point(3, 14);
            btnEye.Size = new System.Drawing.Size(37, 35);
            btnEye.Click += btnEye_Click;
            btnEye.Tag = test;

            Label lbCode = new Label();
            lbCode.Location = new System.Drawing.Point(46, 19);
            lbCode.Size = new System.Drawing.Size(155, 30);
            lbCode.Text = test.code;
            lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Label lbNameCourse = new Label();
            lbNameCourse.Location = new System.Drawing.Point(207, 19);
            lbNameCourse.Size = new System.Drawing.Size(465, 30);
            lbNameCourse.Text = test.courseID + "              " + test.corseName;
            lbNameCourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            Label lbdateConfirm = new Label();
            lbdateConfirm.Location = new System.Drawing.Point(678, 19);
            lbdateConfirm.Size = new System.Drawing.Size(379, 30);
            lbdateConfirm.Text = test.DateComfirm.ToString("dd/MM/yyyy h:mm tt");
            lbdateConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            Button btnComfirm = new Button();
            btnComfirm.BackColor = System.Drawing.Color.Aquamarine;
            btnComfirm.FlatAppearance.BorderSize = 0;
            btnComfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnComfirm.Location = new System.Drawing.Point(1058, -3);
            btnComfirm.Size = new System.Drawing.Size(291, 63);
            btnComfirm.Text = "Confirm";
            btnComfirm.UseVisualStyleBackColor = false;
            btnComfirm.Click += btnComfirm_Click;
            btnComfirm.Tag = test;

            panel.Controls.Add(btnEye);
            panel.Controls.Add(lbCode);
            panel.Controls.Add(lbNameCourse);
            panel.Controls.Add(lbdateConfirm);
            panel.Controls.Add(btnComfirm);
            
            if(test.DateAppove.Year.ToString()!="1")
            {
                btnComfirm.Enabled = false;
            }
            return panel;
        }

        private void btnEye_Click(object sender, EventArgs e)
        {
            TestDTO test = (sender as Button).Tag as TestDTO;
            FTest f = new FTest(test.code, test.courseID, test.examID, false);
            f.ShowDialog();
        }

        void Alert(string msg, FAlert.emType type)
        {
            FAlert frm = new FAlert();
            frm.showAlert(msg, type);

        }
        private void btnComfirm_Click(object sender, EventArgs e)
        {
            TestDTO test = (sender as Button).Tag as TestDTO;
            Button btn = (sender as Button);
            btn.Enabled = false;
            string query =$"update test set DateAppove1= GETDATE() where examID = '{test.examID}' and Code = '{test.code}' and courseID = '{test.courseID}'";
            DataProvider.Instance.ExecuteNonQuery(query);
            Alert("Success ! ", FAlert.emType.success);
        }
    }
}
