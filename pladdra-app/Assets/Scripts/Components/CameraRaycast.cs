using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

namespace Pladdra.Components {
    public class CameraRaycast : MonoBehaviour {
        public UnityEvent<RaycastHit> onHitEvent;

        public Camera ARCamera;

        public UnityEngine.Object targetType;

        public MonoScript scriptType;

        // Update is called once per frame
        void FixedUpdate() {
            RaycastHit hit;

            if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit, float.MaxValue)) {
                if (targetType != null) {
                    MonoScript script = targetType as MonoScript;
                    Type scriptType = script.GetClass();
                    Component outComponent;

                    if(!hit.transform.TryGetComponent(out outComponent)) {
                        return;
                    }
                }

                onHitEvent.Invoke(hit);
            }
        }
    }
}