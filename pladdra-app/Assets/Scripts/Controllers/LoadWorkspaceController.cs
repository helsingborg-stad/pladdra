using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ILoadWorkspaceController
    {
        public ILoadWorkspaceModel model { get; }
    }

    public class LoadWorkspaceController : ILoadWorkspaceController
    {
        public ILoadWorkspaceModel model { get; }

        UnityEvent render;

        public LoadWorkspaceController(ILoadWorkspaceModel LoadWorkspaceModel)
        {
            model = LoadWorkspaceModel;
        }
        public LoadWorkspaceController(ILoadWorkspaceModel LoadWorkspaceModel, UnityEvent renderEvent)
        {
            model = LoadWorkspaceModel;
            render = renderEvent;
        }
    }
}