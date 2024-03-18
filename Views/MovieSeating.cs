using CS161_FinalProject_MovieTheaterManager.Data;
using System.Text.Json;
using static CS161_FinalProject_MovieTheaterManager.Data.TheaterDataManager;

namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class MovieSeating : Form
    {
        int movieIndex; // The movies index;
        MoviesView movieView;
        public MovieSeating(int movieIndex, MoviesView currentMoviesView) // Adding a paramater to our seating form, to pass the selected movies ID.
        {
            this.movieIndex = movieIndex; // Setting the movide index in movie collections.
            this.movieView = currentMoviesView;
            InitializeComponent();
        }

        TheaterDataManager theaterDataManager = new TheaterDataManager(); // New Instance of our custom class.
        TheaterDataManager.Movies MovieCollections = new TheaterDataManager.Movies(); // Getting our custom movie manager class.
    
        const int TICKET_PRICE = 15;
        int totalCost = 0; //Vairable to track the total.

        DateTime[] movieAvailability = new DateTime[5]; // Array that holds our five possible showtimes.

        DateTime? selectedShowTime = null; // vairable to track the currently selected showtime.

        List<Label> seatsPicked = new List<Label>(); // Creating a list to track all the selcted seats.

        //Window load method, when the window is opened do....
        private void MovieSeating_Load(object sender, EventArgs e)
        {
            //Get our current movies and reservations.

            MovieCollections = theaterDataManager.Retreieve(); // Retreieving Movies.

            movieTumbnail_PictureBox.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(MovieCollections.movies[movieIndex].tumbnail))); // Set our movie thumbnail.
            movieTitle_Label.Text = MovieCollections.movies[movieIndex].title; // Set the movie title.
            movieScreen_Label.Text = $"SCREEN {MovieCollections.movies[movieIndex].screen}"; // State which screen it's playing on.

            loadShowTimes(); // Calling our loadShowTimes method, which displays all avialable show times.
            loadSeats(); // Calling our loadSeats method, which checks for reservations.


        }

        //Our LoadSeats method.
        private void loadSeats()
        {
            MovieCollections = theaterDataManager.Retreieve();
            List<reservation> reservedSeats = MovieCollections.movies[movieIndex].reservations; // Getting our reservations.


            clearCartButton_Click(this, new EventArgs()); // Resetting Cart.

            for(int column = 1; column < 11; column++) { 
            
                for(int row = 1; row < 6; row++)
                {
                    Control[] foundControls = (Control[])this.Controls.Find($"seatC{column}R{row}_Label", true); //Getting the current seat Label object.

                    if(foundControls.Length == 0)
                    {
                        continue;
                    }

                    Label seatLabel = (Label)foundControls[0];
                   

                    seatLabel.BackColor = Color.CornflowerBlue;
                }
            }

            if(MovieCollections.movies[movieIndex].reservations == null || MovieCollections.movies[movieIndex].reservations.Count == 0) { return; } // If there no reservations stop loading reservations.

            int seatIndex = 1; // Index vairbale to track the current seat.

            //If no showtime is selcted, don't bother checking for reservations.
            if(selectedShowTime == null)
            {
                return;
            }

            //Foreach reservation... do...
            reservedSeats.ForEach(seat =>
            {
                Label seatLabel = (Label)this.Controls.Find($"seat{seat.seatPosition}_Label", true)[0]; //Getting the current seat Label object.
        
                if(seat.ScreeningTime == selectedShowTime) // Checking the reservation is for the selected showtime.
                {
                    seatLabel.BackColor = Color.Tomato; //Setting the seat to be tomato color sinces it's reserved.
                }
            });
        }

        //LoadShowTimes method.
        private void loadShowTimes()
        {

           
            //Try catch to catch any unforeseen errors.
            try
            {
                //For every possible showtime (only 5 showtimes are allowed per movie, becuase I said so.
                for(int showIndex = 1; showIndex < 6; showIndex++)
                {
                    RadioButton showTimeRadio = (RadioButton)this.Controls.Find($"showTime{showIndex}_RadioButton", true)[0]; // Get the radiobutton showtime object.
                    showTimeRadio.Visible = false; //Hide it by default.
                }

                //Checking if there are any showtimes. Which to be fair there should always be, but just in case....
                if (MovieCollections.movies[movieIndex].availablity == null)
                {
                    return;
                }

                List<DateTime> showTimes = MovieCollections.movies[movieIndex].availablity; //DateTime List to hold all our showTimes.
                
                int showTimeIndex = 1; // Inde to track the current showtime.

                //For each showtime....
                showTimes.ForEach(showTime =>
                {

                    RadioButton showTimeRadio = (RadioButton)this.Controls.Find($"showTime{showTimeIndex}_RadioButton", true)[0]; // Get the radio button showtime object.
                    showTimeRadio.Text = showTime.ToString(); // Set the text to display the showtime date and time.
                    showTimeRadio.AccessibleDescription = (showTimeIndex - 1).ToString(); // Totatlly not abusing unused properties to save the index for the showtime in the actual DateTime array.
                    showTimeRadio.Visible = true; // Reveal the radio button.

                    movieAvailability[showTimeIndex - 1] = showTime; //Pushing the showtime to it's cell in the movie avabaiablity array.
                    showTimeIndex++; // Update the index.
                });

            }
            catch (Exception ex) // Catch and display errors.
            {

                MessageBox.Show(ex.Message);
            }
        }

        //Method that handles the showtime selection aka the RadioButtons.
        private void setSelectedShowTime(object sender, EventArgs e)
        {
            RadioButton showTimeRadio = (RadioButton)sender; // Getting the RadioButton object from the selected showTime.

            try // Try catch to catch any unforeseen errors.
            {
                selectedShowTime = movieAvailability[int.Parse(showTimeRadio.AccessibleDescription)]; // Get the specific showtime.
                loadSeats(); // Reload the seats.
           
            }catch(Exception err)
            {
                MessageBox.Show(err.Message); //Display any errors.
            }
        }

        //Method to add a seat to the users cart.
        private void addSeatToReserve(object sender, EventArgs e)
        {
            Label seatLabel = (Label)sender; // Getting the selected seat object, which happens to be a label.

            string cartText = "M" + MovieCollections.movies[movieIndex].ident + "-" + seatLabel.Text + $" ${TICKET_PRICE}"; // Cart item format.

            if(selectedShowTime == null)
            {
                MessageBox.Show("Please select a showtime before selecting your seats.");
                return;
            }

            if(seatLabel.BackColor == Color.Tomato) // Checking if the seat has already been reserved, if it has the BackColor should be Tomato.
            {
                MessageBox.Show("This seat is not available."); // Displaying said case.
                return;
            }

            if (seatsPicked.Contains(seatLabel)) // Checking if the seat gad already been picked, if so then it's already in the cart, in which case we'll remove it.
            {
                seatLabel.BackColor = Color.CornflowerBlue;  //Reseting the seat to before it was selected.
                seatsCarListBox.Items.Remove(cartText); // Removing it from the cart listBox.
                seatsPicked.Remove(seatLabel); //Removing it from the seats list.
                
                totalCost -= TICKET_PRICE; // Updating our total vairable.
                cartTotal_Label.Text = $"${totalCost.ToString("f2")}"; // Updating the total label.
                return;
            }

            //Otherwise
            seatLabel.BackColor = Color.Lavender; // Setting the color to Lavender to indicate they have added the seat to their cart.
            seatsCarListBox.Items.Add(cartText); //Adding the seat to the cart listBox.
            seatsPicked.Add(seatLabel); //Adding the seat to the list.

            totalCost += TICKET_PRICE; // Updating our total airable.
            cartTotal_Label.Text = $"${totalCost.ToString("f2")}"; // Updating the total label.
        }

        //Method to handle the reserve button click event, adding all seats in the cart to reservations.
        private void reserveSeats(object sender, EventArgs e)
        {
            try // Try catch to catch any unforseen errors and display said unforseen errors.
            {
                string reservationName = reservationName_TextBox.Text; // Get the name entered in the name textBox.
                int reservationIDENT = generateReservationIDENT(); // Get a new reservation IDENT.

                if(reservationName.Length == 0)
                {
                    MessageBox.Show("Please enter a name for the reservation.");
                    return;
                }

                if(seatsPicked.Count == 0)
                {
                    MessageBox.Show("Please select the seats you would like to reserve.");
                    return;
                }

                List<reservation> reservedSeats = MovieCollections.movies[movieIndex].reservations;

                //For each seat in the seatsPicked list create a new reservation.
                seatsPicked.ForEach(seat =>
                {
                    TheaterDataManager.reservation newReservation = new TheaterDataManager.reservation(); //Creating a new instance of our custom reservation class.
                    newReservation.ident = reservationIDENT; // Setting the reservation id to the generated IDENT. Serves a confirmation code ish.
                    newReservation.name = Name; // Setting the customers name for the reservations.
                    newReservation.seatPosition = seat.Text; // Setting the seat position for the rservation.
                    newReservation.movieIdent = MovieCollections.movies[movieIndex].ident; // And setting the movie ID for the rservation.
                    newReservation.ScreeningTime = (DateTime)selectedShowTime; // Set the showtime for the reservation.

                    reservedSeats.Add(newReservation); // adding the new reservations to our movie class.
                });

                MovieCollections.movies[movieIndex].reservations = reservedSeats;
                seatsPicked.Clear();
         
                theaterDataManager.Save(MovieCollections); // Call our save method to actually save stuff to the file.

                movieView.loadMovies();
                loadSeats(); // Reload the seats.
                MessageBox.Show($"Your seats are reserved, your confirmation code is {reservationIDENT}. Please keep this code for check in.");
            }catch {

            }
        }

        //Method to generate a mostly random reservation id.
        private int generateReservationIDENT()
        {
            string newIDENT =""; // String to hold our id in progress.
            Random random = new Random(); // rnadom.

            //Generate 7 digits
            for(int i = 0; i < 8; i++) { 
                int digit = random.Next(0,10); // Generate a random number between 0 and 9.
                newIDENT = newIDENT + digit.ToString(); // Concat the digit to our ID in progress.
            }

            return int.Parse(newIDENT); // Parse and return the id.

        }

        //Clear cart button click method.
        private void clearCartButton_Click(object? sender, EventArgs? e)
        {
            //For every seat in the seatsPicked list...
            seatsPicked.ForEach(seat =>
            {
                seat.BackColor = Color.CornflowerBlue; //Reset the color.
            });

            seatsPicked.Clear(); //Remove all seats from the List.
            seatsCarListBox.Items.Clear(); // Cleat the cart listBox.

            totalCost = 0;
            cartTotal_Label.Text = "$0.00";

        }
      
        //Exit button click method.
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); //This shockingly closes the window.
        }
    }
}
