using System.Collections;
using System.Collections.Generic;
using Pladdra.MVC.Views;
using UnityEngine;


namespace Pladdra.MVC.Controllers
{
    using Pladdra.Core;
    using Pladdra.MVC.Models;

    public class WorkspaceController
    {
        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        private GameObject workspaceObject;
        private WorkspaceView workspaceView;

        public WorkspaceController()
        {
            workspaceObject = GameObject.Find("Workspace");
            workspaceView = workspaceObject.GetComponent<WorkspaceView>();
            context.Init += OnPlannerInit;

            context.grid.OnVisibleChanged += () => workspaceView.blocksRootObject.SetActive(context.grid.visible);
            context.grid.OnSizeChanged += SetBoxCollider;
            context.grid.OnPositionChanged += TransformWorkspace;
            context.grid.OnScaleChanged += ScaleWorkspace;
            context.grid.OnRotationChanged += RotateWorkspace;
            context.grid.OnIsSelectableChanged += () => workspaceView.leanSelectable.enabled = context.grid.isSelectable;

            workspaceView.Initialize();
        }

        public void ScaleWorkspace()
        {
            workspaceObject.transform.localScale = new Vector3(context.grid.scale, context.grid.scale, context.grid.scale);
        }
        public void TransformWorkspace()
        {
            workspaceObject.transform.position = new Vector3(context.grid.position.X, context.grid.position.Y, context.grid.position.Z);
        }
        public void RotateWorkspace()
        {
            // To be continued
        }

        private void OnPlannerInit()
        {
            context.workspace.OnBlockCreated += HandleBlockCreated;
        }

        private void HandleBlockCreated(string id)
        {
            Debug.Log("HandleBlockCreated");
            var createdBlock = context.workspace.GetBlock(id);
            workspaceView.InstantiateBlock(createdBlock, context.assets.Get(createdBlock.assetID));
        }

        public void DestroyHandler()
        {
            var blocks = context.workspace.ListBlocks();
            if (blocks.Count == 0)
                return;

            for (int i = 0; i < blocks.Count; i++)
            {
                workspaceView.RemoveBlock(blocks[i].id);
            }
        }

        public void SetBoxCollider()
        {
            workspaceView.boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, 0.1f, context.grid.size.X * context.grid.size.Z);
        }
    }
}
