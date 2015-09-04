using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;

namespace nTools.Utilities.Shapes
{
    public class Line
    {
        #region Fields

        Drawing.Point _a;
        Drawing.Point _b;
        Vector _vector;
        double _length = 0;
        float _angle = 0f;
        //Drawing.Size _adjacentAndOpposite

        #endregion

        #region Properties

        public Drawing.Point A { get { return _a; } }
        public Drawing.Point B { get { return _b; } }
        public Drawing.Point Vector { get { return _vector; } }
        public int Length { get { return _length; } }
        public float Angle { get { return _angle; } }

        #endregion

        public Line() : this(new Drawing.Point(0, 0), new Drawing.Point(0, 0)) { }
        
        public Line(Drawing.Point a, Drawing.Point b)
        {
            _a = a;
            _b = b;
            _length = Triangle.GetHypotenuseLength(a, b);
            _vector = Shapes.Vector.Difference(b, a);
            _angle = Math.Trig.AngleOf(a, b);
        }

        public Line(Drawing.Point a, float angle, int length)
        {

        }

    }
}
