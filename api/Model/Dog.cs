using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Dog
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public ICollection<Breed> Breeds { get; set; }
        public string Gender { get; set; }
        public string color { get; set; }
        public string FavoriteFood { get; set; }
        public string FavoriteToy { get; set; }
    }
}