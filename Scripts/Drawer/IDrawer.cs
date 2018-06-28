using System;

namespace DH.Drawing
{
    public interface IDrawer : IDisposable
    {
        Line CurrentLine { get; set; }

        void UpdateLineProperty(LineProperty lineProperty);
        
        Action<Line> OnLineCreated { get; set; }
    }

    public class NullDrawer : IDrawer
    {
        public void Dispose()
        {
        }

        public Line CurrentLine { get; set; }
        public void UpdateLineProperty(LineProperty lineProperty)
        {
        }

        public Action<Line> OnLineCreated { get; set; }
    }
}