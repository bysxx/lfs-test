using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CurProgressPanelUI : PopUpUI
{
    enum Buttons {
        ExitBtn
    }

    enum TMPs {
        TargetExplainText
    }

    enum Objects {
        RuneCar,
        RuneElec,
        RuneBoss
    }

    private bool isBinding;

    protected override void Init() {
        base.Init();
    }


    private void Start() {

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(TMPs));
        Bind<GameObject>(typeof(Objects));
        isBinding = true;

        GetButton((int)Buttons.ExitBtn).gameObject.BindEvent(OnExitBtnClicked);

        GetObject((int)Objects.RuneCar).SetActive(false);
        GetObject((int)Objects.RuneElec).SetActive(false);
        GetObject((int)Objects.RuneBoss).SetActive(false);


        gameObject.SetActive(false);
    }


    private void OnEnable() {
        Init();

        if (isBinding)
            PanelOn();
    }

    private void OnExitBtnClicked(PointerEventData data) {
        ClosePopUpUI();
    }
    
    private void PanelOn() {

        GetObject((int)Objects.RuneCar).SetActive(false);
        GetObject((int)Objects.RuneElec).SetActive(false);
        GetObject((int)Objects.RuneBoss).SetActive(false);

        if (Access.QuestM.CurMainQuest != null && !Access.QuestM.CurMainQuest.IsComplete)
            GetTMP((int)TMPs.TargetExplainText).text = Access.QuestM.CurMainQuest.Description;
        else GetTMP((int)TMPs.TargetExplainText).text = "";

        for (int i = 0; i < Access.GameM.stageProgress.Length; i++) {
            if (Access.GameM.stageProgress[i]) GetObject(i).SetActive(true);
        }
        
    }

}
