using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class KeyboardEscapeKeyWatcher : MonoBehaviour
    {
        public delegate void PressEvent(bool pressed);
        public static event PressEvent OnPress;
        
        public static KeyboardEscapeKeyWatcher Instance { get; private set; }
        
        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }
        
        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                OnPress?.Invoke(true);
            }
        }
    }
}