using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IMenuController
    {
        public IMenuModel model { get; }
        public void OnClickCreateWorkspace();
        public void OnClickListWorkspace();
        public void OnClickLogout();
    }

    public class MenuController : IMenuController
    {
        public IMenuModel model { get; }

        UnityEvent render;

        public MenuController(IMenuModel menuModel)
        {
            model = menuModel;
        }
        public MenuController(IMenuModel menuModel, UnityEvent renderEvent)
        {
            model = menuModel;
            render = renderEvent;
        }

        public void OnClickCreateWorkspace()
        {
            ViewManager.Show<CreateWorkspaceView>(true);
        }

        public void OnClickListWorkspace()
        {
            ViewManager.Show<ListWorkspaceView>(true);
        }

        public void OnClickLogout()
        {
            Auth.SignOut();
            ViewManager.Show<LoginView>(true);
        }
    }
}