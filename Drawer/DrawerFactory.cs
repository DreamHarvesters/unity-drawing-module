using DH.DrawingModule.InputReader;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.Drawer
{
    public class DrawerFactory
    {
        public IDrawer GetStraightLineDrawer(LineProperty lineProperty, GameObject linePrefab, Camera rayCamera)
        {
            IInputReader inputReader = new InputReaderFactory().GetInputReader();
            return new StraightLineDrawer(inputReader, lineProperty, linePrefab, rayCamera);
        }

        public IDrawer GetFreeLineDrawer(LineProperty lineProperty, GameObject linePrefab, Camera rayCamera)
        {
            IInputReader inputReader = new InputReaderFactory().GetInputReader();
            return new FreeLineDrawer(inputReader, lineProperty, linePrefab, rayCamera);
        }
    }
}