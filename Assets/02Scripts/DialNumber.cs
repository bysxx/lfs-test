using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DialNumber : MonoBehaviour
{
    [SerializeField] private int num;

    private DialController controller;
    private bool flag;
    private bool isRotateCompleted;
    private MeshRenderer meshRenderer;
    public Vector3 originPos;

    public Collider DialCollider { get; set; }

    private void Awake() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        DialCollider = GetComponent<Collider>();
        controller = GetComponentInParent<DialController>();
    }

    private void Start() {
        originPos = transform.position;
    }

    private void Update() {

        if (!flag) return;
        if (isRotateCompleted) return;

        controller.RotateDial(this);
    }

    public void SelectEnter(SelectEnterEventArgs arg) {
        controller.ToOrigin = false;
        isRotateCompleted = false;
        flag = true;
        meshRenderer.enabled = true;
    }

    public void SelectExit(SelectExitEventArgs arg) {
        isRotateCompleted = false;
        flag = false;
        meshRenderer.enabled = false;
        controller.ToOrigin = true;
    }

    public void HoverEnter(HoverEnterEventArgs arg) {
        meshRenderer.enabled = true;
    }
    public void HoverExit(HoverExitEventArgs arg) {
        if (!flag) meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (!flag) return;

        if (other.CompareTag("StopPoint")) {
            controller.SetNumber(num);
            isRotateCompleted = true;
        }
    }

}
