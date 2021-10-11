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
            string fileName = asset.id + ".png";
            string path = Path.Combine(downloadPath, fileName);
            string fullPath = Path.Combine(Pladdra.App.CachePath, path);
            bool pathIsNullButFileExists = asset.previewTexturePath == null && File.Exists(path);
            asset.previewTexturePath = pathIsNullButFileExists ? path : asset.previewTexturePath;
            asset.previewTexturePath = asset.previewTexturePath != null && asset.previewTexturePath != path ? null : asset.previewTexturePath;

            if (asset.previewTexturePath == null || !File.Exists(fullPath))
            {
                RuntimePreviewGenerator.MarkTextureNonReadable = false;
                RuntimePreviewGenerator.BackgroundColor = Color.white;
                Texture2D thumbnail = RuntimePreviewGenerator.GenerateModelPreview(gameObject.transform, 160, 160);
                byte[] pngBytes = thumbnail.EncodeToPNG();
                FileManager.WriteToFile(fullPath, pngBytes);
                asset.previewTexturePath = path;

                context.assets.Update(asset);
            }

            if (pathIsNullButFileExists)
            {
                context.assets.Update(asset);
            }

            if (successor != null)
                successor.Handler(asset);
        }
    }
}