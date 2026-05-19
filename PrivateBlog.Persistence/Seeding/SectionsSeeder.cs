using PrivateBlog.Domain.Entities.Sections;
using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Text;
using PrivateBlog.Persistence.Data;

namespace PrivateBlog.Persistence.Seeding
{
    internal class SectionsSeeder : ISeedable
    {
        private readonly ApplicationDbContext _context;

        public SectionsSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            string[] sections =
            [
                "Technology",
                "Lifestyle",
                "Travel",
                "Food",
                "Health",
                "Education",
                "Entertainment",
                "Business",
                "Sports",
                "Politics"
            ];

            foreach (string section in sections) 
            {
                if (!_context.Sections.Any(s => s.Name == section))
                {
                    await _context.Sections.AddAsync(new Section(section));
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}

