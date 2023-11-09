using UnityEngine;

namespace UI
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private SphereUIObjectLevelTransition sphereUIObjectLevelTransition;
        [SerializeField] private GameObject up;
        [SerializeField] private GameObject down;
        private void Start()
        {
            // Names look like: Room2FrontSphere01
            string rootSphereName = transform.root.gameObject.name;
            int room = int.Parse(rootSphereName.Substring(4, 1));
            int targetRoom = sphereUIObjectLevelTransition.index + 1;

            if (room < targetRoom)
            {
                up.SetActive(true);
                down.SetActive(false);
            }
            else if (room > targetRoom)
            {
                up.SetActive(false);
                down.SetActive(true);
            }
            else
            {
                up.SetActive(false);
                down.SetActive(false);
            }
        }
        public void Display()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
