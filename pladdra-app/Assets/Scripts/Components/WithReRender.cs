using UnityEngine;
using UnityEngine.Events;


namespace Pladdra.Components
{
    public class WithReRender : MonoBehaviour
    {
        public UnityEvent renderEvent
        {
            get
            {

                Debug.Log(_renderEvent);
                if (_renderEvent != null)
                {
                    return _renderEvent;
                }
                _renderEvent = new UnityEvent();
                _renderEvent.AddListener(() => shouldRender = true);

                return _renderEvent;
            }
        }

        public bool shouldRender = false;
        public delegate void RenderDelegate();
        public RenderDelegate OnRender;
        private UnityEvent _renderEvent;

        private void Update()
        {
            if (shouldRender)
            {
                OnRender();
                shouldRender = false;
            }
        }
    }
}