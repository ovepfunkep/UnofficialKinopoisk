using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using UWPUnofficialKinopoisk.Models;

using Windows.UI.Xaml.Controls;

namespace UWPUnofficialKinopoisk.Services
{
    public static class APIService
    {
        private const string ApiBaseUrl = "https://kinopoiskapiunofficial.tech/api/";
        private const string ApiFilmsSubUrl = "v2.2/films/";
        private const string ApiKey = "7d3e436f-f59c-46dd-989d-dac71211f263";

        public static async Task<List<Film>> GetFilmsAsync(FilmCollectionsTypesEnum type = FilmCollectionsTypesEnum.TOP_POPULAR_ALL, uint page = 1)
        {
            string url = $"{ApiBaseUrl}{ApiFilmsSubUrl}collections?type={type}&page={page}";
            return (await GetAsync<FilmsCollectionResponse>(url)).Items;
        }

        public static async Task<Film> GetFilmAsync(int kinopoiskID)
        {
            string url = ApiBaseUrl + ApiFilmsSubUrl + kinopoiskID;
            return await GetAsync<Film>(url);
        }

        private static async Task<T> GetAsync<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
                client.DefaultRequestHeaders.Add("accept", "application/json");

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var filmsResponse = JsonConvert.DeserializeObject<T>(jsonString);
                    return filmsResponse;
                }
                else throw new Exception("Failed to retrieve films.");
            }
        }
    }
}
