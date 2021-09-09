using System.Collections;
using System.Collections.Generic;
using Pladdra.MVC.Views;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.Core;
    using Pladdra.MVC.Models;

    public class GridController
    {
        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        private GameObject gridObject { get; set; }
        private GridView gridView { get; set; }

        public GridController()
        {
            gridObject = GameObject.Find("Grid");
            gridView = gridObject.GetComponent<GridView>();
            gridView.Initialize();
            gridView.Hide();

            context.grid.OnVisibleChanged += ToggleGrid;
            context.grid.OnIsSelectableChanged += ToggleGridSelection;
            context.grid.OnPositionChanged += TransformGrid;
            context.grid.OnScaleChanged += ScaleGrid;
            context.grid.OnRotationChanged += RotateGrid;
        }

        public void ToggleGrid()
        {
            if (context.grid.visible)
            {
                gridView.Show();
                return;
            }

            gridView.Hide();

        }

        public void ToggleGridSelection()
        {
            gridView.SetSelected(!context.grid.isSelectable);
        }
        public void ScaleGrid()
        {
            gridObject.transform.localScale = new Vector3(context.grid.scale, context.grid.scale, context.grid.scale);
        }
        public void TransformGrid()
        {
            gridObject.transform.position = new Vector3(context.grid.position.X, context.grid.position.Y, context.grid.position.Z);
        }
        public void RotateGrid()
        {
            // To be continued
        }

        public void GenerateGrid()
        {
            var filter = gridObject.GetComponent<MeshFilter>();
            var boxCollider = gridObject.GetComponent<BoxCollider>();

            filter.mesh = PlaneMeshGenerator.GenerateHorizontal((int)context.grid.size.X, (int)context.grid.size.Y, context.grid.size.Z, true);
            boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, 0.01f, context.grid.size.X * context.grid.size.Z);
        }
    }
}
