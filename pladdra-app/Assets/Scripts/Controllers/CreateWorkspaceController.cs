using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ICreateWorkspaceController
    {
        public ICreateWorkspaceModel model { get; }

        public void OnClickCreate();
        public void OnClickBack();
    }

    public class CreateWorkspaceController : ICreateWorkspaceController
    {
        public ICreateWorkspaceModel model { get; }

        UnityEvent render;

        public CreateWorkspaceController(ICreateWorkspaceModel CreateWorkspaceModel, UnityEvent renderEvent)
        {
            model = CreateWorkspaceModel;
            render = renderEvent;
        }

        public void OnClickCreate()
        {

        }
        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }
    }
}