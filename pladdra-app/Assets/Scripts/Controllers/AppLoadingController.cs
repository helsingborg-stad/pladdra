using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

using UnityEngine;
using UnityEngine.Events;

using Newtonsoft.Json;

using Pladdra;
using Pladdra.API;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;
using Pladdra.Core;

namespace Pladdra.MVC.Controllers
{
    public class AppLoadingController
    {

        public AssetModel assets
        {
            get
            {
                App.GetModel<AssetModel>(out var instance);
                return instance;
            }
        }

        public AppLoadingModel model { get; }

        UnityEvent render;

        public AppLoadingController(AppLoadingModel AppLoadingModel)
        {
            model = AppLoadingModel;
        }

        public AppLoadingController(AppLoadingModel AppLoadingModel, UnityEvent renderEvent)
        {
            model = AppLoadingModel;
            render = renderEvent;
        }

        public void InitializeApplication()
        {
            SetLoadingText("Laddar in objekt och arbetsytor ..");
            TryFetchAssetsAndLoad();
        }


        public void LoadAssets()
        {
            var assetsLoader = new AssetsLoader();
            foreach (var asset in assets.List())
            {
                assetsLoader.Enqueue(asset);
            }

            assetsLoader.Load(OnComplete);
        }

        public void TryFetchAssetsAndLoad()
        {
            var refreshTokenTask = Auth.RefreshSession();
            refreshTokenTask.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
            {
                bool successfulRefresh = refreshTokenTask.Result;
                if (successfulRefresh)
                {
                    var fetchTask = GraphQLClient.SendQueryAsync<Pladdra.API.Types.Query>(Pladdra.API.ListAssetsGQL.Request());
                    fetchTask.ConfigureAwait(true).GetAwaiter().OnCompleted(() =>
                    {
                        if (fetchTask.Result.Data.listAssets.items.Count > 0)
                        {
                            foreach (var item in fetchTask.Result.Data.listAssets.items)
                            {
                                if (!assets.Exists(item.id))
                                {
                                    assets.Create(item);
                                }
                                else
                                {
                                    assets.Update(item);

                                }

                            }
                            LoadAssets();
                        }
                    });
                }
                else
                {
                    LoadAssets();
                }
            });
        }

        public void OnComplete()
        {
            ViewManager.Show<MenuView>();
        }

        public void SetLoadingText(string text)
        {
            model.loadingText = text;
            render.Invoke();
        }
    }
}