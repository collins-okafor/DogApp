using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Model;
using AutoMapper;

namespace api.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dog, DogCreation>();
            CreateMap<DogCreation, Dog>();

            CreateMap<Dog, DogRead>();
            CreateMap<DogRead, Dog>();

            CreateMap<Breed, BreedCreation>();
            CreateMap<BreedCreation, Breed>();

            CreateMap<Breed, BreedRead>();
            CreateMap<BreedRead, Breed>();
        }
    }
}