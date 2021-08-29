using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IBuildController
    {
        public IBuildModel model { get; }

        public void OnClickMenu();
        public void OnClickGridButton();
        public void OnClickInventoryButton();
    }

    public class BuildController : IBuildController
    {
        public IBuildModel model { get; }

        UnityEvent render;

        public BuildController(IBuildModel BuildModel)
        {
            model = BuildModel;
        }
        public BuildController(IBuildModel BuildModel, UnityEvent renderEvent)
        {
            model = BuildModel;
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
            ViewManager.Show<InventoryView>();
        }
    }
}