using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class DogRead
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Model.Breed> Breeds { get; set; }
        public string Gender { get; set; }
        public string color { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteToy { get; set; }
    }
}