using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Pladdra.Views
{
    public class Library : View
    {
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
                itemsToRender = AssetsManager.GetAssets();
            }

            if (itemsToRender.Count > 0 && itemsToRender.Count != items.Count)
            {
                itemsToRender.ForEach(InstantiateItem);
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

        private void onClickItem(Pladdra.API.Types.Asset asset)
        {
            Debug.Log(asset);
        }

        private void onClickBackButton()
        {
            ViewManager.ShowLast();
        }
    }
}