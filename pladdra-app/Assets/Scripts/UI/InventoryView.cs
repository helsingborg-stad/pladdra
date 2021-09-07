using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;

namespace Pladdra.MVC.Views
{
    public class InventoryView : View
    {
        public delegate void OnSelectEventHandler(Pladdra.API.Types.Asset asset);

        public static event OnSelectEventHandler onSelectAsset;
        public Button backButton;
        public GridLayoutGroup inventoryGrid;
        public GameObject inventoryItemPrefab;
        private List<AssetModel.Asset> itemsToRender;
        private List<GameObject> items;

        private Dictionary<string, Sprite> loadedPreviewCache = new Dictionary<string, Sprite>();

        private InventoryModel context;
        private InventoryController controller;

        private AssetModel assetModel;

        private bool _EXPERIMENTAL = false;

        public override void Initialize()
        {
            context = new InventoryModel();
            controller = new InventoryController(context);

            backButton.onClick.AddListener(controller.OnClickBack);

            App.GetModel<AssetModel>(out var assetModelInstance);
            assetModel = assetModelInstance;
        }

        private void OnEnable()
        {
            if (assetModel != null)
            {
                RenderItems();
            }
        }

        private void RenderItems()
        {
            if (items != null && items.Count > 0)
            {
                items.ForEach(obj =>
                {
                    Destroy(obj);
                });
            }

            items = new List<GameObject>();
            itemsToRender = new List<AssetModel.Asset>();
            itemsToRender = assetModel.List();

            if (itemsToRender.Count > 0)
            {
                itemsToRender.ForEach((item) =>
                {
                    InstantiateItem(item);
                });
            }
        }

        private void InstantiateItem(AssetModel.Asset asset)
        {
            GameObject newObj = (GameObject)Instantiate(inventoryItemPrefab, inventoryGrid.gameObject.transform);
            AssetGridItem item = newObj.GetComponent<AssetGridItem>();
            item.titleComponent.text = asset.name;
            item.metaComponent.text = asset.id;
            item.buttonComponent.onClick.AddListener(() => onClickItem(asset));

            if (!_EXPERIMENTAL)
            {
                items.Add(newObj);
                return;
            }

            if (loadedPreviewCache.ContainsKey(asset.previewTexturePath))
            {
                item.imageComponent.sprite = loadedPreviewCache[asset.previewTexturePath];
            }
            else
            {
                StartCoroutine(RemoteImageUtil.loadRemoteImage("file://" + asset.previewTexturePath, (Texture2D texture) =>
                {
                    Debug.Log("loaded remote item");

                    Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                    item.imageComponent.sprite = sprite;

                    loadedPreviewCache[asset.previewTexturePath] = sprite;
                }));
            }

            items.Add(newObj);
        }

        protected virtual void onClickItem(Pladdra.API.Types.Asset asset)
        {
            OnSelectEventHandler handler = onSelectAsset;

            if (handler != null)
                handler(asset);

            ViewManager.ShowLast();
        }

        private void onClickBackButton()
        {
            ViewManager.ShowLast();
        }
    }
}
