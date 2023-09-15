using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SFXVolumeSlider : MonoBehaviour
    {
        public delegate void ValueChangedEvent(float value);
        public static event ValueChangedEvent OnValueChanged;
        
        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI valueText;
        [SerializeField] private AudioMixer mixer;
        public float Volume => slider.value;
        private const string AUDIO_MIXER_GROUP_NAME = "SFX";
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
            float log10Volume = Mathf.Log10(value) * 20;
            mixer.SetFloat(AUDIO_MIXER_GROUP_NAME, log10Volume);
            valueText.text = (value * 100).ToString("0");
            OnValueChanged?.Invoke(value);
        }
    }
}
