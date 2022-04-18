using Interface;
using System.Drawing.Drawing2D;
using System.Windows.Markup;
using System.Drawing;
using System.Linq;
using System.Drawing;

namespace Class1
{
    internal class Line : IFigure
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            int cnt = curvePoints.Count();
            g.DrawLine(MyPen, curvePoints[0], curvePoints[cnt - 1]);
            curvePoints.Clear();
        }
    }

    internal class Recctangle : IFigure
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            int cnt = curvePoints.Count();
            float x1 = curvePoints[0].X;
            float x2 = curvePoints[cnt - 1].X;
            float y1 = curvePoints[0].Y;
            float y2 = curvePoints[cnt - 1].Y;
            g.DrawRectangle(MyPen, x1, y1, (x2 - x1), (y2 - y1));
            g.DrawRectangle(MyPen, x2, y2, (x1 - x2), (y1 - y2));
            g.DrawRectangle(MyPen, x1, y2, (x2 - x1), (y1 - y2));
            g.DrawRectangle(MyPen, x2, y1, (x1 - x2), (y2 - y1));
            curvePoints.Clear();
        }
    }

    internal class Ellipse : IFigure
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            int cnt = curvePoints.Count();
            g.DrawEllipse(MyPen, curvePoints[0].X, curvePoints[0].Y, curvePoints[cnt - 1].X - curvePoints[0].X, curvePoints[cnt - 1].Y - curvePoints[0].Y);
            curvePoints.Clear();
        }
    }

    internal class Polygon : IFigure
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            int cnt = curvePoints.Count();
            g.DrawLine(MyPen, curvePoints[cnt-2], curvePoints[cnt - 1]);   
            
        }

        public void Fill(Graphics g, Brush MyBrush, List<PointF> curvePoints)
        {
            PointF[] points = curvePoints.ToArray();
            g.FillPolygon(MyBrush, points);
            curvePoints.Clear();
        }

        public void EndPaint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            PointF[] points = curvePoints.ToArray();
            g.DrawPolygon(MyPen, points);
        }

    }

    internal class Curve : IFigure
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            int cnt = curvePoints.Count();
            g.DrawLine(MyPen, curvePoints[cnt-2], curvePoints[cnt - 1]);
        }

        public void EndPaint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            curvePoints.Clear();
        }

    }
}
