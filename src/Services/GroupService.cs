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

        public IEnumerable<Group> GetGroups()
        {
            return _unitOfWork.Groups.GetAll();
        }

        public Group GetGroupById(int id)
        {
            return _unitOfWork.Groups.GetGroupById(id);
        }

        public Group GetGroupForUser(User user)
        {
            return _unitOfWork.Groups.GetGroupById(1);
        }

    }
}
