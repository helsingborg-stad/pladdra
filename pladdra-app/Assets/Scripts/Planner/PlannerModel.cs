using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class PlannerModel : IModel
    {
        public event PlannerEventHandler UpdatedState;
        public event PlannerEventHandler Init;
        public event PlannerEventHandler OnHideTopAppBarChanged;


        public enum State
        {
            Initializing,
            Grid,
            PlaceGrid,
            EditGrid,
            Build,
            Selection,
            Inventory,
            Inactive,
        }

        public State state = State.Inactive;

        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }
        public ARModel ar
        {
            get
            {
                App.GetModel<ARModel>(out var instance);
                return instance;
            }
        }
        public WorkspaceList workspaceList
        {
            get
            {
                App.GetModel<WorkspaceList>(out var instance);
                return instance;
            }
        }

        public Workspace workspace
        {
            get;
            private set;
        }

        private Dictionary<string, Pladdra.API.Types.Block> blocks;
        public string selectedBlockID;

        public void SetState(State newState)
        {
            if (newState == state)
                return;

            state = newState;
            UpdatedState();
        }

        public void InitializeWorkspace(string workspaceId)
        {
            workspace = workspaceList.Get<Workspace>(workspaceId);
            workspace.Load();

            Init();
        }

        private bool _hideTopAppBar;
        public bool hideTopAppBar
        {
            get { return _hideTopAppBar; }
            set
            {
                if (_hideTopAppBar != value)
                {
                    _hideTopAppBar = value;
                    if (OnHideTopAppBarChanged != null)
                        OnHideTopAppBarChanged();
                }
            }
        }

        public delegate void PlannerEventHandler();

        public string workspaceID;
    }
}
