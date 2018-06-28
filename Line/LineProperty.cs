using System;
using UnityEngine;

namespace DH.DrawingModule.Line
{
    [Serializable]
    public class LineProperty 
    {
        [SerializeField] private float lineWidth;
        [SerializeField] private Color lineColor;
        [SerializeField] private float smootnes;

        public float LineWidth
        {
            get { return lineWidth; }
        }

        public Color LineColor
        {
            get { return lineColor; }
        }

        public float Smootnes
        {
            get { return smootnes; }
        }

        public LineProperty(float lineWidth, Color lineColor, float smootnes)
        {
            this.lineWidth = lineWidth;
            this.lineColor = lineColor;
            this.smootnes = smootnes;
        }
    }
}