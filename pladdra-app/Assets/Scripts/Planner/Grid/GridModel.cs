using System;
using System.Collections.Generic;
using System.Numerics;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class Grid : IModel
    {
        public event GridEventHandler OnSizeChanged;
        public event GridEventHandler OnIsSelectableChanged;
        public event GridEventHandler OnVisibleChanged;
        public event GridEventHandler OnPositionChanged;
        public event GridEventHandler OnRotationChanged;
        public event GridEventHandler OnScaleChanged;

        private float _scale;
        public float scale
        {
            get { return _scale; }
            set
            {
                if (_scale != value)
                {
                    _scale = value;
                    if (OnScaleChanged != null)
                        OnScaleChanged();
                }
            }
        }

        private Vector3 _size;
        public Vector3 size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    if (OnSizeChanged != null)
                        OnSizeChanged();
                }
            }
        }

        private bool _isSelectable;
        public bool isSelectable
        {
            get { return _isSelectable; }
            set
            {
                if (_isSelectable != value)
                {
                    _isSelectable = value;
                    if (OnIsSelectableChanged != null)
                        OnIsSelectableChanged();
                }
            }
        }

        private bool _visible;
        public bool visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    if (OnVisibleChanged != null)
                        OnVisibleChanged();
                }
            }
        }

        private Vector3 _position;
        public Vector3 position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    if (OnPositionChanged != null)
                        OnPositionChanged();
                }
            }
        }

        private Quaternion _rotation;
        public Quaternion rotation
        {
            get { return _rotation; }
            set
            {
                if (_rotation != value)
                {
                    _rotation = value;
                    if (OnRotationChanged != null)
                        OnRotationChanged();
                }
            }
        }
        public delegate void GridEventHandler();
    }
}