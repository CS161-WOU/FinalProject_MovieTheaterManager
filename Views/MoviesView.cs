using CS161_FinalProject_MovieTheaterManager.Data;
using System.Text.Json;
using static CS161_FinalProject_MovieTheaterManager.Data.TheaterDataManager;

namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class MoviesView : Form
    {
        public MoviesView()
        {
            InitializeComponent();
        }

        //Method that gets triggered when the movies form is loaded.
        private void MoviesView_Load(object sender, EventArgs e)
        {
            clearMoviesList(); // Hide all the movie cards since they aren't hidden by default.

            bool laodedMovies = loadMovies(); // Load movies.
            if(laodedMovies) // Check if the movies were loaded.
            {
                MessageBox.Show("Should have worked.");
            }
            else
            {
                MessageBox.Show("There was a problem loading the movies.");
            }
         
        }

        //Method to load all movie cards for each available movie.
        private bool loadMovies()
        {
            bool successful = false; // Flag to track if we sucessfully load movies or not.

            try // Try catch to catch any dumbasses mistakes.
            {
                string jsonString =File.ReadAllText("MainData.json"); // Retreiving out JSON data file that contains all fo the movies data.
                TheaterDataManager.Movies? MovieColelctions = JsonSerializer.Deserialize<TheaterDataManager.Movies?>(jsonString); // Turning our json data back into our custom movies class.

                //Looping through all saved movies to populate the movie cards.
                MovieColelctions.movies.ForEach(movie => //Foreach movie
                {
                    Panel moviePanel = (Panel)this.Controls.Find($"movieCardPanel{movie.ident}", true)[0]; // retreieving the indexed Panel.


                    //Setting the Movie thumbnail.
                   ((PictureBox)this.Controls.Find($"thumbnailPictureBox{movie.ident}", true)[0]).Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(movie.tumbnail))); //Populating the movie thumbnail and turning our image string back to an image.


                    ((Label)this.Controls.Find($"movieNameLabel{movie.ident}", true)[0]).Text = movie.title; // Populating the movie title.

                    //Showing the number of seats available based on reservations.

                    /*
                     * <<<<<<< NOTE >>>>>>>>>>>
                     * Should ADD an if statement to check if there are no seats. Which in said case label should be DarkRed and text should say "SOLD OUT".
                     */
                    ((Label)this.Controls.Find($"movieSeatsLabel{movie.ident}", true)[0]).Text = $"{50-(movie.reservations.Count)}/50";

                    moviePanel.Visible = true; // Revealing our movie card.

                });
                successful = true; // Setting our successful flag to true.
            }catch (Exception ex)
            {
                successful=false;
                MessageBox.Show(ex.Message);
            }

            return successful; //Returning our flag.
        }

        //Method that hides all movie cards from the movies view form and resets them.
        private void clearMoviesList()
        {
            for(int index = 1; index < 22;  index++) // For each movie (there's 21 one possible movies at any given time).
            {
                Panel movieCard = (Panel)this.Controls.Find($"movieCardPanel{index}", true)[0]; // Retreive the Panel of the current index.
                ((Label)this.Controls.Find($"movieSeatsLabel{index}", true)[0]).BackColor = Color.DarkGreen; // Reset the seating label to green, incase it was marked as sold out.
                movieCard.Visible = false; // Hide the movie card.
            }
        }

        //Method to close the Movies View form.
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //Guess what? This closes the form.... CRAZY RIGHT?!?!?!?
        }
    }
}
