using System.Collections;
using System.Collections.Generic;
using Pladdra.MVC.Views;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Lean.Common;
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
        private GameObject leanPlaneObject { get; set; }
        private GridView gridView { get; set; }
        private LeanPlane leanPlane { get; set; }

        public GridController()
        {
            gridObject = GameObject.Find("Grid");
            leanPlaneObject = GameObject.Find("GridLeanPlane");
            leanPlane = leanPlaneObject.GetComponent<LeanPlane>();
            gridView = gridObject.GetComponent<GridView>();
            gridView.Initialize();
            gridView.Hide();

            context.grid.OnVisibleChanged += ToggleGrid;
            context.grid.OnIsSelectableChanged += ToggleGridSelection;
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
            gridView.SetSelected(context.grid.isSelectable);
        }

        public void GenerateGrid()
        {
            var filter = gridObject.GetComponent<MeshFilter>();
            var boxCollider = gridObject.GetComponent<BoxCollider>();

            filter.mesh = PlaneMeshGenerator.GenerateHorizontal((int)context.grid.size.X, (int)context.grid.size.Y, context.grid.size.Z, true);
            boxCollider.center = new Vector3(0f, 0f, 0f);
            boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, 0.01f, context.grid.size.X * context.grid.size.Z);


            leanPlane.ClampX = true;
            leanPlane.ClampY = true;
            leanPlane.MinX = 0;
            leanPlane.MinY = 0;
            leanPlane.MaxX = context.grid.size.X * context.grid.size.Z;
            leanPlane.MaxY = context.grid.size.Y * context.grid.size.Z;

            leanPlaneObject.transform.localPosition = new Vector3(-1 * leanPlane.MaxX / 2, 0.1f, -1 * leanPlane.MaxY / 2);

            // var leanBoxCollider = leanPlaneObject.GetComponent<BoxCollider>();
            // boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, context.grid.size.Y * context.grid.size.Z, 1.0f);
        }
    }
}
