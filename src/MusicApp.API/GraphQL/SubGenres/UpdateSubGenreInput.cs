﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.API.GraphQL.SubGenres
{
    public record UpdateSubGenreInput(int Id, string Title, DateTime DateCreated);
}
