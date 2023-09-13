using UnityEngine;

namespace UI
{
    [System.Serializable]
    public class SubtitleData
    {
        public string speaker;
        [TextArea] public string subtitle;
        public float duration;
    }
}
