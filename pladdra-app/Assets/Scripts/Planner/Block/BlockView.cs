using Lean.Common;
using Lean.Touch;
using UnityEngine;


using Pladdra.Core.Types;
using Pladdra.MVC.Models;

namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(LeanSelectableByFinger))]
    [RequireComponent(typeof(LeanSelectableRendererColor))]
    [RequireComponent(typeof(PladdraDragTranslateAlong))]
    public class BlockView : LeanSelectableByFingerBehaviour
    {
        public string id;
        private LeanSelectableByFinger leanSelectableByFinger;
        private LeanSelectableRendererColor leanSelectableRendererColor;
        private PladdraDragTranslateAlong pladdraDragTranslateAlong;
        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }

        protected override void OnSelected()
        {
            Debug.Log("OnSelected");
            // Debug.Log(context.workspace.selectedBlockID);
            context.workspace.selectedBlockID = id;
        }

        /// <summary>Called when this is deselected, if OnSelectUp hasn't been called yet, it will get called first.</summary>
        protected override void OnDeselected()
        {
            Debug.Log("OnDeselected");
            Debug.Log(context.workspace.selectedBlockID);
            context.workspace.selectedBlockID = null;
        }


        // public void addBoundsToAllChildren()
        // {
        //     if (boxCol == null)
        //     {
        //         boxCol = gameObject.GetComponent(typeof(BoxCollider)) as BoxCollider;
        //         if (boxCol == null)
        //         {
        //             boxCol = gameObject.AddComponent<BoxCollider>();
        //         }
        //     }
        //     Bounds bounds = new Bounds(Vector3.zero, Vector3.zero);
        //     Renderer thisRenderer = transform.GetComponent<Renderer>();
        //     bounds.Encapsulate(thisRenderer.bounds);
        //     boxCol.offset = bounds.center - transform.position;
        //     boxCol.size = bounds.size;

        //     allDescendants = gameObject.GetComponentsInChildren<Transform>();
        //     foreach (Transform desc in allDescendants)
        //     {
        //         Renderer childRenderer = desc.GetComponent<Renderer>();
        //         if (childRenderer != null)
        //         {
        //             bounds.Encapsulate(childRenderer.bounds);
        //         }
        //         boxCol.offset = bounds.center - transform.position;
        //         boxCol.size = bounds.size;
        //     }
        // }


        // private void Awake()
        // {
        //     leanSelectableByFinger = GetComponent<LeanSelectableByFinger>();
        //     leanSelectableRendererColor = GetComponent<LeanSelectableRendererColor>();
        //     pladdraDragTranslateAlong = GetComponent<PladdraDragTranslateAlong>();
        // }

        // private void Start()
        // {
        //     leanSelectableByFinger.OnSelectedFinger.AddListener((LeanFinger) =>
        //     {
        //         Debug.Log("Selected block ID: " + id);
        //     });
        // }
    }
}