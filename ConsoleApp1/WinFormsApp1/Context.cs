using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WinFormsApp1
{
    internal class Context
    {
        public IFigure _figure;

        public Context(IFigure figure)
        {
            _figure = figure;
        }

        public void EndPaint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            _figure.EndPaint(g, MyPen, curvePoints);
        }

        public void Fill(Graphics g, Brush MyBrush, List<PointF> curvePoints)
        {
            _figure.Fill(g, MyBrush, curvePoints);
        }

        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {
            _figure.Paint(g, MyPen, curvePoints);
        }
    }
}
