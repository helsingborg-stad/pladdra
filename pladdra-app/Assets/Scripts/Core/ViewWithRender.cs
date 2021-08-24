using UnityEngine;
using UnityEngine.Events;

public abstract class ViewWithRender : View
{
    public UnityEvent renderEvent;
    private bool shouldRender = false;

    private void Update()
    {
        if (shouldRender)
        {
            OnRender();
            shouldRender = ShoulRenderHandler(this);
        }
    }

    public bool ShoulRenderHandler(View context) => false;

    public override void _Initialize()
    {
        renderEvent = new UnityEvent();
        renderEvent.AddListener(() => shouldRender = true);
    }

    public virtual void OnRender() { }
}