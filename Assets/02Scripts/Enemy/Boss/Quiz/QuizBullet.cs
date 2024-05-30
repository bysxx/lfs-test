using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBullet : MonoBehaviour, IHitable
{
    [Header("Bullet Info")]
    public Quiz quiz;
    [SerializeField] private int hp;
    [SerializeField] private int dmg;
    [SerializeField] private float speed;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private Vector3 scaleRate = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private float duration = 5f;

    private float elapsedTime = 0f;

    private Rigidbody rigid;

    public BossController bossController;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        if (elapsedTime < duration) {
            transform.localScale += scaleRate * Time.deltaTime;
            elapsedTime += Time.deltaTime;
        }
    }

    public void Dead() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Access.BossStageM.DestroyAllBullet();
        Destroy(gameObject);
    }

    public void Hit(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            hp = 0;
            Dead();
        }
    }



    public void Shot(Vector3 dir) {
        rigid.velocity = dir * speed;
    }

    private void OnTriggerEnter(Collider other) {

        IHitable hitable = other.gameObject.GetComponent<IHitable>();
        if (hitable != null) {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            hitable.Hit(dmg);
            Destroy(gameObject);
        }
        else if (!other.CompareTag("AnswerBullet") && !other.CompareTag("PlayerBullet")) {
            Destroy(gameObject);
        }
    }

}
