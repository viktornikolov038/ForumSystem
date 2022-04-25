using ForumSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Data.Seeding
{
    internal class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Categories.AnyAsync())
            {
                return;
            }

            var categories = new List<Category>
            {
                new Category { Name = "Sports", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Programming", CreatedOn = DateTime.UtcNow },
                new Category { Name = "News", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Gaming", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Travel", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Tv", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Health & Fitness", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Music", CreatedOn = DateTime.UtcNow },
                new Category { Name = "Cars", CreatedOn = DateTime.UtcNow }
            };

            await dbContext.AddRangeAsync(categories);
        }
    }
}
