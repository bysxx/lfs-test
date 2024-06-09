using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnObject : MonoBehaviour
{

    [SerializeField, Tooltip("Quaternion.Euler(this Vector3 option)")] private Vector3 spawnRotation;
    private Vector3 reSpawnPos;
    private Rigidbody rigid;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        reSpawnPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("ReSpawnArea")) {
            rigid.velocity = Vector3.zero;
            transform.SetPositionAndRotation(reSpawnPos, Quaternion.Euler(spawnRotation));
        }
    }

    public void SetReSpawnTransform(Transform transform) {
        reSpawnPos = transform.position;
    }
}
