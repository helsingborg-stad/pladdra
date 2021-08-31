using UnityEngine;


namespace Pladdra.MVC.Models
{
    public interface IAppLoadingModel
    {
        bool assetsLoaded {get; set;}
        bool workspaceLoaded {get; set;}
        string loadingText {get; set;}
    }

    public class AppLoadingModel : IAppLoadingModel
    {
        public bool assetsLoaded {get; set;}
        public bool workspaceLoaded {get; set;}
        public string loadingText {get; set;}
    }
}
