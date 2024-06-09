using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TutorialBase : MonoBehaviour
{
    protected virtual bool IsCompleted => false;
    public abstract void Enter();
    public abstract void Activate(TutorialManager tutorialManager);
    public abstract void Exit();
}
