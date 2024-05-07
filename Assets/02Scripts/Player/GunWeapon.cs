using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GunWeapon : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private GameObject shotEffect;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private InputActionReference leftActionReference;
    [SerializeField] private InputActionReference rightActionReference;

    public void GetGun(SelectEnterEventArgs arg) {
        int val = arg.interactorObject.interactionLayers.value;

        if ((val & InteractionLayerMask.GetMask("LeftDirect")) == InteractionLayerMask.GetMask("LeftDirect"))
            leftActionReference.action.performed += Shot;
        else if ((val & InteractionLayerMask.GetMask("RightDirect")) == InteractionLayerMask.GetMask("RightDirect"))
            rightActionReference.action.performed += Shot;
    }
    
    public void DropGun(SelectExitEventArgs arg) {
        leftActionReference.action.performed -= Shot;
        rightActionReference.action.performed -= Shot;
    }

    private void Shot(InputAction.CallbackContext obj) {
        Bullet b = Instantiate(bullet, spawnPos.position, Quaternion.identity);
        GameObject g = Instantiate(shotEffect, spawnPos.position, Quaternion.identity);
        Destroy(g, 1f);
        b.Init(spawnPos.forward);
    }

}
