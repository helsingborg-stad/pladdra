using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;
    using Pladdra.MVC.Models;

    public class PlannerController
    {
        private IPlannerState currentState;

        public PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        public PlannerGUI plannerGUI { get; private set; }
        public GridController gridController { get; private set; }
        public WorkspaceController workspaceController { get; private set; }

        public PlannerController()
        {
            plannerGUI = GameObject.Find("PlannerGUI").GetComponent<PlannerGUI>();

            // Controllers
            gridController = new GridController(this);
            workspaceController = new WorkspaceController(this);

            // Subscribe
            context.Init += () => SetState(new Initialize());
            context.OnHideTopAppBarChanged += () => plannerGUI.topAppBar.SetActive(!context.hideTopAppBar);
            context.OnShowZenButton += () => plannerGUI.zenButton.gameObject.SetActive(context.showZenButton ? true : false);
            plannerGUI.menuButton.onClick.AddListener(OnClickMenu);
            plannerGUI.zenButton.onClick.AddListener(OnClickZen);

            SetState(new Inactive());
        }

        public void SetState(IPlannerState newState)
        {
            if (currentState != null)
                currentState.OnUnmount();

            currentState = newState;
            currentState.planner = this;
            currentState.OnMount();
        }

        public void OnClickMenu()
        {
            SetState(new Destroy());
        }

        public void OnClickZen()
        {
            context.zenMode = context.zenMode ? false : true;

            if (context.zenMode)
            {
                SetState(new Zen());
            }
            else
            {
                SetState(new Build());
            }
        }

        public void OnSelectDeselectBlock(string id)
        {
            if (context.workspace.selectedBlockID != null)
            {
                SetState(new BlockSelection());
                return;
            }

            SetState(new Build());
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
