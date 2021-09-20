using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class PlaneDetection : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.placeGridGUI.placeGridButton.onClick.AddListener(ClickPlaceGrid);

            planner.context.grid.visible = false;
            planner.context.ar.planeDetection = true;
            planner.context.ar.raycast = true;
            planner.context.ar.showMarker = true;

            planner.plannerGUI.placeGridGUI.Show();
        }

        public void OnUnmount()
        {
            planner.plannerGUI.placeGridGUI.placeGridButton.onClick.RemoveListener(ClickPlaceGrid);

            planner.context.ar.planeDetection = false;
            planner.context.ar.raycast = false;
            planner.context.ar.showMarker = false;

            planner.plannerGUI.placeGridGUI.Hide();
        }

        public void ClickPlaceGrid()
        {
            planner.context.grid.position = planner.context.ar.raycastHitPosition;
            planner.SetState(new WorkspaceSelection());
        }
    }
}