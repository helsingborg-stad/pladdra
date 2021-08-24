using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Pladdra.Views
{
    public class Login : View
    {
        public Button loginButton;
        public TMP_InputField usernameFieldLogin;
        public TMP_InputField passwordFieldLogin;
        public TMP_Text noticeText;

        public override void Initialize()
        {
            loginButton.onClick.AddListener(onClickLogin);

            toggleUI(true);

            passwordFieldLogin.text = "";
            noticeText.text = "";

            RefreshToken();
        }


        private void toggleUI(bool visible)
        {
            usernameFieldLogin.interactable = visible;
            passwordFieldLogin.interactable = visible;
            loginButton.interactable = visible;
        }

        private async void RefreshToken()
        {
            bool successfulRefresh = await Auth.RefreshSession();
            if (successfulRefresh)
            {
                ViewManager.Show<MainMenu>();
            }
        }

        private async void onClickLogin()
        {
            noticeText.text = "Signing in .. please wait";
            toggleUI(false);

            bool successfulLogin = await Auth.Login(usernameFieldLogin.text, passwordFieldLogin.text);

            if (successfulLogin)
            {
                ViewManager.Show<MainMenu>();
                passwordFieldLogin.text = "";
                noticeText.text = "";
            }

            toggleUI(true);
            noticeText.text = "Failed to login, please try again.";
        }
    }
}
