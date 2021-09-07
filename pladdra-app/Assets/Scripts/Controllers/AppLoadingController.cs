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


namespace Pladdra.MVC.Controllers
{
    public class AppLoadingController
    {
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
            LoadAssets();
            LoadWorkspaces();
        }

        public void LoadAssets()
        {
            App.GetModel<AssetModel>(out AssetModel assetsModel);
            var items = assetsModel.items;
            var fetchTask = GraphQLClient.SendQueryAsync<Pladdra.API.Types.Query>(Pladdra.API.ListAssetsGQL.Request()).ContinueWith(response =>
            {
                try
                {
                    List<API.Types.Asset> remoteItems = response.Result.Data.listAssets.items;
                    if (remoteItems.Count > 0)
                    {
                        remoteItems.ForEach(item =>
                        {
                            if (!assetsModel.Exists(item.id))
                            {
                                assetsModel.Create(item);
                            }
                            else
                            {
                                assetsModel.Update(item);
                            }
                        });
                    }

                    model.assetsLoaded = true;
                    render.Invoke();
                }
                catch (Exception e)
                {
                    Debug.Log("InitializeApplication: Failed import FetchAssets");
                    Debug.Log(e);
                }
            });
        }

        public void LoadWorkspaces()
        {
            // SetLoadingText("Laddar in arbetsytor..");
            model.workspaceLoaded = true;
        }

        public void OnComplete()
        {
            ViewManager.Show<MenuView>();
        }

        public void OnLoaded()
        {
            // ViewManager.Show<MenuView>();
        }

        public void SetLoadingText(string text)
        {
            model.loadingText = text;
            render.Invoke();
        }
    }
}