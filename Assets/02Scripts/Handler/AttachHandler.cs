using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachHandler : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socketInteractor;
    [SerializeField] private GameObject allowedInteractableObject;
    [SerializeField] private TaskTarget target; 
    [SerializeField] private Category category;

    void Start()
    {
        if (socketInteractor == null)
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
        }
        
        socketInteractor.selectEntered.AddListener(OnObjectPlacedInSocket);
    }

    void OnDestroy()
    {
        socketInteractor.selectEntered.RemoveListener(OnObjectPlacedInSocket);
    }

    private void OnObjectPlacedInSocket(SelectEnterEventArgs args)
    {
        XRBaseInteractable interactable = args.interactable;
        XRBaseInteractor interactor = args.interactor;
        
        if (interactable.gameObject != allowedInteractableObject)
        {
            Debug.Log("Interaction cancelled. Object is not allowed: " + interactable.gameObject.name);
            socketInteractor.interactionManager.SelectExit(interactor, interactable);
        }
        else
        {
            Access.QuestM.ReceiveReport(category, target, 1);
        }
    }
}
