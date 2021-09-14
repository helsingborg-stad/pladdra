using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public class AssetsLoader
    {
        private Pladdra.Core.Types.Asset current;

        AssetsLoaderTask chainedLoader;

        public AssetModel assets
        {
            get
            {
                App.GetModel<AssetModel>(out var instance);
                return instance;
            }
        }
        public OnCompletedPreloadHandler OnCompletePreload;
        public delegate void OnCompletedPreloadHandler();
        private Queue<Pladdra.Core.Types.Asset> queue = new Queue<Pladdra.Core.Types.Asset>();

        public void Load(OnCompletedPreloadHandler callback)
        {
            OnCompletePreload = callback;
            AssetsLoaderTask downloadTask = new AssetsLoaderDownloadTask(this);
            AssetsLoaderTask preloadTask = new AssetsLoaderPreloadTask(this);
            AssetsLoaderTask thumbnailTask = new AssetsLoaderThumbnailTask(this);

            downloadTask.SetSuccessor(preloadTask);
            preloadTask.SetSuccessor(thumbnailTask);

            chainedLoader = downloadTask;

            ProcessQueue();
        }

        public void Enqueue(Pladdra.Core.Types.Asset asset)
        {
            queue.Enqueue(asset);
        }

        private void ProcessQueue()
        {
            Next();
        }

        public void Next()
        {
            if (queue.Count > 0)
            {
                chainedLoader.Handler(queue.Dequeue());
            }

            if (OnCompletePreload != null)
                OnCompletePreload();
        }
    }




}
