using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface IBuildController
    {
        public IBuildModel model { get; }
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
    }
}