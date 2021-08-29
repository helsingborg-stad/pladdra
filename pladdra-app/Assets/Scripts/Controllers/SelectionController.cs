using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ISelectionController
    {
        public ISelectionModel model { get; }

        public void OnClickMenu();
        public void OnClickPlace();
        public void OnClickRemove();
    }

    public class SelectionController : ISelectionController
    {
        public ISelectionModel model { get; }

        UnityEvent render;

        public SelectionController(ISelectionModel SelectionModel)
        {
            model = SelectionModel;
        }
        public SelectionController(ISelectionModel SelectionModel, UnityEvent renderEvent)
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