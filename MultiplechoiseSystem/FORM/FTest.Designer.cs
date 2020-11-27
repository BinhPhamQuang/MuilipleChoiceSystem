namespace MultiplechoiseSystem.FORM
{
    partial class FTest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTest));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flp_question = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_namecourse = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMinimize = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.PictureBox();
            this.lb_minutes = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.flp_question.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(54)))), ((int)(((byte)(100)))));
            this.panel1.Controls.Add(this.buttonMinimize);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1672, 36);
            this.panel1.TabIndex = 0;
            // 
            // flp_question
            // 
            this.flp_question.AutoScroll = true;
            this.flp_question.Controls.Add(this.panel3);
            this.flp_question.Controls.Add(this.panel4);
            this.flp_question.Controls.Add(this.panel5);
            this.flp_question.Location = new System.Drawing.Point(12, 160);
            this.flp_question.Name = "flp_question";
            this.flp_question.Size = new System.Drawing.Size(1648, 809);
            this.flp_question.TabIndex = 1;
            this.flp_question.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_question_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lb_minutes);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lb_namecourse);
            this.panel2.Location = new System.Drawing.Point(13, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1647, 85);
            this.panel2.TabIndex = 2;
            // 
            // lb_namecourse
            // 
            this.lb_namecourse.AutoSize = true;
            this.lb_namecourse.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_namecourse.Location = new System.Drawing.Point(3, 25);
            this.lb_namecourse.Name = "lb_namecourse";
            this.lb_namecourse.Size = new System.Drawing.Size(460, 37);
            this.lb_namecourse.TabIndex = 0;
            this.lb_namecourse.Text = "Principal progaming language";
            this.lb_namecourse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(754, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(1579, 0);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(44, 36);
            this.buttonMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonMinimize.TabIndex = 30;
            this.buttonMinimize.TabStop = false;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.Location = new System.Drawing.Point(1623, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(49, 36);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonExit.TabIndex = 29;
            this.buttonExit.TabStop = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // lb_minutes
            // 
            this.lb_minutes.AutoSize = true;
            this.lb_minutes.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_minutes.Location = new System.Drawing.Point(867, 25);
            this.lb_minutes.Name = "lb_minutes";
            this.lb_minutes.Size = new System.Drawing.Size(93, 37);
            this.lb_minutes.TabIndex = 2;
            this.lb_minutes.Text = "90:55";
            this.lb_minutes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1006, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 37);
            this.label3.TabIndex = 3;
            this.label3.Text = "minutes";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1598, 163);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel4.Location = new System.Drawing.Point(3, 172);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1598, 163);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel5.Location = new System.Drawing.Point(3, 341);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1598, 163);
            this.panel5.TabIndex = 1;
            // 
            // FTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1672, 1025);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flp_question);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FTest";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTest";
            this.panel1.ResumeLayout(false);
            this.flp_question.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flp_question;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_namecourse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox buttonMinimize;
        private System.Windows.Forms.PictureBox buttonExit;
        private System.Windows.Forms.Label lb_minutes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}