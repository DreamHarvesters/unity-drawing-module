using DH.DrawingModule.InputReader;
using UnityEngine;

namespace DH.DrawingModule
{
    public interface IModuleSetup
    {
        GameObject LinePrefab { get; }
        Camera RayCamera { get; }
        IInputReaderFactory InputReaderFactory { get; }
    }
}