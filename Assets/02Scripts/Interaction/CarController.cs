using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody carRigidbody; // �ڵ��� Rigidbody ������Ʈ
    public float speed = 10f; // �̵� �ӵ�
    public float rotationSpeed = 100f; // ȸ�� �ӵ�

    void FixedUpdate()
    {
        // ����� �Է� �ޱ�
        float moveInput = Input.GetAxis("Vertical");
        float rotateInput = Input.GetAxis("Horizontal");

        // �̵� �� ȸ�� ����
        Vector3 moveDirection = transform.forward * moveInput * speed * Time.fixedDeltaTime;
        carRigidbody.MovePosition(carRigidbody.position + moveDirection);
        Quaternion rotateAmount = Quaternion.Euler(0f, rotateInput * rotationSpeed * Time.fixedDeltaTime, 0f);
        carRigidbody.MoveRotation(carRigidbody.rotation * rotateAmount);
    }
}
