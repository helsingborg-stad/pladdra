using UnityEngine;
using UnityEngine.UI;


namespace Pladdra
{
    public class MainMenu : View
    {
        public Button startButton;

        public Button downloadButton;

        public Button logoutButton;


        public override void Initialize()
        {
            logoutButton.onClick.AddListener(onClickLogout);
            startButton.onClick.AddListener(onClickStart);
            downloadButton.onClick.AddListener(onClickDownload);
        }

        private void onClickLogout()
        {
            Auth.SignOut();
            ViewManager.Show<Login>();
        }

        private void onClickStart()
        {
            ViewManager.Show<AR_Idle>();
        }

        private void onClickDownload()
        {
            ViewManager.Show<Download>();
        }
    }
}