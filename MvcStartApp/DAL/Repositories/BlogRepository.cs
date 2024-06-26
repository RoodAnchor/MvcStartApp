﻿using MvcStartApp.Models.Db;
using Microsoft.EntityFrameworkCore;
using MvcStartApp.DAL.Db;

namespace MvcStartApp.DAL.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            var entry = _context.Entry(user);

            if (entry.State == EntityState.Detached )
            {
                await _context.Users.AddAsync(user);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<User[]> GetUsers()
        {
            return await _context.Users.ToArrayAsync();
        }
    }
}
