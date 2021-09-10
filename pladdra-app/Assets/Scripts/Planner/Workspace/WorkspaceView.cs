using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;
using UnityEngine.PlayerLoop;

namespace Pladdra.MVC.Views
{
    using Lean.Common;
    using Lean.Touch;
    using Pladdra.Core.Types;

    [RequireComponent(typeof(LeanSelectable), typeof(BoxCollider))]
    public class WorkspaceView : View
    {
        private Block createdBlock;

        public GameObject blocksRootObject;

        public IDictionary<string, GameObject> blocks = new Dictionary<string, GameObject>();

        public LeanSelectable leanSelectable;
        public BoxCollider boxCollider;

        public override void Initialize()
        {
            leanSelectable = GetComponent<LeanSelectable>();
            boxCollider = GetComponent<BoxCollider>();
        }

        void Update()
        {
            if (createdBlock != null)
            {

            }
        }

        public void InstantiateBlock(Block block, Asset asset)
        {
            createdBlock = block;
            PigletImporter.import(App.CachePath + '/' + asset.meshPath, OnCompleteImport);
        }

        public void OnCompleteImport(GameObject importedBlock)
        {
            blocks.Add(createdBlock.id, importedBlock);
            importedBlock.transform.SetParent(blocksRootObject.transform, false);
            importedBlock.SetActive(true);
            createdBlock = null;
        }

        public void RemoveBlock(string id)
        {
            if (!blocks.ContainsKey(id))
                return;
            Destroy(blocks[id]);
            blocks.Remove(id);
        }
    }
}
