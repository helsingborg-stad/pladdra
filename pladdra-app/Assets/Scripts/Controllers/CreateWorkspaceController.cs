using System;
using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Views;
using System.Numerics;

namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Models;

    public class CreateWorkspaceController
    {
        UnityEvent render;

        private WorkspaceListModel workspaceModel;
        private Grid grid;
        private PlannerModel planner;

        public CreateWorkspaceController(UnityEvent renderEvent)
        {
            render = renderEvent;

            App.GetModel<WorkspaceListModel>(out workspaceModel);
            App.GetModel<Grid>(out grid);
            App.GetModel<PlannerModel>(out planner);
        }

        public void OnClickCreate(string name)
        {
            if (name.Length <= 0)
                return;

            Pladdra.API.Types.CreateWorkspaceInput input = new API.Types.CreateWorkspaceInput();
            input.id = System.Guid.NewGuid().ToString();
            input.name = name;

            workspaceModel.Create(input, out Core.Types.Workspace createdWorkspace);
            planner.workspaceID = createdWorkspace.id;
            planner.InitializeWorkspace(createdWorkspace.id);
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }
    }
}