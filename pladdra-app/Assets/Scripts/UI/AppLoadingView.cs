using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;

namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(WithReRender))]
    public class AppLoadingView : View
    {
        private AppLoadingModel context;
        private AppLoadingController controller;
        private bool hasInitialized;
        public TMP_Text loadingText;

        public override void Initialize()
        {
            WithReRender render = GetComponent<WithReRender>();
            render.OnRender += SetLoadingText;
            render.OnRender += HandleComplete;

            context = new AppLoadingModel();
            controller = new AppLoadingController(context, render.renderEvent);

            hasInitialized = true;
        }

        private void HandleComplete()
        {
            if (context.assetsLoaded && context.workspaceLoaded)
            {
                controller.OnComplete();
            }
        }

        private void SetLoadingText()
        {
            loadingText.text = context.loadingText;
        }

        private void OnEnable()
        {
            if (hasInitialized == true)
            {
                controller.InitializeApplication();
            }
        }
    }
}
