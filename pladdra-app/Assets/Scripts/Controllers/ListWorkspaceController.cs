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
        private WorkspaceList workspaceModel;
        private Grid grid;
        private PlannerModel planner;

        public ListWorkspaceController(ListWorkspaceModel ListWorkspaceModel, UnityEvent renderEvent)
        {
            model = ListWorkspaceModel;
            render = renderEvent;


            App.GetModel<WorkspaceList>(out workspaceModel);
            App.GetModel<Grid>(out grid);
            App.GetModel<PlannerModel>(out planner);
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }

        public void OnClickLoad(string workspaceId)
        {
            planner.workspaceID = workspaceId;
            planner.InitializeWorkspace(workspaceId);
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