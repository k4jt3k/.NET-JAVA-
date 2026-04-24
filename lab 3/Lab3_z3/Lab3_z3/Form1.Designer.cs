namespace Lab3_z3
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
            btnLoad = new Button();
            btnProcess = new Button();
            picMain = new PictureBox();
            picFilter1 = new PictureBox();
            picFilter2 = new PictureBox();
            printDialog1 = new PrintDialog();
            picFilter3 = new PictureBox();
            picFilter4 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)picMain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFilter1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFilter2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFilter3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picFilter4).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(541, 305);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(112, 59);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnProcess
            // 
            btnProcess.Location = new Point(541, 370);
            btnProcess.Name = "btnProcess";
            btnProcess.Size = new Size(112, 82);
            btnProcess.TabIndex = 1;
            btnProcess.Text = "Parallel Processing";
            btnProcess.UseVisualStyleBackColor = true;
            btnProcess.Click += btnProcess_Click;
            // 
            // picMain
            // 
            picMain.Location = new Point(42, 155);
            picMain.Name = "picMain";
            picMain.Size = new Size(471, 427);
            picMain.SizeMode = PictureBoxSizeMode.Zoom;
            picMain.TabIndex = 2;
            picMain.TabStop = false;
            // 
            // picFilter1
            // 
            picFilter1.Location = new Point(680, 94);
            picFilter1.Name = "picFilter1";
            picFilter1.Size = new Size(314, 206);
            picFilter1.SizeMode = PictureBoxSizeMode.Zoom;
            picFilter1.TabIndex = 3;
            picFilter1.TabStop = false;
            // 
            // picFilter2
            // 
            picFilter2.Location = new Point(1000, 94);
            picFilter2.Name = "picFilter2";
            picFilter2.Size = new Size(292, 206);
            picFilter2.SizeMode = PictureBoxSizeMode.Zoom;
            picFilter2.TabIndex = 4;
            picFilter2.TabStop = false;
            // 
            // printDialog1
            // 
            printDialog1.UseEXDialog = true;
            // 
            // picFilter3
            // 
            picFilter3.Location = new Point(680, 315);
            picFilter3.Name = "picFilter3";
            picFilter3.Size = new Size(314, 204);
            picFilter3.SizeMode = PictureBoxSizeMode.Zoom;
            picFilter3.TabIndex = 5;
            picFilter3.TabStop = false;
            // 
            // picFilter4
            // 
            picFilter4.Location = new Point(1000, 315);
            picFilter4.Name = "picFilter4";
            picFilter4.Size = new Size(292, 204);
            picFilter4.SizeMode = PictureBoxSizeMode.Zoom;
            picFilter4.TabIndex = 6;
            picFilter4.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|All files (*.*)|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1416, 671);
            Controls.Add(picFilter4);
            Controls.Add(picFilter3);
            Controls.Add(picFilter2);
            Controls.Add(picFilter1);
            Controls.Add(picMain);
            Controls.Add(btnProcess);
            Controls.Add(btnLoad);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picMain).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFilter1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFilter2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFilter3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picFilter4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private Button btnProcess;
        private PictureBox picMain;
        private PictureBox picFilter1;
        private PictureBox picFilter2;
        private PrintDialog printDialog1;
        private PictureBox picFilter3;
        private PictureBox picFilter4;
        private OpenFileDialog openFileDialog1;
    }
}
