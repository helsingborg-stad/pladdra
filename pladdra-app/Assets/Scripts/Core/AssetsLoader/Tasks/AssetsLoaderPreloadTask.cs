using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public class AssetsLoaderPreloadTask : AssetsLoaderTask
    {
        public AssetsLoaderPreloadTask(AssetsLoader context) : base(context)
        { }

        public override void Handler(Core.Types.Asset asset)
        {
            if (asset.meshPath != null)
            {
                PigletImporter.import(App.CachePath + '/' + asset.meshPath, (gameObject) => OnCompleted(gameObject), (System.Exception e) => OnError(e));

                void OnCompleted(GameObject gameObject)
                {
                    if (successor != null)
                        successor.Handler(asset, gameObject);
                }

                void OnError(System.Exception e)
                {
                    if (successor != null)
                        successor.Handler(asset);
                    Debug.Log("PreloadAssetLoader.PigletImporter error: " + e.Message);
                }
            }
        }
    }
}