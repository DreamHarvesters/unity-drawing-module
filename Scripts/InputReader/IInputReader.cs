using System;
using UnityEngine;

namespace DH.Drawing
{
    public interface IInputReader : IDisposable
    {
        InputEvent OnDown { get; set; }
        InputEvent OnUp { get; set; }
        InputEvent OnMove { get; set; }
    }

    public delegate void InputEvent(object sender, Vector3 position);
}