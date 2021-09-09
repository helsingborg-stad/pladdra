using UnityEngine;
using Lean.Common;
using Lean.Touch;
using UnityEngine.XR.ARFoundation;

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
        public delegate void OnRaycastHitARPlaneHandler(RaycastHit hit);

        public override void Initialize()
        {
            raycaster = GetComponent<CameraRaycast>();
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
                raycaster.onHitEvent.AddListener(HandleCameraRaycast);
                return;
            }

            raycaster.onHitEvent.RemoveListener(HandleCameraRaycast);
        }

        public void TransformMarker(Vector3 position)
        {
            transformTarget = position;
            transformMarker = true;
        }

        private void HandleCameraRaycast(RaycastHit hit)
        {
            ARPlane plane = hit.transform.gameObject.GetComponent<ARPlane>();
            if (plane == null)
                return;

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