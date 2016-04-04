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

        private double _xSum;
        private double _ySum;

        public Corners() { }

        public Corners(List<Coordinates> cornerCoordinates)
        {
            MatchCoordinatesToCorners(cornerCoordinates);

            //TopLeftCorner = cornerCoordinates[0];
            //BottomLeftCorner = cornerCoordinates[1];
            //BottomRightCorner = cornerCoordinates[2];
            //TopRightCorner = cornerCoordinates[3];
        }

        private void MatchCoordinatesToCorners(List<Coordinates> cornerCoordinates)
        {
            foreach (var coordinateSet in cornerCoordinates)
            {
                _xSum += coordinateSet.XCoordinate;
                _ySum += coordinateSet.YCoordinate;
            }

            SetCorners(cornerCoordinates);
        }

        private void SetCorners(List<Coordinates> cornerCoordinates)
        {
            var averageX = _xSum/4;
            var averageY = _ySum/4;

            foreach (var coordinateSet in cornerCoordinates)
            {
                if (coordinateSet.XCoordinate > averageX && coordinateSet.YCoordinate > averageY)
                {
                    TopLeftCorner = coordinateSet;
                }
                else if (coordinateSet.XCoordinate < averageX && coordinateSet.YCoordinate > averageY)
                {
                    BottomLeftCorner = coordinateSet;
                }
                else if (coordinateSet.XCoordinate < averageX && coordinateSet.YCoordinate < averageY)
                {
                    BottomRightCorner = coordinateSet;
                }
                else if (coordinateSet.XCoordinate > averageX && coordinateSet.YCoordinate < averageY)
                {
                    TopRightCorner = coordinateSet;
                }
            }
        }
    }
}