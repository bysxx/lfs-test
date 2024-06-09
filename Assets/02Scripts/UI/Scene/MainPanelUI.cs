using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainPanelUI : SceneUI
{

    enum Buttons {
        StartBtn,
        ExplainBtn,
        OptionBtn,
        QuitBtn
    }

    private void Start() {
        Init();

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.StartBtn).gameObject.BindEvent(OnStartBtnClicked);
        GetButton((int)Buttons.OptionBtn).gameObject.BindEvent(OnOptionBtnClicked);
        GetButton((int)Buttons.QuitBtn).gameObject.BindEvent(OnQuitBtnClicked);
    }

    private void OnStartBtnClicked(PointerEventData data) {
        Access.UIM.FadeToScene("LobbyScene");
    }

    private void OnExplainBtnClicked(PointerEventData data) {
        Access.UIM.ShowPopupUI<PopUpUI>("ExplainPanel");
    }

    private void OnOptionBtnClicked(PointerEventData data) {
        // TODO
    }

    private void OnQuitBtnClicked(PointerEventData data) {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
