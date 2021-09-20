using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class WorkspaceSelection : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.editGridGUI.removeGridButton.onClick.AddListener(OnClickRemoveGrid);
            planner.plannerGUI.editGridGUI.lockGridButton.onClick.AddListener(OnClickLockGrid);

            planner.context.grid.visible = true;
            planner.context.ar.planeDetection = true;
            planner.context.grid.isSelectable = true;

            planner.plannerGUI.editGridGUI.Show();
        }

        public void OnUnmount()
        {
            planner.plannerGUI.editGridGUI.removeGridButton.onClick.RemoveListener(OnClickRemoveGrid);
            planner.plannerGUI.editGridGUI.lockGridButton.onClick.RemoveListener(OnClickLockGrid);

            planner.context.ar.planeDetection = false;
            planner.context.grid.isSelectable = false;

            planner.plannerGUI.editGridGUI.Hide();
        }

        public void OnClickLockGrid()
        {
            planner.context.grid.isSelectable = true;
            planner.SetState(new Build());
        }

        public void OnClickRemoveGrid()
        {
            planner.SetState(new PlaneDetection());
        }
    }
}