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

    [RequireComponent(typeof(LeanSelectable))]
    [RequireComponent(typeof(BoxCollider))]
    public class WorkspaceView : View
    {
        private Block createdBlock;

        public LeanSelect leanSelect;
        public LeanPlane leanPlane;
        public GameObject blocksRootObject;
        public GameObject blockPrefab;
        public IDictionary<string, GameObject> blocks = new Dictionary<string, GameObject>();
        public LeanSelectable leanSelectable;
        public BoxCollider boxCollider;
        public event WorkspaceViewHandler OnSelectBlockEvent;
        public delegate void WorkspaceViewHandler();


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



        public void SelectBlockTrigger(string id)
        {

        }
        public void DeselectBlockTrigger()
        {

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
