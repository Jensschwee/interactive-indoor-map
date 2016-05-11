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

        private double xSum;
        private double ySum;

        public Corners() { }

        public Corners(List<Coordinates> cornerCoordinates)
        {
            MatchCoordinatesToCorners(cornerCoordinates);
        }

        private void MatchCoordinatesToCorners(List<Coordinates> cornerCoordinates)
        {
            foreach (var coordinateSet in cornerCoordinates)
            {
                xSum += coordinateSet.XCoordinate;
                ySum += coordinateSet.YCoordinate;
            }

            SetCorners(cornerCoordinates);
        }

        private void SetCorners(List<Coordinates> cornerCoordinates)
        {
            var averageX = xSum/4;
            var averageY = ySum/4;

            foreach (var coordinateSet in cornerCoordinates)
            {
                if (coordinateSet.XCoordinate > averageX && coordinateSet.YCoordinate > averageY)
                {
                    TopRightCorner  = coordinateSet;
                }
                else if (coordinateSet.XCoordinate < averageX && coordinateSet.YCoordinate > averageY)
                {
                    TopLeftCorner = coordinateSet;
                }
                else if (coordinateSet.XCoordinate < averageX && coordinateSet.YCoordinate < averageY)
                {
                    BottomLeftCorner = coordinateSet;
                }
                else if (coordinateSet.XCoordinate > averageX && coordinateSet.YCoordinate < averageY)
                {
                    BottomRightCorner = coordinateSet;
                }
            }
        }
    }
}