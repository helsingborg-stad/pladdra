
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Piglet;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Pladdra.Views
{
    public class AR_PointCloud : View
    {
        public Button mainMenuButton;
        public Button libraryButton;
        private GameObject spawnedObject;
        private Vector2 touchPosition;
        private GltfImportTask _task;

        public override void Initialize()
        {
            // ARTapToPlaceObject.isActive = false;
            // _arRaycastManager = GetComponent<ARRaycastManager>();
            mainMenuButton.onClick.AddListener(() => ViewManager.Show<MainMenu>());
            libraryButton.onClick.AddListener(() => ViewManager.Show<AssetsLibrary>(true));
            AssetsLibrary.onSelectAsset += handleSelectAsset;
        }

        private void handleSelectAsset(Pladdra.API.Types.Asset asset)
        {
            string path = Path.Combine(App.CachePath, "downloads/" + (asset.id) + '.' + asset.fileFormat.ToString().ToLower());
            if (!System.IO.File.Exists(path))
            {
                Debug.Log("handleSelectAsset: File does not exists at " + path);
                return;
            }

            // Debug.Log(path);
            _task = RuntimeGltfImporter.GetImportTask(path, new GltfImportOptions { AutoScaleSize = 0.1f, AutoScale = true, ShowModelAfterImport = false });
            _task.OnCompleted = handleImportAsset;
        }

        private void handleImportAsset(GameObject importedModel)
        {
            // if (spawnedObject != null)
            // {
            //     importedModel.transform.position = spawnedObject.transform.position;
            //     Destroy(spawnedObject);
            //     importedModel.SetActive(true);
            // }

            // spawnedObject = importedModel;
            // ARTapToPlaceObject.spawnedObject = spawnedObject;
        }

        private void OnEnable()
        {
            // StartCoroutine(EnableTapToPlaceObject());
        }


        private void OnDisable()
        {
            // ARTapToPlaceObject.isActive = false;
        }

        void Update()
        {
            if (_task != null)
            {
                _task.MoveNext();
            }
        }
    }
}