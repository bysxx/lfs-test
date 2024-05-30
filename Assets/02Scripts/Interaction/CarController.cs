using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody carRigidbody; // 자동차 Rigidbody 컴포넌트
    public float speed = 10f; // 이동 속도
    public float rotationSpeed = 100f; // 회전 속도
    public Transform steeringWheel; // 운전대 Transform
    public float maxSteerAngle = 450f; // 운전대의 최대 회전 각도

    private float currentSteerAngle = 0f; // 현재 운전대 회전 각도s

    void FixedUpdate()
    {
        // 조이스틱 입력 받기
        float moveInput = Input.GetAxis("Vertical"); // 상하 입력
        float steerInput = Input.GetAxis("Horizontal"); // 좌우 입력

        // 자동차 이동
        Vector3 moveDirection = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        carRigidbody.MovePosition(carRigidbody.position + moveDirection);

        // 자동차 회전
        Quaternion rotateAmount = Quaternion.Euler(0f, steerInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        carRigidbody.MoveRotation(carRigidbody.rotation * rotateAmount);

        // 지형의 높낮이에 따른 위치 조정
        AdjustCarHeight();

        // 운전대 회전 각도 계산
        currentSteerAngle = steerInput * maxSteerAngle;

        // 운전대 회전 적용
        if (steeringWheel != null)
        {
            steeringWheel.localRotation = Quaternion.Euler(0f, 0f, -currentSteerAngle);
        }
    }

    void AdjustCarHeight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            // 지면과 충돌한 경우, 자동차 모델의 높이를 조정하여 지면과 정확히 맞도록 함
            float targetHeight = hit.point.y - 2f;
            Vector3 newPosition = new Vector3(transform.position.x, targetHeight, transform.position.z);
            transform.position = newPosition;
        }
    }

}
