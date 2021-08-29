using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;
using UnityEngine.XR.ARFoundation;

namespace Pladdra.MVC.Controllers
{
    public interface IDisposeGridController
    {
        public IDisposeGridModel model { get; }
        void OnCameraRaycast(RaycastHit hit);
    }

    public class DisposeGridController : IDisposeGridController
    {
        public IDisposeGridModel model { get; }

        UnityEvent render;

        public DisposeGridController(IDisposeGridModel DisposeGridModel, UnityEvent renderEvent)
        {
            model = DisposeGridModel;
            render = renderEvent;
        }

        public void OnCameraRaycast(RaycastHit hit)
        {
            model.raycastHitPosition = hit.point;
            render.Invoke();
        }
    }
}