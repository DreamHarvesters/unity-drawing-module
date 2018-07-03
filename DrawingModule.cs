using System;
using System.Collections.Generic;
using DH.DrawingModule.Drawer;
using DH.DrawingModule.Exceptions;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule
{
    public class DrawingModule
    {
        private Stack<Line.Line> lines;

        private int layerMask = -1;

        private IDrawer drawer;

        private bool isActivated;
        private ModuleSetup setup;
        
        public LineProperty CurrentLineProperty { get; private set; }

        public bool IsActivated
        {
            get { return isActivated; }
        }

        public Type DrawerType
        {
            get { return drawer.GetType(); }
        }

        public DrawingModule(ModuleSetup setup)
        {
            if(setup == null)
                throw new Exception("Module setup cannot be null");
            
            lines = new Stack<Line.Line>();
            this.setup = setup;
        }

        public void Activate()
        {
            isActivated = true;
            drawer = new NullDrawer();

            Debug.LogWarning("System activated with null drawer. Remember changing drawer type");
        }

        public void Deactivate()
        {
            if (isActivated)
            {
                isActivated = false;
                drawer.Dispose();
                drawer = new NullDrawer();
            }
        }

        public void ChangeToStraighLine(LineProperty lineProperty)
        {
            if (isActivated)
            {
                drawer.Dispose();
                drawer = new DrawerFactory().GetStraightLineDrawer(lineProperty, setup.LinePrefab);
                drawer.OnLineCreated = OnLineCreated;
                return;
            }

            throw new SystemIsNotActive();
        }

        public void ChangeToFreeLine(LineProperty lineProperty)
        {
            if (isActivated)
            {
                drawer.Dispose();
                drawer = new DrawerFactory().GetFreeLineDrawer(lineProperty, setup.LinePrefab);
                drawer.OnLineCreated = OnLineCreated;
                return;
            }

            throw new SystemIsNotActive();
        }

        private void OnLineCreated(Line.Line line)
        {
            lines.Push(line);
        }

        public void UpdateLineProperty(LineProperty lineProperty)
        {
            drawer.UpdateLineProperty(lineProperty);
            CurrentLineProperty = lineProperty;
        }

        public void Undo()
        {
            if (lines.Count > 0)
            {
                GameObject.DestroyImmediate(lines.Pop().gameObject);
            }
        }

        public void ClearAllLines()
        {
            foreach (Line.Line line in lines)
            {
                GameObject.DestroyImmediate(line.gameObject);
            }

            lines.Clear();
        }
    }
}