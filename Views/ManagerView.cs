using CS161_FinalProject_MovieTheaterManager.Data;
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
                    movie.title = "Test";
                    movie.screen = 1;
                    movie.ident = i;
                    movie.index = i - 1;

                    //Turning our demo image into a bye array so that it can be saved as JSON. For testing sakes.

                    movie.tumbnail = theaterDataManager.convertImageToBas64String(@"C:\Users\nrivera23\source\repos\CS161_FinalProject_MovieTheaterManager\Resources\TaylorSwift.png"); // Setting our thumbnail that string we creating.


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
    }
}
