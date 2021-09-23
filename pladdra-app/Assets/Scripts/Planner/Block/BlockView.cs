using Lean.Common;
using Lean.Touch;

using Pladdra.Core.Types;
using Pladdra.MVC.Models;
using GLTF.Math;

namespace Pladdra.MVC.Views
{
    using UnityEngine;
    [RequireComponent(typeof(LeanSelectableByFinger))]
    [RequireComponent(typeof(LeanTwistRotate))]
    [RequireComponent(typeof(LeanSelectableRendererColor))]
    [RequireComponent(typeof(PladdraDragTranslateAlong))]
    public class BlockView : LeanSelectableByFingerBehaviour
    {
        public string id;
        public event DelegateBlockViewHandle OnPositionChanged;
        public event DelegateBlockViewHandle OnRotationChanged;
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
        private bool isSelected = false;
        private LeanSelectableByFinger leanSelectableByFinger;
        private LeanSelectableRendererColor leanSelectableRendererColor;
        private PladdraDragTranslateAlong pladdraDragTranslateAlong;
        private bool _DEBUG = false;
        public delegate void DelegateBlockViewHandle();

        protected override void OnSelected()
        {
            if (_DEBUG)
                Debug.Log("OnSelected");
            isSelected = true;
            context.workspace.selectedBlockID = id;

            if (OnSelectionChanged != null)
                OnSelectionChanged();
        }

        protected override void OnDeselected()
        {
            if (_DEBUG)
                Debug.Log("OnDeselected");
            isSelected = false;
            context.workspace.selectedBlockID = null;

            if (OnSelectionChanged != null)
                OnSelectionChanged();
        }

        void Update()
        {
            if (transform.hasChanged == true)
            {
                if (_DEBUG)
                {
                    Debug.Log("HAS CHANGED!!!");
                    Debug.Log("transform.rotation " + transform.rotation);
                    Debug.Log("transform.rotation.eulerAngles " + transform.rotation.eulerAngles);
                    Debug.Log("transform.position: " + transform.position);
                    Debug.Log("previousPosition " + previousPosition);
                    Debug.Log("previousRotation " + previousRotation);
                }

                if (previousPosition != null && !previousPosition.Equals(transform.position))
                {
                    if (OnPositionChanged != null)
                        OnPositionChanged();
                }

                if (previousRotation != null && !previousRotation.Equals(transform.rotation))
                {
                    if (OnRotationChanged != null)
                        OnRotationChanged();
                }

                previousPosition = transform.position;
                previousRotation = transform.rotation;
                transform.hasChanged = false;

            }
        }

        private void LateUpdate()
        {

        }
    }
}