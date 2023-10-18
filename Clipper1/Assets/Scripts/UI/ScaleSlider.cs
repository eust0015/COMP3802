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
        [SerializeField] private float initialScale;

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
            initialScale = transformToScale.localScale.x;
            valueText.text = "x" + (slider.value).ToString("0.#");
        }

        private void UpdateScale(float value)
        {
            float newScale = initialScale * value;
            transformToScale.localScale = new Vector3(newScale, newScale, newScale);
            valueText.text = "x" + (value).ToString("0.#");
        }
    }
}
