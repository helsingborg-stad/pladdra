using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Inactive : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.plannerGUI.placeGridGUI.Hide();
            planner.plannerGUI.editGridGUI.Hide();
            planner.plannerGUI.buildGUI.Hide();
            planner.plannerGUI.buildSelectionGUI.Hide();
            planner.plannerGUI.inventoryGUI.Hide();
        }

        public void OnUnmount()
        {
        }
    }
}