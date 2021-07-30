using Dapper;
using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace MyWebApi.Repository
{
    public class MoviesApiRepo : IMoviesApiRepo
    {
        private readonly IConfiguration _Configure;
        public MoviesApiRepo(IConfiguration configuration)
        {
            _Configure = configuration;
        }

        public  IEnumerable<Movie> GetMovies()
        {
            List<Movie> movielist = new List<Movie>();
            using (IDbConnection con = new SqlConnection(_Configure.GetConnectionString("MvcMovieContext")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                movielist = con.Query<Movie>("MovieDetails").ToList();
            }
            return movielist;
        }

        public  Movie GetmoviesByID(int? ID)
        {
            Movie movies = new Movie();
            if (ID == null)
                return movies;
            using (IDbConnection con = new SqlConnection(_Configure.GetConnectionString("MvcMovieContext")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", ID);
                movies = con.Query<Movie>("MovieDetailsbyID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return movies;
        }

        public  int AddMovies(Movie movies)
        {
            int rowInserted = 0;
            using (IDbConnection con = new SqlConnection(_Configure.GetConnectionString("MvcMovieContext")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Title", movies.Title);
                parameters.Add("@ReleaseDate", movies.ReleaseDate);
                parameters.Add("@Genre", movies.Genre);
                parameters.Add("@Price", movies.Price);
                parameters.Add("@Rating", movies.Rating);
                parameters.Add("@CoverPhoto", movies.CoverPhoto);
                parameters.Add("@IsPrivate", movies.IsPrivate);
                rowInserted = con.Execute("InsertMovieDetails", parameters, commandType: CommandType.StoredProcedure);
            }
            return rowInserted;

        }


        public  int UpdateMoviesList(Movie movies,int ID)
        {
            int rowAffected = 0;

            using (IDbConnection con = new SqlConnection(_Configure.GetConnectionString("MvcMovieContext")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", movies.Id);
                parameters.Add("@Title", movies.Title);
                parameters.Add("@ReleaseDate", movies.ReleaseDate);
                parameters.Add("@Genre", movies.Genre);
                parameters.Add("@Price", movies.Price);
                parameters.Add("@Rating", movies.Rating);
                parameters.Add("@CoverPhoto", movies.CoverPhoto);
                parameters.Add("@IsPrivate", movies.IsPrivate); ;
                rowAffected = con.Execute("UpdateMovieDetails", parameters, commandType: CommandType.StoredProcedure);
            }

            return rowAffected;
        }


        public  int DeleteMovies(int id)
        {
            int rowAffected = 0;
            using (IDbConnection con = new SqlConnection(_Configure.GetConnectionString("MvcMovieContext")))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                rowAffected = con.Execute("DelteMovie", parameters, commandType: CommandType.StoredProcedure);

            }

            return rowAffected;
        }

    }
}
