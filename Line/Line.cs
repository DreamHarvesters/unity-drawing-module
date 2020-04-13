using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DH.DrawingModule.Line
{
	public class Line : MonoBehaviour {

		public LineRenderer lineRenderer;
		public int LineCount
		{
			get { return points.Count; }
		}

		List<Vector3> points;
		
		private LineProperty lineProperty;

		public void UpdateLineRenderer(LineProperty lineProperty)
		{
			this.lineProperty = lineProperty;
			
			lineRenderer.startWidth = lineProperty.LineWidth;
			lineRenderer.endWidth = lineProperty.LineWidth;
			lineRenderer.startColor = (lineProperty.LineColor);
			lineRenderer.endColor = (lineProperty.LineColor);
			lineRenderer.useWorldSpace = lineProperty.UseWorldSpace;
		}

		public void UpdateLine (Vector3 mousePos)
		{
			if (points == null)
			{
				points = new List<Vector3>();
				SetPoint(mousePos + lineProperty.PointOffsetInWorldCoordinate);
				return;
			}

			if (Vector2.Distance(points.Last(), mousePos) > lineProperty.Smoothness)
				SetPoint(mousePos + lineProperty.PointOffsetInWorldCoordinate);
		}

		void SetPoint (Vector3 point)
		{
			points.Add(point);

			lineRenderer.positionCount = points.Count;
			lineRenderer.SetPosition(points.Count - 1, point);
		}

		public void SetLastPoint(Vector3 point)
		{
			if (points.Count < 2)
			{
				UpdateLine(point);
			}
		
			points[points.Count - 1] = point;

			lineRenderer.positionCount = points.Count;
			lineRenderer.SetPosition(points.Count - 1, point);
		}


	}
}


