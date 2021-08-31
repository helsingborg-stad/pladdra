using System.Collections.Generic;

using UnityEngine;

using Pladdra;
using Pladdra.MVC.Views;

public class ViewManager : MonoBehaviour
{
    private static ViewManager s_instance;

    [SerializeField] private bool _initOnStart;
    [SerializeField] private View _startingView;

    [SerializeField] private View[] _views;

    private View _currentView;

    private readonly Stack<View> _history = new Stack<View>();

    public static void Init()
    {
        for (int i = 0; i < s_instance._views.Length; i++)
        {
            s_instance._views[i]._Initialize();
            s_instance._views[i].Initialize();

            s_instance._views[i].Hide();
        }

        if (s_instance._startingView != null)
        {
            Show(s_instance._startingView, true);
            s_instance.RefreshSession();
        }
    }

    public static T GetView<T>() where T : View
    {
        for (int i = 0; i < s_instance._views.Length; i++)
        {
            if (s_instance._views[i] is T tView)
            {
                return tView;
            }
        }

        return null;
    }

    public static void Show<T>(bool remember = true) where T : View
    {
        for (int i = 0; i < s_instance._views.Length; i++)
        {
            if (s_instance._views[i] is T)
            {
                if (s_instance._currentView != null)
                {
                    if (remember)
                    {
                        s_instance._history.Push(s_instance._currentView);
                    }

                    s_instance._currentView.Hide();
                }

                s_instance._views[i].Show();

                s_instance._currentView = s_instance._views[i];
            }
        }
    }

    public static void Show(View view, bool remember = true)
    {
        if (s_instance._currentView != null)
        {
            if (remember)
            {
                s_instance._history.Push(s_instance._currentView);
            }

            s_instance._currentView.Hide();
        }

        view.Show();

        s_instance._currentView = view;
    }

    public static void ShowLast()
    {
        if (s_instance._history.Count != 0)
        {
            Show(s_instance._history.Pop(), false);
        }
    }

    private void Awake() => s_instance = this;

    private void Start()
    {
        if (_initOnStart == true)
        {
            Init();
        }
    }



    private void RefreshSession()
    {
        Auth.RefreshSession().ContinueWith(response =>
        {
            bool successfulRefresh = response.Result;

            if (!successfulRefresh)
            {
                ViewManager.Show<LoginView>();
            }
        });
    }
}