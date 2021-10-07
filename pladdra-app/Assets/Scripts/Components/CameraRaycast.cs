using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using System;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
namespace Pladdra.Components
{
    public class CameraRaycast : MonoBehaviour
    {
        public UnityEvent<RaycastHit> onHitEvent;
        public UnityEvent<ARRaycastHit> onARHitEvent;
        public Camera ARCamera;
        public bool raycastTargetAR;

        private ARRaycastManager _ARRaycastManager;

        private RaycastHit hit;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();

        void Update()
        {
            if (raycastTargetAR)
            {
                ARRaycast();
                return;
            }

            PhysicsRaycast();
        }

        void PhysicsRaycast()
        {

            if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit, float.MaxValue))
            {
                if (onHitEvent != null)
                    onHitEvent.Invoke(hit);
            }
        }

        void Awake()
        {
            _ARRaycastManager = GameObject.Find("AR Session Origin").GetComponent<ARRaycastManager>();
        }

        void ARRaycast()
        {
            if (_ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.PlaneWithinPolygon))
            {
                if (onARHitEvent != null)
                    onARHitEvent.Invoke(hits[0]);

                // foreach (ARRaycastHit hit in hits)
                // {
                //     // Debug.Log(hit.distance);
                //     // Debug.Log(hit.sessionRelativeDistance);
                //     // Debug.Log(hit.hitType);
                //     // Debug.Log(hit.trackableId);
                //     Pose hitPose = hit.pose;
                //     if (onARHitEvent != null)
                //         onARHitEvent.Invoke(hit);
                // }

            }
        }
    }
}