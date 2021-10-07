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
using UnityEngine.PlayerLoop;

namespace Pladdra.MVC.Views
{
    using Lean.Common;
    using Lean.Touch;
    using Pladdra.Core.Types;

    [RequireComponent(typeof(LeanSelectable))]
    [RequireComponent(typeof(BoxCollider))]
    public class WorkspaceView : View
    {
        private Block createdBlock;
        public LeanSelect leanSelect;
        public LeanPlane leanPlane;
        public GameObject blocksRootObject;
        public GameObject blockPrefab;
        public GameObject workspacePivot;
        public IDictionary<string, GameObject> blocks = new Dictionary<string, GameObject>();
        public LeanSelectable leanSelectable;
        public BoxCollider boxCollider;
        public event WorkspaceViewHandler OnSelectBlockEvent;
        public delegate void WorkspaceViewHandler();

        public Vector3 pivotPoint;
        public Camera targetCamera;
        public bool findClosestPivot;

        public override void Initialize()
        {
            leanSelectable = GetComponent<LeanSelectable>();
            boxCollider = GetComponent<BoxCollider>();
            targetCamera = Camera.main;
        }

        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        void Update()
        {
            if (findClosestPivot || pivotPoint == null)
            {
                Vector3 cameraPosition = targetCamera.transform.position;
                Vector3 closestPoint = boxCollider.ClosestPoint(new Vector3(cameraPosition.x, 0f, cameraPosition.z));
                pivotPoint = new Vector3(closestPoint.x, 0f, closestPoint.z);
            }
        }

        // void OnDrawGizmosSelected()
        // {
        //     Gizmos.color = Color.blue;
        //     Gizmos.DrawSphere(pivotPoint, 0.2f);

        //     Gizmos.color = Color.red;
        //     Gizmos.DrawSphere(context.grid.pivotPosition + transform.position, 0.2f);

        // }
    }
}

