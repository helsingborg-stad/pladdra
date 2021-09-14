using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public abstract class AssetsLoaderTask
    {
        protected string downloadPath = "downloads/";
        protected AssetsLoader context;
        protected AssetsLoaderTask successor;
        public void SetSuccessor(AssetsLoaderTask successor)
        {
            this.successor = successor;
        }
        public virtual void Handler(Core.Types.Asset asset) { }
        public virtual void Handler(Core.Types.Asset asset, GameObject gameObject) { }

        protected AssetsLoaderTask(AssetsLoader context)
        {
            this.context = context;
        }
    }
}