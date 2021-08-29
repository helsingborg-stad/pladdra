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
    public class SelectionView : View
    {
        public Button menuButton;
        public Button removeButton;
        public Button placeButton;

        private ISelectionModel context;
        private ISelectionController controller;

        public override void Initialize()
        {
            context = new SelectionModel();
            controller = new SelectionController(context);

            menuButton.onClick.AddListener(controller.OnClickMenu);
            placeButton.onClick.AddListener(controller.OnClickPlace);
            removeButton.onClick.AddListener(controller.OnClickRemove);
        }
    }
}
