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

namespace Pladdra.MVC.Views
{
    public class ExampleView : View
    {
        private IExampleModel context;
        private IExampleController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = true;

        public override void Initialize()
        {
            // logoutButton.onClick.AddListener(controller.OnClickLogout);
        }

        private void ReRender()
        {
            shouldRender = true;
        }

        private void Update()
        {
            if (shouldRender)
            {
                shouldRender = false;

                //
            }
        }
    }
}
