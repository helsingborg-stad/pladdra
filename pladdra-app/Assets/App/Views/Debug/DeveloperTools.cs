using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Pladdra.Views
{
    public class DeveloperTools : View
    {
        public Button pointCloudButton;
        public Button assetsCacheButton;
        public Button clearCacheButton;
        public Button backButton;

        public override void Initialize()
        {
            backButton.onClick.AddListener(() => ViewManager.Show<MainMenu>());
            assetsCacheButton.onClick.AddListener(() => ViewManager.Show<Debug_AssetsCache>(true));
            pointCloudButton.onClick.AddListener(() => ViewManager.Show<AR_PointCloud>(true));
            clearCacheButton.onClick.AddListener(() => AssetsManager.clearCache());
        }
    }
}