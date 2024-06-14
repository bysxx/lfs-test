using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PhonePanalUI : PopUpUI
{
    enum Buttons {
        ResetBtn
    }

    enum TMPs {
        TargetNumberText,
        CurNumberText
    }

    private bool isBinding;
    [SerializeField] private DialController dialController;

    protected override void Init() {
        base.Init();
    }


    private void Start() {

        Bind<Button>(typeof(Buttons));
        Bind<TextMeshProUGUI>(typeof(TMPs));

        GetButton((int)Buttons.ResetBtn).gameObject.BindEvent(OnResetBtnClicked);

        GetTMP((int)TMPs.TargetNumberText).text = "";
        foreach (var num in dialController.TargetPhoneNumber) {
            GetTMP((int)TMPs.TargetNumberText).text += num.ToString();
        }

        isBinding = true;

        dialController.OnSetNumbered += OnSetNumberedHandler;
        dialController.OnResetNumbered += OnResetNumberedHandler;

        gameObject.SetActive(false);
    }

    private void OnDestroy() {
        dialController.OnSetNumbered -= OnSetNumberedHandler;
        dialController.OnResetNumbered -= OnResetNumberedHandler;
    }


    private void OnEnable() {
        Init();

        //if (isBinding)
    }

    private void OnResetBtnClicked(PointerEventData data) {
        dialController.ResetNumber();
    }

    private void OnSetNumberedHandler(DialController dialController) {
        GetTMP((int)TMPs.CurNumberText).text = "";

        foreach (var num in dialController.CurPhoneNumber) {
            if (num != -1)
                GetTMP((int)TMPs.CurNumberText).text += num.ToString();
        }
    }

    private void OnResetNumberedHandler(DialController dialController) {
        GetTMP((int)TMPs.CurNumberText).text = "";
    }

}
