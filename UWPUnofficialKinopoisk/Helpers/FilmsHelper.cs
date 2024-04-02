using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UWPUnofficialKinopoisk.Models;

namespace UWPUnofficialKinopoisk.Helpers
{
    public static class FilmsHelper
    {
        public static string GetInfo(Film film) =>
            $"{film?.Year}, {film?.RatingKinopoisk}, {film?.FilmLength} min.";
    }
}
