using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform initialGrabTransform;
    private Transform dialTransform;

    void Start()
    {
        dialTransform = transform;
    }

    void Update()
    {
        if (isGrabbed)
        {
            Vector3 direction = initialGrabTransform.position - dialTransform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, 0, 360);  
            dialTransform.rotation = Quaternion.Euler(0, 0, angle);

            
            if (angle >= 270 && angle <= 280)
            {
                
                Debug.Log("Dial rotated to the desired angle!");
            }
        }
    }

    public void OnGrab(Transform grabTransform)
    {
        isGrabbed = true;
        initialGrabTransform = grabTransform;
    }

    public void OnRelease()
    {
        isGrabbed = false;
    }
}

