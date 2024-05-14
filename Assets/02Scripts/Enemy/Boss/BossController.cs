using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IHitable {

    [Header("Boss Info")]
    [SerializeField] private int hp;
    [SerializeField] private GameObject deadEffect;
    [SerializeField] private Animator animator;

    [Header("Spawn Info")]
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject spawnEffect;
    [SerializeField] private GameObject spawnPos;
    [SerializeField] private int[] spawnCnt;

#if UNITY_EDITOR
    [Header("Debug")]
    [SerializeField] private KeyCode spawnKey;
    [SerializeField] private KeyCode nextPhaseKey;
    [SerializeField] private KeyCode prevPhaseKey;
#endif

    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int curPhase = 0;

#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(spawnKey)) {
            StartCoroutine(SpawnEnemy(spawnCnt[curPhase]));
        }
        if (Input.GetKeyDown(nextPhaseKey)) {
            curPhase++;
            if (curPhase >= spawnCnt.Length) {
                Define.Log("max phase");
                curPhase = spawnCnt.Length - 1;
            }
        }
        if (Input.GetKeyDown(prevPhaseKey)) {
            curPhase--;
            if (curPhase < 0) {
                Define.Log("min phase");
                curPhase = 0;
            }
        }

    }
#endif

    public void Dead() {
        animator.SetTrigger("Die");
        Invoke(nameof(DeadEffect), 3f);
    }

    public void Hit(int dmg) {
        hp -= dmg;
        if (hp <= 0) {
            hp = 0;
            Dead();
        }
    }

    private void DeadEffect() {
        Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator SpawnEnemy(int cnt) {

        Transform[] result = GetRandomTransforms(cnt, spawnPos.transform);

        foreach (Transform t in result) {
            Instantiate(spawnEffect, t.position, Quaternion.identity);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], t.position, Quaternion.identity);
            yield return null;
        }
    }

    private Transform[] GetRandomTransforms(int cnt, Transform origin) {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in origin) {
            children.Add(child);
        }

        if (children.Count <= cnt) {
            return children.ToArray();
        }

        System.Random random = new();
        int n = children.Count;

        for (int i = n - 1; i > 0; i--) {
            int j = random.Next(0, i + 1);
            Transform temp = children[i];
            children[i] = children[j];
            children[j] = temp;
        }

        return children.GetRange(0, cnt).ToArray();
    }

}
