using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class GunWeapon : MonoBehaviour
{
    [SerializeField] private Bullet normalBullet;
    public Bullet specialBullet;
    [SerializeField] private GameObject shotEffect;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private InputActionReference leftActionReference;
    [SerializeField] private InputActionReference rightActionReference;

    private QuestReporter questReporter;
    private Bullet curBullet;

    public bool CanShot { get; set; }
    public bool IsReLoded { get; set; }

    private void Awake() {
        questReporter = GetComponent<QuestReporter>();
    }

    private void Start() {
        ChangeBullet(normalBullet);
    }

    public void GetGun(SelectEnterEventArgs arg) {
        int val = arg.interactorObject.interactionLayers.value;
        questReporter.Report(0);

        if ((val & InteractionLayerMask.GetMask("LeftDirect")) == InteractionLayerMask.GetMask("LeftDirect"))
            leftActionReference.action.performed += Shot;
        else if ((val & InteractionLayerMask.GetMask("RightDirect")) == InteractionLayerMask.GetMask("RightDirect"))
            rightActionReference.action.performed += Shot;

        Access.Player.P_DInfo.CurGunWeapon = this;
    }
    
    public void DropGun(SelectExitEventArgs arg) {
        leftActionReference.action.performed -= Shot;
        rightActionReference.action.performed -= Shot;
    }

    private void Shot(InputAction.CallbackContext obj) {

        if (CanShot) {
            questReporter.Report(1);

            Bullet b = Instantiate(curBullet, spawnPos.position, Quaternion.identity);
            GameObject g = Instantiate(shotEffect, spawnPos.position, Quaternion.identity);
            Destroy(g, 1f);
            b.Init(spawnPos.forward);

            if (curBullet != normalBullet) {
                ChangeBullet(normalBullet);
                IsReLoded = false;
            }
        }

    }

    public void ChangeBullet(Bullet bullet) {
        curBullet = bullet;
    }

}
