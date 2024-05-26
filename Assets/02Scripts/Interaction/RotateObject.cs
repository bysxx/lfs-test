using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateObject : MonoBehaviour
{
    public XRBaseControllerInteractor controller; // XR Controller를 참조할 변수
    public InputHelpers.Button rotateButton = InputHelpers.Button.MenuButton; // 회전 버튼을 Menu Button으로 설정
    public float rotationAngle = 90f; // 회전 각도
    private bool isRotating = false;

    void Update()
    {
        if (controller != null)
        {
            // 회전 버튼이 눌렸는지 확인
            if (CheckIfActivated(controller))
            {
                if (!isRotating) // 버튼이 눌렸을 때만 회전
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
        // 컨트롤러의 입력 장치를 가져옴
        var xrController = interactor.GetComponent<XRController>();
        if (xrController != null)
        {
            InputDevice inputDevice = xrController.inputDevice;

            // 회전 버튼이 눌렸는지 확인
            return inputDevice.IsPressed(rotateButton, out bool isPressed) && isPressed;
        }
        return false;
    }

    private void RotateLeft()
    {
        // 오브젝트를 왼쪽으로 90도 회전
        transform.Rotate(0, -rotationAngle, 0);
    }
}
