using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

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

        private IInventoryModel context;
        private IInventoryController controller;

        private AssetModel assetModel;

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
                itemsToRender.ForEach(InstantiateItem);
            }
        }

        private void InstantiateItem(Pladdra.API.Types.Asset asset)
        {
            GameObject newObj = (GameObject)Instantiate(inventoryItemPrefab, inventoryGrid.gameObject.transform);
            AssetGridItem item = newObj.GetComponent<AssetGridItem>();
            item.titleComponent.text = asset.name;
            item.metaComponent.text = asset.id;
            item.buttonComponent.onClick.AddListener(() => onClickItem(asset));
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
