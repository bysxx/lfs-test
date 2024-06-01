using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsetManager : MonoBehaviour
{
    public GameObject receiverPart1;
    public GameObject receiverPart2;
    public GameObject receiverPart3;

    private GameObject receiverParent;
    private Rigidbody receiverParentRigidbody;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        Debug.Log("HandsetManager script started");

        if (receiverPart1 == null || receiverPart2 == null || receiverPart3 == null)
        {
            Debug.LogError("Receiver parts are not assigned.");
            return;
        }

        // Create a parent object for the receiver parts
        receiverParent = new GameObject("ReceiverParent");

        // Set the position and rotation of the parent object to match the first receiver part
        receiverParent.transform.position = receiverPart1.transform.position;
        receiverParent.transform.rotation = receiverPart1.transform.rotation;

        // Set the receiver parts as children of the parent object
        receiverPart1.transform.SetParent(receiverParent.transform);
        receiverPart2.transform.SetParent(receiverParent.transform);
        receiverPart3.transform.SetParent(receiverParent.transform);

        // Add Rigidbody components to the receiver parts to enable physics interactions
        Rigidbody rb1 = receiverPart1.AddComponent<Rigidbody>();
        rb1.isKinematic = true;

        Rigidbody rb2 = receiverPart2.AddComponent<Rigidbody>();
        rb2.isKinematic = true;

        Rigidbody rb3 = receiverPart3.AddComponent<Rigidbody>();
        rb3.isKinematic = true;

        // Add a Rigidbody component to the parent object to enable physics interactions
        receiverParentRigidbody = receiverParent.AddComponent<Rigidbody>();
        receiverParentRigidbody.isKinematic = true;

        // Add XRGrabInteractable component to the parent object
        grabInteractable = receiverParent.AddComponent<XRGrabInteractable>();

        // Subscribe to the selectEntered event to handle object grab
        grabInteractable.selectEntered.AddListener(OnGrab);

        Debug.Log("Receiver parts have been parented");
    }

    // Method to handle object grab
    private void OnGrab(SelectEnterEventArgs args)
    {
        receiverParentRigidbody.isKinematic = false; // Enable physics on the parent object to allow it to be lifted
    }
}
