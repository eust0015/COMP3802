using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace Input
{
    public class XRMenuButtonWatcher : MonoBehaviour
    {
        public delegate void PressEvent(bool pressed);
        public static event PressEvent OnPress;

        public static XRMenuButtonWatcher Instance { get; private set; }
        private bool lastButtonState = false;
        private List<InputDevice> devicesWithMenuButton;

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
            
            devicesWithMenuButton = new List<InputDevice>();
        }

        private void Start()
        {
            List<InputDevice> allDevices = new List<InputDevice>();
            InputDevices.GetDevices(allDevices);
            foreach(InputDevice device in allDevices)
                InputDevices_deviceConnected(device);

            InputDevices.deviceConnected += InputDevices_deviceConnected;
            InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
        }

        private void OnDestroy()
        {
            InputDevices.deviceConnected -= InputDevices_deviceConnected;
            InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
            devicesWithMenuButton.Clear();
        }

        private void InputDevices_deviceConnected(InputDevice device)
        {
            bool discardedValue;
            if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
            {
                devicesWithMenuButton.Add(device); // Add any devices that have a menu button.
            }
        }

        private void InputDevices_deviceDisconnected(InputDevice device)
        {
            if (devicesWithMenuButton.Contains(device))
                devicesWithMenuButton.Remove(device);
        }

        private void Update()
        {
            bool tempState = false;
            foreach (var device in devicesWithMenuButton)
            {
                bool menuButtonState = false;
                tempState = device.TryGetFeatureValue(CommonUsages.menuButton, out menuButtonState) // did get a value
                            && menuButtonState // the value we got
                            || tempState; // cumulative result from other controllers
            }

            if (tempState != lastButtonState) // Button state changed since last frame
            {
                OnPress?.Invoke(tempState);
                lastButtonState = tempState;
            }
        }
    }
}