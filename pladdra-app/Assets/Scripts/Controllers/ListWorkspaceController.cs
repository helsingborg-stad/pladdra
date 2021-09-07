using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Models;

    public class ListWorkspaceController
    {
        public ListWorkspaceModel model { get; }

        UnityEvent render;
        private WorkspaceModel workspaceModel;
        private Grid grid;
        private PlannerModel plannerModel;

        public ListWorkspaceController(ListWorkspaceModel ListWorkspaceModel, UnityEvent renderEvent)
        {
            model = ListWorkspaceModel;
            render = renderEvent;


            App.GetModel<WorkspaceModel>(out workspaceModel);
            App.GetModel<Grid>(out grid);
            App.GetModel<PlannerModel>(out plannerModel);
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }

        public void OnClickLoad(string workspaceId)
        {
            plannerModel.workspaceID = workspaceId;
            grid.size = new System.Numerics.Vector3(1f, 1f, 10f);

            ViewManager.Show<DisposeGridView>();
        }
        public void OnClickDelete(string workspaceId)
        {
            API.Types.DeleteWorkspaceInput input = new API.Types.DeleteWorkspaceInput();
            input.id = workspaceId;
            workspaceModel.Delete(input);
            render.Invoke();
        }
    }
}