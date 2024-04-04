using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.Input;

using UWPUnofficialKinopoisk.Models;
using static UWPUnofficialKinopoisk.Repositories.FavoriteFilmsRepository;

namespace UWPUnofficialKinopoisk.Commands
{
    public class FavoritesCommands
    {
        public ICommand AddToFavoritesCommand { get; }

        public FavoritesCommands()
        {
            AddToFavoritesCommand = new RelayCommand<Film>(film => SwitchFilmIsFavorite(film));
        }

        private void SwitchFilmIsFavorite(Film film)
        {
            if (film.IsFavorite ?? false) RemoveFavoriteFilm(film.KinopoiskId);
            else AddFavoriteFilm(film.KinopoiskId);

            film.IsFavorite = !film.IsFavorite;
        }
    }
}
