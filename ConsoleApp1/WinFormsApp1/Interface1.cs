using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal interface IFigure : IFill, IEndPaint
    {
        public void Paint(Graphics g, Pen MyPen, List<PointF> curvePoints);
    }

    internal interface IFill
    {
        public void Fill(Graphics g, Brush MyBrush, List<PointF> curvePoints)
        {

        }

    }
    internal interface IEndPaint
    {
        public void EndPaint(Graphics g, Pen MyPen, List<PointF> curvePoints)
        {

        }

    }
}
