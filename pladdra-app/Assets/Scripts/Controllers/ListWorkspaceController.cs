using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IListWorkspaceController
    {
        public IListWorkspaceModel model { get; }

        public void OnClickBack();
        public void OnClickLoad(string workspaceId);
        public void OnClickDelete(string workspaceId);
    }

    public class ListWorkspaceController : IListWorkspaceController
    {
        public IListWorkspaceModel model { get; }

        UnityEvent render;

        public ListWorkspaceController(IListWorkspaceModel ListWorkspaceModel, UnityEvent renderEvent)
        {
            model = ListWorkspaceModel;
            render = renderEvent;
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }

        public void OnClickLoad(string workspaceId)
        {
            ViewManager.Show<DisposeGridView>();
        }
        public void OnClickDelete(string workspaceId)
        {
            Debug.Log(workspaceId);
            API.Types.DeleteWorkspaceInput input = new API.Types.DeleteWorkspaceInput();
            input.id = workspaceId;
            App.workspaceModel.Delete(input);
            render.Invoke();
        }
    }
}