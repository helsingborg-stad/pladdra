using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Initialize : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            ViewManager.Show<PlannerGUI>();

            planner.context.workspace.OnBlockSelected += planner.OnSelectDeselectBlock;
            planner.context.workspace.OnBlockDeselected += planner.OnSelectDeselectBlock;

            // Generate Workspace
            var scaleFactor = 10f;
            var scale = 1.0f / scaleFactor;
            planner.context.grid.size = new System.Numerics.Vector3(1f, 1f, 10f);
            planner.context.grid.scale = scale;
            planner.context.grid.isSelectable = false;
            planner.context.grid.visible = false;
            planner.gridController.GenerateGrid();

            planner.SetState(new PlaneDetection());
        }

        public void OnUnmount()
        {
            planner.context.hideTopAppBar = false;
        }
    }
}