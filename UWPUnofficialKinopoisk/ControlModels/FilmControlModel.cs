using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UWPUnofficialKinopoisk.ControlModels
{
    public class FilmControlModel
    {
        public int KinopoiskId { get; set; }
        public string ImageURL { get; set; }
        public string FilmName { get; set; }
        public string FilmInfo { get; set; }

        public FilmControlModel(int kinopoiskId,
                                string imageURL, 
                                string filmName, 
                                string filmInfo)
        {
            KinopoiskId = kinopoiskId;
            ImageURL = imageURL;
            FilmName = filmName;
            FilmInfo = filmInfo;
        }
    }
}
