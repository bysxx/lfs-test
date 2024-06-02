using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PowerDial : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    public TVController tvController;
    private float previousAngle;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    void OnGrab(XRBaseInteractor interactor)
    {
        previousAngle = transform.localEulerAngles.z;
    }

    void OnRelease(XRBaseInteractor interactor)
    {
        float currentAngle = transform.localEulerAngles.z;
        tvController.SetPower(currentAngle);
    }
}
