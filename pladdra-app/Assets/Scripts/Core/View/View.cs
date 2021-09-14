using UnityEngine;
using UnityEngine.Events;

public abstract class View : MonoBehaviour
{
    public event ViewEventHandler OnInit;
    public event ViewEventHandler OnShow;
    public event ViewEventHandler OnHide;

    public virtual void _Initialize() { }
    public abstract void Initialize();

    public virtual void Hide()
    {
        gameObject.SetActive(false);
        if (OnHide != null)
            OnHide();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        if (OnShow != null)
            OnShow();
    }

    public delegate void ViewEventHandler();
}