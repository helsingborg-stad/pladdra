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
    public class LoadWorkspaceView : View
    {
        private ILoadWorkspaceModel context;
        private ILoadWorkspaceController controller;

        public override void Initialize()
        {
            context = new LoadWorkspaceModel();
            controller = new LoadWorkspaceController(context);
        }
    }
}
