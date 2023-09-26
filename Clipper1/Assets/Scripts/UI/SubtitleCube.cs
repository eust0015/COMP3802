using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class SubtitleCube : MonoBehaviour
    {
        [SerializeField] private List<SubtitleData> subtitles;
        [SerializeField] private TMP_Text subtitle;
        [SerializeField] private int subtitleIndex;

        private void OnEnable()
        {
            SubtitleFontSizeSlider.OnValueChanged += UpdateFontSizes;
        }

        private void OnDisable()
        {
            SubtitleFontSizeSlider.OnValueChanged -= UpdateFontSizes;
        }
        
        private void Start()
        {
            Display();
        }

        private void Display()
        {
            var nextSubtitle = subtitles[subtitleIndex];
            subtitle.text = "<color=orange><font-weight=900>" + nextSubtitle.speaker + ":</font-weight></color> " + nextSubtitle.subtitle;
            StartCoroutine(Wait(nextSubtitle.duration));
        }
        
        private IEnumerator Wait(float duration)
        {
            yield return new WaitForSeconds(duration);
            subtitleIndex = subtitleIndex < subtitles.Count - 1 ? subtitleIndex + 1 : 0;
            Display();
        }
        
        private void UpdateFontSizes(float value)
        {
            subtitle.fontSize = value;
        }
    }
}
