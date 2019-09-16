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

        /// <summary>
        /// Find User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User model</returns>
        public User GetUserById(int id)
        {
            return _dbSet.Where(u => u.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List of Users</returns>
        public IEnumerable<User> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user">User model</param>
        public void AddUser(User user)
        {
            _dbSet.Add(user);
            _context.SaveChanges();
        }

    }
}