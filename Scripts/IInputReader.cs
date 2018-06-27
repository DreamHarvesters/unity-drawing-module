using System;
using UnityEngine;

namespace DH.Drawing
{
    public interface IInputReader
    {
        InputEvent OnDown { get; set; }
        InputEvent OnUp { get; set; }
        InputEvent OnMove { get; set; }
        bool IsActive { get; set; }
    }

    public delegate void InputEvent(object sender, Vector3 position);
}