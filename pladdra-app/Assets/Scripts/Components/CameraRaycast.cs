using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

namespace Pladdra.Components {
    public class CameraRaycast : MonoBehaviour {
        public UnityEvent<RaycastHit> onHitEvent;

        public Camera ARCamera;

        [Tooltip("The component to look for in hit objects.\nIf specified, it only triggers the hit event if the hit object contains the component.\nIf not specified, it triggers the event on any hit.")]
        public UnityEngine.Object targetType;

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