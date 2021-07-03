using System;
using System.Collections.Generic;
using System.Drawing;

namespace wscad.BusinessLogic.Models
{
    public abstract class Primitive
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public bool Filled { get; set; }
        public abstract List<PointF> GetOriginPoints { get; }

        public Color ArgbColor
        {
            get
            {
                var argb = Color.Split(';');
                if (argb.Length < 3 || !int.TryParse(argb[0], out var A) ||
                    !int.TryParse(argb[1], out var R) ||
                    !int.TryParse(argb[2], out var G) ||
                    !int.TryParse(argb[3], out var B))
                {
                    throw new InvalidCastException($"Invalid color parameter { Color } for cast to ARGB format");
                }
                return System.Drawing.Color.FromArgb(A, R, G, B);
            }
        }

        public PointF GetPoint(string pointStr, ScaleParameters scale = default)
        {
            var points = pointStr.Split(';');
            if (points.Length < 2 || !float.TryParse(points[0], out var x) ||
                !float.TryParse(points[1], out var y))
            {
                throw new InvalidCastException($"Invalid point parameters of { pointStr } for cast to ARGB format");
            }

            scale = scale ?? new ScaleParameters();

            return new PointF(x * scale.ScaleX - scale.MoveX, (-1) * y * scale.ScaleY - scale.MoveY);
        }

        public abstract void DrawFigure(Graphics g, ScaleParameters scale = default);
    }
}
