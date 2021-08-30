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
    public class CreateWorkspaceView : View
    {
        private ICreateWorkspaceModel context;
        private ICreateWorkspaceController controller;
        public UnityEvent render;
        public WithReRender withReRender;
        public TMP_InputField nameField;
        public Button createButton;
        public Button backButton;

        public override void Initialize()
        {
            withReRender = GetComponent<WithReRender>();
            render = withReRender.renderEvent;

            context = new CreateWorkspaceModel();
            controller = new CreateWorkspaceController(context, render);

            createButton.onClick.AddListener(() => controller.OnClickCreate(nameField.text));
            backButton.onClick.AddListener(controller.OnClickBack);
        }

        private void OnEnable()
        {
            nameField.text = "";
        }
    }
}
