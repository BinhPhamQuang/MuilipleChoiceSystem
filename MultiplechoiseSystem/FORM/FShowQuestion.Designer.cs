namespace MultiplechoiseSystem.FORM
{
    partial class FShowQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FShowQuestion));
            this.richQuestion = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.flp_answers = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.flp_answers.SuspendLayout();
            this.SuspendLayout();
            // 
            // richQuestion
            // 
            this.richQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richQuestion.Location = new System.Drawing.Point(12, 38);
            this.richQuestion.Name = "richQuestion";
            this.richQuestion.ReadOnly = true;
            this.richQuestion.Size = new System.Drawing.Size(971, 109);
            this.richQuestion.TabIndex = 0;
            this.richQuestion.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(966, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 30);
            this.btnClose.TabIndex = 13;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flp_answers
            // 
            this.flp_answers.AllowDrop = true;
            this.flp_answers.Controls.Add(this.panel2);
            this.flp_answers.Controls.Add(this.richTextBox3);
            this.flp_answers.Location = new System.Drawing.Point(8, 163);
            this.flp_answers.Name = "flp_answers";
            this.flp_answers.Size = new System.Drawing.Size(975, 208);
            this.flp_answers.TabIndex = 14;
            this.flp_answers.Paint += new System.Windows.Forms.PaintEventHandler(this.flp_answers_Paint);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox3.ForeColor = System.Drawing.Color.Crimson;
            this.richTextBox3.Location = new System.Drawing.Point(3, 9);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.ReadOnly = true;
            this.richTextBox3.Size = new System.Drawing.Size(972, 33);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "dadasda";
            this.richTextBox3.Visible = false;
            // 
            // FShowQuestion
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(995, 375);
            this.Controls.Add(this.flp_answers);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.richQuestion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FShowQuestion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FShowQuestion";
            this.Load += new System.EventHandler(this.FShowQuestion_Load);
            this.flp_answers.ResumeLayout(false);
            this.flp_answers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richQuestion;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.FlowLayoutPanel flp_answers;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox3;
    }
}