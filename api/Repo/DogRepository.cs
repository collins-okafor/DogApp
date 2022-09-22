using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.DTOs;
using api.Model;
using api.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.Repo
{
    public class DogRepository : IDogRepository
    {
        private readonly DataContext dataContext;

        public DogRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            dataContext.Add(entity);
        }

        public async Task<Dog> AddDog(DogCreation field)
        {
            var Data = new Dog
            {
                Name = field.Name,
                Age = field.Age,
                Breeds = field.Breeds,
                Gender = field.Gender,
                color = field.color,
                FavoriteFood = field.FavoriteFood,
                FavoriteToy = field.FavoriteToy
            };

            await dataContext.Dogs.AddAsync(Data);
            await SaveAll();
            return Data;

        }

        public void Delete<T>(T entity) where T : class
        {
            dataContext.Remove(entity);
        }

        public async Task<bool> DeleteDog(int id)
        {
            var dataFromRepo = await dataContext.Dogs.FirstOrDefaultAsync(a => a.DogId == id);
            if(dataFromRepo != null)
            {
                dataContext.Dogs.Remove(dataFromRepo);
                await SaveAll();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Dog>> GetDogs()
        {
            var dataFromRepo = await dataContext.Dogs.ToListAsync();
            return dataFromRepo;
        }

        public async Task<IEnumerable<object>> GetDogWithId(int id)
        {
            var dataFromRepo = await dataContext.Dogs.Where(x => x.DogId == id).Include(x => x.Breeds).ToListAsync();
            return dataFromRepo;
        }

        public async Task<IEnumerable<object>> GetDogWithName(string name)
        {
            var dataFromRepo = await dataContext.Dogs.Where(x => x.Name == name).Include(x => x.Breeds).ToListAsync();
            return dataFromRepo;
        }

        public async Task<bool> SaveAll()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Dog> UpdateDog(DogUpdate model)
        {
            var data = await dataContext.Dogs.FirstOrDefaultAsync(x => x.Name == model.Name);
            if(data == null)
            {
                return null;
            }

            data.Name = model.Name;
            data.Age = model.Age;
            data.FavoriteFood = model.FavoriteFood;
            data.FavoriteToy = model.FavoriteToy;
         
            await SaveAll();

            return data;
        }
    }
}