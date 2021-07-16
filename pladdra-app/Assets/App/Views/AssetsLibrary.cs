using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;

namespace Pladdra.Views
{
    public delegate void OnSelectEventHandler(Pladdra.API.Types.Asset asset);

    public class AssetsLibrary : View
    {
        public static event OnSelectEventHandler onSelectAsset;
        public Button backButton;

        public GridLayoutGroup assetGrid;

        private List<GameObject> items;

        public GameObject assetItemPrefab;

        private List<Pladdra.API.Types.Asset> itemsToRender;

        public override void Initialize()
        {
            backButton.onClick.AddListener(onClickBackButton);

        }

        private void OnEnable()
        {
            if (itemsToRender == null || itemsToRender.Count == 0)
            {
                items = new List<GameObject>();
                itemsToRender = AssetsManager.GetAssets();
                if (itemsToRender.Count > 0)
                {
                    itemsToRender.ForEach(InstantiateItem);
                }
            }
        }

        private void InstantiateItem(Pladdra.API.Types.Asset asset)
        {
            GameObject newObj = (GameObject)Instantiate(assetItemPrefab, assetGrid.gameObject.transform);
            AssetGridItem item = newObj.GetComponent<AssetGridItem>();
            item.titleComponent.text = asset.name;
            item.metaComponent.text = asset.id;
            item.buttonComponent.onClick.AddListener(() => onClickItem(asset));
            items.Add(newObj);
        }

        protected virtual void onClickItem(Pladdra.API.Types.Asset asset)
        {
            // Debug.Log("onClickItem: " + asset.fileName);
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