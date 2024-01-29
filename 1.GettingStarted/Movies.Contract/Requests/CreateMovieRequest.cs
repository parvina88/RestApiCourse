using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contract.Requests
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }
        public int YearOfRelease { get; set; }

        public IEnumerable<string> Genres { get; set; } = Enumerable.Empty<string>();
    }
}
