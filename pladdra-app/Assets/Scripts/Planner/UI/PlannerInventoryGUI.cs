using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Pladdra.MVC.Views
{
    using Pladdra.MVC.Models;
    using Pladdra.MVC.Controllers;
    using Pladdra.Components;
    public class PlannerInventoryGUI : View
    {
        public event OnClickGridItemEventHandler OnClickGridItem;

        public Button backButton;
        public GridLayoutGroup inventoryGrid;
        public GameObject inventoryItemPrefab;
        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        private List<Pladdra.Core.Types.Asset> itemsToRender;
        private List<GameObject> items;

        private Dictionary<string, Sprite> loadedPreviewCache = new Dictionary<string, Sprite>();

        public Sprite placeholderIcon;

        private bool _EXPERIMENTAL = true;

        public override void Initialize()
        {

        }

        public override void Show()
        {
            base.Show();

            RenderItems();
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
            itemsToRender = new List<Pladdra.Core.Types.Asset>();
            itemsToRender = context.assets.List();

            if (itemsToRender.Count > 0)
            {
                itemsToRender.ForEach((item) =>
                {
                    InstantiateItem(item);
                });
            }
        }

        private void InstantiateItem(Pladdra.Core.Types.Asset asset)
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

            if (asset.previewTexturePath == null)
            {
                item.imageComponent.sprite = placeholderIcon;
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
                    if (texture == null)
                    {
                        item.imageComponent.sprite = placeholderIcon;
                        loadedPreviewCache[asset.previewTexturePath] = placeholderIcon;
                    }
                    else
                    {

                        Debug.Log("loaded remote item");

                        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                        item.imageComponent.sprite = sprite;

                        loadedPreviewCache[asset.previewTexturePath] = sprite;
                    }
                }));
            }

            items.Add(newObj);
        }

        protected void onClickItem(Pladdra.Core.Types.Asset asset)
        {
            if (OnClickGridItem != null)
                OnClickGridItem(asset);
        }

        public delegate void OnClickGridItemEventHandler(Pladdra.Core.Types.Asset asset);
    }
}
