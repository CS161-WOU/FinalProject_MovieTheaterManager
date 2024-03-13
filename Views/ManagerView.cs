using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS161_FinalProject_MovieTheaterManager.Data;
using Microsoft.VisualBasic;


namespace CS161_FinalProject_MovieTheaterManager.Views
{
    public partial class ManagerView : Form
    {
        public ManagerView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                TheaterDataManager.Movies MovieCollections = new TheaterDataManager.Movies();
                List< TheaterDataManager.movie > MovieList = new List< TheaterDataManager.movie >();

                for (int i = 1; i <= 10; i++)
                {
                    TheaterDataManager.movie movie = new TheaterDataManager.movie();
                    movie.title = "Test";
                    movie.screen = 1;
                    movie.ident = i;
                    movie.reservations = null;
                    movie.tumbnail = ResourceMain.TaylorSwift;

                    List<DateTime> availableTimes = new List<DateTime>();

                    for (int j = 1; j <= 3; j++)
                    {
                        DateTime DT = DateTime.Now;
                        availableTimes.Add(DT);
                    }

                    MovieList.Add(movie);
                }


                MovieCollections.movies = MovieList;

                string fileName = "MainData.json";
                string jsonMovieCollections = JsonSerializer.Serialize(MovieCollections);

                File.WriteAllText(fileName, jsonMovieCollections);
            }catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }

        }
    }
}
