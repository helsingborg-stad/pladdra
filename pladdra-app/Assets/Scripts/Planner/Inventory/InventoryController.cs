using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class InventoryController
    {
        public InventoryModel model { get; }

        UnityEvent render;

        public InventoryController(InventoryModel InventoryModel)
        {
            model = InventoryModel;
        }
        public InventoryController(InventoryModel InventoryModel, UnityEvent renderEvent)
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