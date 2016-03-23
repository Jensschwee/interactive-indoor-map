using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website.Logic.BO.Utility
{
    public class Corners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Coordinates TopLeftCorner { get; set; }
        public Coordinates BottomLeftCorner { get; set; }
        public Coordinates BottomRightCorner { get; set; }
        public Coordinates TopRightCorner { get; set; }

        public Corners() { }

        public Corners(List<Coordinates> cornerCoordinates)
        {
            //Algorithm which decide which coordinate corresponds to which corner
            TopLeftCorner = cornerCoordinates[0];
            BottomLeftCorner = cornerCoordinates[1];
            BottomRightCorner = cornerCoordinates[2];
            TopRightCorner = cornerCoordinates[3];
        }

    }
}