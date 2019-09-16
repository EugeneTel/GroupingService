using Repository.UnitOfWork;
using System.Collections.Generic;
using System;
using Models;
using System.Linq;

namespace Services.Reports
{
    public class ReportService
    {
        private IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create a Report for a Group
        /// </summary>
        /// <param name="groups">List of Groups</param>
        /// <returns>List of Reports</returns>
        public List<IReport> CreateGroupReport(IEnumerable<Group> groups)
        {
            List<IReport> report = new List<IReport>();
            foreach (Group group in groups)
            {
                DateTime waitTillTime = group.IsStarted ? (DateTime)group.StartedAt : DateTime.Now;

                report.Add(new GroupReport
                {
                    MatchNumber = group.Id,
                    NumPlayers = group.ConnectedUsers,
                    MinSkillIndex = group.Users.Min(em => em.SkillIndex),
                    MaxSkillIndex = group.Users.Max(em => em.SkillIndex),
                    AvgSkillIndex = group.Users.Average(em => em.SkillIndex),
                    MinRemoteIndex = group.Users.Min(em => em.RemoteIndex),
                    MaxRemoteIndex = group.Users.Max(em => em.RemoteIndex),
                    AvgRemoteIndex = group.Users.Average(em => em.RemoteIndex),
                    MinWaitingTime = group.Users.Min(em => waitTillTime.Subtract(em.ConnectedAt).TotalSeconds),
                    MaxWaitingTime = group.Users.Max(em => waitTillTime.Subtract(em.ConnectedAt).TotalSeconds),
                    AvgWaitingTime = group.Users.Average(em => waitTillTime.Subtract(em.ConnectedAt).TotalSeconds)
                });
            }

            return report;
        }



    }
}
