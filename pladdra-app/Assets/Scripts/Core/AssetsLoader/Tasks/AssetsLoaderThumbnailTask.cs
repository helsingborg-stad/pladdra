using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

namespace Pladdra.Core
{
    using Pladdra.Components;
    using Pladdra.MVC.Models;

    public class AssetsLoaderThumbnailTask : AssetsLoaderTask
    {
        public AssetsLoaderThumbnailTask(AssetsLoader context) : base(context)
        { }
        public override void Handler(Core.Types.Asset asset)
        {
            if (successor != null)
                successor.Handler(asset);
        }
        public override void Handler(Core.Types.Asset asset, GameObject gameObject)
        {
            Debug.Log("Thumbnail!");
            Debug.Log(successor);
            string fullMeshPath = Path.Combine(Pladdra.App.CachePath, asset.meshPath);

            string fileName = asset.id + ".png";
            string assetPath = Path.Combine(downloadPath, fileName);
            string fullPreviewPath = Path.Combine(Pladdra.App.CachePath, assetPath);

            asset.previewTexturePath = File.Exists(assetPath) && asset.meshPath == null ? assetPath : asset.previewTexturePath;
            if (asset.previewTexturePath == null || !File.Exists(fullPreviewPath))
            {
                RuntimePreviewGenerator.MarkTextureNonReadable = false;
                Texture2D thumbnail = RuntimePreviewGenerator.GenerateModelPreview(gameObject.transform);
                byte[] pngBytes = thumbnail.EncodeToPNG();
                FileManager.WriteToFile(fullPreviewPath, pngBytes);
                asset.previewTexturePath = fullPreviewPath;

                context.assets.Update(asset);
            }

            if (successor != null)
                successor.Handler(asset);
        }
    }
}