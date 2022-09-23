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
    public class BreedRepository : IBreedRepository
    {
        private readonly DataContext dataContext;

        public BreedRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Add<T>(T entity) where T : class
        {
            dataContext.Add(entity);
        }

        public async Task<Breed> AddBreed(BreedCreation field)
        {
            var Data = new Breed
            {
                Name = field.Name
            };

            await dataContext.Breeds.AddAsync(Data);
            await SaveAll();
            return Data;
        }

        public void Delete<T>(T entity) where T : class
        {
            dataContext.Remove(entity);
        }

        public async Task<bool> DeleteBreed(int id)
        {
            var dataFromRepo = await dataContext.Breeds.FirstOrDefaultAsync(a => a.BreedId == id);
            if(dataFromRepo != null)
            {
                dataContext.Breeds.Remove(dataFromRepo);
                await SaveAll();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<Breed>> GetBreeds()
        {
            var dataFromRepo = await dataContext.Breeds.ToListAsync();
            return dataFromRepo;
        }

        public async Task<IEnumerable<object>> GetBreedWithId(int id)
        {
            var dataFromRepo = await dataContext.Breeds.Where(x => x.BreedId == id).Include(x => x.Dog).ToListAsync();
            return dataFromRepo;
        }

        public async Task<IEnumerable<object>> GetBreedWithName(string name)
        {
            var dataFromRepo = await dataContext.Breeds.Where(x => x.Name == name).Include(x => x.Dog).ToListAsync();
            return dataFromRepo;
        }

        public async Task<bool> SaveAll()
        {
            return await dataContext.SaveChangesAsync() > 0;
        }

        public async Task<Breed> UpdateBreed(BreedUpdate model)
        {
            
            var data = await dataContext.Breeds.FirstOrDefaultAsync(x => x.BreedId == model.BreedId);
            if(data == null)

            {
                return null;
            }

            data.Name = model.Name;
            data.Size = model.Size;
            data.Friendliness = model.Friendliness;
            data.Trainability = model.Trainability;
            data.SheddingAmount = model.SheddingAmount;
            data.ExerciseNeeds = model.ExerciseNeeds;
            await SaveAll();

            return data;
        }
    }
}