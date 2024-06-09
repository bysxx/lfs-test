using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SpecialBullet : MonoBehaviour
{
    private Answer answerData;
    [SerializeField] private TextMeshProUGUI text;
    private bool isinHand;

    private void Start() {
        BossStageManager.OnDestroyAllBullet += DestroyBullet;
    }

    private void OnDestroy() {
        BossStageManager.OnDestroyAllBullet -= DestroyBullet;
    }

    private void ReLoad(GunWeapon gun) {
        AnswerBullet answerBullet = gun.specialBullet as AnswerBullet;
        answerBullet.answer = answerData;
        gun.ChangeBullet(answerBullet);
        gun.IsReLoded = true;
        Destroy(transform.parent.gameObject);
    }


    private void OnTriggerEnter(Collider other) {

        if (!isinHand) return;

        if (other.gameObject.CompareTag("Weapon")) {
            GunWeapon gun = other.GetComponent<GunWeapon>();

            if (gun.IsReLoded) return;

            GetComponent<QuestReporter>().Report(1);
            ReLoad(gun);
        }
    }

    private void DestroyBullet() {
        Destroy(transform.parent.gameObject);
    }

    public void Grab(bool flag) {
        isinHand = flag;
    }

    public void SetData(Answer answer) {
        answerData = answer;
        text.text = answer.answerString;
    }

}
