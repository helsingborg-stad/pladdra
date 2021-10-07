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
    public class PlannerGUI : View
    {
        public Button menuButton;
        public Button zenButton;
        public GameObject topAppBar;
        public PlannerPlaceGridGUI placeGridGUI;
        public PlannerEditGridGUI editGridGUI;
        public PlannerBuildSelectionGUI buildSelectionGUI;
        public PlannerBuildGUI buildGUI;
        public PlannerInventoryGUI inventoryGUI;

        public override void Initialize()
        {
        }
    }
}
