using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DH.Drawing
{
    public class FreeLineDrawer : Drawer
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

        public FreeLineDrawer(IInputReader inputReader,bool isActivated) : base(inputReader)
        {
            LineFactory = new LineFactory();
            layer_mask = LayerMask.GetMask("DrawingPlane");

            this.IsActive = isActivated;
        }
        
        ~FreeLineDrawer()
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
        private void OnDown(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layer_mask))
            {
                DrawEnable = true;
                objectHit = hit.transform;
                Debug.Log(objectHit.name);
                // Do something with the object that was hit by the raycast.
                GameObject lineGO = LineFactory.GetFreeLine(LineProperty);
                line = lineGO.GetComponent<Line>();
            }
            else
            {
                objectHit = null;
            }
        }

        private void OnMove(object sender, Vector3 args)
        {
            Ray ray = Camera.main.ScreenPointToRay(args);

            if (Physics.Raycast(ray, out hit, 10000, layer_mask))
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
            if (line != null && objectHit != null )
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

