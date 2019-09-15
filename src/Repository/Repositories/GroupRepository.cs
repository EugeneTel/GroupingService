using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository.Context;

namespace Repository.Repositories
{
    public class GroupRepository
    {
        private DbSet<Group> _dbSet;

        public GroupRepository(AppDbContext context)
        {
            _dbSet = context.Groups;
        }
        public Group GetGroupById(int id)
        {
            return _dbSet.Where(g => g.Id == id).Select(g => new Group
            {
                Id = g.Id

            }).FirstOrDefault();
        }

        public IEnumerable<Group> GetAll()
        {
            return _dbSet.Select(g => new Group
            {
                Id = g.Id
            }).ToList();
        }
    }
}