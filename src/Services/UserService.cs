using System;
using System.Collections.Generic;
using Models;
using Repository.UnitOfWork;

namespace Services
{
    public class UserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>List of Users</returns>
        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        /// <summary>
        /// Find User by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User</returns>
        public User GetUserById(int id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="skill">Skill index</param>
        /// <param name="remoteness">Remote index</param>
        /// <returns>User</returns>
        public User CreateUser(string name, float skill, int remoteness)
        {
            return new User
            {
                Name = name,
                SkillIndex = skill,
                RemoteIndex = remoteness,
                ConnectedAt = DateTime.Now
            };
        }

        /// <summary>
        /// Connect User To Group
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="group">Group</param>
        public void ConnectUserToGroup(User user, Group group)
        {
            user.GroupId = group.Id;

            group.ConnectedUsers++;

            if (group.MaxUsers <= group.ConnectedUsers)
            {
                group.IsActive = false;
            }

            _unitOfWork.Users.AddUser(user);
        }
    }
}
