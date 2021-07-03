using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace wscad.BusinessLogic.Models
{
    public class ScaleParameters
    {
        public ScaleParameters()
        {
        }

        public ScaleParameters(List<PointF> points, Size size)
        {
            var width = Math.Abs(points.Max(x => x.X) - points.Min(x => x.X));
            var height = Math.Abs(points.Max(y => y.Y) - points.Min(y => y.Y));

            ScaleX = (size.Width - 1) / width;
            ScaleY = (size.Height - 1) / height;

            MoveX = points.Min(x => x.X) * ScaleX;
            MoveY = points.Min(y => y.Y) * ScaleY;
        }

        public float ScaleX { get; set; } = 1;
        public float ScaleY { get; set; } = 1;

        public float MoveX { get; set; } = 0;
        public float MoveY { get; set; } = 0;
    }
}
