using System;
using System.Net.Http;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
// using System.Reflection;
using System.Threading.Tasks;
using System.IO;

using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Newtonsoft.Json;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pladdra.API;


using GraphQL.Types;
using GraphQL.SystemTextJson;

namespace Pladdra
{
    public class Debug_AssetsCache : View
    {
        public TMP_Text debugText;
        public TMP_Text errorText;

        private string debugOutput;
        private bool isError;
        private bool debugOutputHasChanged;

        public override void Initialize() { }

        public override void Show()
        {
            gameObject.SetActive(true);
            debugText.text = "";
            errorText.text = "";
            debugOutput = "";

            try
            {
                List<Pladdra.API.Types.Asset> items = AssetsManager.GetAssets();
                if (items != null)
                {
                    debugOutput = "Total Items: " + items.Count + "\n Items output: \n" + JsonConvert.SerializeObject(items);
                    isError = false;
                }
                else
                {
                    throw new Exception("No items :(");
                }
            }
            catch (Exception e)
            {
                debugOutput = e.Message;
                isError = true;
            }
            debugOutputHasChanged = true;
        }

        IEnumerator ReturnToMainMenu(string statusTextContent, bool hasError = false)
        {
            debugText.text = !hasError ? statusTextContent : "";
            errorText.text = hasError ? statusTextContent : "";
            yield return new WaitForSecondsRealtime(10);

            debugText.text = "";
            errorText.text = "";
            ViewManager.ShowLast();
        }


        private void Update()
        {
            if (debugOutputHasChanged)
            {
                debugOutputHasChanged = false;
                StartCoroutine(ReturnToMainMenu(debugOutput, isError));
            }
        }
    }
}