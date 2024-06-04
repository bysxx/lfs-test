using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // �ʱ� ��ġ�� ȸ�� ����
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        // XRGrabInteractable ������Ʈ ��������
        grabInteractable = GetComponent<XRGrabInteractable>();

        // �̺�Ʈ �ڵ鷯 ���
        grabInteractable.selectExited.AddListener(OnRelease);
        grabInteractable.selectEntered.AddListener(OnGrab);
    }

    void OnDestroy()
    {
        // �̺�Ʈ �ڵ鷯 ����
        grabInteractable.selectExited.RemoveListener(OnRelease);
        grabInteractable.selectEntered.RemoveListener(OnGrab);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // ��ȭ�⸦ ����� ��, ������ �ൿ�� �ʿ��� ��� ���⼭ ó��
        Debug.Log("Handset grabbed");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // ��ȭ�⸦ ���� �� ���� ��ġ�� �ǵ���
        ResetPosition();
    }

    public void ResetPosition()
    {
        // ��ġ�� ȸ���� ������� �ǵ���
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
