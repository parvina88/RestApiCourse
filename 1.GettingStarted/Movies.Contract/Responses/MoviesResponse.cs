﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Contract.Responses
{
    public class MoviesResponse
    {
        public IEnumerable<MovieResponse> Items { get; set; }
    }
}
