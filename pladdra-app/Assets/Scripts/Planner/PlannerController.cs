using System.Collections;
using System.Collections.Generic;
using Pladdra.MVC.Views;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.Core.Types;
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
        private WorkspaceController workspaceController;

        public PlannerController()
        {
            plannerGUI = GameObject.Find("PlannerGUI").GetComponent<PlannerGUI>();
            gridController = new GridController();
            workspaceController = new WorkspaceController();

            // Subscribe Init
            context.Init += Initialize;
            context.Init += plannerGUI.inventoryGUI.Initialize;

            //Subscribe model events 
            context.UpdatedState += OnStateChanged;
            context.OnHideTopAppBarChanged += () => plannerGUI.topAppBar.SetActive(!context.hideTopAppBar);

            //Subscribe GUI Handlers
            plannerGUI.menuButton.onClick.AddListener(OnClickMenu);
            plannerGUI.placeGridGUI.placeGridButton.onClick.AddListener(OnClickPlaceGrid);
            plannerGUI.editGridGUI.removeGridButton.onClick.AddListener(OnClickRemoveGrid);
            plannerGUI.editGridGUI.lockGridButton.onClick.AddListener(OnClickLockGrid);
            plannerGUI.buildGUI.editGridButton.onClick.AddListener(OnClickEditGrid);
            plannerGUI.buildGUI.showInventoryButton.onClick.AddListener(OnClickShowInventory);
            plannerGUI.inventoryGUI.backButton.onClick.AddListener(OnClickExitInventory);
            plannerGUI.inventoryGUI.OnClickGridItem += OnClickInvetoryItem;

            //Hide GUI partials
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
                        context.grid.isSelectable = true;
                    }
                    break;
                case PlannerModel.State.Build:
                    {
                        plannerGUI.placeGridGUI.Hide();
                        plannerGUI.editGridGUI.Hide();
                        plannerGUI.buildGUI.Show();
                        plannerGUI.inventoryGUI.Hide();

                        context.grid.isSelectable = false;
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
                case PlannerModel.State.Destroy:
                    {
                        context.hideTopAppBar = true;
                        workspaceController.DestroyHandler();
                        context.grid.visible = false;
                        context.SetState(PlannerModel.State.Inactive);
                        ViewManager.Show<MenuView>();
                    }
                    break;
            }
        }


        private void Initialize()
        {
            ViewManager.Show<PlannerGUI>();
            SetupGrid();
            context.SetState(PlannerModel.State.PlaceGrid);
            context.hideTopAppBar = false;
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

        // Common
        public void OnClickMenu()
        {
            context.SetState(PlannerModel.State.Destroy);
        }


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

        public void OnClickInvetoryItem(Pladdra.Core.Types.Asset asset)
        {
            var input = new CreateBlockInput();
            input.id = context.workspace.UUID();
            input.workspaceID = context.workspace.id;
            input.assetID = asset.id;
            input.position = new Vect3Input { x = context.grid.position.X, y = context.grid.position.Y, z = context.grid.position.Z };
            input.rotation = new QuatInput { x = context.grid.rotation.X, y = context.grid.rotation.Y, z = context.grid.rotation.Z, w = context.grid.rotation.W };
            context.workspace.CreateBlock(input);
            context.SetState(PlannerModel.State.Build);
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
