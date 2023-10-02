using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SubtitleFontSizeSlider : MonoBehaviour
    {
        public delegate void ValueChangedEvent(float value);
        public static event ValueChangedEvent OnValueChanged;
        
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI valueText;
        public float Size => slider.value;
        private void OnEnable()
        {
            slider.onValueChanged.AddListener(OnValueChangedHandler);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(OnValueChangedHandler);
        }

        private void OnValueChangedHandler(float value)
        {
            valueText.text = value.ToString("0");
            OnValueChanged?.Invoke(value);
        }
    }
}
