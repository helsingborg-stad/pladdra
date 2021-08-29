using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IInventoryController
    {
        public void OnClickBack();
        public void OnClickItem();
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

        public void OnClickBack()
        {
            ViewManager.Show<BuildView>();
        }
        public void OnClickItem()
        {
            ViewManager.Show<SelectionView>();
        }
    }
}