using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

namespace Pladdra.Components
{
    public class CameraRaycast : MonoBehaviour
    {
        public UnityEvent<RaycastHit> onHitEvent;
        public Camera ARCamera;
        void FixedUpdate()
        {
            RaycastHit hit;

            if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit, float.MaxValue))
            {
                onHitEvent.Invoke(hit);
            }
        }
    }
}