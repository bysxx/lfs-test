using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerRotation : MonoBehaviour
{
    public XRBaseInteractor controller; // XR Controller�� ������ ����

    void Update()
    {
        if (controller != null)
        {
            // ��Ʈ�ѷ��� ȸ�� ��������
            Quaternion controllerRotation = controller.transform.rotation;

            // ���� ������Ʈ�� ��ġ ��������
            Vector3 currentPosition = transform.position;

            // ������Ʈ�� ȸ���� ��Ʈ�ѷ��� ȸ������ ���� (��ġ ���� ����)
            transform.rotation = controllerRotation;
        }
    }
}
