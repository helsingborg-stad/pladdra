using UnityEngine;

using System;
using System.Collections.Generic;
using System.Numerics;

namespace Pladdra.MVC.Models
{
    using System.Numerics;
    using Pladdra.Core;
    public class ARModel : IModel
    {
        public event AREventHandler RaycastHitPositionChanged;
        public event AREventHandler PlaneDetectionChanged;
        public event AREventHandler RaycastChanged;
        public event AREventHandler ShowMarkerChanged;





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
        public bool _raycast { get; set; }
        public bool raycast
        {
            get { return _raycast; }
            set
            {
                if (_raycast != value)
                {
                    _raycast = value;
                    if (RaycastChanged != null)
                        RaycastChanged();
                }
            }
        }
        public bool _showMarker { get; set; }
        public bool showMarker
        {
            get { return _showMarker; }
            set
            {
                if (_showMarker != value)
                {
                    _showMarker = value;
                    if (ShowMarkerChanged != null)
                        ShowMarkerChanged();
                }
            }
        }

        public delegate void AREventHandler();
    }
}
