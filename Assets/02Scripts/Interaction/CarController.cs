using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody carRigidbody; // 자동차 Rigidbody 컴포넌트
    public float speed = 10f; // 이동 속도
    public float rotationSpeed = 100f; // 회전 속도

    void FixedUpdate()
    {
        // 사용자 입력 받기
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // 이동 및 회전 적용
        Vector3 moveDirection = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        carRigidbody.MovePosition(carRigidbody.position + moveDirection);
        Quaternion rotateAmount = Quaternion.Euler(0f, rotateInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        carRigidbody.MoveRotation(carRigidbody.rotation * rotateAmount);
    }
}
