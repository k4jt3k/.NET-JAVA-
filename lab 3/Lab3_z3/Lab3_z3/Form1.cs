using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_z3
{
    public partial class Form1 : Form
    {
        private Bitmap? img;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = openFileDialog1.FileName;
                if (file != null)
                {
                    img = new Bitmap(file); 
                    picMain.Image = img;    

                    picFilter1.Image = null;
                    picFilter2.Image = null;
                    picFilter3.Image = null;
                    picFilter4.Image = null;
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                MessageBox.Show("Najpierw załaduj obrazek!");
                return;
            }

            Bitmap copy1 = new Bitmap(img);
            Bitmap copy2 = new Bitmap(img);
            Bitmap copy3 = new Bitmap(img);
            Bitmap copy4 = new Bitmap(img);

            btnProcess.Enabled = false;

            Task.Run(() =>
            {
                Parallel.Invoke(
                    () => ApplyGrayscale(copy1),
                    () => ApplyNegative(copy2),
                    () => ApplyThreshold(copy3),
                    () => ApplyGreenTint(copy4)
                );


                this.Invoke(new Action(() =>
                {
                    picFilter1.Image = copy1; 
                    picFilter2.Image = copy2; 
                    picFilter3.Image = copy3; 
                    picFilter4.Image = copy4; 
                    btnProcess.Enabled = true;
                }));
            });
        }

        private void ApplyGrayscale(Bitmap bmp)
        {
            for (int y = 0; y < bmp.Height; y++) 
            {
                for (int x = 0; x < bmp.Width; x++) 
                {
                    Color p = bmp.GetPixel(x, y); 
                    int a = p.A;
                    int avg = (p.R + p.G + p.B) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg)); 
                }
            }
        }

        private void ApplyNegative(Bitmap bmp)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color p = bmp.GetPixel(x, y); 
                    int a = p.A;
                    
                    bmp.SetPixel(x, y, Color.FromArgb(a, 255 - p.R, 255 - p.G, 255 - p.B)); 
                }
            }
        }

        private void ApplyThreshold(Bitmap bmp)
        {
            int threshold = 128; 
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color p = bmp.GetPixel(x, y);
                    int avg = (p.R + p.G + p.B) / 3;
                    Color resultColor = avg < threshold ? Color.Black : Color.White;
                    bmp.SetPixel(x, y, resultColor); 
                }
            }
        }

        private void ApplyGreenTint(Bitmap bmp)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color p = bmp.GetPixel(x, y); 
                    int a = p.A;
                    bmp.SetPixel(x, y, Color.FromArgb(a, p.R / 4, p.G, p.B / 4));
                }
            }
        }
    }
}