using CS161_FinalProject_MovieTheaterManager.Views;

namespace CS161_FinalProject_MovieTheaterManager
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getMoviesButton_Click(object sender, EventArgs e)
        {
            Form movieForm = new MoviesView();
            movieForm.Show();
        }

        private void managerButton_Click(object sender, EventArgs e)
        {
            Form securityForm = new SecurityView();
            securityForm.Show();
        }
    }
}
