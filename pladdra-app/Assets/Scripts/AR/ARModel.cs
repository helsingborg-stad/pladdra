using UnityEngine;

using System;
using System.Collections.Generic;
using System.Numerics;

namespace Pladdra.MVC.Models
{
    using System.Numerics;
    using Pladdra.Core;
    public class AR : IModel
    {
        public event AREventHandler RaycastHitPositionChanged;
        public event AREventHandler PlaneDetectionChanged;
        public Vector3 _raycastHitPosition { get; set; }
        public Vector3 raycastHitPosition
        {
            get { return _raycastHitPosition; }
            set
            {
                if (_raycastHitPosition != value)
                {
                    _raycastHitPosition = value;
                    if (RaycastHitPositionChanged != null)
                        RaycastHitPositionChanged();
                }
            }
        }

        public bool _planeDetection { get; set; }
        public bool planeDetection
        {
            get { return _planeDetection; }
            set
            {
                if (_planeDetection != value)
                {
                    _planeDetection = value;
                    if (PlaneDetectionChanged != null)
                        PlaneDetectionChanged();
                }
            }
        }

        public bool raycast;
        public bool showMarker;

        public delegate void AREventHandler();
    }
}
