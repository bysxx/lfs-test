using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateObject : MonoBehaviour
{
    public XRBaseControllerInteractor controller; // XR Controller�� ������ ����
    public InputHelpers.Button rotateButton = InputHelpers.Button.MenuButton; // ȸ�� ��ư�� Menu Button���� ����
    public float rotationAngle = 90f; // ȸ�� ����
    private bool isRotating = false;

    void Update()
    {
        if (controller != null)
        {
            // ȸ�� ��ư�� ���ȴ��� Ȯ��
            if (CheckIfActivated(controller))
            {
                if (!isRotating) // ��ư�� ������ ���� ȸ��
                {
                    RotateLeft();
                    isRotating = true;
                }
            }
            else
            {
                isRotating = false;
            }
        }
    }

    private bool CheckIfActivated(XRBaseControllerInteractor interactor)
    {
        // ��Ʈ�ѷ��� �Է� ��ġ�� ������
        var xrController = interactor.GetComponent<XRController>();
        if (xrController != null)
        {
            InputDevice inputDevice = xrController.inputDevice;

            // ȸ�� ��ư�� ���ȴ��� Ȯ��
            return inputDevice.IsPressed(rotateButton, out bool isPressed) && isPressed;
        }
        return false;
    }

    private void RotateLeft()
    {
        // ������Ʈ�� �������� 90�� ȸ��
        transform.Rotate(0, -rotationAngle, 0);
    }
}
