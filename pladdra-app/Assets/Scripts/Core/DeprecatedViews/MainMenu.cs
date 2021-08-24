using UnityEngine;
using UnityEngine.UI;


namespace Pladdra.Views
{
    public class MainMenu : View
    {
        public Button startButton;

        public Button downloadButton;

        public Button logoutButton;
        public Button devToolsButton;

        public override void Initialize()
        {
            logoutButton.onClick.AddListener(onClickLogout);
            startButton.onClick.AddListener(() => ViewManager.Show<AR_Idle>());
            downloadButton.onClick.AddListener(() => ViewManager.Show<Download>());

            if (devToolsButton != null)
            {
                devToolsButton.onClick.AddListener(() => ViewManager.Show<DeveloperTools>());
            }
        }

        private void OnEnable()
        {
            Auth.RefreshSession().ContinueWith(response =>
            {
                bool successfulRefresh = response.Result;

                if (!successfulRefresh)
                {
                    ViewManager.Show<Login>();
                }
            });
        }

        private void onClickLogout()
        {
            Auth.SignOut();
            ViewManager.Show<Login>();
        }
    }
}