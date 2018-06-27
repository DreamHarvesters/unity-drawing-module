using System;
using DH.Drawing;
using UnityEngine;

public class MouseInputReader : MonoBehaviour,IInputReader
{
    public InputEvent OnDown { get; set; }
    public InputEvent OnUp { get; set; }
    public InputEvent OnMove { get; set; }
    public bool IsActive { get; set; }

    private bool buttonActive;

    public MouseInputReader(bool isActive)
    {
        IsActive = isActive;
    }
    
    private void Update()
    {
        if (!IsActive)
        {
            return;
        }
        
       if(Input.GetMouseButtonDown(0))
        {
            OnDown.Invoke(this,Input.mousePosition);
            buttonActive = true;
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            OnUp.Invoke(this,Input.mousePosition);    
            buttonActive = false;
        }
        
        if(Input.GetMouseButton(0) && buttonActive)
        {
            OnMove.Invoke(this,Input.mousePosition);    
            Debug.Log("onmove");
        }

    }
   
}