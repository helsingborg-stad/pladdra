using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class LoadWorkspaceController
    {
        public LoadWorkspaceModel model { get; }

        UnityEvent render;

        public LoadWorkspaceController(LoadWorkspaceModel LoadWorkspaceModel)
        {
            model = LoadWorkspaceModel;
        }
        public LoadWorkspaceController(LoadWorkspaceModel LoadWorkspaceModel, UnityEvent renderEvent)
        {
            model = LoadWorkspaceModel;
            render = renderEvent;
        }
    }
}