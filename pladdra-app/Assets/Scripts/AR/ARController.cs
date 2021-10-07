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

        public void SetRaycastPosition(ARRaycastHit hit)
        {
            var pose = hit.pose;

            context.raycastHitPosition = new System.Numerics.Vector3(pose.position.x, pose.position.y, pose.position.z) + new System.Numerics.Vector3(0, 0.003f, 0);
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
            {
                // switch (plane.classification)
                // {
                //     case PlaneClassification.None:
                //         Debug.Log(PlaneClassification.None);
                //         break;
                //     case PlaneClassification.Wall:
                //         Debug.Log(PlaneClassification.Wall);
                //         break;
                //     case PlaneClassification.Floor:
                //         Debug.Log(PlaneClassification.Floor);
                //         break;
                //     case PlaneClassification.Ceiling:
                //         Debug.Log(PlaneClassification.Ceiling);
                //         break;
                //     case PlaneClassification.Table:
                //         Debug.Log(PlaneClassification.Table);
                //         break;
                //     case PlaneClassification.Seat:
                //         Debug.Log(PlaneClassification.Seat);
                //         break;
                //     case PlaneClassification.Door:
                //         Debug.Log(PlaneClassification.Door);
                //         break;
                //     case PlaneClassification.Window:
                //         Debug.Log(PlaneClassification.Window);
                //         break;
                // }

                plane.gameObject.SetActive(value);
            }
        }
    }
}