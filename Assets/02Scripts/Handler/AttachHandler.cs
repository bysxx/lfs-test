using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AttachHandler : MonoBehaviour
{
    static public void OnAttach(SelectEnterEventArgs args)
    {
        Debug.Log(args);
    }
}
