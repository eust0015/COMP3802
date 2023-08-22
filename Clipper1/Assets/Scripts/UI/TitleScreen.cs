using System;
using UnityEngine;

namespace UI
{
    public class TitleScreen : MonoBehaviour
    {
        public delegate void HideEvent();
        public static event HideEvent OnHide;
        
        [SerializeField] private GameObject background;

        private void OnEnable()
        {
            StartButton.OnClick += Hide;
        }

        private void OnDisable()
        {
            StartButton.OnClick -= Hide;
        }
        
        private void Hide()
        {
            background.SetActive(false);
            OnHide?.Invoke();
        }
    }
}
