using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class BlockSelection : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.buildSelectionGUI.confirmSelectionButton.onClick.AddListener(OnClickPlaceBlock);
            planner.plannerGUI.buildSelectionGUI.removeSelectionButton.onClick.AddListener(OnClickRemoveBlock);
            planner.plannerGUI.buildSelectionGUI.Show();
        }

        public void OnUnmount()
        {
            planner.plannerGUI.buildSelectionGUI.confirmSelectionButton.onClick.RemoveListener(OnClickPlaceBlock);
            planner.plannerGUI.buildSelectionGUI.removeSelectionButton.onClick.RemoveListener(OnClickRemoveBlock);
            planner.plannerGUI.buildSelectionGUI.Hide();
        }

        public void OnClickPlaceBlock()
        {
            planner.workspaceController.DeselectAllBlocks();
            planner.context.workspace.selectedBlockID = null;
        }

        public void OnClickRemoveBlock()
        {
            planner.context.workspace.DeleteBlock(planner.context.workspace.selectedBlockID);
        }
    }
}