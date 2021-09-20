using UnityEngine;


namespace Pladdra
{
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;
    public interface IPlannerState
    {
        public PlannerController planner { get; set; }

        public void OnMount();
        public void OnUnmount();
    }
}