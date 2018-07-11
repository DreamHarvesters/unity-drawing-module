using UnityEngine;

namespace DH.DrawingModule.InputReader
{
    public class SceneInputReader : MonoBehaviour, IInputReader
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