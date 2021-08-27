using UnityEngine;


namespace Pladdra.MVC.Models
{
    public interface IPlannerModel
    {
        public Vector3 raycastHitPosition { get; set; }
    }

    public class PlannerModel : IPlannerModel
    {
        public Vector3 raycastHitPosition { get; set; }
    }
}
