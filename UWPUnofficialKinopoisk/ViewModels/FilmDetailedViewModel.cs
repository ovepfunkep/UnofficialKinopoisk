using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;

using UWPUnofficialKinopoisk.Models;
using UWPUnofficialKinopoisk.Services;

namespace UWPUnofficialKinopoisk.ViewModels
{
    public class FilmDetailedViewModel : ObservableObject
    {
        private Film _film;
        public Film Film
        {
            get => _film;
            set => SetProperty(ref _film, value);
        }

        public FilmDetailedViewModel(int kinopoiskID) 
        {
            LoadFilmAsync(kinopoiskID);
        }

        private async void LoadFilmAsync(int kinopoiskID)
        {
            Film = await APIService.GetFilmAsync(kinopoiskID);
        }
    }
}
