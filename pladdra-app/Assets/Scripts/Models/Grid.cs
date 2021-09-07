using System;
using System.Collections.Generic;
using System.Numerics;

using Pladdra.Core;
namespace Pladdra.MVC.Models
{
    public class Grid : IModel
    {
        public Vector3 size;
        private bool _isLocked;
        public delegate void IsLockedEvent();
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

        public event IsLockedEvent OnIsLockedChanged;
        private bool _visible;
        public delegate void VisibleEvent();
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

        public event VisibleEvent OnVisibleChanged;


        private Vector3 _position;
        public delegate void PositionEvent();
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
        public event PositionEvent OnPositionChanged;


        private Quaternion _rotation;
        public delegate void RotationEvent();
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
        public event PositionEvent OnRotationChanged;
    }
}
