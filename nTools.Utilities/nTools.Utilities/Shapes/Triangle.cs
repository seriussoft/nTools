using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;
using SMath = System.Math;

namespace nTools.Utilities.Shapes
{
    public class Triangle : Line//, IShape
    {
        Line _hypotenuse;
        Line _adjacent;
        Line _opposite;



        #region Static Methods
        /// <summary>
        /// finds the length of the opposite side of a right triangle given point a, and point b
        /// </summary>
        /// <param name="a">the point who's rays are the hypotenuse and adjacent sides</param>
        /// <param name="b">the point how's rays are the hypotenuse and opposite sides</param>
        /// <returns></returns>
        public static double GetOppositeLength(Drawing.Point a, Drawing.Point b)
        {
            return (double)(b.Y - a.Y);
        }

        /// <summary>
        /// finds the length of the hypotenuse of a right triangle given point a, and point b
        /// </summary>
        /// <param name="a">the point who's rays are the hypotenuse and adjacent sides</param>
        /// <param name="b">the point how's rays are the hypotenuse and opposite sides</param>
        /// <returns></returns>
        public static double GetHypotenuseLength(Drawing.Point a, Drawing.Point b)
        {
            return SMath.Sqrt(SMath.Pow(b.X - a.X, 2) + SMath.Pow(b.Y - a.Y, 2));
        }

        /// <summary>
        /// finds the length of the opposite side of a right triangle given point a, and point b
        /// </summary>
        /// <param name="a">the point who's rays are the hypotenuse and adjacent sides</param>
        /// <param name="b">the point how's rays are the hypotenuse and opposite sides</param>
        /// <returns></returns>
        public static float GetOppositeLength(Drawing.PointF a, Drawing.PointF b)
        {
            return b.Y - a.Y;
        }

        /// <summary>
        /// finds the length of the hypotenuse of a right triangle given point a, and point b
        /// </summary>
        /// <param name="a">the point who's rays are the hypotenuse and adjacent sides</param>
        /// <param name="b">the point how's rays are the hypotenuse and opposite sides</param>
        /// <returns></returns>
        public static float GetHypotenuseLength(Drawing.PointF a, Drawing.PointF b)
        {
            return (float)SMath.Sqrt(SMath.Pow(b.X - a.X, 2) + SMath.Pow(b.Y - a.Y, 2));
        }

        #endregion

    }
}
