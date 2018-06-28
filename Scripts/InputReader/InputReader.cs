using System;
using UnityEngine;

namespace DH.Drawing
{
    public class InputReader : MonoBehaviour, IInputReader
    {
        public virtual InputEvent OnDown { get; set; }
        public virtual InputEvent OnUp { get; set; }
        public virtual InputEvent OnMove { get; set; }

        public void Dispose()
        {
            StopAllCoroutines();
            Destroy(gameObject);
        }
    }
}