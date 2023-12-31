using UnityEngine;

namespace UI
{
    public class ExclamationPoint : MonoBehaviour
    {
        private void Start()
        {
            if (PuzzleManager.IsPuzzleToSolve(transform.parent)) return;
            gameObject.SetActive(false);
        }

        public void Display()
        {
            if (!PuzzleManager.IsPuzzleToSolve(transform.parent)) return;
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
