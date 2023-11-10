using System.Collections.Generic;
using Input;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class PDFViewer : MonoBehaviour
    {
        public delegate void HideEvent();
        public static event HideEvent OnHide;
        
        [SerializeField] private float spawnOffsetDistance = 2f;
        [SerializeField] private Image page;
        [SerializeField] private List<Sprite> pages;
        [SerializeField] private Slider pageNumberSlider;
        [SerializeField] private TextMeshProUGUI valueText;
        
        private void Awake()
        {
            pageNumberSlider.maxValue = pages.Count;
            UpdatePage(1);
        }
        
        private void Start()
        {
            HideButton.OnClick += Hide;
            KeyboardSpaceKeyWatcher.OnPress += Display;
            XRPrimaryButtonWatcher.OnPress += Display;
            XRPrimary2DAxisClickWatcher.OnPress += Display;
            XRSecondaryButtonWatcher.OnPress += Display;
            XRSecondary2DAxisClickWatcher.OnPress += Display;
            pageNumberSlider.onValueChanged.AddListener(UpdatePage);
        }

        private void OnDestroy()
        {
            HideButton.OnClick -= Hide;
            KeyboardSpaceKeyWatcher.OnPress -= Display;
            XRPrimaryButtonWatcher.OnPress -= Display;
            XRPrimary2DAxisClickWatcher.OnPress -= Display;
            XRSecondaryButtonWatcher.OnPress -= Display;
            XRSecondary2DAxisClickWatcher.OnPress -= Display;
            pageNumberSlider.onValueChanged.RemoveListener(UpdatePage);
        }
        
        private void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
        
        private void Display(bool pressed)
        {
            if (!pressed) return;
            gameObject.SetActive(true);
            transform.position = (Camera.main.transform.position + Camera.main.transform.forward * spawnOffsetDistance) +
                                 (Vector3.down * (transform.localScale.y / 2));
        }
        
        private void UpdatePage(float pageNumber)
        {
            page.sprite = pages[(int)pageNumber - 1];
            valueText.text = (pageNumber).ToString("0");
        }
    }
}
