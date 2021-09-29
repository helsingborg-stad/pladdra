using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class Destroy : IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount()
        {
            planner.context.hideTopAppBar = true;
            planner.workspaceController.DestroyHandler();
            planner.context.grid.visible = false;

            SaveDataManager.SaveJsonData(planner.context.workspace);

            planner.SetState(new Inactive());
        }

        public void OnUnmount()
        {
            ViewManager.Show<MenuView>();
        }
    }
}