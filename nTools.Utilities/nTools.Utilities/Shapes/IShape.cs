using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;

namespace nTools.Utilities.Shapes
{
    public interface IShape
    {
        Drawing.Point Center {get;}
        Drawing.Rectangle BoundingRectangle {get;}
        Drawing.Region BoundingRegion {get;}

        bool Contains(Drawing.Point singlePoint);
        bool Contains(Drawing.Rectangle rectangle);
        bool Contains(Drawing.Region region);
        bool Contains(IShape shape);

        bool Intersects(Drawing.Point singlePoint);
        bool Intersects(Drawing.Rectangle rectangel);
        bool Intersects(Drawing.Region region);
        bool Intersects(IShape shape);

    }

    public interface IShapeF
    {
        Drawing.PointF Center { get; }
        Drawing.RectangleF BoundingRectangle { get; }
        Drawing.Region BoundingRegion { get; }

        bool Contains(Drawing.PointF singlePoint);
        bool Contains(Drawing.RectangleF rectangle);
        bool Contains(Drawing.Region region);
        bool Contains(IShapeF shape);

        bool Intersects(Drawing.PointF singlePoint);
        bool Intersects(Drawing.RectangleF rectangel);
        bool Intersects(Drawing.Region region);
        bool Intersects(IShapeF shape);
    }
}
