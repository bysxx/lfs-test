using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller, IHitable {

    [SerializeField] private int hp;
    [SerializeField] private GameObject deadEffect;

    private void Start() {
        BossSpawnState.OnBossKilledAllEnemy += Dead;
    }

    private void OnDestroy() {
        BossSpawnState.OnBossKilledAllEnemy -= Dead;
    }

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
