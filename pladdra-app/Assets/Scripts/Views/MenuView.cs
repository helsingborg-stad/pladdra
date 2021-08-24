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
    public class MenuView : ViewWithRender
    {
        private IMenuModel context;
        private IMenuController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = true;
        public Button startButton;
        public Button downloadButton;
        public Button logoutButton;
        public Button devToolsButton;

        public override void Initialize()
        {
            context = new MenuModel();
            controller = new MenuController(context, renderEvent);

            logoutButton.onClick.AddListener(controller.OnClickLogout);
            startButton.onClick.AddListener(controller.OnClickStart);
            downloadButton.onClick.AddListener(controller.OnClickSync);
        }
    }
}
