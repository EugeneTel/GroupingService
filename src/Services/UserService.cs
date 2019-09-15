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

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.Users.GetAll();
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        public User CreateUser(string name)
        {
            return new User
            {
                Name = name,
                SkillIndex = 0.5f,
                RemoteIndex = 50,
                ConnectedAt = DateTime.Now
            };
        }

        public void ConnectUserToGroup(User user, Group group)
        {
            // user.Group = group;
            _unitOfWork.Users.SaveUser(user);
        }
    }
}
