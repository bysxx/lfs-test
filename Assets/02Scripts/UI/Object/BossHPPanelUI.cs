using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPPanelUI : ObjectUI
{
    [SerializeField] private BossController controller;

    enum Objects {
        HP
    }

    private Image[] HPList;

    private void Start() {
        Bind<GameObject>(typeof(Objects));
        HPList = GetObject((int)Objects.HP).GetComponentsInChildren<Image>();

        controller.Hp.ChangeCallback += HPChange;
    }

    private void OnDestroy() {
        controller.Hp.ChangeCallback -= HPChange;
    }

    private void HPChange(int i) {
        HPList[5 - (i + 1)].gameObject.SetActive(!HPList[5 - (i + 1)].gameObject.activeSelf);
    }
}
