using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public delegate void HideEvent();

        public static event HideEvent OnHide;

        private void Start()
        {
            ContinueButton.OnClick += Hide;
        }

        private void OnDestroy()
        {
            ContinueButton.OnClick -= Hide;
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
    }
}
