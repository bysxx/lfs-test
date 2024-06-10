using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuPanelUI : PopUpUI
{
    enum Buttons {
        MainMenuBtn,
        CurQuestBtn,
        CurProgressBtn,
        ExplainBtn,
        ExitBtn
    }

    protected override void Init() {
        base.Init();
    }


    private void Start() {

        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.MainMenuBtn).gameObject.BindEvent(OnMainMenuBtnClicked);
        GetButton((int)Buttons.CurQuestBtn).gameObject.BindEvent(OnCurQuestBtnClicked);
        GetButton((int)Buttons.CurProgressBtn).gameObject.BindEvent(OnCurProgressBtnClicked);
        GetButton((int)Buttons.ExplainBtn).gameObject.BindEvent(OnExplainBtnClicked);
        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(OnExitBtnClicked);

        gameObject.SetActive(false);
    }


    private void OnEnable() {
        Init();
    }

    private void OnMainMenuBtnClicked(PointerEventData data) {
        Access.UIM.FadeToScene("MainMenu");
    }
    private void OnCurQuestBtnClicked(PointerEventData data) {
        Access.UIM.ShowPopupUI<PopUpUI>("Quest View");
    }
    private void OnCurProgressBtnClicked(PointerEventData data) {
        Access.UIM.ShowPopupUI<PopUpUI>("CurProgressPanel");
    }
    private void OnExplainBtnClicked(PointerEventData data) {
        Access.UIM.ShowPopupUI<PopUpUI>("ExplainPanel");
    }
    private void OnExitBtnClicked(PointerEventData data) {
        ClosePopUpUI();
    }
}
