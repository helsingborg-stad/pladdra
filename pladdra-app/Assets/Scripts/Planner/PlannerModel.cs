using System;
using System.Collections.Generic;
using System.Numerics;
using Newtonsoft.Json;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class PlannerModel : IModel
    {
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

        public event PlannerEventHandler UpdatedState;
        public event PlannerEventHandler Init;

        public Grid grid
        {
            get
            {
                App.GetModel<Grid>(out var instance);
                return instance;
            }
        }
        public AR ar
        {
            get
            {
                App.GetModel<AR>(out var instance);
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

        public delegate void PlannerEventHandler();

        public string workspaceID;
    }
}
