using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class SimpleEnemyChase : MonoBehaviour
{

    private Rigidbody rigid;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bombEffect;



    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (Access.Player.transform != null) {
            Vector3 dir = (Access.Player.transform.position - transform.position).normalized;
            Vector3 moveVec = dir * speed * Time.fixedDeltaTime;
            rigid.rotation = Quaternion.LookRotation(dir);
            rigid.position += moveVec;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        IHitable hitable = collision.gameObject.GetComponent<IHitable>();
        if (hitable != null) {
            hitable.Hit(1);
        }
        else {
            Instantiate(bombEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
