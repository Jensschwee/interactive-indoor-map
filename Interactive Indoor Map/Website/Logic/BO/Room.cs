using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO
{
    public abstract class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Alias { get; set; }
        public RoomType RoomType { get; set; }
    }

    public enum RoomType
    {
        Classroom, Studyzone, Office, Hallway, Stairs, Elevator, Toilet, Utility
    }
}