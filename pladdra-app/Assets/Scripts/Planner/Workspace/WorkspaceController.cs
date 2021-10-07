using UnityEngine;

using Lean.Common;
using Lean.Touch;

namespace Pladdra.MVC.Controllers
{
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

        private GameObject preloadParent;

        public WorkspaceView workspaceView;

        public WorkspaceController(PlannerController plannerInstance)
        {
            planner = plannerInstance;
            preloadParent = GameObject.Find("Preloaded");
            workspaceObject = GameObject.Find("Workspace");
            workspaceView = workspaceObject.GetComponent<WorkspaceView>();
            context.Init += OnPlannerInit;

            context.grid.OnVisibleChanged += () =>
            {
                workspaceView.blocksRootObject.SetActive(context.grid.visible);

                if (!context.grid.visible)
                {
                    TransformAwayWorkspace();
                }
            };
            context.grid.OnSizeChanged += SetBoxCollider;
            context.grid.OnPivotPositionChanged += TransformWorkspacePivot;
            context.grid.OnPositionChanged += TransformWorkspace;
            context.grid.OnScaleChanged += ScaleWorkspace;
            context.grid.OnRotationChanged += RotateWorkspace;
            context.grid.OnIsSelectableChanged += () =>
            {
                workspaceView.leanSelectable.enabled = context.grid.isSelectable;
                workspaceView.findClosestPivot = context.grid.isSelectable;

            };


            workspaceView.Initialize();
        }

        private void OnPlannerInit()
        {
            context.workspace.OnBlockCreated += RenderBlock;
            context.workspace.OnBlockDeleted += HandleBlockDeleted;
            context.workspace.OnBlockPositionChanged += TransformBlock;
            context.workspace.OnBlockRotationChanged += RotateBlock;

            workspaceView.leanSelect.OnSelected.AddListener((LeanSelectable selectable) =>
            {
                if (selectable.gameObject.TryGetComponent<BlockView>(out var blockView))
                {
                    planner.SetState(new BlockSelection());
                }
            });
        }

        public void ScaleWorkspace()
        {
            if (context.grid.scale == context.grid.maxScale)
            {
                Vector3 pivotPointLocal = workspaceView.pivotPoint - workspaceView.transform.position;
                bool initialScaleIsLessThenOne = true;
                pivotPointLocal = initialScaleIsLessThenOne ? (pivotPointLocal * (1 / context.grid.minScale)) : pivotPointLocal;
                Vector3 pivotPosition = (new Vector3(workspaceView.transform.position.x, 0f, workspaceView.transform.position.z) - pivotPointLocal);
                context.grid.pivotPosition = pivotPosition - workspaceView.transform.position + (pivotPointLocal * (context.grid.minScale / context.grid.maxScale));
            }
            else
            {
                context.grid.pivotPosition = Vector3.zero;
            }

            workspaceObject.transform.localScale = new Vector3(context.grid.scale, context.grid.scale, context.grid.scale);
        }

        public void TransformWorkspacePivot()
        {
            if (context.grid.scale != context.grid.maxScale)
            {
                workspaceView.workspacePivot.transform.localPosition = Vector3.zero;
                return;
            }

            workspaceView.workspacePivot.transform.position = new Vector3(context.grid.pivotPosition.x * context.grid.minScale, 0, context.grid.pivotPosition.z * context.grid.minScale) + workspaceView.transform.position;
        }
        public void TransformAwayWorkspace()
        {
            workspaceObject.transform.position = new Vector3(context.grid.position.X, context.grid.position.Y, -999f);
        }
        public void TransformWorkspace()
        {
            workspaceObject.transform.position = new Vector3(context.grid.position.X, context.grid.position.Y, context.grid.position.Z);
        }
        public void RotateWorkspace()
        {
            // To be continued
        }

        private void HandleBlockDeleted(string id)
        {
            if (!workspaceView.blocks.ContainsKey(id))
                return;

            workspaceView.leanSelect.DeselectAll();
            UnityEngine.Object.Destroy(workspaceView.blocks[id]);
            workspaceView.blocks.Remove(id);
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
        public void DeselectAllBlocks()
        {
            planner.SetState(new Build());
            workspaceView.leanSelect.DeselectAll();
        }

        public void TransformBlock(string id)
        {
            if (context.workspace.selectedBlockID == id)
            {
                return;
            }

            Debug.Log("TransformBlock Trigger! Block ID: " + id);
            if (context.workspace.GetBlock(id, out var block))
            {
                if (block.position != workspaceView.blocks[id].transform.localPosition)
                {
                    Debug.Log("TransformBlock Trigger! Block ID: " + id);
                    workspaceView.blocks[id].transform.localPosition = block.position;
                }
            }
        }

        public void RotateBlock(string id)
        {
            if (context.workspace.selectedBlockID == id)
            {
                return;
            }

            Debug.Log("RotateBlock Trigger! Block ID: " + id);
            if (context.workspace.GetBlock(id, out var block))
            {
                if (block.rotation != workspaceView.blocks[id].transform.localRotation)
                {
                    Debug.Log("RotateBlock Trigger! Block ID: " + id);
                    workspaceView.blocks[id].transform.localRotation = block.rotation;
                }
            }
        }

        public void HandleBlockTransform(Vector3 position)
        {
            Debug.Log("Trigger HandleBlockTransform with postion: " + position);
            if (context.workspace.selectedBlockID != null
            && context.workspace.GetBlock(context.workspace.selectedBlockID, out var block))
            {
                Debug.Log("Trigger HandleBlockTransform with position: " + position);
                if (block.position != position)
                {
                    Debug.Log("Trigger HandleBlockTransform with position: " + position);
                    block.position = position;
                    context.workspace.UpdateBlock(block);
                }
            }
        }

        public void HandleBlockRotation(Quaternion rotation)
        {
            Debug.Log("Trigger HandleBlockRotation with rotation: " + rotation);
            if (context.workspace.selectedBlockID != null
                && context.workspace.GetBlock(context.workspace.selectedBlockID, out var block))
            {
                Debug.Log("Trigger HandleBlockRotation with rotation: " + rotation + "  , former rotation: " + block.rotation + " (ID: " + block.id + ")");
                if (block.rotation != rotation)
                {
                    Debug.Log("Trigger HandleBlockRotation with rotation: " + rotation + "  , former rotation: " + block.rotation + " (ID: " + block.id + ")");
                    block.rotation = rotation;
                    context.workspace.UpdateBlock(block);
                }
            }
        }

        public void RenderAllBlocks()
        {
            var blocks = context.workspace.ListBlocks();
            if (blocks.Count > 0)
            {
                Debug.Log("RenderAllBlocks TOTAL COUNT: " + blocks.Count);
                Debug.Log(blocks.Count);
                foreach (var block in blocks)
                {
                    RenderBlock(block.id, true);
                }
            }
        }

        private void RenderBlock(string id, bool shouldTransform)
        {
            Debug.Log("RenderBlock");
            var block = context.workspace.GetBlock(id);
            var preloadedAsset = preloadParent.transform.Find(block.assetID);
            var preloadedAssetClone = UnityEngine.Object.Instantiate(preloadedAsset);


            Debug.Log(block.assetID);
            Debug.Log(preloadedAsset);
            if (preloadedAsset != null)
            {
                Debug.Log("RenderBlock");
                if (!shouldTransform)
                {
                    Debug.Log("RenderBlock");
                    OnCompleteImport(preloadedAssetClone.gameObject, block);
                    return;
                }

                Debug.Log("RenderBlock");
                Debug.Log("RenderBlock");
                OnCompleteImport(preloadedAssetClone.gameObject, block, false);
                TransformBlock(block.id);
                RotateBlock(block.id);
            }


            // var asset = context.assets.Get(block.assetID);

            // PigletImporter.import(App.CachePath + '/' + asset.meshPath, OnCompleteImport, (Exception e) =>
            // {
            //     Debug.Log(e);
            // });
        }

        private void RenderBlock(string id)
        {
            Debug.Log("HandleBlockCreated");
            var block = context.workspace.GetBlock(id);
            var preloadedAsset = preloadParent.transform.Find(block.assetID);
            var preloadedAssetClone = UnityEngine.Object.Instantiate(preloadedAsset);

            if (preloadedAsset != null)
            {
                OnCompleteImport(preloadedAssetClone.gameObject, block);
            }


            // var asset = context.assets.Get(block.assetID);

            // PigletImporter.import(App.CachePath + '/' + asset.meshPath, OnCompleteImport, (Exception e) =>
            // {
            //     Debug.Log(e);
            // });
        }

        public void OnCompleteImport(GameObject assetObject, Block block, bool selectAfterImport = true)
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
            blockView.id = block.id;

            blockView.OnPositionChanged += HandleBlockTransform;
            blockView.OnRotationChanged += HandleBlockRotation;

            // TranslateAlong Props
            var pladdraDragTranslateAlong = parentObject.GetComponent<PladdraDragTranslateAlong>();
            pladdraDragTranslateAlong.ScreenDepth.Object = workspaceView.leanPlane;
            pladdraDragTranslateAlong.ScreenDepth.Camera = Camera.main;

            // Draw bounds based on children
            Bounds bounds = Pladdra.Core.Utils.CalculateBoundsFromChildren(parentObject);

            // Draw BoxCollider based on Bounds
            BoxCollider parentBoxCollider = parentObject.GetComponent<BoxCollider>();
            parentBoxCollider.center = bounds.center;
            parentBoxCollider.size = bounds.size;

            // Draw Cube Mesh based on Bounds
            MeshFilter parentMeshFilter = parentObject.GetComponent<MeshFilter>();
            parentMeshFilter.mesh = Pladdra.Core.MeshGenerator.GenerateCube(bounds.size, bounds.center);

            // Move to workspace & enable
            parentObject.transform.SetParent(workspaceView.blocksRootObject.transform, false);
            parentObject.SetActive(true);

            workspaceView.blocks.Add(block.id, parentObject);

            if (selectAfterImport)
            {
                var selectable = parentObject.GetComponent<LeanSelectable>();
                workspaceView.leanSelect.Select(selectable);
            }
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
