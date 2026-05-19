using Microsoft.AspNetCore.Identity;
using PrivateBlog.Persistence.Entities;
using System;
using PrivateBlog.Persistence.Data;
using System.Collections.Generic;
using PrivateBlog.Persistence.Data;
using System.Text;
using PrivateBlog.Persistence.Data;

namespace PrivateBlog.Persistence.Seeding
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedDb(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await new SectionsSeeder(_context).SeedAsync();
            await new PermissionsSeeder(_context).SeedAsync();
            await new UsersSeeder(_userManager, _context).SeedAsync();
        }
    }
}

