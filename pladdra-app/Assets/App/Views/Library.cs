using UnityEngine;
using UnityEngine.UI;

public class Library : View
{
    public Button backButton;

    public override void Initialize()
    {
        backButton.onClick.AddListener(onClickBackButton);
    }

    private void onClickBackButton()
    {
        ViewManager.ShowLast();
    }
}