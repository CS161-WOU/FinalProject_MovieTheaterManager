using CS161_FinalProject_MovieTheaterManager.Data;
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
            clearMoviesList();

            bool laodedMovies = loadMovies();
            if(laodedMovies)
            {
                MessageBox.Show("Should have worked.");
            }
        }

        
        private bool loadMovies()
        {
            bool successful = false;
            try
            {
                StreamReader jsonFile = File.OpenText("MainData.json");
                TheaterDataManager.Movies? MovieColelctions = JsonSerializer.Deserialize<TheaterDataManager.Movies?>(jsonFile.ReadLine());

                MovieColelctions.movies.ForEach(movie =>
                {
                    Panel moviePanel = (Panel)this.Controls.Find($"movieCardPanel{movie.ident}", true)[0];

                    ((Label)this.Controls.Find($"movieNameLabel{movie.ident}", true)[0]).Text = movie.title;
                    ((PictureBox)this.Controls.Find($"thumbnailPictureBox{movie.ident}", true)[0]).Image = movie.tumbnail;
                    moviePanel.Visible = true;

                });
                successful = true;
            }catch (Exception ex)
            {
                successful=false;
                MessageBox.Show(ex.Message);
            }

            return successful;
        }

        //Method that hides all movie cards from the movies view form.
        private void clearMoviesList()
        {
            for(int index = 1; index < 22;  index++)
            {
               Panel movieCard = (Panel)this.Controls.Find($"movieCardPanel{index}", true)[0];
                movieCard.Visible = false;
            }
        }

        //Method to close the Movies View form.
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
