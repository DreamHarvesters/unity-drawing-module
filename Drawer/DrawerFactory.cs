using DH.DrawingModule.InputReader;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.Drawer
{
    public class DrawerFactory
    {
        private IInputReaderFactory inputReaderFactory;

        public DrawerFactory(IInputReaderFactory inputReaderFactory)
        {
            this.inputReaderFactory = inputReaderFactory;
        }

        public IDrawer GetStraightLineDrawer(LineProperty lineProperty, GameObject linePrefab, Camera rayCamera)
        {
            IInputReader inputReader = inputReaderFactory.GetInputReader();
            return new StraightLineDrawer(inputReader, lineProperty, linePrefab, rayCamera);
        }

        public IDrawer GetFreeLineDrawer(LineProperty lineProperty, GameObject linePrefab, Camera rayCamera)
        {
            IInputReader inputReader = inputReaderFactory.GetInputReader();
            return new FreeLineDrawer(inputReader, lineProperty, linePrefab, rayCamera);
        }
    }
}