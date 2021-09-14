using UnityEngine;
using UnityEngine.Events;

public abstract class View : MonoBehaviour
{
    public virtual void _Initialize() { }
    public abstract void Initialize();

    public virtual void Hide() => gameObject.SetActive(false);

    public virtual void Show() => gameObject.SetActive(true);
}