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
    

        List<Label> seatsPicked = new List<Label>();

        private void addSeatToReserve(object sender, EventArgs e)
        {
            Label seatLabel = (Label)sender;

            string cartText = "M" + movieIDENT + "-" + seatLabel.Text + " $15";

            if(seatLabel.BackColor == Color.Tomato)
            {
                MessageBox.Show("This seat is not available.");
                return;
            }

            if (seatsPicked.Contains(seatLabel))
            {
                seatLabel.BackColor = Color.CornflowerBlue;
                seatsCarListBox.Items.Remove(cartText);
                seatsPicked.Remove(seatLabel);
                return;
            }
            seatLabel.BackColor = Color.Lavender;
            seatsCarListBox.Items.Add(cartText);
            seatsPicked.Add(seatLabel);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearCartButton_Click(object sender, EventArgs e)
        {
            seatsPicked.ForEach(seat =>
            {
                seat.BackColor = Color.CornflowerBlue;
            });

            seatsPicked.Clear();
            seatsCarListBox.Items.Clear();

        }

        private void MovieSeating_Load(object sender, EventArgs e)
        {
            string jsonString = File.ReadAllText("MainData.json"); // Retreiving out JSON data file that contains all fo the movies data.
            MovieCollections = JsonSerializer.Deserialize<TheaterDataManager.Movies?>(jsonString); // Turning our json data back into our custom movies class.

            movieTumbnail_PictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(MovieCollections.movies[movieIDENT].tumbnail)));
            movieTitle_Label.Text = MovieCollections.movies[movieIDENT].title;
            movieScreen_Label.Text = $"SCREEN {MovieCollections.movies[movieIDENT].screen}";

            loadSeats();

            loadShowTimes();

        }

        private void loadSeats()
        {
            List<reservation> reservedSeats = MovieCollections.movies[movieIDENT].reservations;

            int seatIndex = 1;
            reservedSeats.ForEach(seat =>
            {
                Label seatLabel = (Label)this.Controls.Find($"seatC{seat.seatColumn}R{seat.seatRow}_Label", true)[0];

                seatLabel.BackColor = Color.Tomato;
            });
        }

        private void loadShowTimes()
        {
            List<DateTime> showTimes = MovieCollections.movies[movieIDENT].availablity;

           

            try
            {

                for(int showIndex = 1; showIndex < 6; showIndex++)
                {
                    RadioButton showTimeRadio = (RadioButton)this.Controls.Find($"showTime{showIndex}_RadioButton", true)[0];
                    showTimeRadio.Visible = false;
                }

                int showTimeIndex = 1;
                showTimes.ForEach(showTime =>
                {

                    RadioButton showTimeRadio = (RadioButton)this.Controls.Find($"showTime{showTimeIndex}_RadioButton", true)[0];
                    showTimeRadio.Text = showTime.ToString();
                    showTimeRadio.Visible = true;

                    showTimeIndex++;
                });

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
