using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnMainPanelUI : MonoBehaviour
{
    [Header("Action Variable")]
    [SerializeField, Tooltip("Register the action you want.")] private InputActionReference actionReference;
    [SerializeField] private GameObject ui;

    private bool isOn;

    // event register
    private void OnEnable() {
        actionReference.action.performed += On;
    }

    // event unregister
    private void OnDisable() {
        actionReference.action.performed -= On;
    }

    private void On(InputAction.CallbackContext obj) {
        Access.UIM.ShowPopupUI<PopUpUI>("MenuPanel");        
    }

}
