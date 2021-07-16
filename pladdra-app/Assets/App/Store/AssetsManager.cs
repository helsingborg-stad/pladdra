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

        private void Start()
        {
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
            s_instance.diffAssets = s_instance.remoteAssets.Where(asset => (s_instance.items.Count == 0
                               || (s_instance.items.Where(item => item.id == asset.id).ToList().Count == 0))).ToList();


            return s_instance.diffAssets.Count;
        }

        public static Task<bool> SyncRemote()
        {
            foreach (Pladdra.API.Types.Asset newAsset in s_instance.diffAssets)
            {
                // Debug.Log("SyncRemote : " + newAsset.id);
                Task streamTask = S3.SaveObjectToFile("downloads/" + newAsset.id + "." + newAsset.fileFormat.ToString().ToLower(), "public/" + newAsset.file.key, newAsset.file.bucket).ContinueWith(ctx =>
                {
                    _assetsCache.items.Add(newAsset);
                    SaveDataManager.SaveJsonData(_assetsCache);
                });
                streamTask.Wait();
            }
            return Task.FromResult(true);
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