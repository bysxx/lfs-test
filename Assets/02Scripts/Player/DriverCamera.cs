using UnityEngine;

public class DriverCameraFollow : MonoBehaviour
{
    public Transform carTransform; // �ڵ����� Transform ������Ʈ
    public Vector3 cameraOffset; // ī�޶��� ������ ��
    public Transform driverSeat; // ������ �¼�(Transform ������Ʈ)

    void LateUpdate()
    {
        // �ڵ����� ��ġ�� ȸ���� �������� ī�޶� ��ġ �� ȸ�� ������Ʈ
        transform.position = carTransform.TransformPoint(cameraOffset);
        transform.rotation = driverSeat.rotation;
    }
}
