using Input;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public delegate void HideEvent();

        public static event HideEvent OnHide;

        public MenuButtonWatcher watcher;
        
        [SerializeField] private float spawnOffsetDistance = 2f;
        
        private void Start()
        {
            ContinueButton.OnClick += Hide;
            watcher.menuButtonPress.AddListener(OnMenuButtonEvent);
        }

        private void OnDestroy()
        {
            ContinueButton.OnClick -= Hide;
            watcher.menuButtonPress.RemoveListener(OnMenuButtonEvent);
        }
        
        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                OnMenuButtonEvent(true);
            }
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
        
        private void OnMenuButtonEvent(bool pressed)
        {
            if (!pressed) return;
            
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * spawnOffsetDistance;
        }
    }
}
