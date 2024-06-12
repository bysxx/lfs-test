using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHPPanelUI : ObjectUI
{
    enum TMPs {
        HPText
    }

    private void Start() {
        Bind<TextMeshProUGUI>(typeof(TMPs));

        Access.Player.GetComponent<PlayerHPComponent>().OnHPChanged += OnPlayerHPChanged;

        GetComponent<CanvasGroup>().alpha = 0f;
    }

    private void OnDestroy() {
        if (Access.Player) {
            Access.Player.GetComponent<PlayerHPComponent>().OnHPChanged -= OnPlayerHPChanged;
        }
    }

    private void OnPlayerHPChanged(int hp) {
        GetTMP((int)TMPs.HPText).text = hp + "/10";
    }
}
