using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private bool isHeld = false;
    private Rigidbody rb;

    // 드롭 시의 속도 조절을 위한 변수
    public float dropSpeed = 5f;

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        // Rigidbody가 없다면 Rigidbody를 추가합니다.
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        // 물체의 운동을 키도록 합니다. (부드러운 드롭을 위해서는 Rigidbody의 isKinematic을 false로 설정해야 합니다.)
        rb.isKinematic = true;
    }

    void Update()
    {
        if (isHeld)
        {
            // 물체가 들어져 있는 상태에서 마우스 이동이나 VR 컨트롤러 움직임에 따라 물체를 이동시킬 수 있음
            // 여기서는 간단히 들고 있을 때 위치를 고정함
        }
    }

    void FixedUpdate()
    {
        // 물체를 들고 있지 않을 때, 드롭 속도로 원래 위치로 부드럽게 이동시킵니다.
        if (!isHeld)
        {
            Vector3 velocity = (originalPosition - transform.position) * dropSpeed;
            rb.velocity = velocity;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // 물체가 다시 놓여지면 원래 위치와 회전값으로 돌아가게 함
        if (!isHeld)
        {
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            // 속도 초기화
            rb.velocity = Vector3.zero;
        }
    }

    public void PickUp()
    {
        // 물체를 들었을 때 호출되는 함수
        isHeld = true;
        // 물체를 들 때는 운동을 멈추도록 합니다.
        rb.isKinematic = true;
    }

    public void Drop()
    {
        // 물체를 놓았을 때 호출되는 함수
        isHeld = false;
        // 물체를 놓을 때는 운동을 다시 활성화하고 속도를 초기화합니다.
        rb.isKinematic = false;
        rb.velocity = Vector3.zero;
    }
}
