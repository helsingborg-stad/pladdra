using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class MenuController
    {
        public MenuModel model { get; }

        UnityEvent render;

        public MenuController(MenuModel menuModel)
        {
            model = menuModel;
        }
        public MenuController(MenuModel menuModel, UnityEvent renderEvent)
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

        public async void RefreshToken()
        {
            bool successfulRefresh = await Auth.RefreshSession();
            if (!successfulRefresh)
            {
                ViewManager.Show<LoginView>();
            }
        }
    }
}