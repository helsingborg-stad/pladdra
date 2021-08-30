using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IAppLoadingController
    {
        public IAppLoadingModel model { get; }
    }

    public class AppLoadingController : IAppLoadingController
    {
        public IAppLoadingModel model { get; }

        UnityEvent render;

        public AppLoadingController(IAppLoadingModel AppLoadingModel)
        {
            model = AppLoadingModel;
        }
        public AppLoadingController(IAppLoadingModel AppLoadingModel, UnityEvent renderEvent)
        {
            model = AppLoadingModel;
            render = renderEvent;
        }
    }
}