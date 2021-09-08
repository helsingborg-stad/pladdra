using System;
using System.Collections.Generic;
using System.Numerics;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class Grid : IModel
    {
        public event GridEventHandler OnSizeChanged;
        public event GridEventHandler OnIsLockedChanged;
        public event GridEventHandler OnVisibleChanged;
        public event GridEventHandler OnPositionChanged;
        public event GridEventHandler OnRotationChanged;

        private Vector3 _size;
        private bool _isLocked;
        private bool _visible;
        private Vector3 _position;
        private Quaternion _rotation;

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

        public bool isLocked
        {
            get { return _isLocked; }
            set
            {
                if (_isLocked != value)
                {
                    _isLocked = value;
                    if (OnIsLockedChanged != null)
                        OnIsLockedChanged();
                }
            }
        }

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
