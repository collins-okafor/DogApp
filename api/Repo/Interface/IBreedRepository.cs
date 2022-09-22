using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Model;

namespace api.Repo.Interface
{
    public interface IBreedRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<Breed> AddBreed(BreedCreation field);
        Task<IEnumerable<Breed>> GetBreeds();
        Task<IEnumerable<object>> GetBreedWithId(int id);
        Task<IEnumerable<object>> GetBreedWithName(string name);
        Task<Breed> UpdateBreed(BreedUpdate model);
        Task<bool> DeleteBreed(int id);
    }
}