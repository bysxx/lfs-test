using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PhoneReceiver : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private DialController dialController;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        dialController = FindObjectOfType<DialController>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        dialController.enabled = true;
        Debug.Log("수화기 그랩됨");
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        if (!args.isCanceled)
        {
            dialController.enabled = false;
        }
    }
}
