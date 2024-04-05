using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPUnofficialKinopoisk.Parameters
{
    public class FilmsCollectionPageParameters
    {
        public bool ShowOnlyFavorite { get; set; }

        public FilmsCollectionPageParameters(bool showOnlyFavorite = false)
        {
            ShowOnlyFavorite = showOnlyFavorite;
        }
    }
}
