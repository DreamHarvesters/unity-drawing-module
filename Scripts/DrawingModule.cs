using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DH.Drawing;
using DH.Drawing.Exceptions;
using UnityEngine;
using Object = UnityEngine.Object;

public class DrawingModule : MonoBehaviour
{
    [SerializeField] private LineProperty lineProperty;

    [SerializeField] private Stack<Line> lines;

    public Stack<Line> Lines
    {
        get
        {
            if (lines == null)
                lines = new Stack<Line>();

            return lines;
        }
    }

    private int layerMask = -1;

    private IDrawer drawer;
    public IInputReader inputReader;

    private bool isActivated;

    public IDrawer Drawer
    {
        get { return drawer; }
    }

    public IInputReader InputReader
    {
        get { return inputReader; }
    }

    public LineProperty LineProperty
    {
        get
        {
            if (lineProperty == null)
            {
                lineProperty = new LineProperty();
            }

            return lineProperty;
        }
        set { lineProperty = value; }
    }

    public float LineWidth
    {
        get { return LineProperty.LineWidth; }
        set { LineProperty.LineWidth = value; }
    }

    public Color LineColor
    {
        get { return LineProperty.LineColor; }
        set { LineProperty.LineColor = value; }
    }

    public int LayerMaskValue
    {
        get { return layerMask; }

        set { layerMask = value; }
    }

    public bool IsActivated
    {
        get { return isActivated; }
    }


    public void Activate()
    {
        if (inputReader != null && drawer != null)
        {
            inputReader.IsActive = true;
            drawer.IsActive = true;
            isActivated = true;
            return;
        }

        throw new SystemCouldNotBeActivated();
    }

    public bool DeActivate()
    {
        if (inputReader != null && drawer != null)
        {
            inputReader.IsActive = false;
            drawer.IsActive = false;
            isActivated = false;
            return true;
        }

        return false;
    }

    public bool ChangeInputModule(Type inputType)
    {
        if (!inputType.GetInterfaces().Contains(typeof(IInputReader)).Equals(null))
        {
            inputReader = gameObject.AddComponent(inputType) as IInputReader; //inputType) as IInputReader;
            inputReader.IsActive = IsActivated;
            return true;
        }

        return false;
    }

    public bool ChangeDrawingModule(Type draweType)
    {
        if (draweType.BaseType != null && draweType.BaseType == typeof(Drawer))
        {
//            DestroyImmediate(drawer);
            drawer = (IDrawer) Activator.CreateInstance(draweType, inputReader, IsActivated);
            UpdateLineProperty(this.LineProperty);
            UpdateLineEvent();
            return true;
        }

        return false;
    }

    public void UpdateLineEvent()
    {
        Drawer.LineFactory.OnLineCreated = OnLineCreated;
    }

    private void OnLineCreated(object sender, Line line)
    {
        Lines.Push(line);
    }

    public bool UpdateLineProperty(LineProperty lineProperty)
    {
        if (drawer != null)
        {
            drawer.LineProperty = lineProperty;
            this.LineProperty = lineProperty;
            return true;
        }

        return false;
    }

    private void Undo()
    {
        if (Lines.Count > 0)
        {
            DestroyImmediate(Lines.Pop().gameObject);
        }
    }

    private void ClearAllLines()
    {
        foreach (Line line in Lines)
        {
            DestroyImmediate(line.gameObject);
        }

        Lines.Clear();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Activate();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeActivate();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Undo();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearAllLines();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UpdateLineProperty(new LineProperty()
            {
                lineSize = 0.3f,
                LineColor = Color.green,
                LineWidth = 0.4f,
                Smootnes = 0.5f
            });
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateLineProperty(new LineProperty()
            {
                lineSize = 1f,
                LineColor = Color.cyan,
                LineWidth = 0.4f,
                Smootnes = 0.01f
            });
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            DestroyImmediate(inputReader as Object);

            ChangeInputModule(typeof(MouseInputReader));
            ChangeDrawingModule(typeof(FreeLineDrawer));
        }
        else if ((Input.GetKeyDown(KeyCode.S)))
        {
            DestroyImmediate(inputReader as Object);

            ChangeInputModule(typeof(MouseInputReader));
            ChangeDrawingModule(typeof(StraightLineDrawer));
        }
    }
}

public enum DrawingType
{
    Straight,
    Free,
    Smoot
}