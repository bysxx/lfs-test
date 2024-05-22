using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerRotation : MonoBehaviour
{
    public XRBaseInteractor controller; // XR Controller를 참조할 변수

    void Update()
    {
        if (controller != null)
        {
            // 컨트롤러의 회전 가져오기
            Quaternion controllerRotation = controller.transform.rotation;

            // 현재 오브젝트의 위치 가져오기
            Vector3 currentPosition = transform.position;

            // 오브젝트의 회전을 컨트롤러의 회전으로 설정 (위치 변경 없음)
            transform.rotation = controllerRotation;
        }
    }
}
