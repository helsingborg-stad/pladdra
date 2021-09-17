using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

namespace Pladdra.MVC.Views
{
    using Pladdra.MVC.Models;
    using Pladdra.MVC.Controllers;
    using Pladdra.Components;
    public class PlannerBuildSelectionGUI : View
    {
        public Button confirmSelectionButton;
        public Button removeSelectionButton;

        public override void Initialize()
        {
        }
    }
}
