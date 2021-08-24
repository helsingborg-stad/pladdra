using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IPlannerController
    {
        public IPlannerModel model { get; }
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
    }
}