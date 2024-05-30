using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DialInteraction : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform dialTransform;
    private Vector3 initialRotation;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        dialTransform = transform;
        initialRotation = dialTransform.localEulerAngles;
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
       
    }

    void Update()
    {
        
        if (grabInteractable.isSelected)
        {
            Vector3 currentRotation = dialTransform.localEulerAngles;
            float deltaRotation = CalculateDeltaRotation(currentRotation);
            ApplyRotation(deltaRotation);
        }
    }

    private float CalculateDeltaRotation(Vector3 currentRotation)
    {
        
        return currentRotation.z - initialRotation.z;
    }

    private void ApplyRotation(float deltaRotation)
    {
        
        dialTransform.localEulerAngles = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z + deltaRotation);
    }
}
