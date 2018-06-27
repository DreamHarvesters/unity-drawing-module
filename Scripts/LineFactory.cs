using System;
using UnityEngine;

namespace DH.Drawing
{
    public class LineFactory
    {
        public LineEvent OnLineCreated
        {
            get { return onLineCreated; }
            set { onLineCreated = value; }
        }

        private LineEvent onLineCreated;

        public GameObject GetStraightLine(LineProperty lineProperty)
        {
            GameObject lineGameObject = GameObject.Instantiate(Resources.Load("Line_Normal") as GameObject);
            Line line = lineGameObject.GetComponent<Line>();

            line.LineProperty = lineProperty;
            if (OnLineCreated != null) OnLineCreated.Invoke(this, line);

            return lineGameObject;
        }

        public GameObject GetFreeLine(LineProperty lineProperty)
        {
            GameObject lineGameObject = GameObject.Instantiate(Resources.Load("Line_Normal") as GameObject);
            Line line = lineGameObject.GetComponent<Line>();

            if (OnLineCreated != null) OnLineCreated.Invoke(this, line);
            line.LineProperty = lineProperty;
            return lineGameObject;
        }
    }

    public delegate void LineEvent(object sender, Line line);
}