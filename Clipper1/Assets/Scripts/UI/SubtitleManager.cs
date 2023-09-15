using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace UI
{
    public class SubtitleManager : MonoBehaviour
    {
        [SerializeField] private GameObject background;
        [SerializeField] private List<SubtitleData> subtitles;
        [SerializeField] private bool isDisplaying;
        [SerializeField] private TMP_Text speaker;
        [SerializeField] private TMP_Text subtitle;

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
        
        private void EnqueueSubtitles(List<SubtitleData> setSubtitles)
        {
            foreach (var subtitleData in setSubtitles)
            {
                subtitles.Add(subtitleData);
            }

            Display();
        }

        private void Display()
        {
            if (isDisplaying) return;
            isDisplaying = true;
            background.SetActive(true);
            var nextSubtitle = subtitles[0];
            speaker.text = nextSubtitle.speaker + ":";
            subtitle.text = nextSubtitle.subtitle;
            StartCoroutine(Wait(nextSubtitle.duration));
        }
        
        private IEnumerator Wait(float duration)
        {
            yield return new WaitForSeconds(duration);
            subtitles.RemoveAt(0);
            Hide();
        }

        private void Hide()
        {
            isDisplaying = false;
            background.SetActive(false);
            if (subtitles.Count > 0)
            {
                Display(); 
            }
        }
        
        private void UpdateFontSizes(float value)
        {
            speaker.fontSize = value;
            subtitle.fontSize = value;
        }
        
    }
}
