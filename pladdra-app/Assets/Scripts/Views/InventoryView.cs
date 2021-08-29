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
    public class InventoryView : View
    {
        public Button backButton;
        public GridLayoutGroup inventoryGrid;
        public GameObject inventoryItemPrefab;
        private List<GameObject> items;
        private IInventoryModel context;
        private IInventoryController controller;

        public override void Initialize()
        {
            context = new InventoryModel();
            controller = new InventoryController(context);
        }
    }
}
