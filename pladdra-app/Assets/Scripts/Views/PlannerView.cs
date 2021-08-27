using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;
namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(CameraRaycast))]
    public class PlannerView : View
    {
        private IPlannerModel context;
        private IPlannerController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = true;

        public GameObject arMarkerPrefab;
        public GameObject createdARMarker;

        CameraRaycast raycaster;

        public override void Initialize()
        {
            raycaster = GetComponent<CameraRaycast>();

            renderEvent = new UnityEvent();
            context = new PlannerModel();
            controller = new PlannerController(context, renderEvent);

            raycaster.onHitEvent.AddListener(controller.OnCameraRaycast);
            renderEvent.AddListener(() => shouldRender = true);
        }
        
        private void Update()
        {
            if (shouldRender)
            {
                shouldRender = false;
            }
        }

        private void FixedUpdate () {
            if (createdARMarker == null) {
                createdARMarker = Instantiate(arMarkerPrefab, context.raycastHitPosition, Quaternion.identity);
            } else {
                createdARMarker.transform.position = context.raycastHitPosition;
            }
        }
    }
}
