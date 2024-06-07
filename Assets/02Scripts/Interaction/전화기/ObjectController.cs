using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isHeld = false;
    private bool isReturning = false;
    public float returnSpeed = 10f; // ���� ��ġ�� ���ư��� �ӵ�, ���ϴ� �ӵ��� ���� ����

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isReturning)
        {
            // �ε巴�� ���� ��ġ�� ȸ������ �̵�
            transform.position = Vector3.Lerp(transform.position, originalPosition, Time.deltaTime * returnSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * returnSpeed);

            // ���� ��ġ�� ȸ���� ���� �����ϸ� �̵� ������ ���� �÷��׸� ����
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
        // ��ü�� �ٽ� �������� �� ���� ��ġ�� ȸ�������� ���ư����� �÷��� ����
        if (!isHeld && !isReturning)
        {
            isReturning = true;
        }
    }

    public void PickUp()
    {
        // ��ü�� ����� �� ȣ��Ǵ� �Լ�
        isHeld = true;
        isReturning = false; // ��ü�� ��� ��ȯ ��� ����
    }

    public void Drop()
    {
        // ��ü�� ������ �� ȣ��Ǵ� �Լ�
        isHeld = false;
    }
}
