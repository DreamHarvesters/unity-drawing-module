using UnityEngine;

namespace DH.DrawingModule
{
    [CreateAssetMenu(fileName = "DrawingModuleSetup", menuName = "DH/Drawing/Create Module Setup", order = 0)]
    public class ModuleSetup : ScriptableObject
    {
        [SerializeField] private GameObject linePrefab;

        public GameObject LinePrefab
        {
            get { return linePrefab; }
        }
    }
}