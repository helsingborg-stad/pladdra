using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Build : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.buildGUI.editGridButton.onClick.AddListener(OnClickEditGrid);
            planner.plannerGUI.buildGUI.showInventoryButton.onClick.AddListener(OnClickShowInventory);
            planner.plannerGUI.buildGUI.Show();
        }

        public void OnUnmount()
        {
            planner.plannerGUI.buildGUI.editGridButton.onClick.RemoveListener(OnClickEditGrid);
            planner.plannerGUI.buildGUI.showInventoryButton.onClick.RemoveListener(OnClickShowInventory);
            planner.plannerGUI.buildGUI.Hide();
        }

        public void OnClickShowInventory()
        {
            planner.SetState(new Inventory());
        }
        public void OnClickEditGrid()
        {
            planner.SetState(new WorkspaceSelection());
        }
    }
}