using System;
using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ICreateWorkspaceController
    {
        public ICreateWorkspaceModel model { get; }

        public void OnClickCreate(string name);
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

        public void OnClickCreate(string name)
        {
            Pladdra.API.Types.CreateWorkspaceInput input = new API.Types.CreateWorkspaceInput();
            input.id = System.Guid.NewGuid().ToString();
            input.name = name;
            App.workspaceModel.Create(input);
            ViewManager.Show<DisposeGridView>();
        }

        public void OnClickBack()
        {
            ViewManager.ShowLast();
        }
    }
}