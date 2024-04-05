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
        private ushort _yearLowerBound = 0;
        public ushort YearLowerBound 
        {
            get => _yearLowerBound;
            set => SetProperty(ref _yearLowerBound, value);
        }

        public ObservableCollection<FilmControlModel> FilteredFilmsList { get; set; } = new ObservableCollection<FilmControlModel>();
        public ICommand ApplyFiltersCommand { get; }

        public void ApplyFilters()
        {
            FilteredFilmsList.Clear();
            FilmsList.Where(f => IsFilmSuits(f.Film))
                     .ToList()
                     .ForEach(f => FilteredFilmsList.Add(f));
        }

        private bool IsFilmSuits(Film film) => IsFavoriteSatisfies(film.IsFavorite) && IsYearSatisfies(film.Year ?? film.StartYear);
        private bool IsFavoriteSatisfies(bool? isFavorite) => !ShowOnlyFavorites || isFavorite == ShowOnlyFavorites;
        private bool IsYearSatisfies(int? year) => year != null && year >= YearLowerBound;

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
