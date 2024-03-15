using System.Text.Json;

namespace CS161_FinalProject_MovieTheaterManager.Data
{
    internal class TheaterDataManager
    {

        public class Movies
        {

            public List<movie> movies { get; set; }

        }

        public class movie
        {
            public int ident { get; set; }
            public string title { get; set; }
            public List<DateTime> availablity { get; set; }
            public int screen { get; set; }
            public List<reservation>? reservations { get; set; }
            public string tumbnail { get; set; }
            public int index;
        }

        public class reservation
        {
            public int ident { get; set; }
            public string name { get; set; }
            public string seatPosition { get; set; }
            public int movieIdent { get; set; }

            public DateTime ScreeningTime { get; set; }

        }

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

        //TODO TODO TODO add method for retreiving data.
        public Movies? Retreieve()
        {
            if (!File.Exists("MainData.json"))
            {
                MessageBox.Show("There is no data to load.");
                return null;
            }
            string jsonString = File.ReadAllText("MainData.json"); // Retreiving out JSON data file that contains all fo the movies data.
            return  JsonSerializer.Deserialize<Movies>(jsonString); // Turning our json data back into our custom movies class.
        }
    }
}
