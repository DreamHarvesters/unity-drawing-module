﻿using DH.DrawingModule.InputReader;
using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.Drawer
{
    public class StraightLineDrawer : Drawer
    {
        private Line.Line line;
        RaycastHit hit;
        Transform objectHit;

        private bool drawEnable;

        public StraightLineDrawer(IInputReader inputReader, LineProperty property) : base(inputReader, property)
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

        private void OnMove(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layerMask) && line != null)
            {
                line.SetLastPoint(hit.point);
            }
        }

        private void OnDown(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layerMask))
            {
                drawEnable = true;
                objectHit = hit.transform;
                Debug.Log(objectHit.name);
                // Do something with the object that was hit by the raycast.
                line = lineFactory.GetLine(lineProperty);
                line.UpdateLine(hit.point);
                
                RaiseLineCreated(line);
            }
            else
            {
                objectHit = null;
            }
        }

        private void OnUp(object sender, Vector3 args)
        {
            line = null;
        }
    }
}