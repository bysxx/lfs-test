using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExplainPanelUI : PopUpUI
{
    [System.Serializable]
    class ExplainGRP {
        public Sprite explainImg;
        [Multiline]
        public string explainText;
    }

    enum Buttons {
        ExitBtn,
        NextBtn,
        PrevBtn
    }

    enum TMPs {
        ExplainText
    }

    enum Images {
        ControllerImage
    }

    protected override void Init() {
        base.Init();
    }

    [SerializeField] private List<ExplainGRP> explainGRPs;
    [SerializeField] private int curExplainIdx = -1;
    private bool isBinding;

    private void Start() {

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(TMPs));
        Bind<Image>(typeof(Images));

        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(OnExitBtnClicked);
        GetButton((int)Buttons.NextBtn).gameObject.BindEvent(OnNextBtnClicked);
        GetButton((int)Buttons.PrevBtn).gameObject.BindEvent(OnPrevBtnClicked);

        isBinding = true;
        OnNextBtnClicked(null);

        gameObject.SetActive(false);
    }


    private void OnEnable() {
        Init();
        if (isBinding) {
            curExplainIdx = -1;
            OnNextBtnClicked(null);
        }
    }

    private void OnExitBtnClicked(PointerEventData data) {
        ClosePopUpUI();
    }

    private void OnNextBtnClicked(PointerEventData data) {

        if (curExplainIdx >= explainGRPs.Count-1) return;

        ExplainGRP explainGRP = explainGRPs[++curExplainIdx];
        GetImage((int)Images.ControllerImage).sprite = explainGRP.explainImg;
        GetTMP((int)TMPs.ExplainText).text = explainGRP.explainText;

     
    }

    private void OnPrevBtnClicked(PointerEventData data) {

        if (curExplainIdx == 0) return;

        ExplainGRP explainGRP = explainGRPs[--curExplainIdx];
        GetImage((int)Images.ControllerImage).sprite = explainGRP.explainImg;
        GetTMP((int)TMPs.ExplainText).text = explainGRP.explainText;
    }
}
