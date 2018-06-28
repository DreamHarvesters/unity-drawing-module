﻿using DH.Drawing;
using UnityEngine;

namespace TestScripts
{
    public class TestDrawing : MonoBehaviour
    {
        private DrawingModule module;

        private void Start()
        {
            module = new DrawingModule();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
                module.ClearAllLines();
            
            if(Input.GetKeyDown(KeyCode.A))
                module.Activate();
            
            if(Input.GetKeyDown(KeyCode.D))
                module.DeActivate();
            
            if(Input.GetKeyDown(KeyCode.U))
                module.Undo();
            
            if(Input.GetKeyDown(KeyCode.F))
                module.ChangeToFreeLine(new LineProperty(0.5f, Color.yellow, 0.2f));
            
            if(Input.GetKeyDown(KeyCode.S))
                module.ChangeToStraighLine(new LineProperty(0.5f, Color.yellow, 0.2f));
        }
    }
}