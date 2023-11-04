using UnityEngine;

namespace UI
{
    public class ExclamationPoint : MonoBehaviour
    {
        public bool isAPuzzleToSolveHere;

        public void Display()
        {
            if (!isAPuzzleToSolveHere) return;
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
