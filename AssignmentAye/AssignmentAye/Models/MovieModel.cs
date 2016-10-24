using System.Windows.Input;

namespace AssignmentAye.Models
{
    public class MovieModel
    {
        public string Type { get; set; }
        public string imdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public ICommand RateCommand { get; set; }
    }
}