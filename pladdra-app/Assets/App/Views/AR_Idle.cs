using Pladdra;
using UnityEngine;
using UnityEngine.UI;
namespace Pladdra.Views
{
    public class AR_Idle : View
    {
        public Button mainMenuButton;
        public Button libraryButton;

        public override void Initialize()
        {
            mainMenuButton.onClick.AddListener(onClickMainMenu);
            libraryButton.onClick.AddListener(onClickLibrary);
        }

        private void onClickMainMenu()
        {
            ViewManager.Show<MainMenu>();
        }
        private void onClickLibrary()
        {
            ViewManager.Show<AssetsLibrary>(true);
        }
    }
}