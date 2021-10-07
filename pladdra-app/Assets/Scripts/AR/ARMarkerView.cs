using UnityEngine;
using Lean.Common;
using Lean.Touch;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Pladdra.MVC.Views
{
    using Pladdra;
    using Pladdra.Core;
    using Pladdra.Components;

    [RequireComponent(typeof(CameraRaycast))]
    public class ARMarkerView : View
    {

        private Vector3 transformTarget;
        private bool transformMarker;
        private CameraRaycast raycaster;
        public event OnRaycastHitARPlaneHandler OnRaycastHitARPlane;
        public delegate void OnRaycastHitARPlaneHandler(ARRaycastHit hit);

        public override void Initialize()
        {
            raycaster = GetComponent<CameraRaycast>();
            raycaster.raycastTargetAR = true;
            raycaster.enabled = false;
            Hide();
        }

        public void ToggleCameraRaycast(bool enabled)
        {
            if (raycaster.enabled == enabled)
                return;

            raycaster.enabled = enabled;

            if (raycaster.enabled)
            {
                raycaster.onARHitEvent.AddListener(HandleCameraRaycast);
                return;
            }

            raycaster.onARHitEvent.RemoveListener(HandleCameraRaycast);
        }

        public void TransformMarker(Vector3 position)
        {
            transformTarget = position;
            transformMarker = true;
        }

        private void HandleCameraRaycast(ARRaycastHit hit)
        {
            if (hit.hitType != TrackableType.PlaneWithinPolygon)
            {
                return;
            }

            if (OnRaycastHitARPlane != null)
                OnRaycastHitARPlane(hit);
        }

        private void Update()
        {
            if (transformMarker && transformTarget != null)
            {
                if (transformTarget == transform.position)
                    transformMarker = false;

                if (transformTarget != transform.position)
                    transform.position = transformTarget;
            }
        }
    }
}