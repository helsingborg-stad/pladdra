using UnityEngine;
using UnityEngine.Events;

using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Models;

    public class EditGridController
    {
        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }

        public EditGridModel model { get; }

        UnityEvent render;

        public EditGridController()
        {
        }

        public EditGridController(EditGridModel EditGridModel)
        {
            model = EditGridModel;
        }
        public EditGridController(EditGridModel EditGridModel, UnityEvent renderEvent)
        {
            model = EditGridModel;
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
            grid.visible = false;
            ViewManager.Show<DisposeGridView>();
        }

        public void OnGridChanged(float twistDegree)
        {

        }
        public void OnTwistGesture(float twistDegree)
        {

        }
    }
}