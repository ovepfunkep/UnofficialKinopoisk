using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPUnofficialKinopoisk.Models
{
    public class FilmsCollectionResponse
    {
        public uint Total { get; set; }
        public uint TotalPages { get; set; }
        public List<Film> Items { get; set; }
    }
}
