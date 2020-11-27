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
            this.flpListCourse = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.flpExam = new System.Windows.Forms.FlowLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.flpListCourse.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flpExam.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpListCourse
            // 
            this.flpListCourse.AutoScroll = true;
            this.flpListCourse.Controls.Add(this.panel1);
            this.flpListCourse.Location = new System.Drawing.Point(3, 59);
            this.flpListCourse.Name = "flpListCourse";
            this.flpListCourse.Size = new System.Drawing.Size(1192, 692);
            this.flpListCourse.TabIndex = 0;
            this.flpListCourse.Paint += new System.Windows.Forms.PaintEventHandler(this.flpListCourse_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 69);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(583, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "lie bie";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Priciple progaming language";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(939, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = false;
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(721, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 30);
            this.label5.TabIndex = 6;
            this.label5.Text = "Lecturter";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // flpExam
            // 
            this.flpExam.Controls.Add(this.button2);
            this.flpExam.Controls.Add(this.button3);
            this.flpExam.Location = new System.Drawing.Point(1201, 59);
            this.flpExam.Name = "flpExam";
            this.flpExam.Size = new System.Drawing.Size(229, 692);
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
            // ListCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flpExam);
            this.Controls.Add(this.flpListCourse);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ListCourse";
            this.Size = new System.Drawing.Size(1401, 871);
            this.Load += new System.EventHandler(this.ListCourse_Load);
            this.flpListCourse.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flpExam.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpListCourse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flpExam;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}
