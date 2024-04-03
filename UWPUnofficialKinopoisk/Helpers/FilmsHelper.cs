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
        public static string GetInfo(Film film)
        {
            var sb = new StringBuilder();

            if (film.Type == FilmTypesEnum.FILM.ToString())
            {
                if (film.Year != null) sb.Append(film.Year);
                if (film.FilmLength != null)
                {
                    if (film.Year != null) sb.Append(", ");
                    sb.Append($"{film.FilmLength} min.");
                }
            }
            else
            {
                if (film.StartYear != null)
                {
                    sb.Append(film.StartYear);
                    if (film.Completed ?? false && film.EndYear != null)
                    {
                        sb.Append($" - {film.EndYear}");
                    }
                }
            }

            if (film.RatingImdb != null)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append($"imdb: {film.RatingImdb}");
            }
            else if (film.RatingKinopoisk != null)
            {
                if (sb.Length > 0) sb.Append(", ");
                sb.Append($"our rating: {film.RatingKinopoisk}");
            }

            if (film.Genres.Count > 0)
            {
                if (sb.Length == 0) sb.Append(film.Genres[0].genre);
                film.Genres.Skip(1).ToList().ForEach(g => sb.Append($", {g.genre}"));
            }

            if (film.Countries.Count > 0)
            {
                if (sb.Length == 0) sb.Append(film.Countries[0].country);
                film.Countries.Skip(1).ToList().ForEach(g => sb.Append($", {g.country}"));
            }

            return sb.ToString();
        }
    }
}
