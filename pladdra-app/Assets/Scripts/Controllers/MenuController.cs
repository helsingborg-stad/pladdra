using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IMenuController
    {
        public IMenuModel model { get; }
        public void OnClickStart();
        public void OnClickSync();
        public void OnClickLogout();
    }

    public class MenuController : IMenuController
    {
        public IMenuModel model { get; }

        UnityEvent render;

        public MenuController(IMenuModel menuModel, UnityEvent renderEvent)
        {
            model = menuModel;
            render = renderEvent;
        }

        public void OnClickStart()
        {
            ViewManager.Show<PlannerView>();
        }

        public void OnClickSync()
        {
            // ViewManager.Show<Download>();
        }

        public void OnClickLogout()
        {
            Auth.SignOut();
            ViewManager.Show<LoginView>();
        }
    }
}