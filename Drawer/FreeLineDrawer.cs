using System;
using DH.DrawingModule.InputReader;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.Drawer
{
    public class FreeLineDrawer : Drawer, IDisposable
    {
        private Line.Line line;
        RaycastHit hit;
        Transform objectHit;

        private bool DrawEnable;

        public FreeLineDrawer(IInputReader inputReader, LineProperty lineProperty) : base(inputReader, lineProperty)
        {
        }

        protected override void SubscribeInputEvents()
        {
            inputReader.OnDown += OnDown;
            inputReader.OnMove += OnMove;
            inputReader.OnUp += OnUp;
        }

        protected override void UnsubscribeInputEvents()
        {
            inputReader.OnDown -= OnDown;
            inputReader.OnMove -= OnMove;
            inputReader.OnUp -= OnUp;
        }

        private void OnDown(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layerMask))
            {
                DrawEnable = true;
                objectHit = hit.transform;
                Debug.Log(objectHit.name);
                // Do something with the object that was hit by the raycast.
                line = lineFactory.GetLine(lineProperty);
                
                RaiseLineCreated(line);
            }
            else
            {
                objectHit = null;
            }
        }

        private void OnMove(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layerMask))
            {
                DrawEnable = true;
                objectHit = hit.transform;
            }
            else
            {
                objectHit = null;
                DrawEnable = false;
                line = null;
            }

            if (line != null && objectHit != null)
            {
                Vector3 mousePos = hit.point;

                line.UpdateLine(mousePos);
            }
            else
            {
                line = null;
            }
        }

        private void OnUp(object sender, Vector3 args)
        {
            line = null;
        }
    }
}