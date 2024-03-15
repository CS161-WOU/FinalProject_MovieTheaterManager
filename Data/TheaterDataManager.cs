using System.Text.Json;

namespace CS161_FinalProject_MovieTheaterManager.Data
{
    //Our custom Theater Manager class.
    internal class TheaterDataManager
    {
        //List of movies that incporates all the sub classes below.
        public class Movies
        {

            public List<movie> movies { get; set; } // Movies list.

        }

        //Movie class.
        public class movie
        {
            public int ident { get; set; } //Movie ID, I like to call ID IDENT.
            public string title { get; set; } // Title for said movie.
            public List<DateTime> availablity { get; set; } // Showtimes.
            public int screen { get; set; } // The screen the movie will be playing on.
            public List<reservation>? reservations { get; set; } // ALl reservations for said movie.
            public string tumbnail { get; set; } // The movie thumbnail/Image that us shown in MoviesView and SeatingView.
            public int index; // The index of said movie in the movies list.
        }

        //Reservation class.
        public class reservation 
        {
            public int ident { get; set; } // The IDENT of the reservation, which is less of an ID in this case and more of a confirmation code holder.
            public string name { get; set; } // The name of whomever reserved.
            public string seatPosition { get; set; } // The exact seat being reserved.
            public int movieIdent { get; set; } // The movie IDENT.

            public DateTime ScreeningTime { get; set; } // The exact showtime for the reserved seat.

        }

        //Save method to save the data.
        public bool Save(Movies moviesCollection) {

            bool successFull = false;
            try
            {
                string fileName = "MainData.json"; // The filename of where we will be storing all these movies data.
                string jsonMovieCollections = JsonSerializer.Serialize(moviesCollection); // Turning our custom classes into JSON for storing purposes.

                File.WriteAllText(fileName, jsonMovieCollections); // Writing said JSON to our said File.
                successFull = true;
            }
            catch(Exception ex)
            {
                successFull = false;
                MessageBox.Show(ex.Message);
            }
            return successFull;
        }

        //Retreieve method for getting our data.
        public Movies? Retreieve()
        {
            if (!File.Exists("MainData.json")) // Checking if the data file exists, if not return null, abort retreieving movies.
            {
                MessageBox.Show("There is no data to load.");
                return null;
            }
            string jsonString = File.ReadAllText("MainData.json"); // Retreiving out JSON data file that contains all fo the movies data.
            return  JsonSerializer.Deserialize<Movies>(jsonString); // Turning our json data back into our custom movies class.
        }

        //Method to convert an image into a string to save it in our json file.
        public string? convertImageToBas64String(string filename)
        {
            byte[] imageByteArray = File.ReadAllBytes(filename); // Turning the image into an array of bytes.

            return Convert.ToBase64String(imageByteArray); // Turning said array of bytes into a base 64 string and returning said string.
        }                                                                                                   
    }
}
