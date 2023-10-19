using UnityEngine;

namespace Utilities
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private bool activateOnStart;
        [SerializeField] private bool activateOnEnable;
    
        private void Awake()
        {
            if (targetGameObject == null) targetGameObject = gameObject;
        }
    
        // Start is called before the first frame update
        private void Start()
        {
            if (activateOnStart) Activate();
        }

        private void OnEnable()
        {
            if (activateOnEnable) Activate();
        }
    
        public void Activate() => DontDestroyOnLoad(targetGameObject);
    }
}
