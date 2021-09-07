using UnityEngine;


namespace Pladdra.MVC.Models
{
    public class AppLoadingModel
    {
        public bool assetsLoaded { get; set; }
        public bool workspaceLoaded { get; set; }
        public string loadingText { get; set; }
    }
}
