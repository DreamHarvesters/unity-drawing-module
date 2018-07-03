using System;
using DH.DrawingModule.InputReader;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.Drawer
{
    public abstract class Drawer : IDrawer
    {
        protected LineFactory lineFactory;
        protected LineProperty lineProperty;
        protected IInputReader inputReader;
        protected int layerMask;

        public Drawer(IInputReader inputReader, LineProperty lineProperty, GameObject linePrefab)
        {
            lineFactory = new LineFactory(linePrefab);
            layerMask = LayerMask.GetMask("DrawingPlane");

            this.inputReader = inputReader;

            UpdateLineProperty(lineProperty);
            SubscribeInputEvents();
        }

        public void Dispose()
        {
            UnsubscribeInputEvents();
            inputReader.Dispose();
            OnLineCreated = null;
        }

        protected void RaiseLineCreated(Line.Line line)
        {
            if (OnLineCreated != null)
                OnLineCreated(line);
        }

        public Line.Line CurrentLine { get; set; }

        public void UpdateLineProperty(LineProperty lineProperty)
        {
            this.lineProperty = lineProperty;
        }

        public Action<Line.Line> OnLineCreated { get; set; }

        protected abstract void SubscribeInputEvents();
        protected abstract void UnsubscribeInputEvents();
    }
}