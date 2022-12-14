using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Model
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Friendliness { get; set; }
        public int Trainability { get; set; }
        public int SheddingAmount { get; set; }
        public int ExerciseNeeds { get; set; } 
        public Dog Dog { get; set; }
    }
}