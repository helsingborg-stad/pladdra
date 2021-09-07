using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class ExampleController
    {
        public IExampleModel model { get; }

        UnityEvent render;

        public ExampleController(IExampleModel ExampleModel)
        {
            model = ExampleModel;
        }
        public ExampleController(IExampleModel ExampleModel, UnityEvent renderEvent)
        {
            model = ExampleModel;
            render = renderEvent;
        }
    }
}