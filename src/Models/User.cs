using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 1)]
        public double SkillIndex { get; set; }

        [Range(0, 100)]
        public int RemoteIndex { get; set; }

        public DateTime ConnectedAt { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
    }
}
