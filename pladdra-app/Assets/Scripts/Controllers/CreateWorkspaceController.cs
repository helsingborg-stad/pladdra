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
        public CreateWorkspaceModel model { get; }

        UnityEvent render;

        private WorkspaceModel workspaceModel;
        private Grid grid;
        private PlannerModel plannerModel;

        public CreateWorkspaceController(CreateWorkspaceModel CreateWorkspaceModel, UnityEvent renderEvent)
        {
            model = CreateWorkspaceModel;
            render = renderEvent;

            App.GetModel<WorkspaceModel>(out workspaceModel);
            App.GetModel<Grid>(out grid);
            App.GetModel<PlannerModel>(out plannerModel);
        }

        public void OnClickCreate(string name)
        {
            if (name.Length <= 0)
                return;

            Pladdra.API.Types.CreateWorkspaceInput input = new API.Types.CreateWorkspaceInput();
            input.id = System.Guid.NewGuid().ToString();
            input.name = name;

            workspaceModel.Create(input, out API.Types.Workspace createdItem);

            plannerModel.workspaceID = createdItem.id;
            grid.size = new System.Numerics.Vector3(1f, 1f, 10f);

            ViewManager.Show<DisposeGridView>();
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }
    }
}