using lab1;

namespace lab1_win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int n = int.Parse(text1.Text);
            int seed = int.Parse(text2.Text);
            int capacity = int.Parse(text3.Text);

            Problem problem = new Problem(n, seed);
            text4.Text = problem.ToString();

            Result result = problem.Solve(capacity);
            text5.Text = result.ToString();
        }

        private void validate(object sender, EventArgs e)
        {
            if (!int.TryParse(text1.Text, out int val) || val <= 0)
            {
                text1.BackColor = Color.LightCoral;
            }
            else
            {
                text1.BackColor = Color.White;
            }
        }
    }
}
