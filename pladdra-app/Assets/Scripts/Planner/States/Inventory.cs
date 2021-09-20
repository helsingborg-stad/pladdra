using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Inventory : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.inventoryGUI.backButton.onClick.AddListener(OnClickExitInventory);
            planner.plannerGUI.inventoryGUI.OnClickGridItem += OnClickInvetoryItem;
            planner.plannerGUI.inventoryGUI.Show();
        }

        public void OnUnmount()
        {
            planner.plannerGUI.inventoryGUI.backButton.onClick.RemoveListener(OnClickExitInventory);
            planner.plannerGUI.inventoryGUI.OnClickGridItem -= OnClickInvetoryItem;
            planner.plannerGUI.inventoryGUI.Hide();
        }

        public void OnClickExitInventory()
        {
            planner.SetState(new Build());
        }

        public void OnClickInvetoryItem(Pladdra.Core.Types.Asset asset)
        {
            var input = new CreateBlockInput();
            input.id = planner.context.workspace.UUID();
            input.workspaceID = planner.context.workspace.id;
            input.assetID = asset.id;
            input.position = new Vect3Input { x = planner.context.grid.position.X, y = planner.context.grid.position.Y, z = planner.context.grid.position.Z };
            input.rotation = new QuatInput { x = planner.context.grid.rotation.X, y = planner.context.grid.rotation.Y, z = planner.context.grid.rotation.Z, w = planner.context.grid.rotation.W };
            planner.context.workspace.CreateBlock(input);
        }
    }
}