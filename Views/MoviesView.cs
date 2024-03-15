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
            if(!laodedMovies) // Check if the movies were NOT loaded.
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
                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.
               
                TheaterDataManager.Movies? MovieColelctions = theaterDataManager.Retreieve(); // Retreieving Movies.
                if(MovieColelctions == null)
                {
                    MessageBox.Show("Unable to load movies, there are no movies");
                    return false;
                }

                int movieIndex = 0; // Movie index tracker.
                //Looping through all saved movies to populate the movie cards.
                MovieColelctions.movies.ForEach(movie => //Foreach movie
                {
                    Panel moviePanel = (Panel)this.Controls.Find($"movieCardPanel{movie.ident}", true)[0]; // retreieving the indexed Panel.
                    PictureBox movieThumbnail = (PictureBox)this.Controls.Find($"thumbnailPictureBox{movie.ident}", true)[0]; // retreiveing the movie picture box.

                    //Setting the Movie thumbnail.
                    movieThumbnail.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(movie.tumbnail))); //Populating the movie thumbnail and turning our image string back to an image.
                    movieThumbnail.AccessibleDescription = movie.ident.ToString();

                    ((Label)this.Controls.Find($"movieNameLabel{movie.ident}", true)[0]).Text = movie.title; // Populating the movie title.

                    int seatsPossible = movie.availablity.Count * 44; // Variable to calculate the total number of seat options avialable per movie.

                    //Checking if a movie is sold out. 
                    if(movie.reservations.Count == seatsPossible)
                    {
                        ((Label)this.Controls.Find($"movieSeatsLabel{movie.ident}", true)[0]).Text = "SOLD OUT"; // Updating label to display such case.
                        ((Label)this.Controls.Find($"movieSeatsLabel{movie.ident}", true)[0]).BackColor = Color.DarkRed; // Updating color to Dark Red.

                    }
                    else
                    {
                        ((Label)this.Controls.Find($"movieSeatsLabel{movie.ident}", true)[0]).Text = $"{(seatsPossible - movie.reservations.Count)}/{seatsPossible}"; // Otherwise displaying the number of seats available based on reservations..
                    }

                    moviePanel.Visible = true; // Revealing our movie card.
                    movieIndex++; // Advance index.
                });
                successful = true; // Setting our successful flag to true.
            }catch (Exception ex)
            {
                successful=false;
                MessageBox.Show(ex.Message);
            }

   
            return successful; //Returning our flag.
        }

        //Method that handles a click event froma movie thumbnail, when triggered displays the seating window.
        private void ShowSeating(object sender, EventArgs e)
        {
            try
            {
                PictureBox movieThumbnail = (PictureBox)sender; // Getting the specific movie tumbnail that triggered the event.
                Form SeatingWindow = new MovieSeating(int.Parse(movieThumbnail.AccessibleDescription)); // Passing the movie ID to the mmovie seating window.
                SeatingWindow.Show(); // Showing the seating window.

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message); // Displaying any errors.
            }

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
