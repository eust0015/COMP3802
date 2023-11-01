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
        private List<InputDevice> devicesWithInput;

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
            
            devicesWithInput = new List<InputDevice>();
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
            devicesWithInput.Clear();
        }

        private void InputDevices_deviceConnected(InputDevice device)
        {
            bool discardedValue;
            if (device.TryGetFeatureValue(CommonUsages.menuButton, out discardedValue))
            {
                devicesWithInput.Add(device); // Add any devices that have  the type of input.
            }
        }

        private void InputDevices_deviceDisconnected(InputDevice device)
        {
            if (devicesWithInput.Contains(device))
                devicesWithInput.Remove(device);
        }

        private void Update()
        {
            bool tempState = false;
            foreach (var device in devicesWithInput)
            {
                bool inputState = false;
                tempState = device.TryGetFeatureValue(CommonUsages.menuButton, out inputState) // did get a value
                            && inputState // the value we got
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