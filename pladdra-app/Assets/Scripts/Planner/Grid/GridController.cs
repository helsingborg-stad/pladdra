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
        private PlannerController planner;

        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        private BoxCollider gridViewBoxCollider;

        private GameObject workspaceObject { get; set; }
        private GameObject gridObject { get; set; }
        private GameObject leanPlaneObject { get; set; }
        private GridView gridView { get; set; }
        private LeanPlane leanPlane { get; set; }

        public GridController(PlannerController plannerInstance)
        {
            planner = plannerInstance;

            gridObject = GameObject.Find("Grid");
            workspaceObject = gridObject.transform.parent.gameObject;
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
                workspaceObject.SetActive(true);
                gridView.Show();
                return;
            }

            gridView.Hide();
            workspaceObject.SetActive(false);
        }

        public void ToggleGridSelection()
        {
            gridView.SetSelected(context.grid.isSelectable);
        }

        public void GenerateGrid()
        {
            gridView.filter.mesh = PlaneMeshGenerator.GenerateHorizontal((int)context.grid.size.X, (int)context.grid.size.Y, context.grid.size.Z, true);
            gridView.boxCollider.center = new Vector3(0f, 0f, 0f);
            gridView.boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, 0.01f, context.grid.size.X * context.grid.size.Z);

            leanPlane.ClampX = true;
            leanPlane.ClampY = true;
            leanPlane.MinX = 0;
            leanPlane.MinY = 0;
            leanPlane.MaxX = context.grid.size.X * context.grid.size.Z;
            leanPlane.MaxY = context.grid.size.Y * context.grid.size.Z;

            leanPlaneObject.transform.localPosition = new Vector3(-1 * leanPlane.MaxX / 2, 0f, -1 * leanPlane.MaxY / 2);
        }
    }
}
