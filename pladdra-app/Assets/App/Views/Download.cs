using System.Collections;
using UnityEngine;
using TMPro;
using System;
using GraphQL.Client.Http;

namespace Pladdra.Views
{
    public class Download : View
    {
        public TMP_Text titleText;
        public TMP_Text statusText;
        public string statusTextContent;
        public bool statusTextHasChanged;

        private GraphQLHttpClient _client;

        private AssetsCache _assetsCache;
        private static int itemsToDownloadCount;
        private static bool isFetching;
        private static bool hasError;

        private static bool hasFetched;
        private static bool isDownloading;
        private static bool hasDownloaded;
        private static bool isDisabled;

        private void Awake()
        {
            _assetsCache = new AssetsCache();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            SyncronizeAssets();
        }

        private void SyncronizeAssets()
        {
            titleText.text = "Please wait";
            statusText.text = "Fetching remote objects...";
            isFetching = true;
            isDisabled = false;

            AssetsManager.FetchRemote().ContinueWith(response =>
            {
                try
                {
                    itemsToDownloadCount = response.Result;


                    if (itemsToDownloadCount > 0)
                    {
                        SetStatusText("Downloading remote objects...");
                        AssetsManager.SyncRemote().ContinueWith(response =>
                        {
                            Debug.Log("CONTINUE WITH (DOWNLOAD)");
                            hasDownloaded = true;
                        });
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Pladdra.Download.SyncronizeAssets: Failed to Syncronize Assets");
                    Debug.Log(e);
                    hasError = true;
                }

                isFetching = false;
            });
        }

        private void SetStatusText(string content)
        {
            statusTextContent = content;
            statusTextHasChanged = true;
        }

        IEnumerator ReturnToMainMenu(string statusTextContent, bool hasError = false)
        {
            isDisabled = true;
            hasDownloaded = false;
            titleText.text = hasError ? "Error" : "Done!";
            statusText.text = statusTextContent;
            yield return new WaitForSecondsRealtime(1);

            ViewManager.Show<MainMenu>();
        }

        private void Update()
        {
            if (isDisabled)
            {
                return;
            }

            if (statusTextHasChanged)
            {
                Debug.Log("STATUS TEXT CHANGES");
                statusTextHasChanged = false;
                statusText.text = statusTextContent;
            }

            if (!isFetching && !hasError)
            {
                if (itemsToDownloadCount > 0 && hasDownloaded)
                {
                    StartCoroutine(ReturnToMainMenu("Sucessfully downloaded."));
                }
                else
                {
                    StartCoroutine(ReturnToMainMenu("Everything is up to date."));
                }
            }

            if (hasError)
            {
                hasError = false;
                StartCoroutine(ReturnToMainMenu("Failed to download assets..", true));
            }
        }

        public override void Initialize()
        {

        }
    }
}
