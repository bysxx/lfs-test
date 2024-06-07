using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private Collider myCollider;
    [SerializeField] private int dmg;

    private void Awake() {
        myCollider = GetComponent<Collider>();
    }

    private void Start() {
        myCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other) {
        IHitable hitable = other.GetComponent<IHitable>();
        if (hitable != null) {
            hitable.Hit(dmg);
            myCollider.enabled = false;
        }
    }
}
