using CS161_FinalProject_MovieTheaterManager.Data;
using System.Configuration;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using static CS161_FinalProject_MovieTheaterManager.Data.TheaterDataManager;


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
            this.Close(); //Close the window.
        }

        private void ManagerViewResized(object sender, EventArgs e) //Custom resize for the managers movie list.
        {

            ///
            /// Updates the movie pnales based ont he flow panels width.
            ///
            titleMoviePanel.Width = (flowLayoutPanel1.Width - 20);
            for (int i = 1; i < 22; i++)
            {
                ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Width = (flowLayoutPanel1.Width - 20);
                ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Height = (flowLayoutPanel1.Width) / 3;

            }
        }

        private void onWindowLoad(object sender, EventArgs e)
        {

            loadMovies(); //When the window is opened, load the movies.
        }

        public bool loadMovies()
        {
            bool successful = false; // Flag to track if we sucessfully load movies or not.

            try // Try catch to catch any dumbasses mistakes.
            {
                for (int i = 1; i < 22; i++)
                {
                    ((TableLayoutPanel)this.Controls.Find($"movieCard_TableLayoutPanel{i}", true)[0]).Visible = false; // Hide all movie panels by default.
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

                    if (movie.reservations == null)
                    {
                        ((Label)this.Controls.Find($"movieSeatsLabel{movie.ident}", true)[0]).Text = $"{seatsPossible}/{seatsPossible}";
                    }
                    else if (movie.reservations.Count == seatsPossible)  //Checking if a movie is sold out. 
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

        /// 
        /// Movie Editor Stuff.
        /// 
        TheaterDataManager.movie? selectedMovie = null;
        List<DateTime> movieEditor_DateTimes = new List<DateTime>();

        // Add movie date method..
        private void movieAddDate_Button_Click(object sender, EventArgs e)
        {
            try
            {

                DateTimePicker movieDatePicker = movieDate_DateTimePicker; //Get the movie time entered.

                if (movieEditor_DateTimes.Count >= 5) //Check if the showtime limit has been reached.
                {
                    MessageBox.Show("You may not exceed more than 5 showtimes. Womp Womp.");
                    return;
                }

                bool? warningAnswer = null; //Flag to hold the answer of a Messaegbox below.

                //Checking if the date entered was in the pase.
                if (movieDatePicker.Value < DateTime.Now)
                {
                    DialogResult warningResault = MessageBox.Show("Mmmm... You sure about that?. You are adding a date and time that is in the past", "Warrning", MessageBoxButtons.YesNo); //If so ask the user fi they are sure.

                    if (warningResault.Equals(DialogResult.No)) //Check the answer and update the flag.
                    {
                        warningAnswer = false;
                    }
                    else
                    {
                        warningAnswer = true;
                    }
                }

                if (warningAnswer == false) // if they said no, return.
                {
                    return;
                }

                //otherwise add the movie date to the list, and await saving.

                movieEditor_DateTimes.Add(movieDatePicker.Value);
                movieDateTimes_Listbox.Items.Add(movieDatePicker.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Method to remove a movie date.
        private void movieRemoveDateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (movieDateTimes_Listbox.SelectedItem == null) { MessageBox.Show("Mmmmm. Try selecting a time to remove first."); return; } //Checking if a showtime was even selected.

                DateTime selectedDate = (DateTime)movieDateTimes_Listbox.SelectedItem; //Getting the DateTime Object of the showtime selected.
                movieEditor_DateTimes.Remove(selectedDate); //Removing it from the lists.
                movieDateTimes_Listbox.Items.Remove(selectedDate);

                //Awaiting save button.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //thumbnail update method.
        private void movieThumbnail_PictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) //Display the open file dialog.
                {
                    string imageFileName = openFileDialog1.FileName; //Get the path.
                    movieThumbnail_PictureBox.Image = new Bitmap(imageFileName); //Update te picturebox to reflect the new thumbnail.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //Adding movie method.
        private void movieAdd_Button_Click(object sender, EventArgs e)
        {
            try
            {

                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.

                TheaterDataManager.Movies? MovieCollections = theaterDataManager.Retreieve(); // Retreieving Movies.

                if (MovieCollections == null) //Chekcing if a  movie collectiosn exist/ Data file.
                {
                    MovieCollections = new TheaterDataManager.Movies();
                    MovieCollections.movies = new List<TheaterDataManager.movie>();
                }

                TheaterDataManager.movie newMovie = new TheaterDataManager.movie(); //Creating a new mvoie.

                Random rand = new Random(); // Rand object for screen showing.
                string title = movieTitle_TextBox.Text; //Getting the title.

                if (title == null || title == "") //Checking if a title was entered.
                {
                    MessageBox.Show("Please enter a movie title.");
                    return;
                }

                //Checking if showtimes were entered.
                if (movieEditor_DateTimes.Count == 0)
                {
                    MessageBox.Show("Please add screening times.");
                    return;
                }

                //Checking if a thumbnail has been added.
                if (openFileDialog1.FileName == null || movieThumbnail_PictureBox.Image == null || openFileDialog1.FileName == string.Empty)
                {
                    MessageBox.Show("Please upload a movie thumbnail.");
                    return;
                }

                //Setting all the movie properties.
                newMovie.title = movieTitle_TextBox.Text;
                newMovie.availablity = movieEditor_DateTimes;
                newMovie.screen = rand.Next(1, 11);
                newMovie.tumbnail = theaterDataManager.convertImageToBas64String(openFileDialog1.FileName);
                newMovie.reservations = new List<TheaterDataManager.reservation>();
                newMovie.index = MovieCollections.movies.Count;
                newMovie.ident = MovieCollections.movies.Count + 1;

                //Adding the movie tot he movie collection.
                MovieCollections.movies.Add(newMovie);

                theaterDataManager.Save(MovieCollections); //Saving the movie and data file.

                //Clean up.
                loadMovies();
                MessageBox.Show("Movie added.");
                openFileDialog1.FileName = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Loading the selected mvoie.
        private void loadSelectedMovie(object sender, EventArgs e)
        {
            //Clearing all lists.
            movieEditor_DateTimes.Clear(); 
            movieDateTimes_Listbox.Items.Clear();

            TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.

            TheaterDataManager.Movies? MovieCollections = theaterDataManager.Retreieve(); // Retreieving Movies.

            //Getting the picturebox that was clicked.
            PictureBox selectexPictureBox = (PictureBox)sender;
            selectedMovie = MovieCollections.movies[int.Parse(selectexPictureBox.AccessibleDescription)]; //Getting the movie index through our cheat cheat.

            movieThumbnail_PictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(selectedMovie.tumbnail)));//Getting the tumbnail from the data file.

            movieTitle_TextBox.Text = selectedMovie.title; //Displaying the title

            //Displaying the showtimes.
            selectedMovie.availablity.ForEach(showtime =>
            {
                movieDateTimes_Listbox.Items.Add(showtime);
                movieEditor_DateTimes.Add(showtime);
            });
        }

        // Save button method.
        private void movieSave_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMovie == null) // if no movie was selected to edit, return.
                {
                    MessageBox.Show("Please select a movie to edit first.");
                    return;
                }
                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.

                TheaterDataManager.Movies? MovieCollections = theaterDataManager.Retreieve(); // Retreieving Movies.

                if (MovieCollections == null) // Checking if there any movies....
                {
                    MovieCollections = new TheaterDataManager.Movies();
                    MovieCollections.movies = new List<TheaterDataManager.movie>();
                }

                TheaterDataManager.movie editedMovie = MovieCollections.movies[selectedMovie.index];

                string title = movieTitle_TextBox.Text; //Getting the new title (or old).

                if (title == null || title == "") // Checking if a title is entered.
                {
                    MessageBox.Show("Please enter a movie title.");
                    return;
                }

                if (movieEditor_DateTimes.Count == 0) // Checking if the showtimes exist.
                {
                    MessageBox.Show("Please add screening times.");
                    return;
                }

                //Checking if a new tumbnail was selected, if not let the user know.
                if (openFileDialog1.FileName == string.Empty || openFileDialog1.FileName == null || openFileDialog1.FileName == "")
                {
                    MessageBox.Show("Just to let you know, the thumbnail has not been changed because you didn't upload a new one.");
                }
                else
                {
                    editedMovie.tumbnail = theaterDataManager.convertImageToBas64String(openFileDialog1.FileName); //Otherwise update the thumbnail to the new thumbnail.
                }

                //Update all the movie properties.
                editedMovie.title = title;
                editedMovie.availablity = movieEditor_DateTimes;
                MovieCollections.movies[selectedMovie.index] = editedMovie;

                //Save and reload movies.
                theaterDataManager.Save(MovieCollections);
                loadMovies();

                MessageBox.Show("Movie has been edited."); //let the user know.

                //Clean up.
                selectedMovie = null;
                openFileDialog1.FileName = string.Empty;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void movieDelete_Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedMovie == null) // Checking if a movie was selected.
                {
                    MessageBox.Show("Please select a movie to delete first.");
                    return;
                }
                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.

                Movies? MovieCollections = theaterDataManager.Retreieve(); // Retreieving Movies.

                if (MovieCollections == null) // Checking if there even any movies just in case....
                {
                    MessageBox.Show("Hmmm... There are no current movies to delete. The data file was not found.");
                    return;
                }

                TheaterDataManager.movie indexedMovie = MovieCollections.movies[selectedMovie.index]; // getting the selected movie.

                List<movie> newMovies = new List<movie>(); // Creating a new list of movies.

                int index = 0; // Index to track the index...
                MovieCollections.movies.ForEach(movie => //For each movie.....
                {
                    if (movie == indexedMovie) // If the current movie is the selected movie, don't add it to the list.
                    {
                        return;
                    }

                    //Otherwise update the movie index and ident, and add it to the list.
                    movie.index = index;
                    movie.ident = index + 1;
                    newMovies.Add(movie);

                    index++;//Update index.
                });


                MovieCollections.movies = newMovies; // Set the movies collections to the new movies collections.

                theaterDataManager.Save(MovieCollections); // Save to the data file.
                loadMovies(); // Reload the movie list.

                newMovies.Clear(); //Clean up.
                MessageBox.Show("Movie has been deleted."); // Inform the user.
                selectedMovie = null; // Clean up.
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void confirmationCheck_Button_Click(object sender, EventArgs e)
        {
            try // Try catch to catch any unforseen errors and display said unforseen errors.
            {
                TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.
                Movies MovieCollections = theaterDataManager.Retreieve();

                for (int column = 1; column < 11; column++)
                {

                    for (int row = 1; row < 6; row++)
                    {
                        Control[] foundControls = (Control[])this.Controls.Find($"seatC{column}R{row}_Label", true); //Getting the current seat Label object.

                        if (foundControls.Length == 0)
                        {
                            continue;
                        }

                        Label seatLabel = (Label)foundControls[0];


                        seatLabel.BackColor = Color.CornflowerBlue;
                    }
                }

                int confirmationCode = int.Parse(confirmationCode_TextBox.Text); // getting the inputted confirmation code.

                bool confirmationFound = false;

                //Loop through each movie and through each reservation check if said reservation matches with the entered confirmation code.
                MovieCollections.movies.ForEach(movie =>
                {
                    movie.reservations.ForEach(seat =>
                    {
                        Label seatLabel = (Label)this.Controls.Find($"seat{seat.seatPosition}_Label", true)[0]; //Getting the current seat Label object.
                        if(seat.ident == confirmationCode) // Checking to see if the confirmation codes match.
                        {
                            seatLabel.BackColor = Color.Tomato; // Updating the seat.
                            movieTitle_Label.Text = movie.title;
                            reservationName_Label.Text = seat.name;
                            confirmationFound = true;
                        }
                    });
                });

                if(confirmationFound == false) // If no confirmation was found, say so.
                {
                    MessageBox.Show("No reservations were found under the entered confirmation code.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
