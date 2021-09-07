using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using Lean.Common;
using Lean.Touch;

using FSA = UnityEngine.Serialization.FormerlySerializedAsAttribute;

using TMPro;

using Pladdra.Core;


namespace Pladdra.MVC.Views
{
    using Pladdra.MVC.Models;
    using Pladdra.MVC.Controllers;

    public class EditGridView : View
    {
        public Button menuButton;
        public Button removeButton;
        public Button placeButton;

        public Vector3 gridSize;

        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }
        public GameObject gridPrefab;

        public GameObject gridObject;
        private Pladdra.Components.Grid gridComponent;
        private LeanSelectable gridSelectable;

        private EditGridController controller;

        private bool initialized = false;


        public override void Initialize()
        {
            controller = new EditGridController();

            menuButton.onClick.AddListener(controller.OnClickMenu);
            placeButton.onClick.AddListener(controller.OnClickPlace);
            removeButton.onClick.AddListener(controller.OnClickRemove);

            grid.OnVisibleChanged += ToggleGrid;
            initialized = true;
        }

        public void TransformGrid()
        {
            if (gridObject.transform.position.x != grid.position.X
            || gridObject.transform.position.y != grid.position.Y)
                gridObject.transform.position = new Vector3(grid.position.X, grid.position.Y, grid.position.Z);
        }

        public void ToggleGrid()
        {
            if (grid.visible)
            {
                var scaleFactor = 16f;
                var scale = 1.0f / scaleFactor;

                if (gridSize == null
                    || !gridSize.Equals(new Vector3(grid.size.X, grid.size.Y, grid.size.Z)))
                {
                    var filter = gridObject.GetComponent<MeshFilter>();
                    filter.mesh = PlaneMeshGenerator.GenerateHorizontal((int)grid.size.X, (int)grid.size.Y, grid.size.Z, true);
                    gridSize = new Vector3(grid.size.X, grid.size.Y, grid.size.Z);


                    BoxCollider boxCollider = gridObject.GetComponent<BoxCollider>();
                    boxCollider.size = new Vector3(grid.size.X * grid.size.Z, 0.01f, grid.size.X * grid.size.Z);
                    // var renderer = gridObject.AddComponent<MeshRenderer>();
                    // var material = renderer.material;
                    // material.color = new Color(1f, 0f, 0f, 0.5f);
                }

                if (!gridObject.transform.position.Equals(new Vector3(grid.position.X, grid.position.Y, grid.position.Z)))
                    gridObject.transform.position = new Vector3(grid.position.X, grid.position.Y, grid.position.Z);

                if (!gridObject.transform.localScale.Equals(new Vector3(scale, scale, scale)))
                    gridObject.transform.localScale = new Vector3(scale, scale, scale);


                if (gridComponent != null)
                    gridComponent.SetSelected(true);
            }

            gridObject.SetActive(grid.visible);
        }

        private void OnEnable()
        {
            if (initialized)
            {
                if (gridObject == null)
                    gridObject = (GameObject)Instantiate(gridPrefab);

                if (gridComponent == null)
                    gridComponent = gridObject.GetComponent<Pladdra.Components.Grid>();

                if (gridSelectable == null)
                {
                    gridSelectable = gridObject.GetComponent<LeanSelectable>();
                }
                ToggleGrid();
            }

            if (gridSelectable != null)
                gridSelectable.enabled = true;

        }
        private void OnDisable()
        {
            if (gridComponent != null)
                gridComponent.SetSelected(false);

            if (gridSelectable != null)
                gridSelectable.enabled = false;
        }
    }
}
