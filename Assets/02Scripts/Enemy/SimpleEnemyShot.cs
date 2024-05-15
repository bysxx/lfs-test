using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyShot : MonoBehaviour
{
    [SerializeField] private Bullet missile;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Animator animator;
    [SerializeField] private float maxCool;
    [SerializeField] private float minCool;

    private float curCool;
    private float cool;

    private void Start() {
        cool = Random.Range(minCool, maxCool);
    }

    private void Update() {
        curCool += Time.deltaTime;
        if (curCool >= cool) {
            curCool = 0f;
            cool = Random.Range(minCool, maxCool);
            animator.SetTrigger("Shot");
            Bullet b = Instantiate(missile, spawnPos.position, Quaternion.identity);
            b.Init(spawnPos.forward);
        }
    }

}
