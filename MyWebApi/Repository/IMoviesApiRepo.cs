using MyWebApi.Models;
using System.Collections.Generic;

namespace MyWebApi.Repository
{
    public interface IMoviesApiRepo
    {
        
        IEnumerable<Movie> GetMovies();
        Movie GetmoviesByID(int? ID);

        int AddMovies(Movie movies);

        int UpdateMoviesList(Movie movies,int ID);

        int DeleteMovies(int id);


    }
}