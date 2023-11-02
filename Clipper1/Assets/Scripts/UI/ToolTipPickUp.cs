using UnityEngine;

namespace UI
{
    public class ToolTipPickup : MonoBehaviour
    {
        public static bool IsEnabled = true;

        public void Display()
        {
            if (!IsEnabled) return;
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
