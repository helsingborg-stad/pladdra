using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class BuildController
    {
        UnityEvent render;

        public BuildController()
        {
        }

        public BuildController(UnityEvent renderEvent)
        {
            render = renderEvent;
        }
        public void OnClickMenu()
        {
            ViewManager.Show<MenuView>();
        }

        public void OnClickGridButton()
        {
            ViewManager.Show<EditGridView>();
        }
        public void OnClickInventoryButton()
        {
            // ViewManager.Show<InventoryView>();
        }
    }
}