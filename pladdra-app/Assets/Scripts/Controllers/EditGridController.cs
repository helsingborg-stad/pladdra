using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IEditGridController
    {
        public IEditGridModel model { get; }
    }

    public class EditGridController : IEditGridController
    {
        public IEditGridModel model { get; }

        UnityEvent render;

        public EditGridController(IEditGridModel EditGridModel)
        {
            model = EditGridModel;
        }
        public EditGridController(IEditGridModel EditGridModel, UnityEvent renderEvent)
        {
            model = EditGridModel;
            render = renderEvent;
        }
    }
}