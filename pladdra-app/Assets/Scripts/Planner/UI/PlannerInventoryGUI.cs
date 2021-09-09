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
    public class PlannerInventoryGUI : View
    {
        public event OnClickGridItemEventHandler OnClickGridItem;

        public Button backButton;
        public GridLayoutGroup inventoryGrid;
        public GameObject inventoryItemPrefab;

        public override void Initialize()
        {
        }

        public delegate void OnClickGridItemEventHandler(Pladdra.API.Types.Asset asset);
    }
}
