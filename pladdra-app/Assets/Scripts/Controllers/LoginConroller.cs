using UnityEngine;
using UnityEngine.Events;
using Pladdra.MVC.Models;
using Pladdra.MVC.Views;


namespace Pladdra.MVC.Controllers
{
    public interface ILoginController
    {
        public ILoginModel model { get; }
        void OnClickLogin(string userName, string password);
    }

    public class LoginController : ILoginController
    {
        public ILoginModel model { get; }

        UnityEvent render;

        public LoginController(ILoginModel loginModel, UnityEvent renderEvent)
        {
            model = loginModel;
            render = renderEvent;
        }

        public async void OnClickLogin(string userName, string password)
        {
            model.noticeMessage = "Signing in .. please wait";
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
                ViewManager.Show<MenuView>();

                return;
            }

            model.noticeMessage = "Something went wrong ...";
            render.Invoke();
        }
    }
}