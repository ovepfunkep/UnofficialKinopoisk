using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UWPUnofficialKinopoisk.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using static UWPUnofficialKinopoisk.Services.APIService;
using UWPUnofficialKinopoisk.ControlModels;
using UWPUnofficialKinopoisk.Repositories;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace UWPUnofficialKinopoisk.ViewModels
{
    public class FilmsCollectionViewModel : ObservableObject
    {
        private List<FilmControlModel> FilmsList { get; set; } = new List<FilmControlModel>();
        private bool _showOnlyFavorites = false;
        public bool ShowOnlyFavorites
        {
            get => _showOnlyFavorites;
            set => SetProperty(ref _showOnlyFavorites, value);
        }
        public ObservableCollection<FilmControlModel> FilteredFilmsList { get; set; } = new ObservableCollection<FilmControlModel>();
        public ICommand ApplyFiltersCommand { get; }

        public void ApplyFilters()
        {
            FilteredFilmsList.Clear();
            FilmsList.Where(f => !ShowOnlyFavorites || f.Film.IsFavorite == ShowOnlyFavorites)
                     .ToList()
                     .ForEach(f => FilteredFilmsList.Add(f));
        }

        public FilmsCollectionViewModel()
        {
            LoadDataAsync();
            ApplyFiltersCommand = new RelayCommand(ApplyFilters);
        }

        private async void LoadDataAsync(FilmCollectionsTypesEnum type = FilmCollectionsTypesEnum.TOP_POPULAR_ALL, uint page = 1)
        {
            try
            {
                var films = await GetFilmsAsync(type, page);
                films.ApplyFavoriteFilmsIDs();

                var filmsList = films.Select(f => new FilmControlModel(f));

                FilmsList.Clear();
                filmsList.ToList().ForEach(f => FilmsList.Add(f));
                ApplyFilters();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading films: " + ex.Message);
            }
        }
    }
}
