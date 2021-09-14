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


        AssetsLoaderTask thumbnailTask;
        AssetsLoaderTask preloadTask;
        AssetsLoaderTask downloadTask;
        AssetsLoaderTask chainedLoader;
        AssetsLoaderTask completeTask;

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
        public int initialQueues;
        public int completedQueues;

        public void Load(OnCompletedPreloadHandler callback)
        {
            OnCompletePreload = callback;

            downloadTask = new AssetsLoaderDownloadTask(this);
            preloadTask = new AssetsLoaderPreloadTask(this);
            thumbnailTask = new AssetsLoaderThumbnailTask(this);
            completeTask = new AssetsLoaderCompleteTask(this);

            downloadTask.SetSuccessor(preloadTask);
            preloadTask.SetSuccessor(thumbnailTask);
            thumbnailTask.SetSuccessor(completeTask);

            chainedLoader = downloadTask;

            initialQueues = queue.Count;
            completedQueues = 0;

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
        }
    }
}
