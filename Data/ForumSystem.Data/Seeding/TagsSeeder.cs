﻿namespace ForumSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Models;

    internal class TagsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Tags.AnyAsync())
            {
                return;
            }

            var tags = new List<Tag>
            {
                new Tag { Name = "C#", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Python", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Java", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "MongoDB", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "NoSQL", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "SQL", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Football", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Basketball", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "PS4", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Microsoft", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Facebook", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Instagram", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Audi", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Mercedes", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "BMW", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "Dota", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "CS: GO", CreatedOn = DateTime.UtcNow },
                new Tag { Name = "League Of Legends", CreatedOn = DateTime.UtcNow },
            };

            await dbContext.AddRangeAsync(tags);
        }
    }
}
