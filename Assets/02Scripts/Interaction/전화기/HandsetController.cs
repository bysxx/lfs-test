using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // 초기 위치와 회전 저장
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // XRGrabInteractable 컴포넌트 가져오기
        grabInteractable = GetComponent<XRGrabInteractable>();

        // 이벤트 핸들러 등록
        grabInteractable.selectExited.AddListener(OnRelease);
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDestroy()
    {
        // 이벤트 핸들러 해제
        grabInteractable.selectExited.RemoveListener(OnRelease);
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // 수화기를 잡았을 때, 별도의 행동이 필요할 경우 여기서 처리
        Debug.Log("Handset grabbed");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // 수화기를 놓을 때 원래 위치로 되돌림
        ResetPosition();
    }

    public void ResetPosition()
    {
        // 위치와 회전을 원래대로 되돌림
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
