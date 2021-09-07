using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public class LoginController
    {
        public LoginModel model { get; }

        UnityEvent render;

        public LoginController(LoginModel loginModel, UnityEvent renderEvent)
        {
            model = loginModel;
            render = renderEvent;
        }

        public async void OnClickLogin(string userName, string password)
        {
            model.noticeMessage = "Loggar in ..";
            model.isLoading = true;
            render.Invoke();

            bool successfulLogin = await Auth.Login(userName, password);

            model.isLoading = false;
            render.Invoke();

            if (successfulLogin)
            {
                model.noticeMessage = "";
                model.resetPassword = true;
                render.Invoke();
                model.resetPassword = false;
                // Navigate to Menu
                ViewManager.Show<AppLoadingView>();

                return;
            }
            model.noticeMessage = "Något gick fel, försök igen.";
            render.Invoke();
        }

        public async void RefreshToken()
        {
            bool successfulRefresh = await Auth.RefreshSession();
            if (successfulRefresh)
            {
                ViewManager.Show<MenuView>();
            }
        }
    }
}