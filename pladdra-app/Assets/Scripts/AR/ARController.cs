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

        private AR context
        {
            get
            {
                Pladdra.App.GetModel<AR>(out var instance);
                return instance;
            }
        }

        public ARController()
        {
            planeManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();
            context.PlaneDetectionChanged += TogglePlaneDetection;
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