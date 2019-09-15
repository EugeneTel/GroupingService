using System;
using System.Collections.Generic;
using Models;
using Repository.UnitOfWork;

namespace Services
{
    public class GroupService
    {
        private IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get All Groups
        /// </summary>
        /// <returns>List of Groups</returns>
        public IEnumerable<Group> GetGroups()
        {
            return _unitOfWork.Groups.GetAll();
        }

        /// <summary>
        /// Find Group By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Group</returns>
        public Group GetGroupById(int id)
        {
            return _unitOfWork.Groups.GetGroupById(id);
        }

        /// <summary>
        /// Find a Group for a User according to Skill Index and Remoteness
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Group</returns>
        public Group GetGroupForUser(User user)
        {
            var group = _unitOfWork.Groups.GetGroupInRange(user.SkillIndex, user.RemoteIndex);

            if (group == null)
            {
                group = _unitOfWork.Groups.Create(user.SkillIndex, user.RemoteIndex);
            }

            return group;
        }
       

    }
}
