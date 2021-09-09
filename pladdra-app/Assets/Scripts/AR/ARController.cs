using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Views;
    using Pladdra.MVC.Models;

    public class ARController
    {
        private ARPlaneManager planeManager;
        private ARMarkerView arMarkerView;

        private ARModel context
        {
            get
            {
                Pladdra.App.GetModel<ARModel>(out var instance);
                return instance;
            }
        }

        public ARController()
        {
            arMarkerView = GameObject.Find("AR Marker").GetComponent<ARMarkerView>();
            planeManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

            context.PlaneDetectionChanged += TogglePlaneDetection;
            context.RaycastChanged += ToggleRaycast;
            context.ShowMarkerChanged += ToggleMarker;
            context.RaycastHitPositionChanged += SetMarkerPosition;


            arMarkerView.OnRaycastHitARPlane += SetRaycastPosition;
            arMarkerView.Initialize();
        }

        public void SetRaycastPosition(RaycastHit hit)
        {
            context.raycastHitPosition = new System.Numerics.Vector3(hit.point.x, hit.point.y, hit.point.z) + new System.Numerics.Vector3(0, 0.003f, 0);
        }

        public void ToggleRaycast()
        {
            arMarkerView.ToggleCameraRaycast(context.raycast);
        }

        public void ToggleMarker()
        {
            if (context.showMarker)
            {

                arMarkerView.Show();
                context.RaycastHitPositionChanged += SetMarkerPosition;
                return;
            }

            arMarkerView.Hide();
            context.RaycastHitPositionChanged -= SetMarkerPosition;
        }

        public void SetMarkerPosition()
        {
            arMarkerView.TransformMarker(new Vector3(context.raycastHitPosition.X, context.raycastHitPosition.Y, context.raycastHitPosition.Z) + new Vector3(0, 0, 0.01f));
        }

        public void TogglePlaneDetection()
        {
            Debug.Log(context.planeDetection);
            if (planeManager.enabled == context.planeDetection)
                return;

            SetAllPlanesActive(context.planeDetection);
            planeManager.enabled = context.planeDetection;
        }

        /// <summary>
        /// Iterates over all the existing planes and activates
        /// or deactivates their <c>GameObject</c>s'.
        /// </summary>
        /// <param name="value">Each planes' GameObject is SetActive with this value.</param>
        public void SetAllPlanesActive(bool value)
        {
            foreach (var plane in planeManager.trackables)
                plane.gameObject.SetActive(value);
        }
    }

}