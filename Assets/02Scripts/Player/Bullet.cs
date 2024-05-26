using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] float speed;
    [SerializeField] int dmg;

    private void Start() {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other) {
        IHitable hitable = other.gameObject.GetComponent<IHitable>();
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        if (hitable != null) {
            hitable.Hit(dmg);
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Init(Vector3 dir) {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = dir * speed;

    }
}
