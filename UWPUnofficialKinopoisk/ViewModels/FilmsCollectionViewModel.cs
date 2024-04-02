using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UWPUnofficialKinopoisk.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static UWPUnofficialKinopoisk.Services.APIService;
using Windows.UI.Xaml.Controls;
using UWPUnofficialKinopoisk.ControlModels;
using static UWPUnofficialKinopoisk.Helpers.FilmsHelper;

namespace UWPUnofficialKinopoisk.ViewModels
{
    public class FilmsCollectionViewModel : ObservableObject
    {
        public ObservableCollection<FilmControlModel> FilmsList { get; set; } = new ObservableCollection<FilmControlModel>();

        public FilmsCollectionViewModel()
        {
            LoadDataAsync();
        }

        private async void LoadDataAsync(FilmCollectionsTypesEnum type = FilmCollectionsTypesEnum.TOP_POPULAR_ALL, uint page = 1)
        {
            try
            {
                var films = await GetFilmsAsync(type, page);

                var filmsList = films.Select(f => new FilmControlModel(f.KinopoiskId,
                                                                      f.PosterUrl,
                                                                      f.NameRu,
                                                                      GetInfo(f)));

                FilmsList.Clear();
                filmsList.ToList().ForEach(f => FilmsList.Add(f));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading films: " + ex.Message);
            }
        }
    }
}
