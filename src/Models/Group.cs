using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 1)]
        public float BaseSkillIndex { get; set; }

        [Range(0, 100)]
        public float BaseRemoteIndex { get; set; }

        [Range(0, 100)]
        public int MaxUsers { get; set; }

        [Range(0, 100)]
        public int ConnectedUsers { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
