using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using DH.Drawing;
using DH.Drawing.Exceptions;
using UnityEditor;

public class DrawingTests
{
    [Test]
    public void CreateStraightLine()
    {
        LineFactory factory = new LineFactory();
        IInputReader input = new InputReader();

        GameObject l = factory.GetStraightLine(new LineProperty(){LineColor = Color.gray,LineWidth = 2});

        IDrawer drawer = new StraightLineDrawer(input,false);

        drawer.CurrentLine = l.GetComponent<Line>();

        Assert.AreEqual(drawer.CurrentLine, l.GetComponent<Line>());
    }

    [Test]
    public void ActivateDrawingModule()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        module.ChangeInputModule(typeof(MouseInputReader));
        module.ChangeDrawingModule(typeof(StraightLineDrawer));
        module.Activate();

        Assert.IsTrue(module.IsActivated);
    }
    
    [Test]
    public void DrawingModuleCouldNotBeActivated()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        
        Assert.Throws<SystemCouldNotBeActivated>(delegate { module.Activate(); });
    }
    
    [Test]
    public void UpdateLineProperty()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        module.ChangeInputModule(typeof(MouseInputReader));
        module.ChangeDrawingModule(typeof(StraightLineDrawer));
        LineProperty lineProperty = new LineProperty() {LineColor = Color.blue, lineSize = 2};
        module.UpdateLineProperty(lineProperty);
        
        Assert.IsTrue(module.Drawer.LineProperty == lineProperty);
    }
    
    [Test]
    public void ChangeLineWidth()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        module.ChangeInputModule(typeof(MouseInputReader));
        module.ChangeDrawingModule(typeof(StraightLineDrawer));
        module.LineWidth = 2;
        Assert.IsTrue(module.LineWidth == 2);
    }
    
    [Test]
    public void ChangeLineColor()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        module.ChangeInputModule(typeof(MouseInputReader));
        module.ChangeDrawingModule(typeof(StraightLineDrawer));
        module.LineColor = (Color.green);
        Assert.IsTrue(module.LineColor == Color.green);
    }
    
    [Test]
    public void DeActivateDrawingModule()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();

        module.DeActivate();
        
        Assert.IsTrue(!module.IsActivated);
    }

    [Test]
    public void ChangeDrawer()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        module.ChangeInputModule(typeof(MouseInputReader));

        module.ChangeDrawingModule(typeof(StraightLineDrawer));
        Assert.IsTrue(module.ChangeDrawingModule(typeof(StraightLineDrawer)));
    }

    [Test]
    public void CheckLayerMask()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();
        
        module.LayerMaskValue = LayerMask.GetMask("DrawingPlane");
        
        Assert.IsTrue(!module.LayerMaskValue.Equals(-1));
    }
    
    [Test]
    public void ChangeInput()
    {
        GameObject obj = new GameObject("Cool GameObject made from Code");

        DrawingModule module = obj.AddComponent<DrawingModule>();

        Assert.IsTrue(module.ChangeInputModule(typeof(MouseInputReader)));
    }

    [Test]
    public void DrawStraightLine()
    {
        IInputReader inputReader = new InputReader();

        IDrawer drawer = new StraightLineDrawer(inputReader,false);

        Assert.IsTrue(drawer.StartDrawing());
    }
}