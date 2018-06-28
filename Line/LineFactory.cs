using UnityEngine;

namespace DH.DrawingModule.Line
{
    public class LineFactory
    {
        public Line GetLine(LineProperty lineProperty)
        {
            GameObject lineGameObject = GameObject.Instantiate(Resources.Load("Line") as GameObject);
            Line line = lineGameObject.GetComponent<Line>();
            
            line.UpdateLineRenderer(lineProperty);

            return line;
        }
    }
}