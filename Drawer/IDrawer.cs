using System;
using DH.DrawingModule.Line;

namespace DH.DrawingModule.Drawer
{
    public interface IDrawer : IDisposable
    {
        void UpdateLineProperty(LineProperty lineProperty);
        
        Action<Line.Line> OnLineCreated { get; set; }
        Action<Line.Line> OnLineEnded { get; set; }
    }

    public class NullDrawer : IDrawer
    {
        public void Dispose()
        {
        }

        public void UpdateLineProperty(LineProperty lineProperty)
        {
        }

        public Action<Line.Line> OnLineCreated { get; set; }
        public Action<Line.Line> OnLineEnded { get; set; }
    }
}