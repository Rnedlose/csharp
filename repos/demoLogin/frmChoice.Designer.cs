namespace demoLogin
{
    partial class frmChoice
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
            this.cusr_btn1 = new System.Windows.Forms.Button();
            this.exusr_btn2 = new System.Windows.Forms.Button();
            this.choice_lbl1 = new System.Windows.Forms.Label();
            this.appTxtBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cusr_btn1
            // 
            this.cusr_btn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cusr_btn1.Location = new System.Drawing.Point(167, 124);
            this.cusr_btn1.Name = "cusr_btn1";
            this.cusr_btn1.Size = new System.Drawing.Size(134, 35);
            this.cusr_btn1.TabIndex = 0;
            this.cusr_btn1.Text = "Create New User";
            this.cusr_btn1.UseVisualStyleBackColor = true;
            this.cusr_btn1.Click += new System.EventHandler(this.cusr_btn1_Click);
            // 
            // exusr_btn2
            // 
            this.exusr_btn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exusr_btn2.Location = new System.Drawing.Point(167, 197);
            this.exusr_btn2.Name = "exusr_btn2";
            this.exusr_btn2.Size = new System.Drawing.Size(134, 35);
            this.exusr_btn2.TabIndex = 1;
            this.exusr_btn2.Text = "Existing User";
            this.exusr_btn2.UseVisualStyleBackColor = true;
            this.exusr_btn2.Click += new System.EventHandler(this.exusr_btn2_Click);
            // 
            // choice_lbl1
            // 
            this.choice_lbl1.AutoSize = true;
            this.choice_lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choice_lbl1.Location = new System.Drawing.Point(216, 166);
            this.choice_lbl1.Name = "choice_lbl1";
            this.choice_lbl1.Size = new System.Drawing.Size(29, 24);
            this.choice_lbl1.TabIndex = 2;
            this.choice_lbl1.Text = "or";
            // 
            // appTxtBox1
            // 
            this.appTxtBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appTxtBox1.Location = new System.Drawing.Point(53, 21);
            this.appTxtBox1.Name = "appTxtBox1";
            this.appTxtBox1.Size = new System.Drawing.Size(381, 68);
            this.appTxtBox1.TabIndex = 3;
            this.appTxtBox1.Text = "College Records";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(167, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Exit Application";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "or";
            // 
            // frmChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 318);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.appTxtBox1);
            this.Controls.Add(this.choice_lbl1);
            this.Controls.Add(this.exusr_btn2);
            this.Controls.Add(this.cusr_btn1);
            this.Name = "frmChoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "College Records";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cusr_btn1;
        private System.Windows.Forms.Button exusr_btn2;
        private System.Windows.Forms.Label choice_lbl1;
        private System.Windows.Forms.RichTextBox appTxtBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}