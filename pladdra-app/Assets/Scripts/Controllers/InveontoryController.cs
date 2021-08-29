using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IInventoryController
    {
        public IInventoryModel model { get; }
    }

    public class InventoryController : IInventoryController
    {
        public IInventoryModel model { get; }

        UnityEvent render;

        public InventoryController(IInventoryModel InventoryModel)
        {
            model = InventoryModel;
        }
        public InventoryController(IInventoryModel InventoryModel, UnityEvent renderEvent)
        {
            model = InventoryModel;
            render = renderEvent;
        }
    }
}