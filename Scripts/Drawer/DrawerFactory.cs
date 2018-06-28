using System;

namespace DH.Drawing
{
    public class DrawerFactory
    {
        public IDrawer GetStraightLineDrawer(LineProperty lineProperty)
        {
            IInputReader inputReader = new InputReaderFactory().GetInputReader();
            return new StraightLineDrawer(inputReader, lineProperty);
        }

        public IDrawer GetFreeLineDrawer(LineProperty lineProperty)
        {
            IInputReader inputReader = new InputReaderFactory().GetInputReader();
            return new FreeLineDrawer(inputReader, lineProperty);
        }
    }
}