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
    public class MenuView : View
    {
        private MenuModel context;
        private MenuController controller;
        private UnityEvent renderEvent;
        private bool shouldRender = true;
        public Button createButton;
        public Button listButton;
        public Button logoutButton;
        public Button devToolsButton;
        public bool refreshTokenOnShow;

        public override void Initialize()
        {
            renderEvent = new UnityEvent();
            context = new MenuModel();
            controller = new MenuController(context);
            renderEvent.AddListener(() => shouldRender = true);

            createButton.onClick.AddListener(controller.OnClickCreateWorkspace);
            listButton.onClick.AddListener(controller.OnClickListWorkspace);
            logoutButton.onClick.AddListener(controller.OnClickLogout);
        }
    }
}
