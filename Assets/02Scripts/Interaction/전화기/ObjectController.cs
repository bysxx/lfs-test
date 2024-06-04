using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isHeld = false;
    private Rigidbody rb;

    // ��� ���� �ӵ� ������ ���� ����
    public float dropSpeed = 5f;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        // Rigidbody�� ���ٸ� Rigidbody�� �߰��մϴ�.
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        // ��ü�� ��� Ű���� �մϴ�. (�ε巯�� ����� ���ؼ��� Rigidbody�� isKinematic�� false�� �����ؾ� �մϴ�.)
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isHeld)
        {
            // ��ü�� ����� �ִ� ���¿��� ���콺 �̵��̳� VR ��Ʈ�ѷ� �����ӿ� ���� ��ü�� �̵���ų �� ����
            // ���⼭�� ������ ��� ���� �� ��ġ�� ������
        }
    }

    void FixedUpdate()
    {
        // ��ü�� ��� ���� ���� ��, ��� �ӵ��� ���� ��ġ�� �ε巴�� �̵���ŵ�ϴ�.
        if (!isHeld)
        {
            Vector3 velocity = (originalPosition - transform.position) * dropSpeed;
            rb.velocity = velocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // ��ü�� �ٽ� �������� ���� ��ġ�� ȸ�������� ���ư��� ��
        if (!isHeld)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            // �ӵ� �ʱ�ȭ
            rb.velocity = Vector3.zero;
        }
    }

    public void PickUp()
    {
        // ��ü�� ����� �� ȣ��Ǵ� �Լ�
        isHeld = true;
        // ��ü�� �� ���� ��� ���ߵ��� �մϴ�.
        rb.isKinematic = true;
    }

    public void Drop()
    {
        // ��ü�� ������ �� ȣ��Ǵ� �Լ�
        isHeld = false;
        // ��ü�� ���� ���� ��� �ٽ� Ȱ��ȭ�ϰ� �ӵ��� �ʱ�ȭ�մϴ�.
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }
}
