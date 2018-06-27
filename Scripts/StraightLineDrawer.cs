using System;
using UnityEngine;

namespace DH.Drawing
{
    public class StraightLineDrawer : Drawer
    {
        private int layer_mask;
        private Line line;
        RaycastHit hit;
        Transform objectHit;

        private bool DrawEnable;

        public override bool IsActive {
            set
            {
                var b = value == true ? StartDrawing() : StopDrawing();
            } }


        public StraightLineDrawer(IInputReader inputReader,bool isActive) : base(inputReader)
        {
            LineFactory = new LineFactory();
            layer_mask = LayerMask.GetMask("DrawingPlane");
            this.IsActive = isActive;
        }

        ~StraightLineDrawer()
        {
            StopDrawing();
        }

        public override bool StartDrawing()
        {
            if (inputReader != null)
            {
                inputReader.OnUp = OnUp;
                inputReader.OnDown = OnDown;
                inputReader.OnMove = OnMove;
                return true;
            }
            return false;
        }

        public override bool StopDrawing()
        {
            if (inputReader != null)
            {
                inputReader.OnUp -= OnUp;
                inputReader.OnDown -= OnDown;
                inputReader.OnMove -= OnMove;
                return true;
            }

            return false;
        }

        private void OnMove(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layer_mask) && line != null)
            {
                line.SetLastPoint(hit.point);
            }
            
        }

        private void OnDown(object sender, Vector3  args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layer_mask))
            {
                DrawEnable = true;
                objectHit = hit.transform;
                Debug.Log(objectHit.name);
                // Do something with the object that was hit by the raycast.
                GameObject lineGO = LineFactory.GetStraightLine(LineProperty);
                line = lineGO.GetComponent<Line>();
                line.UpdateLine(hit.point);

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