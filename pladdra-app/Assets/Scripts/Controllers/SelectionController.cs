using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class SelectionController
    {
        public SelectionModel model { get; }

        UnityEvent render;

        public SelectionController(SelectionModel SelectionModel)
        {
            model = SelectionModel;
        }
        public SelectionController(SelectionModel SelectionModel, UnityEvent renderEvent)
        {
            model = SelectionModel;
            render = renderEvent;
        }

        public void OnClickMenu()
        {
            ViewManager.Show<MenuView>();
        }
        public void OnClickPlace()
        {
            ViewManager.Show<BuildView>();
        }
        public void OnClickRemove()
        {
            ViewManager.Show<BuildView>();
        }
    }
}