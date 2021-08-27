using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;
using Pladdra.Components;

namespace Pladdra.MVC.Views
{
    [RequireComponent(typeof(WithReRender))]
    public class ListWorkspaceView : View
    {
        private IListWorkspaceModel context;
        private IListWorkspaceController controller;
        public UnityEvent render;
        private WithReRender withReRender;
        public GameObject itemPrefab;
        public VerticalLayoutGroup workspaceList;
        public Button backButton;

        public override void Initialize()
        {
            withReRender = GetComponent<WithReRender>();
            render = withReRender.renderEvent;
            context = new ListWorkspaceModel();
            controller = new ListWorkspaceController(context, render);

            backButton.onClick.AddListener(controller.OnClickBack);
        }
    }
}
