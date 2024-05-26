using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrabber : MonoBehaviour
{
    private XRGrabInteractable interactable;
    private XRBaseInteractor interactor;

    void Start()
    {
        // 오브젝트에 연결된 XRGrabInteractable 컴포넌트 가져오기
        interactable = GetComponent<XRGrabInteractable>();

        // 컨트롤러에 연결된 XRBaseInteractor 컴포넌트 가져오기
        interactor = GetComponent<XRBaseInteractor>();

        // 컨트롤러가 오브젝트를 잡을 때 호출되는 이벤트에 함수 등록
        interactable.selectEntered.AddListener(OnGrab); // selectEntered로 수정

        // 컨트롤러가 오브젝트를 놓을 때 호출되는 이벤트에 함수 등록
        interactable.selectExited.AddListener(OnRelease); // selectExited로 수정
    }

    // 오브젝트를 잡을 때 호출되는 함수
    void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object Grabbed!");
    }

    // 오브젝트를 놓을 때 호출되는 함수
    void OnRelease(SelectExitEventArgs args) // 매개변수 형식 변경
    {
        Debug.Log("Object Released!");
    }
}
