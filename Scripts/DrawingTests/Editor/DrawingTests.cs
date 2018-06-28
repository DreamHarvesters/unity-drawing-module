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
        DrawingModule module = new DrawingModule();
        module.Activate();
        module.ChangeToStraighLine(new LineProperty(2, Color.black, 1));
        Assert.AreEqual(typeof(StraightLineDrawer), module.DrawerType);
    }

    [Test]
    public void CreateFreeLine()
    {
        DrawingModule module = new DrawingModule();
        module.Activate();
        module.ChangeToFreeLine(new LineProperty(2, Color.black, 1));
        Assert.AreEqual(typeof(FreeLineDrawer), module.DrawerType);
    }

    [Test]
    public void ActivateDrawingModule()
    {
        DrawingModule module = new DrawingModule();
        module.Activate();
        Assert.IsTrue(module.IsActivated);
    }

    [Test]
    public void DeactivateDrawingModule()
    {
        DrawingModule module = new DrawingModule();
        module.Activate();
        Assert.IsTrue(module.IsActivated);
        module.DeActivate();
        Assert.IsFalse(module.IsActivated);
    }
}