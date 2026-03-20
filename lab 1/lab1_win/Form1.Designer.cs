namespace lab1_win
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            text1 = new TextBox();
            text2 = new TextBox();
            text3 = new TextBox();
            Label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            text4 = new TextBox();
            text5 = new TextBox();
            Label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // text1
            // 
            text1.Location = new Point(27, 57);
            text1.Name = "text1";
            text1.Size = new Size(150, 31);
            text1.TabIndex = 0;
            text1.TextChanged += validate;
            // 
            // text2
            // 
            text2.Location = new Point(27, 149);
            text2.Name = "text2";
            text2.Size = new Size(150, 31);
            text2.TabIndex = 1;
            text2.TextChanged += validate;
            // 
            // text3
            // 
            text3.Location = new Point(27, 244);
            text3.Name = "text3";
            text3.Size = new Size(150, 31);
            text3.TabIndex = 2;
            text3.TextChanged += validate;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Location = new Point(36, 26);
            Label1.Name = "Label1";
            Label1.Size = new Size(60, 25);
            Label1.TabIndex = 3;
            Label1.Text = "Items:";
            Label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 116);
            label2.Name = "label2";
            label2.Size = new Size(55, 25);
            label2.TabIndex = 4;
            label2.Text = "Seed:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 210);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 5;
            label3.Text = "Capacity:";
            // 
            // button1
            // 
            button1.Location = new Point(33, 314);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 6;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnRun_Click;
            // 
            // text4
            // 
            text4.Location = new Point(327, 53);
            text4.MaximumSize = new Size(200, 500);
            text4.Multiline = true;
            text4.Name = "text4";
            text4.Size = new Size(200, 314);
            text4.TabIndex = 7;
            // 
            // text5
            // 
            text5.Location = new Point(580, 63);
            text5.Multiline = true;
            text5.Name = "text5";
            text5.Size = new Size(200, 314);
            text5.TabIndex = 8;
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Location = new Point(375, 25);
            Label4.Name = "Label4";
            Label4.Size = new Size(67, 25);
            Label4.TabIndex = 9;
            Label4.Text = "Results";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(622, 24);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 10;
            label5.Text = "Instances";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(Label4);
            Controls.Add(text5);
            Controls.Add(text4);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Label1);
            Controls.Add(text3);
            Controls.Add(text2);
            Controls.Add(text1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox text1;
        private TextBox text2;
        private TextBox text3;
        private Label Label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox text4;
        private TextBox text5;
        private Label Label4;
        private Label label5;
    }
}
