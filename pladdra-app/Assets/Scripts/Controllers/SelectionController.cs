using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ISelectionController
    {
        public ISelectionModel model { get; }
    }

    public class SelectionController : ISelectionController
    {
        public ISelectionModel model { get; }

        UnityEvent render;

        public SelectionController(ISelectionModel SelectionModel)
        {
            model = SelectionModel;
        }
        public SelectionController(ISelectionModel SelectionModel, UnityEvent renderEvent)
        {
            model = SelectionModel;
            render = renderEvent;
        }
    }
}