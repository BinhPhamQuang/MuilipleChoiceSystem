namespace MultiplechoiseSystem.FORM
{
    partial class ListCourse
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCourse));
            this.flpListCourse = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_header = new System.Windows.Forms.Label();
            this.flpExam = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panelCreateExam = new System.Windows.Forms.Panel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numTimeTest = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMinutes = new System.Windows.Forms.NumericUpDown();
            this.cbHour = new System.Windows.Forms.ComboBox();
            this.dateTest = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNameExam = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flpListCourse.SuspendLayout();
            this.panel2.SuspendLayout();
            this.flpExam.SuspendLayout();
            this.panelCreateExam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).BeginInit();
            this.SuspendLayout();
            // 
            // flpListCourse
            // 
            this.flpListCourse.AutoScroll = true;
            this.flpListCourse.Controls.Add(this.panel2);
            this.flpListCourse.Location = new System.Drawing.Point(34, 59);
            this.flpListCourse.Name = "flpListCourse";
            this.flpListCourse.Size = new System.Drawing.Size(1192, 625);
            this.flpListCourse.TabIndex = 0;
            this.flpListCourse.Paint += new System.Windows.Forms.PaintEventHandler(this.flpListCourse_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 69);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(603, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(336, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create set of questions";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(583, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(350, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "lie bie";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(507, 37);
            this.label6.TabIndex = 2;
            this.label6.Text = "Priciple progaming language";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(939, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(210, 48);
            this.button4.TabIndex = 0;
            this.button4.Text = "View";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 30);
            this.label4.TabIndex = 5;
            this.label4.Text = "Course Name";
            // 
            // lb_header
            // 
            this.lb_header.AutoSize = true;
            this.lb_header.Location = new System.Drawing.Point(724, 16);
            this.lb_header.Name = "lb_header";
            this.lb_header.Size = new System.Drawing.Size(188, 30);
            this.lb_header.TabIndex = 6;
            this.lb_header.Text = "Head Lecturter";
            this.lb_header.Click += new System.EventHandler(this.label5_Click);
            // 
            // flpExam
            // 
            this.flpExam.Controls.Add(this.button2);
            this.flpExam.Controls.Add(this.button3);
            this.flpExam.Location = new System.Drawing.Point(1232, 59);
            this.flpExam.Name = "flpExam";
            this.flpExam.Size = new System.Drawing.Size(198, 768);
            this.flpExam.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 69);
            this.button2.TabIndex = 0;
            this.button2.Text = "MidTerm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(3, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 69);
            this.button3.TabIndex = 1;
            this.button3.Text = "FinalTerm";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // panelCreateExam
            // 
            this.panelCreateExam.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCreateExam.Controls.Add(this.btnConfirm);
            this.panelCreateExam.Controls.Add(this.label8);
            this.panelCreateExam.Controls.Add(this.numTimeTest);
            this.panelCreateExam.Controls.Add(this.label7);
            this.panelCreateExam.Controls.Add(this.label5);
            this.panelCreateExam.Controls.Add(this.numMinutes);
            this.panelCreateExam.Controls.Add(this.cbHour);
            this.panelCreateExam.Controls.Add(this.dateTest);
            this.panelCreateExam.Controls.Add(this.label2);
            this.panelCreateExam.Controls.Add(this.panel1);
            this.panelCreateExam.Controls.Add(this.txtNameExam);
            this.panelCreateExam.Controls.Add(this.btnClose);
            this.panelCreateExam.Controls.Add(this.label1);
            this.panelCreateExam.Location = new System.Drawing.Point(37, 692);
            this.panelCreateExam.Name = "panelCreateExam";
            this.panelCreateExam.Size = new System.Drawing.Size(1189, 135);
            this.panelCreateExam.TabIndex = 7;
            this.panelCreateExam.Visible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(431, 97);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(299, 34);
            this.btnConfirm.TabIndex = 47;
            this.btnConfirm.Text = "Comfirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(854, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 30);
            this.label8.TabIndex = 46;
            this.label8.Text = "minutes";
            // 
            // numTimeTest
            // 
            this.numTimeTest.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTimeTest.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTimeTest.Location = new System.Drawing.Point(753, 6);
            this.numTimeTest.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numTimeTest.Name = "numTimeTest";
            this.numTimeTest.Size = new System.Drawing.Size(95, 32);
            this.numTimeTest.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(601, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 30);
            this.label7.TabIndex = 44;
            this.label7.Text = "Test Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 30);
            this.label5.TabIndex = 43;
            this.label5.Text = "Exam time:";
            // 
            // numMinutes
            // 
            this.numMinutes.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinutes.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numMinutes.Location = new System.Drawing.Point(881, 50);
            this.numMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numMinutes.Name = "numMinutes";
            this.numMinutes.Size = new System.Drawing.Size(95, 32);
            this.numMinutes.TabIndex = 42;
            // 
            // cbHour
            // 
            this.cbHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHour.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHour.FormattingEnabled = true;
            this.cbHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbHour.Location = new System.Drawing.Point(753, 52);
            this.cbHour.Name = "cbHour";
            this.cbHour.Size = new System.Drawing.Size(122, 31);
            this.cbHour.TabIndex = 39;
            // 
            // dateTest
            // 
            this.dateTest.CalendarMonthBackground = System.Drawing.SystemColors.ControlLight;
            this.dateTest.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTest.Location = new System.Drawing.Point(172, 48);
            this.dateTest.Name = "dateTest";
            this.dateTest.Size = new System.Drawing.Size(406, 32);
            this.dateTest.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 30);
            this.label2.TabIndex = 37;
            this.label2.Text = "Exam date:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Location = new System.Drawing.Point(172, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(406, 3);
            this.panel1.TabIndex = 36;
            // 
            // txtNameExam
            // 
            this.txtNameExam.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtNameExam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNameExam.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNameExam.Location = new System.Drawing.Point(179, 4);
            this.txtNameExam.Name = "txtNameExam";
            this.txtNameExam.Size = new System.Drawing.Size(399, 29);
            this.txtNameExam.TabIndex = 35;
            this.txtNameExam.TextChanged += new System.EventHandler(this.txtNameExam_TextChanged);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1159, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 30);
            this.btnClose.TabIndex = 34;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exam name:";
            // 
            // ListCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCreateExam);
            this.Controls.Add(this.lb_header);
            this.Controls.Add(this.flpExam);
            this.Controls.Add(this.flpListCourse);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ListCourse";
            this.Size = new System.Drawing.Size(1401, 871);
            this.Load += new System.EventHandler(this.ListCourse_Load);
            this.flpListCourse.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.flpExam.ResumeLayout(false);
            this.panelCreateExam.ResumeLayout(false);
            this.panelCreateExam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinutes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpListCourse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_header;
        private System.Windows.Forms.FlowLayoutPanel flpExam;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelCreateExam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtNameExam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTest;
        private System.Windows.Forms.ComboBox cbHour;
        private System.Windows.Forms.NumericUpDown numMinutes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numTimeTest;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnConfirm;
    }
}
