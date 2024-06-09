using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Enter(Controller controller);
    public abstract void Activate();
    public abstract void Exit();
}
