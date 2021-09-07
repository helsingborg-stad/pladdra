using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Pladdra.API;

namespace Pladdra
{
    public class AssetsManager : MonoBehaviour
    {
        private static AssetsManager s_instance;

        public List<Pladdra.API.Types.Asset> items
        {
            get
            {
                if (_assetsCache == null)
                {
                    return new List<Pladdra.API.Types.Asset>();
                }
                //test comment
                return _assetsCache.items;
            }
        }

        public List<Pladdra.API.Types.Asset> remoteAssets;

        public List<Pladdra.API.Types.Asset> diffAssets;

        private static AssetsCache _assetsCache;

        private static string downloadPath;

        private void Start()
        {
            downloadPath = "downloads/";
            _assetsCache = new AssetsCache();
            SaveDataManager.LoadJsonData(_assetsCache, true);
        }

        public static void clearCache()
        {
            string assetsJson = Path.Combine(Pladdra.App.CachePath, "assets.json");
            string downloadsDir = Path.Combine(Pladdra.App.CachePath, "downloads");

            if (File.Exists(assetsJson)) { File.Delete(assetsJson); }
            _assetsCache = new AssetsCache();
            SaveDataManager.LoadJsonData(_assetsCache, true);

            if (Directory.Exists(downloadsDir)) { Directory.Delete(downloadsDir, true); }
            Directory.CreateDirectory(downloadsDir);
        }

        public async static Task<int> FetchRemote()
        {
            var response = await GraphQLClient.SendQueryAsync<Pladdra.API.Types.Query>(Pladdra.API.ListAssetsGQL.Request());

            s_instance.remoteAssets = response.Data.listAssets.items;
            s_instance.diffAssets = s_instance.remoteAssets.Where(asset => !AsssetFileExists(asset)).ToList();

            return s_instance.diffAssets.Count;
        }

        public static Task<bool> SyncRemote()
        {
            _assetsCache.items = s_instance.remoteAssets;
            SaveDataManager.SaveJsonData(_assetsCache);

            if (s_instance.diffAssets.Count > 0)
            {
                s_instance.diffAssets.ForEach(DownloadAsset);
            }
            return Task.FromResult(true);
        }

        private static bool AsssetFileExists(Pladdra.API.Types.Asset asset)
        {
            string fileName = asset.id + "." + asset.fileFormat.ToString().ToLower();
            string path = Path.Combine(App.CachePath, downloadPath, fileName);
            return File.Exists(path);
        }

        private static void DownloadAsset(Pladdra.API.Types.Asset asset)
        {
            string fileName = asset.id + "." + asset.fileFormat.ToString().ToLower();
            string path = Path.Combine(downloadPath, fileName);
            string bucketKey = "public/" + asset.file.key;

            Task streamTask = S3.SaveObjectToFile(path, bucketKey, asset.file.bucket).ContinueWith(ctx =>
            {
                // _assetsCache.items.Add(asset);
                // SaveDataManager.SaveJsonData(_assetsCache);
            });
            streamTask.Wait();
            Task.FromResult(true);
        }

        public static List<Pladdra.API.Types.Asset> GetAssets()
        {
            return s_instance.items;
        }

        public static void GetAsset(string ID)
        { }
        private void Awake() => s_instance = this;
    }
}