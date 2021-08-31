using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Pladdra.API;
using Pladdra.MVC.Models;
using System.Linq;

using Pladdra.Core;
namespace Pladdra
{
    [RequireComponent(typeof(Auth))]
    [RequireComponent(typeof(S3))]
    [RequireComponent(typeof(GraphQLClient))]
    [RequireComponent(typeof(ViewManager))]
    public class App : MonoBehaviour
    {
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
            Views();
        }

        private void Models()
        {
            // Init your global models here
            IModel[] instances = {
                new AssetModel(),
                new WorkspaceModel(),
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