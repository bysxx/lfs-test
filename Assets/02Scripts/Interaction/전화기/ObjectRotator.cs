using UnityEngine;
using System.Collections;
using System;

public class DialController : MonoBehaviour
{

    public event Action<DialController> OnSetNumbered;
    public event Action<DialController> OnResetNumbered;

    [SerializeField] private DialNumber[] dialNumbers;
    [SerializeField] private int[] targetPhoneNumber;
    [SerializeField] private float speed;
    [SerializeField] private Transform stopPoint;
    [SerializeField] private Transform centerPoint;
    [SerializeField] private float angle;

    public int[] TargetPhoneNumber => targetPhoneNumber;
    public int[] CurPhoneNumber => curPhoneNumber;

    private Transform curPoint;
    private Vector3 originPos;

    private int[] curPhoneNumber = new int[10];
    private int curIdx = 0;
    [field: SerializeField] public bool ToOrigin { get; set; }


    void Start()
    {
        EnableCollider(false);

        for (int i = 0; i < curPhoneNumber.Length; i++) {
            curPhoneNumber[i] = -1;
        }
    }

    private void Update() {

        if (!ToOrigin) return;

        Vector3 curVec = (curPoint.position - centerPoint.position).normalized;
        Vector3 targetVec = (originPos - centerPoint.position).normalized;
        angle = CalculateAngle(curVec, targetVec);
        transform.Rotate(Vector3.up, angle * -speed * Time.deltaTime, Space.Self);

    }

    public void EnableCollider(bool flag) {
        foreach (var dial in dialNumbers) {
            dial.DialCollider.enabled = flag;
        }
    }

    public void RotateDial(DialNumber curDial) {
        curPoint = curDial.transform;
        originPos = curDial.originPos;
        Vector3 curVec = (curPoint.position - centerPoint.position).normalized;
        Vector3 targetVec = (stopPoint.position - centerPoint.position).normalized;
        angle = CalculateAngle(curVec, targetVec);
        transform.Rotate(Vector3.up, angle * speed * Time.deltaTime, Space.Self);
    }

    float CalculateAngle(Vector3 from, Vector3 to) {
        Vector2 from2D = new Vector2(from.x, from.z);
        Vector2 to2D = new Vector2(to.x, to.z);
        float angle = Quaternion.FromToRotation(from2D, to2D).eulerAngles.z;
        return angle;
    }

    public void SetNumber(int i) {
        curPhoneNumber[curIdx++] = i;
        Define.Log(i);
        OnSetNumbered?.Invoke(this);
        if (curIdx == curPhoneNumber.Length) CheckNumber();
    }

    private void CheckNumber() {
        for (int i = 0; i < targetPhoneNumber.Length; i++) {
            if (curPhoneNumber[i] != targetPhoneNumber[i]) {
                Define.Log("전화 번호 다름");
                ResetNumber();
                return;
            }
        }

        Complete();
    }

    private void Complete() {
        GetComponent<QuestReporter>().Report(0);
    }

    public void ResetNumber() {
        for (int i = 0; i < curPhoneNumber.Length; i++) {
            curPhoneNumber[i] = -1;
        }
        curIdx = 0;
        OnResetNumbered?.Invoke(this);
    }
}
