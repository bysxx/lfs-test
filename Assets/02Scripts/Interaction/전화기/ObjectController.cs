using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isHeld = false;
    private bool isReturning = false;
    public float returnSpeed = 10f; // 원래 위치로 돌아가는 속도, 원하는 속도로 조정 가능

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isReturning)
        {
            // 부드럽게 원래 위치와 회전으로 이동
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * returnSpeed);

            // 원래 위치와 회전에 거의 도달하면 이동 중지를 위해 플래그를 리셋
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f && Quaternion.Angle(transform.rotation, originalRotation) < 1f)
            {
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                isReturning = false;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 물체가 다시 놓여졌을 때 원래 위치와 회전값으로 돌아가도록 플래그 설정
        if (!isHeld && !isReturning)
        {
            isReturning = true;
        }
    }

    public void PickUp()
    {
        // 물체를 들었을 때 호출되는 함수
        isHeld = true;
        isReturning = false; // 물체를 들면 반환 모드 해제
    }

    public void Drop()
    {
        // 물체를 놓았을 때 호출되는 함수
        isHeld = false;
    }
}
