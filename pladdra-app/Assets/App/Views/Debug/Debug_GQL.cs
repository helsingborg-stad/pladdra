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
    public class Debug_GQL : View
    {
        public TMP_Text debugText;
        public TMP_Text errorText;


        public string debugOutput;
        public bool isError;
        public bool debugOutputHasChanged;

        public override void Initialize() { }

        public override void Show()
        {
            gameObject.SetActive(true);
            debugText.text = "";
            errorText.text = "";
            debugOutput = "";
            TestStringQuery().ContinueWith((response) =>
            {
                try
                {

                    var result = response.Result;
                    if (result.Data != null)
                    {
                        var data = response.Result.Data;
                        debugOutput = data.ToString();
                        isError = false;
                    }
                    else
                    {
                        debugOutput = JsonConvert.SerializeObject(result);
                        isError = true;
                    }

                    // Debug.Log("CONTINUED!!!");
                    // Debug.Log(JsonUtility.ToJson(data));
                    // Debug.Log(data.ToString());
                    // Debug.Log(JsonConvert.SerializeObject(data));
                    // Debug.Log("CONTINUED!!!");


                }
                catch (Exception e)
                {
                    if (e.InnerException is GraphQL.Client.Http.GraphQLHttpRequestException)
                    {
                        var err = (GraphQL.Client.Http.GraphQLHttpRequestException)e.InnerException;
                        debugOutput = err.Message + " " + err.Content;
                    }
                    else
                    {
                        debugOutput = e.InnerException.Message;
                    }

                    // debugOutput = e.ToString();
                    isError = true;
                }

                debugOutputHasChanged = true;
            });
        }


        private async Task<GraphQLResponse<object>> TestStringQuery()
        {
            var Query = @"
                query {
                    listAssets {
                        items {
                        file {
                            key
                            bucket
                            region
                        }
                        name
                        fileName
                        fileSize
                        id
                        }
                    }
                }
            ";


            var response = await GraphQLClient.Request<object>(Query);
            return response;
        }

        private void TestArrQuery()
        {

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