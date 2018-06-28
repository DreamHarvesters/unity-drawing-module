using System;
using UnityEngine;

namespace DH.Drawing
{
    public abstract class Drawer : IDrawer
    {
        protected LineFactory lineFactory;
        protected LineProperty lineProperty;
        protected IInputReader inputReader;
        protected int layerMask;

        public Drawer(IInputReader inputReader, LineProperty lineProperty)
        {
            lineFactory = new LineFactory();
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

        protected void RaiseLineCreated(Line line)
        {
            if (OnLineCreated != null)
                OnLineCreated(line);
        }

        public Line CurrentLine { get; set; }

        public void UpdateLineProperty(LineProperty lineProperty)
        {
            this.lineProperty = lineProperty;
        }

        public Action<Line> OnLineCreated { get; set; }

        protected abstract void SubscribeInputEvents();
        protected abstract void UnsubscribeInputEvents();
    }
}