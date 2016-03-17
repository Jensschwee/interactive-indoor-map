using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Area
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<Coordinates> Vertices { get; set; }

        public Area() { }

        public Area(List<Coordinates> vertices)
        {
            Vertices = vertices;
        }

        public Area(Area areaToCopy)
        {
            Vertices = areaToCopy.Vertices;
        }
    }
}