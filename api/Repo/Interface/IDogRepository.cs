using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using api.Model;

namespace api.Repo.Interface
{
    public interface IDogRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();

        Task<Dog> AddDog(DogCreation field);
        Task<IEnumerable<Dog>> GetDogs();
        Task<IEnumerable<object>> GetDogWithId(int id);
        Task<IEnumerable<object>> GetDogWithName(string name);
        Task<Dog> UpdateDog(DogUpdate model);
        Task<bool> DeleteDog(int id);
    }
}