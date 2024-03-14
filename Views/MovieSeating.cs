using CS161_FinalProject_MovieTheaterManager.Data;
using System.Text.Json;
using static CS161_FinalProject_MovieTheaterManager.Data.TheaterDataManager;

namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class MovieSeating : Form
    {
        int movieIDENT;
        public MovieSeating(int movieIdent)
        {
            this.movieIDENT = movieIdent;
            InitializeComponent();
        }

        TheaterDataManager.Movies MovieCollections = new TheaterDataManager.Movies();

        List<string> seatsPicked = new List<string>();
        private void addSeatToReserve(object sender, EventArgs e)
        {
            Label seatLabel = (Label)sender;

            string cartText = "M" + movieIDENT + "-" + seatLabel.Text + " $15";

            if (seatsPicked.Contains(seatLabel.Text))
            {
                seatLabel.BackColor = Color.CornflowerBlue;
                seatsCarListBox.Items.Remove(cartText);
                seatsPicked.Remove(seatLabel.Text);
                return;
            }
            seatLabel.BackColor = Color.Lavender;
            seatsCarListBox.Items.Add(cartText);
            seatsPicked.Add(seatLabel.Text);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearCartButton_Click(object sender, EventArgs e)
        {
            seatsPicked.Clear();

        }

        private void MovieSeating_Load(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText("MainData.json"); // Retreiving out JSON data file that contains all fo the movies data.
            MovieCollections = JsonSerializer.Deserialize<TheaterDataManager.Movies?>(jsonString); // Turning our json data back into our custom movies class.
                                                                                            
            movieTumbnail_PictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(MovieCollections.movies[movieIDENT].tumbnail)));
            movieTitle_Label.Text = MovieCollections.movies[movieIDENT].title;
        }
    }
}
