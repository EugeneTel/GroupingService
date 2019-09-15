using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;

namespace Repository.Repositories
{
    public class UserRepository
    {
        private DbSet<User> _dbSet;

        private AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Users;
        }
        public User GetUserById(int id)
        {
            return _dbSet.Where(u => u.Id == id).Select(u => new User
            {
                Id = u.Id,
                Name = u.Name,
                SkillIndex = u.SkillIndex,
                RemoteIndex = u.RemoteIndex

            }).FirstOrDefault();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbSet.Select(u => new User
            {
                Id = u.Id,
                Name = u.Name,
                SkillIndex = u.SkillIndex,
                RemoteIndex = u.RemoteIndex,
                ConnectedAt = u.ConnectedAt
            }).ToList();
        }

        public void SaveUser(User user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

    }
}