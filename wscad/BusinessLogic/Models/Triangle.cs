using System.Collections.Generic;
using System.Drawing;

namespace wscad.BusinessLogic.Models
{
    public class Triangle : Primitive
    {
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public override List<PointF> GetOriginPoints => 
            new List<PointF> { GetPoint(A), GetPoint(B), GetPoint(C) };

        public override void DrawFigure(Graphics g, ScaleParameters scale = default)
        {
            if (Filled)
            {
                SolidBrush brush = new SolidBrush(ArgbColor);
                g.FillPolygon(brush, new PointF[] 
                { GetPoint(A, scale) , GetPoint(B, scale), GetPoint(C, scale) });
            }
            else
            {
                Pen pen = new Pen(ArgbColor);
                g.DrawPolygon(pen, new PointF[] 
                { GetPoint(A, scale), GetPoint(B, scale), GetPoint(C, scale) });
            }
        }
    }
}
