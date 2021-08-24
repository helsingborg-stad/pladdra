using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using Pladdra.API;

namespace Pladdra
{
    [RequireComponent(typeof(AssetsManager))]
    [RequireComponent(typeof(Auth))]
    [RequireComponent(typeof(S3))]
    [RequireComponent(typeof(GraphQLClient))]
    [RequireComponent(typeof(ViewManager))]
    public class App : MonoBehaviour
    {
        public static string CachePath;

        void Awake()
        {
            CachePath = Application.persistentDataPath;
            Application.targetFrameRate = 30;
        }
    }
}