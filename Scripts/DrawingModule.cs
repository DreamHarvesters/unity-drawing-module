using System;
using System.Collections.Generic;
using System.Linq;
using DH.Drawing;
using DH.Drawing.Exceptions;
using UnityEngine;
using Object = UnityEngine.Object;

public class DrawingModule
{
    private Stack<Line> lines;

    private int layerMask = -1;

    private IDrawer drawer;

    private bool isActivated;

    public bool IsActivated
    {
        get { return isActivated; }
    }

    public Type DrawerType
    {
        get { return drawer.GetType(); }
    }

    public DrawingModule()
    {
        lines = new Stack<Line>();
    }

    public void Activate()
    {
        isActivated = true;
        drawer = new NullDrawer();

        Debug.LogWarning("System activated with null drawer. Remember changing drawer type");
    }

    public void DeActivate()
    {
        if (isActivated)
        {
            isActivated = false;
            drawer.Dispose();
            drawer = new NullDrawer();
        }
    }

    public void ChangeToStraighLine(LineProperty lineProperty)
    {
        if (isActivated)
        {
            drawer.Dispose();
            drawer = new DrawerFactory().GetStraightLineDrawer(lineProperty);
            drawer.OnLineCreated = OnLineCreated;
            return;
        }

        throw new SystemIsNotActive();
    }

    public void ChangeToFreeLine(LineProperty lineProperty)
    {
        if (isActivated)
        {
            drawer.Dispose();
            drawer = new DrawerFactory().GetFreeLineDrawer(lineProperty);
            drawer.OnLineCreated = OnLineCreated;
            return;
        }

        throw new SystemIsNotActive();
    }

    private void OnLineCreated(Line line)
    {
        lines.Push(line);
    }

    public void UpdateLineProperty(LineProperty lineProperty)
    {
        drawer.UpdateLineProperty(lineProperty);
    }

    public void Undo()
    {
        if (lines.Count > 0)
        {
            GameObject.DestroyImmediate(lines.Pop().gameObject);
        }
    }

    public void ClearAllLines()
    {
        foreach (Line line in lines)
        {
            GameObject.DestroyImmediate(line.gameObject);
        }

        lines.Clear();
    }
}