using CS161_FinalProject_MovieTheaterManager.Data;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;


namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class ManagerView : Form
    {
        public ManagerView()
        {
            InitializeComponent();
        }

        //Random ass method and button created for testing sakes.
        private void makeShitUp(object sender, EventArgs e)
        {
            try
            {

                TheaterDataManager theaterDataManager = new TheaterDataManager();
                TheaterDataManager.Movies MovieCollections = new TheaterDataManager.Movies(); // Create a new instance of our custom Movies class.
                List<TheaterDataManager.movie> MovieList = new List<TheaterDataManager.movie>(); // Create a List instance of movies which will be saved to MoviesCollections.

                for (int i = 1; i <= 10; i++) // Loop 10 times to create 10 fake movies.
                {
                    TheaterDataManager.movie movie = new TheaterDataManager.movie(); // Creating a new instance of our movie class.

                    //Setting the movie properties;
                    movie.title = "The Eras Tour " + i;
                    movie.screen = 1;
                    movie.ident = i;
                    movie.index = i - 1;

                    //Turning our demo image into a bye array so that it can be saved as JSON. For testing sakes.

                    movie.tumbnail = theaterDataManager.convertImageToBas64String(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\MovieThumbnails\taylor-swift-the-eras-tour-movie-poster.png"); // Setting our thumbnail that string we creating.


                    List<DateTime> availableTimes = new List<DateTime>(); // Creating a list instance of available times.
                    List<TheaterDataManager.reservation> reservationCollection = new List<TheaterDataManager.reservation>(); // Creating a list instance of reservations;

                    for (int j = 1; j <= 3; j++) // Creating three fake show times and three fake reservations for testing sakes.
                    {
                        DateTime DT = DateTime.Now; // Getting the current date and time for testing sakes.
                        availableTimes.Add(DT); // Adding said date and time to our list.

                        TheaterDataManager.reservation Reservation = new TheaterDataManager.reservation(); // Creating an instance of our reservation class.

                        //Setting all the reservation fields.
                        Reservation.ScreeningTime = DT;
                        Reservation.movieIdent = i;
                        Reservation.name = $"John Doe {j}"; // Fake names for testing sakes.
                        Reservation.seatPosition = $"C{j + 3}R{j}"; // Random ass seating for testing sakes.

                        reservationCollection.Add(Reservation); // Adding our new reservation to our list.
                    }

                    movie.reservations = reservationCollection; // Updating all the reservations for the movie to the three we just created.
                    movie.availablity = availableTimes; // Updating all showtimes for the movie.
                    MovieList.Add(movie); // Adding the final movie class to our movie colleciton list.
                }


                MovieCollections.movies = MovieList; // Setting our movie collections.

                string fileName = "MainData.json"; // The filename of where we will be storing all these movies data.
                string jsonMovieCollections = JsonSerializer.Serialize(MovieCollections); // Turning our custom classes into JSON for storing purposes.

                File.WriteAllText(fileName, jsonMovieCollections); // Writing said JSON to our said File.

                MessageBox.Show("Shit was made up");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManagerViewResized(object sender, EventArgs e)
        {
            titleMoviePanel.Width = (flowLayoutPanel1.Width - 20);
            for (int i = 1; i < 22; i++)
            {
                ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Width = (flowLayoutPanel1.Width - 20);
                ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Height = (flowLayoutPanel1.Width) / 3;

            }
        }

        private void onWindowLoad(object sender, EventArgs e)
        {

            loadMovies();
        }

        public bool loadMovies()
        {
            bool successful = false; // Flag to track if we sucessfully load movies or not.

            try // Try catch to catch any dumbasses mistakes.
            {
                for (int i = 1; i < 22; i++)
                {
                    ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Visible = false;
                }

                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.

                TheaterDataManager.Movies? MovieColelctions = theaterDataManager.Retreieve(); // Retreieving Movies.
                if (MovieColelctions == null)
                {
                    MessageBox.Show("Unable to load movies, there are no movies");
                    return false;
                }

                int movieIndex = 0; // Movie index tracker.
                //Looping through all saved movies to populate the movie cards.
                MovieColelctions.movies.ForEach(movie => //Foreach movie
                {
                    TableLayoutPanel moviePanel = (TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{movie.ident}", true)[0];

                    PictureBox movieThumbnail = (PictureBox)this.Controls.Find($"thumbnailPictureBox{movie.ident}", true)[0]; // retreiveing the movie picture box.

                    //Setting the Movie thumbnail.
                    movieThumbnail.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(movie.tumbnail))); //Populating the movie thumbnail and turning our image string back to an image.
                    movieThumbnail.AccessibleDescription = movieIndex.ToString();

                    ((Label)this.Controls.Find($"movieNameLabel{movie.ident}", true)[0]).Text = movie.title; // Populating the movie title.

                    int seatsPossible = movie.availablity.Count * 44; // Variable to calculate the total number of seat options avialable per movie.

                    //Checking if a movie is sold out. 
                    if (movie.reservations.Count == seatsPossible)
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
            }
            catch (Exception ex)
            {
                successful = false;
                MessageBox.Show(ex.Message);
            }


            return successful; //Returning our flag.
        }

        List<DateTime> movieEditor_DateTimes = new List<DateTime>();

        private void movieAddDate_Button_Click(object sender, EventArgs e)
        {
            DateTimePicker movieDatePicker = movieDate_DateTimePicker;

            bool? warningAnswer = null;
            if(movieDatePicker.Value < DateTime.Now) {
               DialogResult warningResault =  MessageBox.Show("Mmmm... You sure about that?. You are adding a date and time that is in the past", "Warrning", MessageBoxButtons.YesNo);

                if(warningResault.Equals(DialogResult.No)) {
                    warningAnswer = false;
                }
                else
                {
                    warningAnswer = true;
                }
            }

            if(warningAnswer == false)
            {
                return;
            }

            movieEditor_DateTimes.Add(movieDatePicker.Value);
            movieDateTimes_Listbox.Items.Add(movieDatePicker.Value);
        }

        private void movieRemoveDateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
