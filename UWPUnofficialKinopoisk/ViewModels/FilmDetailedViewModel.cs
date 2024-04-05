using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using UWPUnofficialKinopoisk.Models;
using UWPUnofficialKinopoisk.Services;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using static UWPUnofficialKinopoisk.Helpers.FilmsHelper;
using static UWPUnofficialKinopoisk.Repositories.FavoriteFilmsRepository;

namespace UWPUnofficialKinopoisk.ViewModels
{
    public class FilmDetailedViewModel : ObservableObject
    {
        private Film _film;
        public Film Film
        {
            get => _film;
            set
            {
                SetProperty(ref _film, value);
                FilmInfo = GetInfo(Film);
            }
        }
        private string _filmInfo;
        public string FilmInfo 
        { 
            get => _filmInfo;
            set => SetProperty(ref _filmInfo, value);
        }

        public ICommand GoBackCommand { get; }

        public FilmDetailedViewModel(int kinopoiskID) 
        {
            LoadFilmAsync(kinopoiskID);
            GoBackCommand = new RelayCommand(MoveToPreviousPage);
        }

        private async void LoadFilmAsync(int kinopoiskID)
        {
            var film = await APIService.GetFilmAsync(kinopoiskID);
            film.IsFavorite = GetAllFavoriteFilmsIDs().Any(fID => fID == film.KinopoiskId);
            Film = film;
        }

        private void MoveToPreviousPage()
        {
            var frame = Window.Current.Content as Frame;
            frame.GoBack();
        }
    }
}
