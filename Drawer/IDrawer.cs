using System;
using DH.DrawingModule.Line;

namespace DH.DrawingModule.Drawer
{
    public interface IDrawer : IDisposable
    {
        Line.Line CurrentLine { get; set; }

        void UpdateLineProperty(LineProperty lineProperty);
        
        Action<Line.Line> OnLineCreated { get; set; }
    }

    public class NullDrawer : IDrawer
    {
        public void Dispose()
        {
        }

        public Line.Line CurrentLine { get; set; }
        public void UpdateLineProperty(LineProperty lineProperty)
        {
        }

        public Action<Line.Line> OnLineCreated { get; set; }
    }
}