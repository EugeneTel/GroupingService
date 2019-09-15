using System;
using System.Collections.Generic;

namespace Models
{
    public class Group
    {
        public int Id { get; set; }
        public float AvgSkillIndex { get; set; }
        public float AvgRemoteIndex { get; set; }
        public int MaxUsers { get; set; }
        public int ConnectedUsers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime FinishedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
