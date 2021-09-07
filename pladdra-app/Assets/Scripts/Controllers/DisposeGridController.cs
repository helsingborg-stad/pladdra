using UnityEngine;
using UnityEngine.Events;
using Pladdra.Core;
using Pladdra.MVC.Views;
using UnityEngine.XR.ARFoundation;

namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Models;
    public class DisposeGridController
    {
        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }

        public DisposeGridModel model { get; }

        UnityEvent render;

        public DisposeGridController(DisposeGridModel DisposeGridModel, UnityEvent renderEvent)
        {
            model = DisposeGridModel;
            render = renderEvent;
        }

        public void OnEnableGameObject()
        {
            model.showMarker = true;
            render.Invoke();
        }

        public void OnCameraRaycast(RaycastHit hit)
        {
            model.raycastHitPosition = hit.point + new Vector3(0, 0.003f, 0);
            render.Invoke();
        }

        public void OnClickMenu()
        {
            ViewManager.Show<MenuView>();
        }
        public void OnClickPlace()
        {
            grid.position = new System.Numerics.Vector3(model.raycastHitPosition.x, model.raycastHitPosition.y, model.raycastHitPosition.z);
            grid.visible = true;

            model.showMarker = false;
            render.Invoke();

            ViewManager.Show<EditGridView>();
        }
    }
}