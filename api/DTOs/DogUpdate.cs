using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class DogUpdate
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteToy { get; set; }
    }
}