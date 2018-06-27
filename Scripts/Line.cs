using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCol;
	public int LineCount
	{
		get { return points.Count; }
	}

	List<Vector3> points;

	private LineProperty lineProperty;

	public LineProperty LineProperty
	{
		get
		{
			if(lineProperty == null)
				lineProperty =new LineProperty();
			
			return lineProperty;
		}
		set
		{
			lineProperty = value;
			UpdateLineRenderer();
		}
	}

	private void UpdateLineRenderer()
	{
		lineRenderer.widthMultiplier = (lineProperty.lineSize);
		lineRenderer.startColor = (lineProperty.LineColor);
		lineRenderer.endColor = (lineProperty.LineColor);
	}

	public void UpdateLine (Vector3 mousePos)
	{
		if (points == null)
		{
			points = new List<Vector3>();
			SetPoint(mousePos);
			return;
		}

		if (Vector2.Distance(points.Last(), mousePos) > .1f)
			SetPoint(mousePos);
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

[System.Serializable]
public class LineProperty
{
	public float LineWidth;
	public float lineSize;
	public Color LineColor;
	public float Smootnes;
}
