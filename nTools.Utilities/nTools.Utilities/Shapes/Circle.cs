using System;
using System.Collections.Generic;
using System.Text;

using Drawing = System.Drawing;

namespace nTools.Utilities.Shapes
{
    public class Circle : IShape
    {
        Drawing.Point _center;
        Drawing.Rectangle _boundingRectangle;
        Drawing.Region _boundingRegion;
        

        public Drawing.Point Center { get { return _center; } }
        public Drawing.Rectangle BoundingRectangle { get { return _boundingRectangle; } }
        public Drawing.Region BoundingRegion { get { return _boundingRegion; } }

        #region Contains

        public bool Contains(Drawing.Point singlePoint)
        {
            
            return false;
        }

        public bool Contains(Drawing.Rectangle rectangle)
        {

            return false;
        }

        public bool Contains(Drawing.Region region)
        {

            return false;
        }

        public bool Contains(IShape shape)
        {

            return false;
        }

        #endregion

        #region Intersects

        public bool Intersects(Drawing.Point singlePoint)
        {

            return false;
        }

        public bool Intersects(Drawing.Rectangle rectangel)
        {

            return false;
        }

        public bool Intersects(Drawing.Region region)
        {

            return false;
        }

        public bool Intersects(IShape shape)
        {

            return false;
        }

        #endregion

    }
}
