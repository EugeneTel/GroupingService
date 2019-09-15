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

        public float SkillIndex { get; set; }
        public int RemoteIndex { get; set; }
        public DateTime ConnectedAt { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }        
        //public virtual Group Group { get; set; }
    }
}
