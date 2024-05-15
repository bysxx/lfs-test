using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IHitable {

    [SerializeField] private int hp;
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private Animator animator;

    public void Dead() {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Hit(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            hp = 0;
            Dead();
        }
    }
}
