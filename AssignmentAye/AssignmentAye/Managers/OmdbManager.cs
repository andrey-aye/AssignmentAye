using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using AssignmentAye.Models;
using Newtonsoft.Json;

namespace AssignmentAye.Managers
{
    public static class OmdbManager
    {
        //http://www.omdbapi.com/?t=inception&y=&plot=short&r=json

        private static readonly HttpClient _client = new HttpClient();
        private static readonly string ApiBaseAddress = "http://www.omdbapi.com/?s=";

        public static async Task<List<MovieModel>> GetMovies(string title)
        {
            List<MovieModel> movies = new List<MovieModel>();
            try
            {
                var address = ApiBaseAddress + title;
                HttpResponseMessage response = await _client.GetAsync(address);
                string responseString = await response.Content.ReadAsStringAsync();

                var moviesSearchResults = JsonConvert.DeserializeObject<SearchResultModel>(responseString);
                if (moviesSearchResults.Response)
                {
                    movies = moviesSearchResults.Search;
                }
                
                return movies;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return movies;
            }

        }

    }
}



