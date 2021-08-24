
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
    public class AR_Idle : View
    {
        public Button mainMenuButton;
        public Button libraryButton;
        public GameObject gameObjectToInstantiate;
        public GameObject spawnedObject;
        public bool objectHasChanged;

        private ARRaycastManager _arRaycastManager;
        public ARTapToPlaceObject _arTapToPlaceObject;
        private Vector2 touchPosition;

        private GltfImportTask _task;

        static List<ARRaycastHit> hits = new List<ARRaycastHit>();

        public override void Initialize()
        {
            ARTapToPlaceObject.isActive = false;
            _arRaycastManager = GetComponent<ARRaycastManager>();
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
            _task = RuntimeGltfImporter.GetImportTask(path, new GltfImportOptions { AutoScaleSize = 0.1f, AutoScale = true, ShowModelAfterImport = false });
            _task.OnCompleted = handleImportAsset;
        }

        private void handleImportAsset(GameObject importedModel)
        {
            _task = null;
            importedModel.SetActive(true);

            if (spawnedObject != null)
            {
                importedModel.transform.position = spawnedObject.transform.position;
                Destroy(spawnedObject);
            }

            spawnedObject = importedModel;
            ARTapToPlaceObject.spawnedObject = spawnedObject;
        }

        private void OnEnable()
        {
            // ARTapToPlaceObject.isActive = true;
            StartCoroutine(EnableTapToPlaceObject());
        }

        IEnumerator EnableTapToPlaceObject()
        {
            yield return new WaitForSecondsRealtime(1);

            if (gameObject.activeSelf)
            {
                ARTapToPlaceObject.isActive = true;
            }
        }


        private void OnDisable()
        {
            ARTapToPlaceObject.isActive = false;
        }

        bool TryGetTouchPosition(out Vector2 touchPosition)
        {
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }

            touchPosition = default;

            return false;
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