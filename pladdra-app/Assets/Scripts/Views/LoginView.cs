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
    public class LoginView : View
    {
        public UnityEvent render;
        private LoginModel context;
        private LoginController controller;
        private bool shouldRender = true;
        public Button loginButton;
        public TMP_InputField usernameFieldLogin;
        public TMP_InputField passwordFieldLogin;
        public TMP_Text noticeText;
        public WithReRender withReRender;

        public bool refreshTokenOnShow;

        public override void Initialize()
        {
            withReRender = GetComponent<WithReRender>();
            withReRender.OnRender += SetNoticeText;
            withReRender.OnRender += ToggleUI;

            render = withReRender.renderEvent;

            context = new LoginModel();
            controller = new LoginController(context, render);

            loginButton.onClick.AddListener(() => controller.OnClickLogin(usernameFieldLogin.text, passwordFieldLogin.text));
        }

        public override void Show()
        {
            gameObject.SetActive(true);

            if (refreshTokenOnShow == true)
                controller.RefreshToken();
        }

        private void SetNoticeText()
        {
            noticeText.text = context.noticeMessage != null ? context.noticeMessage : "";
        }

        private void ToggleUI()
        {
            usernameFieldLogin.interactable = !context.isLoading;
            passwordFieldLogin.interactable = !context.isLoading;
            loginButton.interactable = !context.isLoading;
        }
    }
}
