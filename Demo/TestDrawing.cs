using DH.DrawingModule.Line;
using UnityEngine;

namespace DH.DrawingModule.TestScripts
{
    public class TestDrawing : MonoBehaviour
    {
        [SerializeField] private DrawingModuleSetup setup;
        
        private DrawingModule module;

        private void Start()
        {
            module = new DrawingModule(setup);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
                module.ClearAllLines();
            
            if(Input.GetKeyDown(KeyCode.A))
                module.Activate();
            
            if(Input.GetKeyDown(KeyCode.D))
                module.Deactivate();
            
            if(Input.GetKeyDown(KeyCode.U))
                module.Undo();
            
            if(Input.GetKeyDown(KeyCode.F))
                module.ChangeToFreeLine(new LineProperty(0.5f, Color.yellow, 0.2f, true, Vector3.zero));
            
            if(Input.GetKeyDown(KeyCode.S))
                module.ChangeToStraighLine(new LineProperty(0.5f, Color.yellow, 0.2f, true, Vector3.zero));
        }
    }
}