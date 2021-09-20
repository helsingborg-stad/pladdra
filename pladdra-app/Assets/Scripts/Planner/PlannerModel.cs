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
        public AssetModel assets
        {
            get
            {
                App.GetModel<AssetModel>(out var instance);
                return instance;
            }
        }

        public WorkspaceModel workspace
        {
            get;
            private set;
        }

        private Dictionary<string, Pladdra.API.Types.Block> blocks;

        public void InitializeWorkspace(string workspaceId)
        {
            workspace = workspaceList.Get<WorkspaceModel>(workspaceId);
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
