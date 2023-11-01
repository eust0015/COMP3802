using Input;
using UnityEngine;
using System.Collections;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public delegate void HideEvent();
        public static event HideEvent OnHide;
        
        [SerializeField] private float spawnOffsetDistance = 2f;
        
        private void Start()
        {
            ContinueButton.OnClick += Hide;
            XRMenuButtonWatcher.OnPress += OnMenuButtonEvent;
            KeyboardEscapeKeyWatcher.OnPress += OnMenuButtonEvent;
        }

        private void OnDestroy()
        {
            ContinueButton.OnClick -= Hide;
            XRMenuButtonWatcher.OnPress -= OnMenuButtonEvent;
            KeyboardEscapeKeyWatcher.OnPress -= OnMenuButtonEvent;
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
        
        private void OnMenuButtonEvent(bool pressed)
        {
            if (!pressed) return;
            gameObject.SetActive(true);
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * spawnOffsetDistance;
        }
    }
}
