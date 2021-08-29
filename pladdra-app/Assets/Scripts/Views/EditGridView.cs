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
    public class EditGridView : View
    {
        public Button menuButton;
        public Button removeButton;
        public Button placeButton;

        private IEditGridModel context;
        private IEditGridController controller;

        public override void Initialize()
        {
            context = new EditGridModel();
            controller = new EditGridController(context);
        }
    }
}
