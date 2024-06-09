using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Rigidbody rigid;
    [SerializeField] protected GameObject hitEffect;
    [SerializeField] protected float speed;
    public int dmg;
    protected Vector3 dir;
    [SerializeField] protected LayerMask layerMask;

    protected Vector3 lastPosition;

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    private void Start() {
        Destroy(gameObject, 2f);
        lastPosition = rigid.position;
    }

    protected virtual void FixedUpdate() {
        Vector3 currentPosition = rigid.position;

        float distance = speed * Time.deltaTime;
        RaycastHit hit;

        if (Physics.Raycast(lastPosition, dir, out hit, distance, layerMask)) {
            Instantiate(hitEffect, transform.position, Quaternion.identity);

            if (hit.collider.gameObject.CompareTag("QuizBullet")) {
                Destroy(gameObject);
                return;
            }

            IHitable hitable = hit.collider.GetComponent<IHitable>();
            if (hitable != null) {
                hitable.Hit(dmg);
            }

            Destroy(gameObject);
        }

        rigid.transform.Translate(dir * distance);

        lastPosition = currentPosition;
    }

    public void Init(Vector3 dir) {
        this.dir = dir;
    }
}
