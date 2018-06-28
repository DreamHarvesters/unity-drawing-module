using System;
using System.Collections;
using DH.Drawing;
using UnityEngine;

public class MouseInputReader : InputReader
{
    public override InputEvent OnDown { get; set; }
    public override InputEvent OnUp { get; set; }
    public override InputEvent OnMove { get; set; }

    private bool buttonActive;

    private void Start()
    {
        StartCoroutine(UpdateRoutine());
    }
    
    IEnumerator UpdateRoutine()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDown.Invoke(this, Input.mousePosition);
                buttonActive = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnUp.Invoke(this, Input.mousePosition);
                buttonActive = false;
            }

            if (Input.GetMouseButton(0) && buttonActive)
            {
                OnMove.Invoke(this, Input.mousePosition);
                Debug.Log("onmove");
            }

            yield return null;
        }
    }
}