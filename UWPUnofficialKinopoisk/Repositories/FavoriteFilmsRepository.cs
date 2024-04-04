using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using UWPUnofficialKinopoisk.Models;

namespace UWPUnofficialKinopoisk.Repositories
{
    public static class FavoriteFilmsRepository
    {
        private static readonly string FilePath = ApplicationData.Current.LocalFolder.Path + "\\favoriteFilms.json";

        public static void AddFavoriteFilm(int filmId)
        {
            var data = GetAllFavoriteFilmsIDs() ?? new List<int>();
            data.Add(filmId);
            SaveFavoriteFilms(data);
        }
        
        public static void RemoveFavoriteFilm(int filmId)
        {
            var data = GetAllFavoriteFilmsIDs() ?? new List<int>();
            data.Remove(filmId);
            SaveFavoriteFilms(data);
        }

        public static List<int> GetAllFavoriteFilmsIDs()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<int>>(json);
            }
            return new List<int>();
        }

        public static void ApplyFavoriteFilmsIDs(this List<Film> films)
        {
            var favoriteFilmsIDs = GetAllFavoriteFilmsIDs();
            films.ForEach(f => f.IsFavorite = favoriteFilmsIDs.Any(fID => fID == f.KinopoiskId));
        }

        private static void SaveFavoriteFilms(List<int> data)
        {
            var json = JsonConvert.SerializeObject(data);
            File.WriteAllText(FilePath, json);
        }
    }
}
