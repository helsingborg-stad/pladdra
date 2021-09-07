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
        private ExampleController controller;

        public override void Initialize()
        {
            context = new ExampleModel();
            controller = new ExampleController(context);
        }
    }
}
