using Lean.Common;
using Lean.Touch;

using Pladdra.Core.Types;
using Pladdra.MVC.Models;
using GLTF.Math;

namespace Pladdra.MVC.Views
{
    using UnityEngine;
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(LeanSelectableByFinger))]
    [RequireComponent(typeof(LeanTwistRotateAxis))]
    [RequireComponent(typeof(PladdraDragTranslateAlong))]
    public class BlockView : LeanSelectableByFingerBehaviour
    {
        public string id;
        public event OnPositionChangedHandler OnPositionChanged;
        public event OnRotationChangedHandler OnRotationChanged;
        public event DelegateBlockViewHandle OnSelectionChanged;

        private PlannerModel context
        {
            get
            {
                App.GetModel<PlannerModel>(out var instance);
                return instance;
            }
        }
        private Vector3 previousPosition;
        private Quaternion previousRotation;
        public bool isSelected = false;
        private MeshRenderer meshRenderer;
        private MeshFilter meshFilter;
        private LeanSelectableByFinger leanSelectableByFinger;
        private LeanTwistRotateAxis leanTwistRotateAxis;
        private LeanSelectableRendererColor leanSelectableRendererColor;
        private PladdraDragTranslateAlong pladdraDragTranslateAlong;
        private bool _DEBUG = true;
        public delegate void OnPositionChangedHandler(Vector3 position);
        public delegate void OnRotationChangedHandler(Quaternion rotation);
        public delegate void DelegateBlockViewHandle();

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();
        }

        protected override void Start()
        {
            base.Start();
            if (meshRenderer != null)
                meshRenderer.enabled = isSelected;
        }

        protected override void OnSelected()
        {
            if (meshRenderer != null)
                meshRenderer.enabled = true;

            if (_DEBUG)
                Debug.Log("OnSelected");
            isSelected = true;
            context.workspace.selectedBlockID = id;

            if (OnSelectionChanged != null)
                OnSelectionChanged();
        }

        protected override void OnDeselected()
        {
            if (meshRenderer != null)
                meshRenderer.enabled = false;

            if (_DEBUG)
                Debug.Log("OnDeselected");
            isSelected = false;
            context.workspace.selectedBlockID = null;

            if (OnSelectionChanged != null)
                OnSelectionChanged();
        }

        void Update()
        {
            if (isSelected && transform.hasChanged == true)
            {
                if (previousPosition == null
               || previousPosition != transform.localPosition)
                {
                    if (OnPositionChanged != null)
                        OnPositionChanged(transform.localPosition);
                }

                if (previousPosition == null
                || previousRotation != transform.localRotation)
                {
                    if (OnRotationChanged != null)
                        OnRotationChanged(transform.localRotation);
                }

                previousPosition = transform.localPosition;
                previousRotation = transform.localRotation;
                transform.hasChanged = false;
            }
        }

        private void LateUpdate()
        {

        }
    }
}