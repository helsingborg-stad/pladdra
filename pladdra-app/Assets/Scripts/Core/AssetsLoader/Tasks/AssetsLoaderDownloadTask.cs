using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public class AssetsLoaderDownloadTask : AssetsLoaderTask
    {
        public AssetsLoaderDownloadTask(AssetsLoader context) : base(context)
        { }

        public override void Handler(Core.Types.Asset asset)
        {
            string fileName = asset.id + "." + asset.fileFormat.ToString().ToLower();
            string path = Path.Combine(downloadPath, fileName);
            string fullPath = Path.Combine(Pladdra.App.CachePath, path);
            bool pathIsNullButFileExists = asset.meshPath == null && File.Exists(path);
            asset.meshPath = pathIsNullButFileExists ? path : asset.meshPath;

            if (asset.meshPath == null || !File.Exists(fullPath))
            {
                string bucketKey = "public/" + asset.file.key;
                Task streamTask = S3.SaveObjectToFile(path, bucketKey, asset.file.bucket);
                streamTask.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
                {
                    asset.meshPath = path;
                    context.assets.Update(asset);
                    if (successor != null)
                        successor.Handler(asset);

                    this.context.Next();
                });
                return;
            }

            if (pathIsNullButFileExists)
            {
                context.assets.Update(asset);
            }

            if (successor != null)
                successor.Handler(asset);

            this.context.Next();
        }
    }
}