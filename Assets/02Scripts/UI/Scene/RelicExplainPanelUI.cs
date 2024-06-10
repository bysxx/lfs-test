using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RelicExplainPanelUI : SceneUI {

    enum TMPs {
        RelicNameText,
        RelicExplainText
    }

    enum Images {
        RelicImg
    }

    [SerializeField] LobbyRelic relic;

    private void Start() {
        Init();

        Bind<TextMeshProUGUI>(typeof(TMPs));
        Bind<Image>(typeof(Images));

        GetTMP((int)TMPs.RelicNameText).text = relic.RelicName;
        GetTMP((int)TMPs.RelicExplainText).text = relic.RelicExplain;
        GetImage((int)Images.RelicImg).sprite = relic.RelicImage;

        if (relic.StageNum < Access.GameM.stageProgress.Length && Access.GameM.stageProgress[relic.StageNum])
            gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
