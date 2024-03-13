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
        }

        public class reservation
        {
            public int ident { get; set; }
            public string name { get; set; }
            public int seatRow { get; set; }
            public int seatColumn { get; set; }

            public int movieIdent { get; set; }

            public DateTime ScreeningTime { get; set; }

        }
    }
}
