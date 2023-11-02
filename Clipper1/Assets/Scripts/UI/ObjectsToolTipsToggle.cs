using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ObjectsToolTipsToggle : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
    
        private void Start()
        {
            toggle.onValueChanged.AddListener(OnToggleValueChanged);
        }
    
        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
        }
    
        private void OnToggleValueChanged(bool value)
        {
            ToolTipPickup.IsEnabled = value;
        }
    }
}
