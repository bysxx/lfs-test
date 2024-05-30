using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPos;

    private void Start() {
        Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.B))
            Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
    }
}
