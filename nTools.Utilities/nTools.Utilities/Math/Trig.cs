using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;
using SMath = System.Math;

namespace nTools.Utilities.Math
{
    /// <summary>
    /// Series of static methods to aid in development of Trig based solutions
    /// </summary>
    public static class Trig
    {
        #region AngleOf Methods

        /// <summary>
        /// finds the angle theta given length of hypotenuse and opposite sides
        /// </summary>
        /// <param name="oppositeLength">length of the opposite side (make negative to represent negative</param>
        /// <param name="hypotenuseLength">length of the hypotenuse</param>
        /// <returns></returns>
        public static float AngleOf(int oppositeLength, int hypotenuseLength)
        {
            return (float)SMath.Asin(oppositeLength / hypotenuseLength);
        }

        /// <summary>
        /// finds the angle theta given point a and point b
        /// </summary>
        /// <param name="a">point who's rays encompass the hypotenuse and adjacent sides</param>
        /// <param name="b">point who's rays encompass the hypotenuse and opposite sides</param>
        /// <returns type="System.float"></returns>
        public static float AngleOf(Drawing.Point a, Drawing.Point b)
        {
            return (float)SMath.Asin(Shapes.Triangle.GetOppositeLength(a, b) / Shapes.Triangle.GetHypotenuseLength(a, b));
        }

        /// <summary>
        /// finds the angle theta given 2 sets of coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static float AngleOf(int x1, int y1, int x2, int y2)
        {
            return AngleOf(new Drawing.Point(x1, x2), new System.Drawing.Point(x2, y2));
        }

        /// <summary>
        /// finds the angle theta given point a and point b
        /// </summary>
        /// <param name="a">point who's rays encompass the hypotenuse and adjacent sides</param>
        /// <param name="b">point who's rays encompass the hypotenuse and opposite sides</param>
        /// <returns type="System.float"></returns>
        public static float AngleOf(Drawing.PointF a, Drawing.PointF b)
        {
            return (float)SMath.Asin(Shapes.Triangle.GetOppositeLength(a, b) / Shapes.Triangle.GetHypotenuseLength(a, b));
        }

        /// <summary>
        /// finds the angle theta given 2 sets of coordinates
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static float AngleOf(float x1, float y1, float x2, float y2)
        {
            return AngleOf(new Drawing.PointF(x1, x2), new System.Drawing.PointF(x2, y2));
        }

        #endregion
    }
}
