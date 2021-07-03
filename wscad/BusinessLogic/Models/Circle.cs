using System.Collections.Generic;
using System.Drawing;

namespace wscad.BusinessLogic.Models
{
    public class Circle: Primitive
    {
        public string Center { get; set; }
        public float Radius { get; set; }

        public override List<PointF> GetOriginPoints
        {
            get
            {
                var center = GetPoint(Center);
                return new List<PointF>
                {
                    new PointF(center.X + Radius, center.Y + Radius),
                    new PointF(center.X + Radius, center.Y - Radius),
                    new PointF(center.X - Radius, center.Y + Radius),
                    new PointF(center.X - Radius, center.Y - Radius)
                };
            }
        }

        public override void DrawFigure(Graphics g, ScaleParameters scale)
        {           
            var center = GetPoint(Center, scale);
            var radiusX = Radius * scale?.ScaleX ?? 1;
            var radiusY = Radius * scale?.ScaleY ?? 1;

            if (Filled)
            {
                SolidBrush brush = new SolidBrush(ArgbColor);
                g.FillEllipse(brush, center.X - radiusX, center.Y - radiusY, 2 * radiusX, 2 * radiusY);
            }
            else
            {
                Pen pen = new Pen(ArgbColor);
                g.DrawEllipse(pen, center.X - radiusX, center.Y - radiusY, 2 * radiusX, 2 * radiusY);

            }
        }
    }
}
