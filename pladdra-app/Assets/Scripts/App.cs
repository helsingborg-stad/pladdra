using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

using System.Linq;


using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


namespace Pladdra
{
    using Pladdra.API;
    using Pladdra.Core;
    using Pladdra.MVC.Controllers;
    using Pladdra.MVC.Models;
    [RequireComponent(typeof(Auth))]
    [RequireComponent(typeof(S3))]
    [RequireComponent(typeof(GraphQLClient))]
    [RequireComponent(typeof(ViewManager))]
    [RequireComponent(typeof(Components.PigletImporter))]
    public class App : MonoBehaviour
    {

        public static ARRaycastManager _AARRaycastManager;

        public static string CachePath;
        private List<IModel> models;
        private static App _instance;
        public static bool GetModel<T>(out T model) where T : class, IModel
        {
            model = null;

            for (int i = 0; i < _instance.models.Count; i++)
            {
                if (_instance.models[i] is T)
                {
                    model = (T)_instance.models[i];
                    return true;
                }
            }

            return false;
        }

        void Awake()
        {
            _instance = this;
            CachePath = Application.persistentDataPath;
            Application.targetFrameRate = 30;
            models = new List<IModel>();
        }

        void Start()
        {
            Models();
            Controllers();
            Views();
        }

        private void Controllers()
        {
            object[] instances = {
                new ARController(),
                new PlannerController(),
            };
        }

        private void Models()
        {
            // Init your global models here
            IModel[] instances = {
                new AssetModel(),
                new WorkspaceListModel(),
                new ARModel(),
                new PlannerModel(),
                new Grid(),
            };

            for (int i = 0; i < instances.Length; i++)
            {
                // Do stuff with models after init
                PopulateJsonModelData(instances[i]);
            }

            models.AddRange(instances);
        }

        private void PopulateJsonModelData(IModel model)
        {
            if (model is ISaveable)
                SaveDataManager.LoadJsonData((ISaveable)model, true);
        }

        private void Views()
        {
            ViewManager.Init();
        }
    }
}