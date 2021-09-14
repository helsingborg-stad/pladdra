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
        public GridLayoutGroup categoryGrid;
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

        private List<GameObject> categoryItems;
        private Dictionary<string, Sprite> loadedPreviewCache = new Dictionary<string, Sprite>();

        public Sprite placeholderIcon;

        private bool _EXPERIMENTAL = true;

        [SerializeField]
        public List<InventoryModel.InventoryCategory> categories;
        public List<InventoryModel.InventoryCategory> categoryItemsToRender;

        public override void Initialize()
        {

        }

        public override void Show()
        {
            base.Show();

            RenderItems();
            RenderCategories();
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

        private void RenderCategories()
        {
            if (categoryItems != null && categoryItems.Count > 0)
            {
                categoryItems.ForEach(obj => Destroy(obj));
            }

            categoryItems = new List<GameObject>();
            categoryItemsToRender = new List<InventoryModel.InventoryCategory>();
            categoryItemsToRender = categories;

            if (categoryItemsToRender.Count > 0)
            {
                categoryItemsToRender.ForEach((item) =>
                {
                    InstantiateCategoryItem(item);
                });
            }
        }


        private void InstantiateCategoryItem(InventoryModel.InventoryCategory category)
        {
            GameObject newObj = (GameObject)Instantiate(inventoryItemPrefab, categoryGrid.gameObject.transform);
            AssetGridItem item = newObj.GetComponent<AssetGridItem>();
            item.titleComponent.text = category.name;
            item.metaComponent.text = category.name;
            item.buttonComponent.onClick.AddListener(() => Debug.Log("Clicked category: " + category.name));

            categoryItems.Add(newObj);
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
