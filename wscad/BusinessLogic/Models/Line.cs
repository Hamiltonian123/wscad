using System.Collections.Generic;
using System.Drawing;

namespace wscad.BusinessLogic.Models
{
    public class Line : Primitive
    {
        public string A { get; set; }
        public string B { get; set; }

        public override List<PointF> GetOriginPoints => new List<PointF> { GetPoint(A), GetPoint(B) };

        public override void DrawFigure(Graphics g, ScaleParameters scale = default)
        {
            Pen pen = new Pen(ArgbColor);

            var pointA = GetPoint(A, scale);
            var pointB = GetPoint(B, scale);

            g.DrawLine(pen, pointA, pointB);
        }
    }
}
