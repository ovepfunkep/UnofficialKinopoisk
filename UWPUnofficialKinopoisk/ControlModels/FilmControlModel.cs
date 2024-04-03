using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UWPUnofficialKinopoisk.Models;
using UWPUnofficialKinopoisk.ViewModels;
using UWPUnofficialKinopoisk.Views;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using static UWPUnofficialKinopoisk.Helpers.FilmsHelper;

namespace UWPUnofficialKinopoisk.ControlModels
{
    public class FilmControlModel
    {
        private Film _film;
        public Film Film 
        {
            get => _film;
            set
            {
                _film = value;
                FilmInfo = GetInfo(value);
            }
        }
        public string FilmInfo { get; private set; }

        public FilmControlModel(Film film)
        {
            Film = film;
        }

        public void SwitchToDetailed()
        {
            (Application.Current as App).NavigateTo(typeof(FilmDetailedPage), Film.KinopoiskId);
        }
    }
}
