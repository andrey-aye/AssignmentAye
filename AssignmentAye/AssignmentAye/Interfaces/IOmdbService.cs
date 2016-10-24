using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentAye.Models;

namespace AssignmentAye.Interfaces
{
    public interface IOmdbService
    {
        Task<List<MovieModel>> GetMovies(string title);
    }
}