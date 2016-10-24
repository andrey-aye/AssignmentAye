using System.Collections.Generic;

namespace AssignmentAye.Models
{
    public class SearchResultModel
    {
        public List<MovieModel> Search { get; set; }
        public string totalResults { get; set; }
        public bool Response { get; set; }

    }
}