using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GraphQL.Client.Http;

namespace Pladdra
{
    public class Assets : MonoBehaviour
    {
        public List<Pladdra.API.Types.Asset> diffAssets;
        public List<Pladdra.API.Types.Asset> localAssets;
        public List<Pladdra.API.Types.Asset> remoteAssets;
        public List<Pladdra.API.Types.Asset> assetsToDownload;
        public List<Pladdra.API.Types.Asset> resolvedAssets;
        public List<Pladdra.API.Types.Asset> rejectedAssets;

        public string appSyncApiUrl;
        public string appSyncApiKey;
        public string appSyncApiID;

        private App _app;
        private S3 _S3;

        private GraphQLHttpClient _client;

        protected static string assetsJson = "assets.json";

        public void SyncAssets()
        {
            GetRemoteAssets().ContinueWith(response =>
            {
                try
                {
                    var items = response.Result;
                    if (items.Count > 0)
                    {
                        remoteAssets = items;
                    }

                    AssetsCache assetsCache = new AssetsCache();
                    SaveDataManager.LoadJsonData(assetsCache, true);
                    diffAssets = remoteAssets.Where(asset => (assetsCache.items.Count == 0
                    || (assetsCache.items.Where(item => item.id == asset.id).ToList().Count == 0))).ToList();
                    if (diffAssets.Count > 0)
                    {
                        foreach (Pladdra.API.Types.Asset newAsset in diffAssets)
                        {
                            Task streamTask = _S3.SaveObjectToFile("downloads/" + newAsset.id + "." + newAsset.fileFormat.ToString().ToLower(), "public/" + newAsset.file.key, newAsset.file.bucket).ContinueWith(ctx =>
                            {
                                assetsCache.items.Add(newAsset);
                            });
                            streamTask.Wait();
                        }
                        SaveDataManager.SaveJsonData(assetsCache);
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Exception!!");
                    Debug.Log(e);
                }
            });
        }

        public async Task<List<Pladdra.API.Types.Asset>> GetRemoteAssets()
        {
            var response = await _client.SendQueryAsync<Pladdra.API.Types.Query>(Pladdra.API.ListAssetsGQL.Request());
            return response.Data.listAssets.items;
        }

        private void Awake()
        {
            _app = GetComponent<App>();
            _S3 = GetComponent<S3>();
            appSyncApiUrl = _app.appSyncApiUrl;
            appSyncApiKey = _app.appSyncApiKey;
            appSyncApiID = _app.appSyncApiID;

            var clientBuilder = new Pladdra.API.GraphQLClient();
            _client = clientBuilder.Connect(appSyncApiUrl, appSyncApiKey);
        }
    }
}