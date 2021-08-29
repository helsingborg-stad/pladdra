using UnityEngine;


namespace Pladdra.MVC.Models
{
    public interface IDisposeGridModel
    {
        public Vector3 raycastHitPosition { get; set; }
    }

    public class DisposeGridModel : IDisposeGridModel
    {
        public Vector3 raycastHitPosition { get; set; }
    }
}
