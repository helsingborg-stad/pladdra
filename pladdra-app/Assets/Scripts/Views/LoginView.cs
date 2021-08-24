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

namespace Pladdra.MVC.Views
{
    public class LoginView : ViewWithRender
    {
        private ILoginModel context;
        private ILoginController controller;
        private bool shouldRender = true;
        public Button loginButton;
        public TMP_InputField usernameFieldLogin;
        public TMP_InputField passwordFieldLogin;
        public TMP_Text noticeText;

        public override void Initialize()
        {
            context = new LoginModel();
            controller = new LoginController(context, renderEvent);

            loginButton.onClick.AddListener(() => controller.OnClickLogin(usernameFieldLogin.text, passwordFieldLogin.text));
        }

        private void OnEnable()
        {
            passwordFieldLogin.text = "";
            noticeText.text = "";
        }

        public override void OnRender()
        {
            SetNoticeText();
            ToggleUI();
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
