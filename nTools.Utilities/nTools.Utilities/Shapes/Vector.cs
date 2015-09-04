using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;

namespace nTools.Utilities.Shapes
{
    public struct Vector
    {
        Drawing.Point _point;

        #region Properties

        public static Vector Empty { get { return new Vector(0, 0); } }

        public int X
        {
            get { return _point == null ? 0 : _point.X; }
            set { _point.X = value; }
        }

        public int Y
        {
            get { return _point == null ? 0 : _point.X; }
            set { _point.Y = value; }
        }

        #endregion

        #region Cstr

        public Vector(Drawing.Point point)
        {
            _point = point;
        }

        public Vector(int x, int y)
        {
            _point = new System.Drawing.Point(x, y);
        }

        #endregion

        #region Methods

        public void SetDifference(Drawing.Point endPoint, Drawing.Point startPoint)
        {
            X = endPoint.X - startPoint.X;
            Y = endPoint.Y - startPoint.Y;
        }

        public void SetSum(Drawing.Point endPoint, Drawing.Point startPoint)
        {
            X = endPoint.X - startPoint.X;
            Y = endPoint.Y - startPoint.Y;
        }

        #endregion

        #region Static Methods

        public static Vector Difference(Drawing.Point endPoint, Drawing.Point startPoint)
        {
            return new Vector(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);
        }

        public static Vector Sum(Drawing.Point endPoint, Drawing.Point startPoint)
        {
            return new Vector(endPoint.X + startPoint.X, endPoint.Y + startPoint.Y);
        }

        public static Vector operator +(Vector left, Vector right)
        {
            return Sum(left._point, right._point);
        }

        public static Vector operator -(Vector endVector, Vector startVector)
        {
            return Difference(endVector._point, endVector._point);
        }

        #endregion

    }
}
