using System;
using UnityEngine;

namespace UI
{
    public class TitleScreen : MonoBehaviour
    {
        public delegate void HideEvent();

        public static event HideEvent OnHide;

        private void Start()
        {
            StartButton.OnClick += Hide;
        }

        private void OnDestroy()
        {
            StartButton.OnClick -= Hide;
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
    }
}
