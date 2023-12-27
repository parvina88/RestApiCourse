using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Movies.Application.Models
{
    public partial class Movie
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public required int YearOfRelease { get; set; }
        public string Slug => GenerateSlug();

        private string GenerateSlug()
        {
            var sluggerTitle = SlagRegex().Replace(Title, string.Empty)
                .ToLower().Replace(" ", "-");
            return $"{sluggerTitle}-{YearOfRelease}";
        }
        
        

        public required List<string> Genres { get; set; } = new();

        [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 5)]
        private static partial Regex SlagRegex();
    }
}
