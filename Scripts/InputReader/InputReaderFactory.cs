using UnityEngine;

namespace DH.Drawing
{
    public class InputReaderFactory
    {
        public IInputReader GetInputReader()
        {
            GameObject inputReaderObject = new GameObject("InputReader");
            
#if UNITY_WEBGL || UNITY_EDITOR
            return inputReaderObject.AddComponent<MouseInputReader>();
#elif !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
            throw new NotImplementedException();
#endif
        }
    }
}