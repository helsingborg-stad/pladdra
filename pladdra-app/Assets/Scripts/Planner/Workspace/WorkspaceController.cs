using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

using Lean.Common;
using Lean.Touch;

namespace Pladdra.MVC.Controllers
{

    using Pladdra.Core;
    using Pladdra.Components;
    using Pladdra.MVC.Models;
    using Pladdra.MVC.Views;
    using Pladdra.Core.Types;

    public class WorkspaceController
    {
        private PlannerController planner;

        private Block createdBlock;

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

        public WorkspaceController(PlannerController plannerInstance)
        {
            planner = plannerInstance;
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
            context.workspace.OnBlockDeleted += HandleBlockDeleted;

            workspaceView.leanSelect.OnSelected.AddListener((LeanSelectable selectable) =>
            {
                planner.SetState(new BlockSelection());
                Debug.Log("Selected!");
                // context.workspace.selectedBlockID = selectable.gameObject.GetComponent<BlockView>().id;
            });

            // workspaceView.leanSelect.OnDeselected.AddListener((LeanSelectable selectable) =>
            // {
            //     Debug.Log("Deselected!!!!");

            //     context.SetState(PlannerModel.State.Build);
            //     context.workspace.selectedBlockID = null;
            // });
        }



        private void HandleBlockDeleted(string id)
        {
            if (!workspaceView.blocks.ContainsKey(id))
                return;

            workspaceView.leanSelect.DeselectAll();
            UnityEngine.Object.Destroy(workspaceView.blocks[id]);
            workspaceView.blocks.Remove(id);
        }

        private void HandleBlockCreated(string id)
        {
            Debug.Log("HandleBlockCreated");
            createdBlock = context.workspace.GetBlock(id);
            var asset = context.assets.Get(createdBlock.assetID);

            PigletImporter.import(App.CachePath + '/' + asset.meshPath, OnCompleteImport, (Exception e) =>
            {
                Debug.Log(e);
            });
        }

        public void DestroyHandler()
        {
            var blocks = context.workspace.ListBlocks();
            if (blocks.Count == 0)
                return;

            for (int i = 0; i < blocks.Count; i++)
            {
                RemoveBlock(blocks[i].id);
            }
        }

        public void SetBoxCollider()
        {
            workspaceView.boxCollider.size = new Vector3(context.grid.size.X * context.grid.size.Z, 0.1f, context.grid.size.X * context.grid.size.Z);
        }


        public void InstantiateBlock(Block block, Asset asset)
        {
            createdBlock = block;
            PigletImporter.import(App.CachePath + '/' + asset.meshPath, OnCompleteImport, (Exception e) =>
            {
                Debug.Log(e);
            });
        }

        public void DeselectAllBlocks()
        {
            planner.SetState(new Build());
            workspaceView.leanSelect.DeselectAll();
        }


        public void OnCompleteImport(GameObject assetObject)
        {
            // Init parent
            var parentObject = UnityEngine.Object.Instantiate(workspaceView.blockPrefab);
            parentObject.SetActive(false);

            // Transform Props
            assetObject.transform.position = parentObject.transform.position;
            assetObject.transform.rotation = parentObject.transform.rotation;
            assetObject.transform.SetParent(parentObject.transform, false);
            assetObject.SetActive(true);


            // BlockView props
            var blockView = parentObject.GetComponent<BlockView>();
            blockView.id = createdBlock.id;

            // TranslateAlong Props
            var pladdraDragTranslateAlong = parentObject.GetComponent<PladdraDragTranslateAlong>();
            pladdraDragTranslateAlong.ScreenDepth.Object = workspaceView.leanPlane;
            pladdraDragTranslateAlong.ScreenDepth.Camera = Camera.main;

            // Draw bounds based on children
            BoxCollider parentBoxCollider = parentObject.GetComponent<BoxCollider>();
            Renderer[] allChildren = parentObject.GetComponentsInChildren<Renderer>();

            Vector3 center = parentObject.transform.position;
            foreach (Renderer child in allChildren)
            {
                center += child.bounds.center;
            }
            center /= parentObject.transform.childCount;

            Bounds bounds = new Bounds(center, Vector3.zero);
            foreach (Renderer child in allChildren)
            {
                bounds.Encapsulate(child.bounds);
            }

            parentBoxCollider.center = bounds.center;
            parentBoxCollider.size = bounds.size;

            // Move to workspace & enable
            parentObject.transform.SetParent(workspaceView.blocksRootObject.transform, false);
            parentObject.SetActive(true);

            workspaceView.blocks.Add(createdBlock.id, parentObject);

            var selectable = parentObject.GetComponent<LeanSelectable>();
            workspaceView.leanSelect.Select(selectable);

            createdBlock = null;
        }

        public void RemoveBlock(string id)
        {
            if (!workspaceView.blocks.ContainsKey(id))
                return;
            UnityEngine.Object.Destroy(workspaceView.blocks[id]);
            workspaceView.blocks.Remove(id);
        }
    }
}
