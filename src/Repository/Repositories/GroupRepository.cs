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

        private AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Groups;
        }

        /// <summary>
        /// Find Group by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Group</returns>
        public Group GetGroupById(int id)
        {
            return _dbSet.Where(g => g.Id == id).Select(g => new Group
            {
                Id = g.Id

            }).FirstOrDefault();
        }

        /// <summary>
        /// Get All Groups
        /// </summary>
        /// <returns>List of Groups</returns>
        public IEnumerable<Group> GetAll()
        {
            return _dbSet.Select(g => new Group
            {
                Id = g.Id
            }).ToList();
        }

        /// <summary>
        /// Get group in provided skills and remoteness range 
        /// </summary>
        /// <param name="skillIndex">Skill Index</param>
        /// <param name="remoteIndex">Remoteness</param>
        /// <param name="range"></param>
        /// <returns>Group model</returns>
        public Group GetGroupInRange(float skillIndex, int remoteIndex, float range = 0.2f)
        {
            return _dbSet.Where(g => 
                g.BaseSkillIndex >= skillIndex - range
                && g.BaseSkillIndex <= skillIndex + range
                && g.BaseRemoteIndex >= remoteIndex - range * 100
                && g.BaseRemoteIndex <= remoteIndex + range * 100
                && g.IsActive == true
            ).OrderBy(g => g.BaseRemoteIndex).FirstOrDefault<Group>();
        }

        /// <summary>
        /// Create a new Group
        /// </summary>
        /// <param name="skillIndex">Base Skill index</param>
        /// <param name="remoteIndex">Base remoteness</param>
        /// <returns>Group model</returns>
        public Group Create(float skillIndex, int remoteIndex)
        {
            var maxUsers = 5;

            var group = new Group
            {
                BaseRemoteIndex = remoteIndex,
                BaseSkillIndex = skillIndex,
                MaxUsers = maxUsers,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            _dbSet.Add(group);

            _context.SaveChanges();

            return group;
        }
    }
}