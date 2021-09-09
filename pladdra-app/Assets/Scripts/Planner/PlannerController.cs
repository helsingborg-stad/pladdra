using System.Collections;
using System.Collections.Generic;
using Pladdra.MVC.Views;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Models;

    public class PlannerController
    {
        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        private PlannerGUI plannerGUI { get; set; }
        private GridController gridController;
        // private WorkspaceController workspaceController;

        public PlannerController()
        {
            plannerGUI = CreateView("PlannerGUI").GetComponent<PlannerGUI>();
            gridController = new GridController();
            // workspaceController = new WorkspaceController();

            context.Init += Initialize;
            context.Init += plannerGUI.inventoryGUI.Initialize;

            context.UpdatedState += OnStateChanged;
            context.OnHideTopAppBarChanged += () => plannerGUI.topAppBar.SetActive(!context.hideTopAppBar);

            plannerGUI.placeGridGUI.placeGridButton.onClick.AddListener(OnClickPlaceGrid);
            plannerGUI.editGridGUI.removeGridButton.onClick.AddListener(OnClickRemoveGrid);
            plannerGUI.editGridGUI.lockGridButton.onClick.AddListener(OnClickLockGrid);
            plannerGUI.buildGUI.editGridButton.onClick.AddListener(OnClickEditGrid);
            plannerGUI.buildGUI.showInventoryButton.onClick.AddListener(OnClickShowInventory);
            plannerGUI.inventoryGUI.backButton.onClick.AddListener(OnClickExitInventory);
            plannerGUI.inventoryGUI.OnClickGridItem += OnClickInvetoryItem;

            plannerGUI.placeGridGUI.Hide();
            plannerGUI.editGridGUI.Hide();
            plannerGUI.buildGUI.Hide();
            plannerGUI.inventoryGUI.Hide();
        }

        private void OnStateChanged()
        {
            switch (context.state)
            {
                case PlannerModel.State.PlaceGrid:
                    {
                        plannerGUI.placeGridGUI.Show();
                        plannerGUI.editGridGUI.Hide();
                        plannerGUI.buildGUI.Hide();
                        plannerGUI.inventoryGUI.Hide();

                        context.grid.visible = false;
                        context.ar.planeDetection = true;
                        context.ar.raycast = true;
                        context.ar.showMarker = true;
                    }
                    break;
                case PlannerModel.State.EditGrid:
                    {
                        plannerGUI.placeGridGUI.Hide();
                        plannerGUI.editGridGUI.Show();
                        plannerGUI.buildGUI.Hide();
                        plannerGUI.inventoryGUI.Hide();

                        context.ar.planeDetection = true;
                        context.ar.raycast = false;
                        context.ar.showMarker = false;
                        context.grid.visible = true;
                        context.grid.isSelectable = false;
                    }
                    break;
                case PlannerModel.State.Build:
                    {
                        plannerGUI.placeGridGUI.Hide();
                        plannerGUI.editGridGUI.Hide();
                        plannerGUI.buildGUI.Show();
                        plannerGUI.inventoryGUI.Hide();

                        context.ar.planeDetection = false;
                    }
                    break;
                case PlannerModel.State.Inventory:
                    {
                        plannerGUI.placeGridGUI.Hide();
                        plannerGUI.editGridGUI.Hide();
                        plannerGUI.buildGUI.Hide();
                        plannerGUI.inventoryGUI.Show();
                    }
                    break;
                case PlannerModel.State.Inactive:
                    {
                        plannerGUI.placeGridGUI.Hide();
                        plannerGUI.editGridGUI.Hide();
                        plannerGUI.buildGUI.Hide();
                        plannerGUI.inventoryGUI.Hide();
                    }
                    break;
                case PlannerModel.State.Selection:
                    {
                    }
                    break;
            }
        }


        private void Initialize()
        {
            ViewManager.Show<PlannerGUI>();
            SetupGrid();
            context.SetState(PlannerModel.State.PlaceGrid);
        }

        private void SetupGrid()
        {
            var scaleFactor = 16f;
            var scale = 1.0f / scaleFactor;

            context.grid.size = new System.Numerics.Vector3(1f, 1f, 10f);
            context.grid.scale = scale;
            context.grid.isSelectable = false;
            context.grid.visible = false;
            gridController.GenerateGrid();
        }



        private void DestroyWorkspace()
        {

        }


        // Common
        public void OnClickMenu() { }


        // Grid
        public void OnClickPlaceGrid()
        {
            context.grid.position = context.ar.raycastHitPosition;
            context.SetState(PlannerModel.State.EditGrid);
        }
        public void OnClickLockGrid()
        {
            context.grid.isSelectable = true;
            context.SetState(PlannerModel.State.Build);
        }

        public void OnClickRemoveGrid()
        {
            context.SetState(PlannerModel.State.PlaceGrid);
        }
        // Build
        public void OnClickShowInventory()
        {
            context.SetState(PlannerModel.State.Inventory);
        }
        public void OnClickEditGrid()
        {
            context.SetState(PlannerModel.State.EditGrid);
        }
        public void OnClickPlaceBlock() { }
        public void OnClickRemoveBlock() { }


        // Inventory
        public void OnClickExitInventory()
        {
            context.SetState(PlannerModel.State.Build);
        }
        public void OnClickInvetoryItem(Pladdra.API.Types.Asset asset)
        {
            context.SetState(PlannerModel.State.Build);
        }


        GameObject CreateView(string viewName)
        {
            // Loads the prefab with the view and instantiates it inside the View hierarchy
            return GameObject.Find(viewName);
        }
    }
}

// ---INIT
// Generate Grid
// context.grid.size = new Vector3();
// context.workspace.size = new Vector3();

// Load Workspace

// context.SetState(Planner.State.Grid);
// Generate Blocks on top of Grid

// ---GRID DISPOSE
// Enable Plane Detection
// Show AR Marker

// ---GRID EDIT
// Show Grid
// Set Grid Selectable

// ---BUILD
// Set Blocks Selectable

// ---Selection
// Set Blocks Selectable
