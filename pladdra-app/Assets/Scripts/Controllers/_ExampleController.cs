using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IExampleController
    {
        public IExampleModel model { get; }
    }

    public class ExampleController : IExampleController
    {
        public IExampleModel model { get; }

        UnityEvent render;

        public ExampleController(IExampleModel ExampleModel, UnityEvent renderEvent)
        {
            model = ExampleModel;
            render = renderEvent;
        }
    }
}