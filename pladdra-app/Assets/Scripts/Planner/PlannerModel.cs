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
        public event PlannerEventHandler OnShowZenButton;
        public event PlannerEventHandler OnZenModeCHanged;

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
        public WorkspaceListModel workspaceList
        {
            get
            {
                App.GetModel<WorkspaceListModel>(out var instance);
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
            workspace = new WorkspaceModel();
            workspace.id = workspaceId;
            SaveDataManager.LoadJsonData(workspace, true);


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
        private bool _showZenButton;
        public bool showZenButton
        {
            get { return _showZenButton; }
            set
            {
                if (_showZenButton != value)
                {
                    _showZenButton = value;
                    if (OnShowZenButton != null)
                        OnShowZenButton();
                }
            }
        }

        private bool _zenMode;
        public bool zenMode
        {
            get { return _zenMode; }
            set
            {
                if (_zenMode != value)
                {
                    _zenMode = value;
                    if (OnZenModeCHanged != null)
                        OnZenModeCHanged();
                }
            }
        }

        public delegate void PlannerEventHandler();

        public string workspaceID;
    }
}
