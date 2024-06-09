using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerPanelUI : PopUpUI
{
    enum TMPs {
        TimeText,
        ExplainText
    }

    protected override void Init() {
        base.Init();
        Bind<TextMeshProUGUI>(typeof(TMPs));
    }

    private void Start() {
        Init();
        Access.BossStageM.PatternTimer.ChangeCallback += PatternTimer;

        gameObject.SetActive(false);
    }

    private void PatternTimer(float time) {
        GetTMP((int)TMPs.TimeText).text = ((int)time).ToString();
    }

}
