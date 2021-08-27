using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;
using UnityEngine.XR.ARFoundation;

namespace Pladdra.MVC.Controllers
{
    public interface IPlannerController
    {
        public IPlannerModel model { get; }
        void OnCameraRaycast(RaycastHit hit);
    }

    public class PlannerController : IPlannerController
    {
        public IPlannerModel model { get; }

        UnityEvent render;

        public PlannerController(IPlannerModel PlannerModel, UnityEvent renderEvent)
        {
            model = PlannerModel;
            render = renderEvent;
        }

        public void OnCameraRaycast(RaycastHit hit)
        {
            model.raycastHitPosition = hit.point;
            render.Invoke();
        }
    }
}