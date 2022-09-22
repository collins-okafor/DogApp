using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        
        {
        }

        public DbSet <Dog> Dogs { get; set; }
        public DbSet <Breed> Breeds { get; set; }

    }
}