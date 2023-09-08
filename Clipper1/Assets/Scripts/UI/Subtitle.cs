using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Subtitle : MonoBehaviour
    {
        [SerializeField] Camera camera;
        [SerializeField] private Canvas canvas;
        [SerializeField] private float maxAngleDistance = 10f;
        [SerializeField] private float currentYVelocity = 10f;
        [SerializeField] private float smoothSpeed = 0.125f;
        [SerializeField] private bool alignWithPlayer;

        private void Start()
        {
            camera = Camera.main;
        }

        private void LateUpdate()
        {
            Move();
            RotateX();
            RotateY();
        }

        private void Move()
        {
            throw new NotImplementedException();
        }
        
        private void RotateX()
        {
            throw new NotImplementedException();
        }
        
        private void RotateY()
        {
            float targetYRotation = camera.transform.eulerAngles.y;
            float currentYRotation = canvas.transform.parent.eulerAngles.y;
            
            float distance = Mathf.Abs(currentYRotation - targetYRotation);

            if (distance > maxAngleDistance)
            {
                alignWithPlayer = true;
                float newAngle = Mathf.SmoothDampAngle(
                    currentYRotation,
                    targetYRotation,
                    ref currentYVelocity,
                    Time.deltaTime * smoothSpeed
                );
                
                canvas.transform.parent.eulerAngles = new Vector3(
                    canvas.transform.parent.rotation.eulerAngles.x,
                    newAngle,
                    0
                );
            }

            
        }
    }
}
