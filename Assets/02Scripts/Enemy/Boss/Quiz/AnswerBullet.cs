using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerBullet : Bullet
{
    public static event Action<AnswerBullet> OnDestroyBullet;
    public static event Action<AnswerBullet> OnCorrectBulletTrigger;
    public static event Action<AnswerBullet> OnInCorrectBulletTrigger;

    public Answer answer;

    protected override void FixedUpdate() {
        Vector3 currentPosition = rigid.position;

        float distance = speed * Time.deltaTime;
        RaycastHit hit;

        if (Physics.Raycast(lastPosition, dir, out hit, distance, layerMask)) {
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            if (hit.collider.gameObject.CompareTag("QuizBullet")) {
                if (answer.isCorrect) {
                    IHitable hitable = hit.collider.GetComponent<IHitable>();
                    if (hitable != null) {
                        hitable.Hit(dmg);
                        OnCorrectBulletTrigger?.Invoke(this);
                        Destroy(gameObject);
                    }
                }
                else {
                    OnInCorrectBulletTrigger?.Invoke(this);
                    Destroy(gameObject);
                }
            }

            Destroy(gameObject);
        }

        rigid.transform.Translate(dir * distance);

        lastPosition = currentPosition;
    }

    private void OnDestroy() {
        OnDestroyBullet?.Invoke(this);
    }
}
