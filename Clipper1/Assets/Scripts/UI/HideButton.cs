using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HideButton : MonoBehaviour
    {
        public delegate void ClickEvent();
        public static event ClickEvent OnClick;
        
        [SerializeField] private Button button;

        private void OnEnable()
        {
            button.onClick.AddListener(OnClickHandler);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClickHandler);
        }

        private void OnClickHandler()
        {
            OnClick?.Invoke();
        }
    }
}
