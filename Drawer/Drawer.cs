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
        protected Camera rayCamera;

        public Drawer(IInputReader inputReader, LineProperty lineProperty, GameObject linePrefab, Camera rayCamera)
        {
            lineFactory = new LineFactory(linePrefab);
            layerMask = LayerMask.GetMask("DrawingPlane");
            
            this.rayCamera = rayCamera;
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

        protected void RaiseLineEnded(Line.Line line)
        {
            if (OnLineEnded != null)
                OnLineEnded(line);
        }

        public void UpdateLineProperty(LineProperty lineProperty)
        {
            this.lineProperty = lineProperty;
        }

        public Action<Line.Line> OnLineCreated { get; set; }
        public Action<Line.Line> OnLineEnded { get; set; }

        protected abstract void SubscribeInputEvents();
        protected abstract void UnsubscribeInputEvents();
    }
}