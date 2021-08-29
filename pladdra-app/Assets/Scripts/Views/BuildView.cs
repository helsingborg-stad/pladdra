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
    public class BuildView : View
    {
        public Button menuButton;
        public Button GridButton;
        public Button LibraryButton;
        private IBuildModel context;
        private IBuildController controller;

        public override void Initialize()
        {
            context = new BuildModel();
            controller = new BuildController(context);
        }
    }
}
