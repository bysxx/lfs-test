using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SimpleEnemyChase : MonoBehaviour
{

    private Rigidbody rigid;

    [SerializeField] private float speed;
    [SerializeField] private GameObject bombEffect;

    private Transform target;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        target = FindObjectOfType<XROrigin>().transform;
    }

    private void FixedUpdate() {
        if (target != null) {
            Vector3 dir = (target.position - transform.position).normalized;
            Vector3 moveVec = dir * speed * Time.fixedDeltaTime;
            rigid.rotation = Quaternion.LookRotation(dir);
            rigid.position += moveVec;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.CompareTag("PlayerBullet")) {
            Instantiate(bombEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
