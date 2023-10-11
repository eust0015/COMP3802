using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class ScaleSlider : MonoBehaviour
    {
        [SerializeField] private RectTransform transformToScale;
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private float scaleMultiplier;

        private void OnEnable()
        {
            slider.onValueChanged.AddListener(UpdateScale);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(UpdateScale);
        }

        private void Start()
        {
            valueText.text = "x" + (slider.value * scaleMultiplier).ToString("0.#");
        }

        private void UpdateScale(float value)
        {
            //float newScale = 0f + value / 1000f;
            transformToScale.localScale = new Vector3(value, value, value);
            valueText.text = "x" + (value * scaleMultiplier).ToString("0.#");
        }
    }
}
