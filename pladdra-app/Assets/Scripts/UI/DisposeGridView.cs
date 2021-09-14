using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using UnityEngine.XR.ARFoundation;

using Pladdra.Core;
using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;
namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(CameraRaycast))]
    public class DisposeGridView : View
    {
        public Button menuButton;
        public Button placeButton;
        public GameObject arMarkerPrefab;
        public GameObject createdARMarker;
        private DisposeGridModel context;
        private DisposeGridController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = false;
        private bool initialized = false;

        CameraRaycast raycaster;

        public override void Initialize()
        {
            raycaster = GetComponent<CameraRaycast>();

            renderEvent = new UnityEvent();
            context = new DisposeGridModel();
            controller = new DisposeGridController(context, renderEvent);

            raycaster.onHitEvent.AddListener(HandleCameraRaycast);
            renderEvent.AddListener(() => shouldRender = true);

            menuButton.onClick.AddListener(controller.OnClickMenu);
            placeButton.onClick.AddListener(controller.OnClickPlace);

            initialized = true;

            // var mesh = PlaneMeshGenerator.GenerateHorizontal(4, 4, 10, true);
            // var gridObj = new GameObject("Grid");
            // var filter = gridObj.AddComponent<MeshFilter>();
            // filter.mesh = mesh;
            // var renderer = gridObj.AddComponent<MeshRenderer>();
            // var material = renderer.material;
            // material.color = new Color(1, 0, 0, 0.5f);
        }

        private void OnEnable()
        {
            if (!initialized)
                return;

            if (createdARMarker == null)
                createdARMarker = Instantiate(arMarkerPrefab, context.raycastHitPosition, Quaternion.identity);

            // ARController.TogglePlaneDetection(true);

            createdARMarker.SetActive(true);
        }

        private void OnDisable()
        {
            if (createdARMarker != null)
                createdARMarker.SetActive(false);
        }

        private void HandleCameraRaycast(RaycastHit hit)
        {
            ARPlane plane = hit.transform.gameObject.GetComponent<ARPlane>();
            if (plane == null)
                return;

            controller.OnCameraRaycast(hit);
        }

        private void Update()
        {
            if (shouldRender)
            {
                if (createdARMarker != null)
                {
                    createdARMarker.transform.position = context.raycastHitPosition + new Vector3(0, 0, 0.01f);
                }

                shouldRender = false;
            }
        }
    }
}
