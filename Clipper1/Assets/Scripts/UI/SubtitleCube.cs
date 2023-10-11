using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UI
{
    public class SubtitleCube : MonoBehaviour
    {
        [SerializeField] private List<SubtitleData> subtitles;
        [SerializeField] private TMP_Text subtitle;
        [SerializeField] private int subtitleIndex;
        [SerializeField] private Slider scaleSlider;
        
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
    }
}
