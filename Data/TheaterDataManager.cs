using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            public List<DateAndTime> availablity { get; set; }
            public int screen { get; set; }
            public List<reservation>? reservations { get; set; }
            public Image tumbnail { get; set; }
        }

        public class reservation
        {
            public int ident { get; set; }
            public string name { get; set; }
            public int seatRow { get; set; }
            public int seatColumn { get; set; }

            public int movieIdent { get; set; }

            public DateAndTime ScreeningTime { get; set; }

        }
    }
}
